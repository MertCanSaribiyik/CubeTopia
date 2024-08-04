using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private Color[] colors;

    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private int colorChangeStartScore = 2;
    private int coefficient;

    private void Awake() {
        coefficient = 1;
        background.color = playerInfo.backgroundColor;
    }

    private void Update() {
        if(playerInfo.score >= colorChangeStartScore * coefficient) {
            do {
                playerInfo.backgroundColor = colors[Random.Range(0, colors.Length)];
            } while (playerInfo.backgroundColor == background.color);

            background.color = playerInfo.backgroundColor;
            coefficient++;
        }
    }

}
