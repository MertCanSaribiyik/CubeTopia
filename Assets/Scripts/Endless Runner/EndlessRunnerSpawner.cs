using Cysharp.Threading.Tasks;
using UnityEngine;

public class EndlessRunnerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject coinPrefab;

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
        Vector2 randEnemyPos = RandomPosition(enemyPrefabs[randIndex]);

        Instantiate(enemyPrefabs[randIndex], randEnemyPos, Quaternion.identity);
        CreateCoin().Forget();
    }

    private async UniTaskVoid CreateCoin() {
        int coin = Random.Range(0, 2);

        if (coin == 1) {
            float coinDelay = Random.Range(minCoinDelay, maxCoinDelay);
            await UniTask.Delay((int)(coinDelay * 1000));
            Vector2 randCoinPos = RandomPosition(coinPrefab);
            Instantiate(coinPrefab, randCoinPos, Quaternion.identity);
        }
    }

    private Vector2 RandomPosition(GameObject obj) {
        float topPointsY = transform.position.y + obj.GetComponent<PointsPrefabsOccur>().topPoint.y;
        float botttomPointsY = transform.position.y + obj.GetComponent<PointsPrefabsOccur>().bottomPoint.y;
        return new Vector2(transform.position.x, Random.Range(botttomPointsY, topPointsY));
    }
}
