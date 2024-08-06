using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private Color[] colors;

    [SerializeField] private int colorChangeStartScore = 2;
    private int coefficient;

    private void Start() {
        coefficient = 1;
        background.color = GameManager.Instance.playerInfo.backgroundColor;
    }

    private void Update() {
        if(GameManager.Instance.playerInfo.score >= colorChangeStartScore * coefficient) {
            do {
                GameManager.Instance.playerInfo.backgroundColor = colors[Random.Range(0, colors.Length)];
            } while (GameManager.Instance.playerInfo.backgroundColor == background.color);

            background.color = GameManager.Instance.playerInfo.backgroundColor;
            coefficient++;
        }
    }

}
