using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void ChangeScene()
    {
        Invoke("Changer", 1);
    }
    private void Changer()
    {
        SceneManager.LoadScene("Level");
    }
}
