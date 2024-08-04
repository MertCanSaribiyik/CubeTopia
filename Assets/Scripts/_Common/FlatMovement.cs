using UnityEngine;

public class FlatMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 8f;

    [SerializeField] private int direction;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Vector2 movement = Vector2.right * direction * speed;
        movement.y = rb.velocity.y;
        
        rb.velocity = movement;
    }

}
