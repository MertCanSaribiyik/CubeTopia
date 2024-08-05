using UnityEngine;

public class TaretControl : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float t = 3f;

    private void Update() {
        if (joystick.Direction != Vector2.zero) {
            float angle = Mathf.Atan2(joystick.Direction.y, joystick.Direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(Vector3.forward * angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, t * Time.deltaTime);
        } 

    }

}
