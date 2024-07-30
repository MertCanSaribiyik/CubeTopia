using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private GameObject PausePanel;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    private int tempScore;

    public bool GameIsPaused { get; private set; }

    [SerializeField] private float delay = 1.5f;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        }

        else {
            Instance = this;
        }

        scoreTxt.text = playerInfo.score.ToString();
        tempScore = playerInfo.score;

        PausePanel.SetActive(false);

        GameIsPaused = false;
    }

    private void Update() {
        if(tempScore != playerInfo.score) {
            tempScore = playerInfo.score;
            scoreTxt.text = playerInfo.score.ToString();
        }
    }

    public void PauseButton() {
        GameIsPaused = true;
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void ContinueButton() {
        GameIsPaused = false;
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void BackToButton() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public async void RestartGame() {
        await UniTask.Delay((int)(delay * 1000f));
        BackToButton();
    }
}
