using UnityEngine;

public class EndlessRunnerEnemy : MonoBehaviour, IInteraction
{
    private GameObject player;
    [SerializeField] private GameObject explosionParticlePrefab, explosionEffectPrefab;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
    }

    public void Interact() {
        Instantiate(explosionParticlePrefab, player.transform.position, Quaternion.identity);
        Instantiate(explosionEffectPrefab, player.transform.position, Quaternion.identity);
        Camera.main.GetComponent<Animator>().SetTrigger("shake1");

        if(GameManager.Instance.playerInfo.score > PlayerPrefs.GetInt("endlessRunnerHighscore", 0)) {
            PlayerPrefs.SetInt("endlessRunnerHighscore", GameManager.Instance.playerInfo.score);
        }

        AudioManager.Instance.PlayOneShot("playerExplosion");
        player.SetActive(false);
        GameManager.Instance.RestartGame();
    }
}
