using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    private void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {
        // keep looking at target and lock camera position
        transform.position = target.position + offsetPosition;
        transform.LookAt(target);
    }
}