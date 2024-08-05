using UnityEngine;

public class BouncyGround : MonoBehaviour, IInteraction
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private int scoreGiven = 1;
    private bool value;

    private Rigidbody2D playerRb;
    [SerializeField] private float jumpForce = 16.5f;

    private Animator animator;
    [SerializeField] private float destroyInterval = 10f;

    private void Awake() {
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        value = false;
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

            if (!value) {
                playerInfo.score += scoreGiven;
                value = true;
            }
        }
    }
}
