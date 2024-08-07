using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Animator cameraAnimator;
    [SerializeField] private int cameraShakeStartScore = 50;
    private int coefficient;

    [SerializeField] private GameObject flashEffectPrefab;

    private void Awake() {
        cameraAnimator = GetComponent<Animator>();
        coefficient = 1;
    }

    private void Update() {
        if (GameManager.Instance.playerInfo.score >= cameraShakeStartScore * coefficient) {
            coefficient++;
            cameraAnimator.SetTrigger("shake2");
            AudioManager.Instance.PlayOneShot("speedUp");
            Instantiate(flashEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
