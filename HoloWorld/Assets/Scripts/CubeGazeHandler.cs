using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CubeGazeHandler : MonoBehaviour
{
    public void OnGazeEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void OnGazeLeave()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public void OnSelect()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }

}
