using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    private Animator cameraAnimator;
    [SerializeField] private int cameraShakeStartScore = 50;
    private int coefficient;

    [SerializeField] private GameObject flashEffectPrefab;

    private void Awake() {
        cameraAnimator = GetComponent<Animator>();
        coefficient = 1;
    }

    private void Update() {
        if (playerInfo.score >= cameraShakeStartScore * coefficient) {
            coefficient++;
            cameraAnimator.SetTrigger("shake2");
            Instantiate(flashEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
