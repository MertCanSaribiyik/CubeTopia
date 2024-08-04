using UnityEngine;

public class EndlessRunnerDestroyObject : MonoBehaviour
{
    [SerializeField] private float destroyTime = 5f;

    private void Start() {
        Destroy(gameObject, destroyTime);
    }
}
