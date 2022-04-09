using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Header("Object")]
    delegate void SimpleMessage();
    SimpleMessage simpleMessage;

    private void Start()
    {
        simpleMessage = SendConsoleMessage();
        simpleMessage.Invoke();
    }
    private void SendConsoleMessage()
    {
        Debug.Log("Se ha creado este DELEGATE");
    }
}
