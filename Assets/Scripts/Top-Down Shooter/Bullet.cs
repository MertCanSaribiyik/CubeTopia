using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

    private Transform player;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;

        transform.rotation = player.rotation;   
    }

    private void FixedUpdate() {
        rb.velocity = transform.right * speed;
    }
    
}
