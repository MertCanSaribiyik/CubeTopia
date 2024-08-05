using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followIntervalX, followIntervalY;
    [SerializeField] private bool xAxis = true, yAxis = true;
    [SerializeField] private float t;

    private void Update() {
        Vector2 targetPos;

        if(xAxis && yAxis) {
            targetPos = new Vector2(target.position.x + followIntervalX, target.position.y + followIntervalY);
        }

        else if(xAxis) {
            targetPos = new Vector2(target.position.x + followIntervalX, transform.position.y);
        }

        else if(yAxis) {
            targetPos = new Vector2(transform.position.x, target.position.y + followIntervalY);
        }

        else {
            targetPos = transform.position;
        }

        transform.position = Vector2.Lerp(transform.position, targetPos, t * Time.deltaTime);
    }
}
