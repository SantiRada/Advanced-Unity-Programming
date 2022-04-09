using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    #region DELEGATES
    /* ------------- DELEGATES ------------- */
    /*
    delegate void SimpleMessage();
    SimpleMessage simpleMessage;

    private void Start()
    {
        simpleMessage += SendConsoleMessage;
        simpleMessage += SendSecondMessage;
        simpleMessage?.Invoke();
    }
    private void SendConsoleMessage()
    {
        Debug.Log("Se ha creado este DELEGATE");
    }
    private void SendSecondMessage()
    {
        Debug.Log("Segundo mensaje del DELEGATE");
    }
    */
    #endregion

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    public GameObject GameOverScreen;

    private void Awake()
    {
        GameOverScreen.SetActive(false);
        OnPlayerDeath += ShowGameOverScreen;
    }
    private void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }
    public void PlayerKilled()
    {
        OnPlayerDeath?.Invoke();
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
