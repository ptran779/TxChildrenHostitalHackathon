using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingleTaskHandler : MonoBehaviour
{
    // public GameObject TaskHandler;
    public Sprite OnImg;
    public Sprite OffImg;
    public bool check = false;
    private GameObject Cbutton;
    // Start is called before the first frame update
    void Start()
    {
        Cbutton = transform.Find("Button").gameObject;
        Cbutton.GetComponent<Button>().onClick.AddListener(() => CheckTask());
    }

    void CheckTask(){
        if (!check) {
            Cbutton.GetComponent<Image>().sprite = OnImg;
            check = true;
        }
        else {
            Cbutton.GetComponent<Image>().sprite = OffImg;
            check = false;
        }
    }
}
