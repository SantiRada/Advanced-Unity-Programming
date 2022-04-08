using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour {

    [Header("Variable")]
    [SerializeField] private float speed;

    [Header("Object")]
    private  Transform target;

    [Header("Component")]
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerController>().transform;
    }
    private void FixedUpdate()
    {
        rb2d.velocity = (target.position - transform.position).normalized * speed * Time.fixedDeltaTime;
    }
}
