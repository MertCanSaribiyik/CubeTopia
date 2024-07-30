using UnityEngine;

public class DodgeTheBlocksEnemy : MonoBehaviour, IInteraction
{
    [SerializeField] private PlayerInfo playerInfo;
    private PlayerInteract playerInteract;

    [SerializeField] private float timeScaleValue = .25f;

    private void Awake() {
        playerInteract = GameObject.FindWithTag("Player").GetComponent<PlayerInteract>();
    }

    public void Interact() {
        Destroy(playerInteract);
        GameManager.Instance.GameIsPaused = true;
        Time.timeScale = timeScaleValue;


        if(playerInfo.score > PlayerPrefs.GetInt("dodgeTheBlocksHighscore", 0)) {
            PlayerPrefs.SetInt("dodgeTheBlocksHighscore", playerInfo.score);
        } 

        GameManager.Instance.RestartGame();
    }
}
