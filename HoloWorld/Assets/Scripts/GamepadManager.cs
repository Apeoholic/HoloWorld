using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

[RequireComponent(typeof(GazeManager))]
public class GamepadManager : MonoBehaviour
{

    private GazeManager gazeManager;
	void Start ()
    {
        gazeManager = GetComponent<GazeManager>();
	}
	
	void Update ()
    {
        var focusedObject = gazeManager.FocusedObject;

        if (focusedObject != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                gazeManager.FocusedObject.SendMessage("Explode", SendMessageOptions.DontRequireReceiver);
            }


            gazeManager.FocusedObject.transform.Rotate(Input.GetAxis("RightX"), Input.GetAxis("RightY"), 0);
        }
    }
}
