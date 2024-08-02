using UnityEngine;

public class GameStartsTouched : MonoBehaviour
{
    [SerializeField] private GameObject tapToStartTxt;

    private void Awake() {
        tapToStartTxt.SetActive(true);
    }

    private void Start() {
        GameManager.Instance.GameIsPaused = true;
        Time.timeScale = 0f;
    }

    private void Update() {
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (!GameManager.Instance.IsPointerOverUIObject(touch)) {
                GameManager.Instance.GameIsPaused = false;
                Time.timeScale = 1f;
                tapToStartTxt.SetActive(false);
                this.enabled = false;
            }
           
        }
    }
}
