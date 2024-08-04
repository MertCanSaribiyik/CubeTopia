using Cysharp.Threading.Tasks;
using UnityEngine;

public class EndlessRunnerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform firstPoint, lastPoint;

    private float spawnTime;
    [SerializeField] private float startSpawnTime = 1.5f;
    [SerializeField] private float minCoinDelay = .4f, maxCoinDelay = .8f;

    private void Awake() {
        spawnTime = 0f;
    }

    private void Update() {
        if(spawnTime <= 0f) {
            int randIndex = Random.Range(0, enemyPrefabs.Length);
            Create(enemyPrefabs[randIndex]).Forget();
            spawnTime = startSpawnTime;
        }

        else {
            spawnTime -= Time.deltaTime;
        }
    }

    private async UniTaskVoid Create(GameObject enemyPrefab) {
        Vector2 randEnemyPos = new Vector2(transform.position.x, Random.Range(lastPoint.position.y, firstPoint.position.y));
        Instantiate(enemyPrefab, randEnemyPos, Quaternion.identity);

        int coin = Random.Range(0, 2);

        if(coin == 1) {
            float coinDelay = Random.Range(minCoinDelay, maxCoinDelay);
            await UniTask.Delay((int)(coinDelay * 1000));

            Vector2 randCoinPos = new Vector2(transform.position.x, Random.Range(lastPoint.position.y, firstPoint.position.y + 1f));
            Instantiate(coinPrefab, randCoinPos, Quaternion.identity);
        }

    }
}
