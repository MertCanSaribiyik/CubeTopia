using UnityEngine;

public class RotatingObjects : MonoBehaviour
{
    [SerializeField] private float rotatePerSeconds = 2f;

    private void Update() {
        transform.Rotate(0f, 0f, 360f *  rotatePerSeconds * Time.deltaTime);
    }
}
