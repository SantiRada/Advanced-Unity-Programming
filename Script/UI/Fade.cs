using UnityEngine;
using DG.Tweening;

public class Fade : MonoBehaviour {

    [Header("Variables")]
    [SerializeField] private float speed;

    [Header("Component")]
    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();

        GameManager.OnPlayerDeath += FadeIn;
        Debug.Log("FadeIn ha sido incorporado");

        FadeOut();
    }
    private void StartGame()
    {
        Debug.Log("FadeOut Completo");
    }
    public void FadeIn()
    {
        Debug.Log("FadeIn ha sido llamado");

        spr.DOFade(1, speed).OnComplete(()=> {
            Debug.Log("FadeIn Completo");
        });
    }
    public void FadeOut()
    {
        spr.DOFade(0, speed).OnComplete(()=>StartGame()).OnStart(()=> {
            Debug.Log("FadeOut Iniciado");
        });
    }
}
