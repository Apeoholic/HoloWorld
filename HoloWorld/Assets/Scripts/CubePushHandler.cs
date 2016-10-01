using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CubePushHandler : MonoBehaviour
{

    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    void Push(Vector3 position)
    {
        rigidbody.AddForceAtPosition(transform.forward * 100, position);
    }

}
