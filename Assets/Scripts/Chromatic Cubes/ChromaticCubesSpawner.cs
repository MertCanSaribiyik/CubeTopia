using UnityEngine;

public class ChromaticCubesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;

    private float spawnTime;
    [SerializeField] private float startingSpawnTime = 1f;

    private int previousIndex;

    private void Awake() {
        previousIndex = -1;
    }

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
        int randIndex;

        //So that we don't get the same enemy in a row :
        while (true) {
            randIndex = Random.Range(0, enemyPrefabs.Length);
            if (randIndex != previousIndex) {
                Instantiate(enemyPrefabs[randIndex], transform.position, Quaternion.identity);
                break;
            }
        }

        previousIndex = randIndex;
    }
}
