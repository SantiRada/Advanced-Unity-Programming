using UnityEngine;

public class EnemyMove : MonoBehaviour {

    [Header("Object")]
    [SerializeField] private GameObject partycleExplosion;

    private void OnEnable()
    {
        GameManager.OnUpdateScore += Deactivate;
    }
    private void OnDisable()
    {
        GameManager.OnUpdateScore.Invoke();
        GameManager.OnUpdateScore -= Deactivate;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Bullet"))
        {
            Deactivate();

            //DeadEnemy();
        }
    }
    private void DeadEnemy()
    {
        Instantiate(partycleExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
