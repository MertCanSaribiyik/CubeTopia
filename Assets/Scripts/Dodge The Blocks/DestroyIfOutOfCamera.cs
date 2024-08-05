using UnityEngine;

public class DestroyIfOutOfCamera : MonoBehaviour
{
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

}
