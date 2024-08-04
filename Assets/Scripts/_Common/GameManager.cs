using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private TextMeshProUGUI scoreTxt;
    private int tempScore;

    public bool GameIsPaused { get; set; }

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

        pausePanel.SetActive(false);

        GameIsPaused = false;
    }

    private void Update() {
        if(tempScore != playerInfo.score) {
            tempScore = playerInfo.score;
            scoreTxt.text = playerInfo.score.ToString();
        }

        print(Time.timeScale);
    }

    public void PauseButton() {
        GameIsPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ContinueButton() {
        GameIsPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void BackToButton() {
        Time.timeScale = 1f;
        playerInfo.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public async void RestartGame() {
        GameIsPaused = true;
        pauseButton.interactable = false;
        await UniTask.Delay((int)(Time.timeScale * delay * 1000f));
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //True if the touch is on the UI element, false otherwise 
    public bool IsPointerOverUIObject(Touch touch) {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current) {
            position = new Vector2(touch.position.x, touch.position.y)
        };

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
