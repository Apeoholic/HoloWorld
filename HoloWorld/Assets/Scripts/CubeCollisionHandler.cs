using UnityEngine;
using System.Collections;

public class CubeCollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        gameObject.SendMessage("Explode");
    }
}
