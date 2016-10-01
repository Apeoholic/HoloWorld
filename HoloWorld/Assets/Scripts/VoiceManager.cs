using UnityEngine;
using System.Collections;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using System;
using HoloToolkit.Unity;

[RequireComponent(typeof(GazeManager))]
public class VoiceManager : MonoBehaviour
{
    public VoiceCommand[] VoiceCommands;
    private KeywordRecognizer keywordRecognizer;

    private Dictionary<string, string> responses;

    void Start()
    {
        if (VoiceCommands.Length > 0)
        {
            responses = VoiceCommands.ToDictionary(c => c.Keyword,  c => c.Message);

            keywordRecognizer = new KeywordRecognizer(responses.Keys.ToArray());
            keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
            keywordRecognizer.Start();
        }
        else
        {
            Debug.LogError("Must have at least one keyword specified in the Inspector on " + gameObject.name + ".");
        }

    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        string message;
        if (responses.TryGetValue(args.text, out message))
        {
            gameObject.GetComponent<GazeManager>().FocusedObject.SendMessage(message, SendMessageOptions.DontRequireReceiver);
        }
    }

    

    [System.Serializable]
    public struct VoiceCommand
    {
        [Tooltip("The keyword to recognize.")]
        public string Keyword;
        [Tooltip("Message to send to the selected game object")]
        public string Message;
    }
}


