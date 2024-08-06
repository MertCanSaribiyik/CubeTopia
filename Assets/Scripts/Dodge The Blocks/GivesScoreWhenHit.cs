using UnityEngine;

public class GivesScoreWhenHit : MonoBehaviour, IInteraction
{
    public void Interact() {
        GameManager.Instance.playerInfo.score++;
        AudioManager.Instance.PlayOneShot("coinCollect");
        Destroy(gameObject);
    }
}
