using Cysharp.Threading.Tasks;
using UnityEngine;

public class EndlessRunnerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform firstPoint, lastPoint;
    [SerializeField] private float firstPointRange = .5f;

    private float spawnTime;
    [SerializeField] private float startSpawnTime = 1.5f;
    [SerializeField] private float minCoinDelay = .4f, maxCoinDelay = .8f;

    private void Awake() {
        spawnTime = 0f;
    }

    private void Update() {
        if(spawnTime <= 0f) {

            CreateEnemy();
            spawnTime = startSpawnTime;
        }

        else {
            spawnTime -= Time.deltaTime;
        }
    }

    private void CreateEnemy() {
        int randIndex = Random.Range(0, enemyPrefabs.Length);
        Vector2 randEnemyPos;
        float yPos;

        if (randIndex == 0) {
            yPos = Random.Range(lastPoint.position.y, firstPoint.position.y);
            randEnemyPos = new Vector2(transform.position.x, yPos);
        }

        else {
            yPos = Random.Range(lastPoint.position.y, firstPoint.position.y + firstPointRange);
            randEnemyPos = new Vector2(transform.position.x, yPos);
        }

        Instantiate(enemyPrefabs[randIndex], randEnemyPos, Quaternion.identity);
        CreateCoin().Forget();
    }

    private async UniTaskVoid CreateCoin() {
        int coin = Random.Range(0, 2);

        if (coin == 1) {
            float coinDelay = Random.Range(minCoinDelay, maxCoinDelay);
            await UniTask.Delay((int)(coinDelay * 1000));
            float yPos = Random.Range(lastPoint.position.y, firstPoint.position.y + firstPointRange * 2);
            Vector2 randCoinPos = new Vector2(transform.position.x, yPos);
            Instantiate(coinPrefab, randCoinPos, Quaternion.identity);
        }
    }
}
