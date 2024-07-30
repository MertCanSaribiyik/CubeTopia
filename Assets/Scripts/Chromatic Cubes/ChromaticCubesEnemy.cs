using UnityEngine;

public class ChromaticCubesEnemy : MonoBehaviour, IInteraction
{
    private GameObject player;
    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private GameObject explosionParticlePrefab, explosionEffectPrefab;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
    }

    public void Interact() {
        if(GetComponent<SpriteRenderer>().color == player.GetComponent<SpriteRenderer>().color) {
            CreateExplosionParticle(GetComponent<SpriteRenderer>().color, transform.position);
            CreateExplosionEffect(transform.position);

            Camera.main.GetComponent<Animator>().SetTrigger("shake1");

            Destroy(gameObject);
            playerInfo.score++;
        }

        else {
            CreateExplosionEffect(player.transform.position);

            if(playerInfo.score > PlayerPrefs.GetInt("ChromaticCubesHighscore", 0)) {
                PlayerPrefs.SetInt("ChromaticCubesHighscore", playerInfo.score);
            }

            Destroy(player);
            GameManager.Instance.RestartGame();
        }
    }

    private void CreateExplosionParticle(Color color, Vector2 pos) {
        GameObject particle = Instantiate(explosionParticlePrefab, pos, Quaternion.identity);

        var mainModule = particle.GetComponent<ParticleSystem>().main;
        mainModule.startColor = color;

        Destroy(particle, 2f);
    }

    private void CreateExplosionEffect(Vector2 pos) {
        Instantiate(explosionEffectPrefab, pos, Quaternion.identity);
    }

}
