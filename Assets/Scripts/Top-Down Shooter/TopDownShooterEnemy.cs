using UnityEngine;

public class TopDownShooterEnemy : MonoBehaviour, IInteraction
{
    private GameObject player;
    [SerializeField] private int score = 1, health = 1;
    [SerializeField] private float damage = 5;

    private TMPro.TextMeshPro healtTxt;
    [SerializeField] private GameObject explosionParticlePrefab, explosionEffectPrefab;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
        healtTxt = GetComponentInChildren<TMPro.TextMeshPro>();

        healtTxt.text = health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Destroy Enemy : 
        if (collision.gameObject.CompareTag("Bullet") && GameManager.Instance.playerInfo.health > 0) {
            health--;
            healtTxt.text = health.ToString();

            Destroy(collision.gameObject);

            if (health <= 0) {
                CreateExplosionParticle(GetComponentInChildren<SpriteRenderer>().color, transform.position);
                CreateExplosionEffect(transform.position);

                GameManager.Instance.playerInfo.score += score;

                AudioManager.Instance.PlayOneShot("explosion");
                Destroy(gameObject);
            }
        }
    }

    public void Interact() {
        GameManager.Instance.playerInfo.health -= damage;

        CreateExplosionEffect(transform.position);
        Camera.main.GetComponent<Animator>().SetTrigger("shake1");

        AudioManager.Instance.PlayOneShot("playerExplosion");
        Destroy(gameObject);

        if(GameManager.Instance.playerInfo.health <= 0f) {

            if (GameManager.Instance.playerInfo.score > PlayerPrefs.GetInt("topDownShooterHighscore", 0)) {
                PlayerPrefs.SetInt("topDownShooterHighscore", GameManager.Instance.playerInfo.score);
            }

            CreateExplosionParticle(Color.white, player.transform.position);
            player.SetActive(false);

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
