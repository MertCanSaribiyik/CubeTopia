using UnityEngine;

public class TopDownShooterEnemy : MonoBehaviour, IInteraction
{
    private GameObject player;
    [SerializeField] private PlayerInfo playerInfo;
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
        if (collision.gameObject.CompareTag("Bullet")) {
            health--;
            healtTxt.text = health.ToString();

            Destroy(collision.gameObject);

            if (health <= 0) {
                CreateExplosionParticle(GetComponentInChildren<SpriteRenderer>().color, transform.position);
                CreateExplosionEffect(transform.position);

                playerInfo.score += score;

                Destroy(gameObject);
            }
        }
    }

    public void Interact() {
        playerInfo.healh -= damage;

        CreateExplosionEffect(transform.position);
        Camera.main.GetComponent<Animator>().SetTrigger("shake1");
        
        Destroy(gameObject);

        if(playerInfo.healh <= 0f) {

            if (playerInfo.score > PlayerPrefs.GetInt("topDownShooterHighscore", 0)) {
                PlayerPrefs.SetInt("topDownShooterHighscore", playerInfo.score);
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
