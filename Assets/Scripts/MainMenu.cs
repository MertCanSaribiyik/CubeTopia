using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamesPanel;

    private void Awake() {
        Application.targetFrameRate = 60;
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        BacktoMainMenuButton();
    }

    public void PlayButton() {
        menuPanel.SetActive(false);
        gamesPanel.SetActive(true);
    }

    public void QuitButton() {
        Application.Quit();
    }

    public void BacktoMainMenuButton() {
        menuPanel.SetActive(true);
        gamesPanel.SetActive(false);
    }

    public void GameButton(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    
}
