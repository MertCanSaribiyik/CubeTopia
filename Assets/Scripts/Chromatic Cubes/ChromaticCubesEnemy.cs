using UnityEngine;

public class ChromaticCubesEnemy : MonoBehaviour, IInteraction
{
    private GameObject player;

    [SerializeField] private GameObject explosionParticlePrefab, explosionEffectPrefab;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
    }

    public void Interact() {
        if(GetComponent<SpriteRenderer>().color == player.GetComponent<SpriteRenderer>().color) {
            CreateExplosionParticle(GetComponent<SpriteRenderer>().color, transform.position);
            CreateExplosionEffect(transform.position);

            Camera.main.GetComponent<Animator>().SetTrigger("shake1");

            AudioManager.Instance.PlayOneShot("explosion");
            Destroy(gameObject);
            GameManager.Instance.playerInfo.score++;
        }

        else {
            CreateExplosionEffect(player.transform.position);

            if(GameManager.Instance.playerInfo.score > PlayerPrefs.GetInt("chromaticCubesHighscore", 0)) {
                PlayerPrefs.SetInt("chromaticCubesHighscore", GameManager.Instance.playerInfo.score);
            }

            AudioManager.Instance.PlayOneShot("playerExplosion");
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
