using UnityEngine;

public class EndlessRunnerEnemy : MonoBehaviour, IInteraction
{
    private GameObject player;
    [SerializeField] private GameObject explosionParticlePrefab, explosionEffectPrefab;

    [SerializeField] private PlayerInfo playerInfo;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
    }

    public void Interact() {
        Instantiate(explosionParticlePrefab, player.transform.position, Quaternion.identity);
        Instantiate(explosionEffectPrefab, player.transform.position, Quaternion.identity);
        Camera.main.GetComponent<Animator>().SetTrigger("shake1");

        if(playerInfo.score > PlayerPrefs.GetInt("endlessRunnerHighscore", 0)) {
            PlayerPrefs.SetInt("endlessRunnerHighscore", playerInfo.score);
        }

        GameManager.Instance.RestartGame();
        player.SetActive(false);
    }
}
