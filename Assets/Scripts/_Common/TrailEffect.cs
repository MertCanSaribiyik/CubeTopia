using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject trailEffectPrefab;

    private float spawnTime;
    [SerializeField] private float spawnStartTime = 0.1f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(rb.velocity.y != 0) {
            if (spawnTime <= 0f) {
                GameObject trailEffect = Instantiate(trailEffectPrefab, transform.position, Quaternion.identity);
                spawnTime = spawnStartTime;
            }

            else {
                spawnTime -= Time.deltaTime;
            }
        }
       
    }
}
