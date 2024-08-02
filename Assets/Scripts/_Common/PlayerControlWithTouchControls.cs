using UnityEngine;

public class PlayerControlWithTouchControls : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if(Input.touchCount > 0) {
            bool isTouchingRight = false;
            bool isTouchingLeft = false;

            for(int i = 0; i < Input.touchCount; i++) {
                Touch touch = Input.GetTouch(i);

                if(!GameManager.Instance.IsPointerOverUIObject(touch)) {
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                        Vector2 screenPos = Camera.main.ScreenToWorldPoint(touch.position);

                        if (screenPos.x > 0f) {
                            isTouchingRight = true;
                        }

                        else if (screenPos.x < 0f) {
                            isTouchingLeft = true;
                        }
                    }
                }
            }

            if(isTouchingRight && !isTouchingLeft) {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                transform.rotation = Quaternion.identity;
            }

            else if (isTouchingLeft && !isTouchingRight) {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }

            else {
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
        }

        else {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}
