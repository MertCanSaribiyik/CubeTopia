using UnityEngine;

public class JumpingWhenClicked : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private int maxJumpCount = 2;
    private int jumpCount;
    private bool jumping;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        jumpCount = 0;
        jumping = false;

    }

    private void Update() {
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began && jumpCount < maxJumpCount && !GameManager.Instance.IsPointerOverUIObject(touch)) {
                jumping = true;
            }
        }

    }

    private void FixedUpdate() {
        if(jumping) {
            AudioManager.Instance.PlayOneShot("jumping");
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
            jumpCount++;
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            jumpCount = 0;
        }
    }
}
