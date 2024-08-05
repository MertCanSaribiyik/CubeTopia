using UnityEngine;

public class TopDownShooterEnemyFollowing : MonoBehaviour
{
    private Transform target;
    private float speed;
    [SerializeField] private float minSpeed, maxSpeed;

    private void Awake() {
        target = GameObject.FindWithTag("Player").transform;
        speed = Random.Range(minSpeed, maxSpeed);   
    }

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
