using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SignOutListener : MonoBehaviour
{
  public Button button;
  protected Firebase.Auth.FirebaseAuth auth;

  // Start is called before the first frame update
  void Start()
  {

    button.onClick.AddListener(() => SignOut());
	
  }
  
  void SignOut()
  {
	auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
	auth.SignOut();
	SceneManager.LoadScene("SignInScene");
  }

}
