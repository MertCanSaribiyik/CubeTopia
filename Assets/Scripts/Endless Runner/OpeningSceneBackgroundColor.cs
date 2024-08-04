using UnityEngine;

public class OpeningSceneBackgroundColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private PlayerInfo playerInfo;

    private void Awake() {
        background.color = playerInfo.backgroundColor;
    }
}
