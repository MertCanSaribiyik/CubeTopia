using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float destroyTime = 5f;

    private void Start() {
        Destroy(gameObject, destroyTime);
    }
}
