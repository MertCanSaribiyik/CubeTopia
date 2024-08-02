using UnityEngine;

public class DifficultyIncrease : MonoBehaviour
{
    [SerializeField] private float difficultyRate = 300f;
    [SerializeField] private float maxDifficulty = 1.6f;

    private float tempTimeScale;

    private void Awake() {
        tempTimeScale = 1f;
    }

    private void Update() {
        if(Time.timeScale <= maxDifficulty && !GameManager.Instance.GameIsPaused) {
            tempTimeScale += Time.deltaTime / difficultyRate;
            Time.timeScale = tempTimeScale;
            print(Time.timeScale);
        }   
    }
}
