using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogmovement : MonoBehaviour
{
    Vector3 targetPosition;
    Vector3 TargetVector;
    Quaternion playerRot;
    public float RoSpeed = 10;
    public float speed = 5;

    // Vector3 lookAt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // lock rotation
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        
        // goto to mouse click
        if (Input.GetMouseButton(0)){
            SetTargetPosition();
        }
    }
    void SetTargetPosition(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000)){
            targetPosition = hit.point;
            TargetVector = new Vector3(targetPosition.x - transform.position.x,
            transform.position.y,
            targetPosition.z - transform.position.z);
            
            playerRot = Quaternion.LookRotation(TargetVector);
                        
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                    playerRot,
                                                    RoSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position,
                                                    targetPosition,
                                                    speed * Time.deltaTime);
        }
    }
}
 