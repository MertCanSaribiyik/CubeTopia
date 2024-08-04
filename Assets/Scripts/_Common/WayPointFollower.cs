using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    private int index;

    [SerializeField] private float speed = 5f;

    private void Awake() {
        index = Random.Range(0, points.Length);
    }

    private void Update() {
        Vector2 targetPos = new Vector2(transform.position.x, points[index].position.y);

        if (Vector2.Distance(transform.position, targetPos) <= 0f) {
            index = (index == points.Length - 1) ? 0 : index + 1;
        }

        else {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
