using UnityEngine;

public class FollowingCameraX : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float followUpInterval;

    private void Update() {
        Vector2 targetPos = new Vector2(player.position.x + followUpInterval, transform.position.y);
        transform.position = targetPos;
    }
}
