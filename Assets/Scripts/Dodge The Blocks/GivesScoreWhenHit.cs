using UnityEngine;

public class GivesScoreWhenHit : MonoBehaviour, IInteraction
{
    [SerializeField] private PlayerInfo playerInfo;

    public void Interact() {
        playerInfo.score++;
        Destroy(gameObject);
    }
}
