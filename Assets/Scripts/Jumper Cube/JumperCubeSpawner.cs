using UnityEngine;

public class JumperCubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float minX = -5f, maxX = 5f;
    [SerializeField] private float minIntervalY = 3f, maxIntervalY = 3.3f;
    [SerializeField] private float minWidth = 4, maxWidth = 5;

    [SerializeField] private GameObject[] groundPrefabs;
    [SerializeField] private int extraBouncyGroundRatio = 10 ,groundCount = 10;

    [SerializeField] private Transform firstGround;
    private float middleGroundYPos;
    private float yPoint;

    private void Awake() {
        yPoint = firstGround.position.y + maxIntervalY + .5f;
        CreatingGrounds();
    }

    private void Update() {
        if(player.position.y > middleGroundYPos) {
            CreatingGrounds();
        }
    }

    private void CreatingGrounds() {
        for (int i = 0; i < groundCount; i++) {
            float xPoint = Random.Range(minX, maxX);
            float width = Random.Range(minWidth, maxWidth);

            GameObject obj = Instantiate(GroundType(), new Vector2(xPoint, yPoint), Quaternion.identity);
            obj.transform.localScale = new Vector2(width, obj.transform.localScale.y);

            yPoint += Random.Range(minIntervalY, maxIntervalY);

            if(i == groundCount / 2) {
                middleGroundYPos = obj.transform.position.y;
            }
        }
    }

    private GameObject GroundType() {
        int rate = Random.Range(0, 100);

        if(rate < extraBouncyGroundRatio) {
            return groundPrefabs[1];
        }

        else {
            return groundPrefabs[0];
        }
    }


}
