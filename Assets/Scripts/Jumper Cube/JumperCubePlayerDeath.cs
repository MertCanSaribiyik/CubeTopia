using UnityEngine;
using UnityEngine.UI;

public class JumperCubePlayerDeath : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    private bool playerIsDeath;

    private Rigidbody2D rb;
    [SerializeField] private float deathValue = 30f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerIsDeath = false;
    }

    private void Update() {
        if(rb.velocity.y <= -deathValue && !playerIsDeath) {
            playerIsDeath = true;
            if (GameManager.Instance.playerInfo.score > PlayerPrefs.GetInt("jumperCubeHighscore", 0)) {
                PlayerPrefs.SetInt("jumperCubeHighscore", GameManager.Instance.playerInfo.score);
            }
            GameManager.Instance.RestartGame();
        }
    }
}
