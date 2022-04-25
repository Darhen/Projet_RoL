using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle : MonoBehaviour
{

    public Transform Camera;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.forward);
    }
}
