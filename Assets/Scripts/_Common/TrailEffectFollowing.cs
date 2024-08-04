using UnityEngine;

public class TrailEffectFollowing : MonoBehaviour
{
    private Transform target;

    private void Awake() {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update() {
        transform.position = new Vector2(target.position.x, transform.position.y);
    }
}
