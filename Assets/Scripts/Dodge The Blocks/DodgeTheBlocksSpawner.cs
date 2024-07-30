using UnityEngine;

public class DodgeTheBlocksSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject blockPrefab, giftScoreBlockPrefab;

    private float spawnTime;
    [SerializeField] private float startSpawnTime = 1f;

    private void Awake() {
        spawnTime = startSpawnTime;
    }

    private void Update() {
        if(spawnTime <= 0f) {
            spawnTime = startSpawnTime;
            Create();
        }

        else {
            spawnTime -= Time.deltaTime;
        }
    }

    private void Create() {
        int randIndex = Random.Range(0, points.Length);
        GameObject prefab;

        for(int i = 0; i < points.Length; i++) {
            if (i == randIndex) {
                prefab = giftScoreBlockPrefab;
            }

            else {
                prefab = blockPrefab;
            }

            Instantiate(prefab, points[i].position, Quaternion.identity);
        }
    }
}
