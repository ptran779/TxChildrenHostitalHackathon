using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Interaction : MonoBehaviour
{
    public GameObject UiFloater;
    public GameObject UiTasker;
    public Canvas UserCanvas;
    public float BouncyLevel = 200; 
    private bool DoBounce = false;  // if object should bounce
    private GameObject InteUI;
    private MonoBehaviour DMoveScript;
    public bool busy = false;
    Rigidbody m_Rigidbody;

    void Start() {
        Debug.developerConsoleVisible = true;
        m_Rigidbody = GetComponent<Rigidbody>();
        DMoveScript = GetComponent<Dogmovement>();
    }
    void OnTriggerEnter(Collider collide) {
        if (collide.gameObject.name == "Bed"){
            InteUI = Instantiate(UiFloater, UserCanvas.transform);
            InteUI.name = "BedInter";
            InteUI.GetComponent<lockonobject>().target = collide.gameObject;
            if (!busy){
                InteUI.transform.Find("Description").GetComponent<TextMeshProUGUI>().SetText("Lay on Bed");
                InteUI.GetComponent<Button>().onClick.AddListener(() => LayOnBed(collide.gameObject.transform.position));
            } 
            else{
                InteUI.transform.Find("Description").GetComponent<TextMeshProUGUI>().SetText("Get Off Bed");
                InteUI.GetComponent<Button>().onClick.AddListener(() => GetOffStuff(collide.gameObject.transform.position));
            }
        }
        else if (collide.gameObject.name == "Couch"){
            InteUI = Instantiate(UiFloater, UserCanvas.transform);
            InteUI.name = "CouchInte";
            InteUI.GetComponent<lockonobject>().target = collide.gameObject;
            if (!busy){
                InteUI.transform.Find("Description").GetComponent<TextMeshProUGUI>().SetText("Jump on Couch");
                InteUI.GetComponent<Button>().onClick.AddListener(() => JumpOnCouch(collide.gameObject.transform.position));
            } 
            else{
                InteUI.transform.Find("Description").GetComponent<TextMeshProUGUI>().SetText("Get Off Couch");
                InteUI.GetComponent<Button>().onClick.AddListener(() => GetOffStuff(collide.gameObject.transform.position));
            }
        }
        else if (collide.gameObject.name == "ClipBoard"){
            InteUI = Instantiate(UiFloater, UserCanvas.transform);
            InteUI.name = "UITaskInte";
            InteUI.GetComponent<lockonobject>().target = collide.gameObject;
            if (!busy){
                InteUI.transform.Find("Description").GetComponent<TextMeshProUGUI>().SetText("View Task");
                InteUI.GetComponent<Button>().onClick.AddListener(() => OpenMyTask());
            } 
            // else{
            //     InteUI.transform.Find("Description").GetComponent<TextMeshProUGUI>().SetText("Get Off Couch");
            //     InteUI.GetComponent<Button>().onClick.AddListener(() => GetOffStuff(collide.gameObject.transform.position));
            // }
        }
    }
    void OnTriggerExit(Collider collide) {
        if (collide.gameObject.name == "Bed"){
            Destroy(UserCanvas.transform.Find("BedInter").gameObject);
        }
        else if (collide.gameObject.name == "Couch"){
            Destroy(UserCanvas.transform.Find("CouchInte").gameObject);
        }
        else if (collide.gameObject.name == "ClipBoard"){
            Destroy(UserCanvas.transform.Find("UITaskInte").gameObject);
        }
    }
    void GetOffStuff(Vector3 Bedpos){
        transform.position = Bedpos + new Vector3(-1f,0,-1.4f);
        transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        busy = false;
        DoBounce = false;
        DMoveScript.enabled = true;
    }
    void LayOnBed(Vector3 Bedpos){
        DMoveScript.enabled = false;
        transform.position = Bedpos + new Vector3(0,2.4f,0);
        transform.rotation = Quaternion.Euler(new Vector3(0, 90, 90));
        busy = true;
    }
    void JumpOnCouch(Vector3 CouchPos){
        DMoveScript.enabled = false;
        transform.position = CouchPos + new Vector3(-0.5f,2.4f,0);
        transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        m_Rigidbody.freezeRotation = true; // lock rotation for simpler simulation
        DoBounce = true;
        StartCoroutine(Bounce());
        busy = true;
    }

    // coroutine to keep object bouncing
    IEnumerator Bounce(){
        while (DoBounce){  // flip this on before runing this code. AND remember to turn it off
            yield return new WaitForSeconds(1);
            m_Rigidbody.AddForce(transform.up * BouncyLevel);
        }
    }
    void OpenMyTask(){
        DMoveScript.enabled = false;
        InteUI = Instantiate(UiTasker, UserCanvas.transform);
        InteUI.name = "UITask";
        InteUI.GetComponent<TaskHandler>().Player = transform.gameObject;
        busy = true;
    }
}
