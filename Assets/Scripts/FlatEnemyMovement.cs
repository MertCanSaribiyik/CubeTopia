using UnityEngine;

public class FlatEnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 8f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Vector2 movement = Vector2.left * speed;
        movement.y = rb.velocity.y;
        
        rb.velocity = movement;
    }

}
