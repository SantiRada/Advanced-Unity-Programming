using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    [Header("Audio")]
    [SerializeField] private AudioClip shoot;
    private AudioSource music;

    private void Start()
    {
        music = GetComponent<AudioSource>();

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    [ContextMenu("PlayShoot")]
    public void PlayShoot()
    {
        Debug.Log("Reproduciendo");
        music.PlayOneShot(shoot);
    }
}
