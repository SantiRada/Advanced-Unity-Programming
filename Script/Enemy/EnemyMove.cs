using UnityEngine;

public class EnemyMove : MonoBehaviour {

    [Header("Object")]
    [SerializeField] private GameObject partycleExplosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(partycleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
