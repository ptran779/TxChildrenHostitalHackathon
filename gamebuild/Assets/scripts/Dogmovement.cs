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
    bool moving = false;
    public float tollerate = 0.5f;

    // Vector3 lookAt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // goto to mouse click
        if (Input.GetMouseButton(0)){
            SetTargetPosition();
            }
        if (moving){
            moveto();
            float xdiff = targetPosition.x - transform.position.x;
            float zdiff = targetPosition.z - transform.position.z;
            float distance = Mathf.Sqrt(Mathf.Pow(xdiff, 2)+ Mathf.Sqrt(Mathf.Pow(zdiff, 2)));
            if (distance <= tollerate){
                moving = false;
            }
        }
    }
    void SetTargetPosition(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // only set new target if hit
        if (Physics.Raycast(ray, out hit, 1000)){
            targetPosition = hit.point;
            moving = true;
        }
    }
    void moveto(){
        TargetVector = new Vector3(targetPosition.x - transform.position.x,
            0.0f,
            targetPosition.z - transform.position.z);
            
            playerRot = Quaternion.LookRotation(TargetVector);
                        
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                    playerRot,
                                                    RoSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position,
                                                    new Vector3(targetPosition.x, transform.position.y,targetPosition.z),
                                                    speed * Time.deltaTime);
        }
}