using UnityEngine;

public class TopDownShooterSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private Transform[] points;
    [SerializeField] private float xDistance = 15f, yDistance = 9f;

    private float spawnTime;
    [SerializeField] private float startSpawnTime;
    [SerializeField] private float minTime, decreaseTime;

    private void Awake() {
        spawnTime = startSpawnTime;
    }

    private void Update() {
        print(startSpawnTime);

        if(spawnTime <= 0f) {
            Create();
            spawnTime = startSpawnTime;

            if(startSpawnTime >= minTime) {
                startSpawnTime -= decreaseTime * Time.deltaTime ;
            }
        }

        else {
            spawnTime -= Time.deltaTime;
        }
    }

    private void Create() {
        int randEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector2 randomPoints = points[Random.Range(0, enemyPrefabs.Length)].position;

        if(randomPoints.y == 0f) {
            float yPos = Random.Range(-yDistance, yDistance);
            Instantiate(enemyPrefabs[randEnemyIndex], new Vector2(randomPoints.x, yPos), Quaternion.identity);
        }

        else {
            float xPos = Random.Range(-xDistance, xDistance);
            Instantiate(enemyPrefabs[randEnemyIndex], new Vector2(xPos, randomPoints.y), Quaternion.identity);
        }
    }



}
