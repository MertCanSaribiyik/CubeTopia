using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShooting : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform barrel;
    [SerializeField] private GameObject bulletPrefab;

    private bool isShooting;

    private float spawnTime;
    [SerializeField] float startSpawnTime;

    private void Awake() {
        isShooting = false;
    }

    public void OnPointerDown(PointerEventData eventData) {
        isShooting = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        isShooting = false;
    }

    private void Update() {
        if (isShooting && GameManager.Instance.playerInfo.health > 0) {
            if(spawnTime <= 0) {
                AudioManager.Instance.PlayOneShot("shooting");
                GameObject bullet = Instantiate(bulletPrefab, barrel.position, Quaternion.identity);
                spawnTime = startSpawnTime;
            }

            else {
                spawnTime -= Time.deltaTime;
            }
        }
    }
}
