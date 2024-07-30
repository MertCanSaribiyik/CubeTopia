using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneManager : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private TextMeshProUGUI scoreTxt, highscoreTxt;
    [SerializeField] private string highScoreString;

    private void Awake() {
        scoreTxt.text = $"Your Score : {playerInfo.score}";
        highscoreTxt.text = $"Best : {PlayerPrefs.GetInt(highScoreString, 0)}";
    }

    public void StartButton() {
        playerInfo.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuButton() {
        playerInfo.score = 0;
        SceneManager.LoadScene(0);
    }
}
