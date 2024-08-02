using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private Transform player;
    [SerializeField] private float t = 3.5f;

    private Animator cameraAnimator;
    [SerializeField] private int cameraShakeStartScore = 50;
    private int coefficient;

    [SerializeField] private GameObject flashEffectPrefab;

    private void Awake() {
        cameraAnimator = GetComponent<Animator>();
        coefficient = 1;
    }

    private void Update() {
        Vector2 targetPos = new Vector2(transform.position.x, player.position.y);
        transform.position = Vector2.Lerp(transform.position, targetPos, t);

        if(playerInfo.score >= cameraShakeStartScore * coefficient) {
            coefficient++;
            cameraAnimator.SetTrigger("shake2");
            Instantiate(flashEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
