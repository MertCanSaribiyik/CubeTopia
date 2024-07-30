using UnityEngine;

public class ChromaticCubesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;

    private float spawnTime;
    [SerializeField] private float startingSpawnTime = 1f;


    private void Update() {
        if (!GameManager.Instance.GameIsPaused) {
            if (spawnTime <= 0f) {
                Create();
                spawnTime = startingSpawnTime;
            }

            else {
                spawnTime -= Time.deltaTime;
            }
        }
    }

    public void Create() {
        int randIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randIndex], transform.position, Quaternion.identity);
    }
}
