using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

}
