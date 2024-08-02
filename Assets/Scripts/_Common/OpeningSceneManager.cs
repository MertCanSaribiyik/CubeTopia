using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneManager : MonoBehaviour
{
    [SerializeField] private string miniGameName;

    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private TextMeshProUGUI scoreTxt, highscoreTxt;

    [SerializeField] private GameObject howToPlayPanel;

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
        playerInfo.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuButton() {
        playerInfo.score = 0;
        SceneManager.LoadScene(0);
    }

    public void HowToPlayButton() {
        howToPlayPanel.SetActive(true);
    }

    public void BackButton() {
        howToPlayPanel.SetActive(false);
    }
}
