using UnityEngine;

public class DodgeTheBlocksEnemy : MonoBehaviour, IInteraction
{
    private PlayerInteract playerInteract;

    [SerializeField] private float slowMotionValue = .25f;

    private void Awake() {
        playerInteract = GameObject.FindWithTag("Player").GetComponent<PlayerInteract>();
    }

    public void Interact() {
        AudioManager.Instance.PlayOneShot("slowDown");
        Destroy(playerInteract);
        GameManager.Instance.GameIsPaused = true;
        Time.timeScale = slowMotionValue;


        if(GameManager.Instance.playerInfo.score > PlayerPrefs.GetInt("dodgeTheBlocksHighscore", 0)) {
            PlayerPrefs.SetInt("dodgeTheBlocksHighscore", GameManager.Instance.playerInfo.score);
        } 

        GameManager.Instance.RestartGame();
    }
}
