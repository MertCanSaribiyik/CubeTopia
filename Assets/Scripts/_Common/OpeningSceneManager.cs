using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneManager : MonoBehaviour
{
    [SerializeField] private string miniGameName;

    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private TextMeshProUGUI scoreTxt, highscoreTxt;

    [SerializeField] private GameObject howToPlayPanel;

    [SerializeField] private AudioClip buttonClip;

    private void Awake() {
        scoreTxt.text = $"Your Score : {playerInfo.score}";
        highscoreTxt.text = $"Best : {PlayerPrefs.GetInt($"{miniGameName}Highscore", 0)}";

        if(PlayerPrefs.HasKey(miniGameName)) {
            howToPlayPanel.SetActive(false);
        }

        else {
            PlayerPrefs.SetInt(miniGameName, 1);
            howToPlayPanel.SetActive(true);
        }
    }

    public void StartButton() {
        ClickButtonSound();
        SetPlayerInfo();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuButton() {
        ClickButtonSound();
        SetPlayerInfo();
        SceneManager.LoadScene(0);
    }

    public void HowToPlayButton() {
        ClickButtonSound();
        howToPlayPanel.SetActive(true);
    }

    private void SetPlayerInfo() {
        playerInfo.score = 0;
        playerInfo.health = 100;
    }

    private void ClickButtonSound() {
        AudioManager.Instance.PlayOneShot(buttonClip);
    }
}
