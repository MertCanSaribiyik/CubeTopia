using UnityEngine;

public class BouncyGround : MonoBehaviour, IInteraction
{
    [SerializeField] private int scoreGiven = 1;
    private bool didCollidePlayer;

    private Rigidbody2D playerRb;
    [SerializeField] private float jumpForce = 16.5f;

    private Animator animator;
    [SerializeField] private float destroyInterval = 10f;

    private void Awake() {
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        didCollidePlayer = false;
    }

    private void Update() {
        if(transform.position.y < Camera.main.transform.position.y - destroyInterval) {
            Destroy(gameObject);
        }
    }

    public void Interact() {
        if (playerRb.velocity.y < .1f) {
            animator.SetTrigger("destroy");
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            AudioManager.Instance.PlayOneShot("bouncing");

            if (!didCollidePlayer) {
                GameManager.Instance.playerInfo.score += scoreGiven;
                didCollidePlayer = true;
            }
        }
    }
}
