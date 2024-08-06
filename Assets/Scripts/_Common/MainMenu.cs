using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamesPanel;

    [SerializeField] private AudioClip buttonClip;

    private void Awake() {
        Application.targetFrameRate = 60;
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        menuPanel.SetActive(true);
        gamesPanel.SetActive(false);
    }

    public void PlayButton() {
        menuPanel.SetActive(false);
        gamesPanel.SetActive(true);
        ClickButtonSound();
    }

    public void QuitButton() {
        ClickButtonSound();
        Application.Quit();
    }

    public void BacktoMainMenuButton() {
        ClickButtonSound();
        menuPanel.SetActive(true);
        gamesPanel.SetActive(false);
    }

    public void GameButton(int sceneIndex) {
        ClickButtonSound();
        SceneManager.LoadScene(sceneIndex);
    }

    private void ClickButtonSound() {
        AudioManager.Instance.PlayOneShot(buttonClip);
    }
}
