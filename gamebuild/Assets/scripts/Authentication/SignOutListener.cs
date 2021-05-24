using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Collections;

public class SignOutListener : MonoBehaviour
{
  public Button button;
  protected Firebase.Auth.FirebaseAuth auth;

  // Start is called before the first frame update
  void Start()
  {
    button.onClick.AddListener(() => SignOut());
    StartCoroutine(Loadgame());
  }
  
  // This is just simulation of some time it take to load the game.
  IEnumerator Loadgame(){
    Debug.Log("Start load: " + Time.time);
    yield return new WaitForSeconds(3);
    Debug.Log("End Load: " + Time.time);
    SceneManager.LoadScene("game scene");
  }

  void SignOut()
  {
	auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
	auth.SignOut();
	SceneManager.LoadScene("SignInScene");
  }

}
