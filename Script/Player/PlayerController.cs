using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [Header("Variable")]
    [SerializeField] [Min(0)] private float speed;
    [SerializeField] [Min(0)] private float maxSpeed;
    [Space]
    [SerializeField] [Min(0)] private float rotationSpeed;
    
    [Header("Privates")]
    private float movementX;
    private float movementY;

    [Header("Component")]
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    private void FixedUpdate()
    {
        rb2d.rotation -= movementX * rotationSpeed * Time.fixedDeltaTime;

        speed = Mathf.Clamp(speed + movementY, 80f, maxSpeed);
        rb2d.velocity = transform.up * speed * Time.fixedDeltaTime;
    }
}
