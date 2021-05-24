using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class TaskHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public Button Submit;
    public Button Quit;
    public GameObject ATaskFormat;
    private GameObject ATask;
    private string GamePath;
    private string todofile;
    private string line;
    public List<string> alltask;
    public List<string> removelist;
    string[] taskdata;
    void Start()
    {
        Quit.onClick.AddListener(() => CloseMe());
        Submit.onClick.AddListener(() => SubmitTask());
        GamePath = Application.dataPath;
        if (!Directory.Exists(GamePath + "/userdat")){
            Directory.CreateDirectory(GamePath + "/userdat");
        }  // make directory if not exist
        todofile = GamePath + "/userdat/patientTask.csv";
        if (!File.Exists(todofile)){
            var sr = File.CreateText(todofile);
            sr.WriteLine ("TaskID,description,Date and time,Note\n");
            sr.Close();
        }  // make file if not exist -- remove later

        // read file
        var sr2 = File.OpenText(todofile);
        sr2.ReadLine(); // skip header line
        line = sr2.ReadLine(); // read first line
        int counter = 0;  // for alighment  

        while(line != null){
            alltask.Add(line);  // for later use
            Debug.Log(line);
            taskdata = line.Split(',');
            if (taskdata[2] == "N"){
                ATask = Instantiate(ATaskFormat, transform);
                ATask.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 220f - 60f*counter);
                ATask.name=taskdata[0];
                ATask.transform.Find("TaskDescription").GetComponent<TextMeshProUGUI>().SetText(taskdata[1]);;
                counter++;
            }
            line = sr2.ReadLine();
        }
    }
    void CloseMe(){
        TurnOnMovement();
        Destroy(gameObject);
    }

    void SubmitTask(){
        var sr = File.CreateText(todofile);
        sr.WriteLine ("TaskID,description,Date and time,Note");
        // scan through to see which task is checked
        foreach (Transform child in transform){
            if (!(child.name == "Submit" | child.name == "Quit")){
                if (child.GetComponent<SingleTaskHandler>().check){
                    // Debug.Log("remove" + child.name);
                    removelist.Add(child.name);
                }
            }
        }
        foreach (string line in alltask){
            taskdata = line.Split(',');
            if (removelist.Contains(taskdata[0])){
                taskdata[2] = "Y";
                sr.WriteLine(string.Join(",", taskdata));
            }
            else {
                sr.WriteLine(line);
            }
        }
            sr.Close();
        TurnOnMovement();
        Destroy(gameObject);
    }
    void TurnOnMovement(){
        Player.GetComponent<Dogmovement>().enabled=true;
    }
}
