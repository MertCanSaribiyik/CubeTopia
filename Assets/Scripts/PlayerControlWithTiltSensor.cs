using UnityEngine;

public class PlayerControlWithTiltSensor : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f, tiltCoefficient;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        float tilt = Input.acceleration.x;
        rb.velocity = new Vector2 (tilt * speed * tiltCoefficient, rb.velocity.y);
    }
}
