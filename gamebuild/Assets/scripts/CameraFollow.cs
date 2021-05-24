using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    Vector3 offsetPosition;

    void LateUpdate()
    {
        Refresh();
    }

    void Refresh()
    {
        // keep looking at target and lock camera position
        transform.position = target.position + offsetPosition;
        transform.LookAt(target);
    }
}