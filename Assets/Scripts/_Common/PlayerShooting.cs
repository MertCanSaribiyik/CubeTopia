using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShooting : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform barrel;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private TMPro.TextMeshProUGUI bulletCountTxt;
    [SerializeField] private int maxBulletCount = 30;
    private int bulletCount;
    private bool isShooting;

    private float shootTime;
    [SerializeField] float startShootTime;

    [SerializeField] private float magazineReloadTime = 1f;
    private bool isReloading;

    private void Awake() {
        isShooting = false;
        bulletCount = maxBulletCount;

        bulletCountTxt.text = bulletCount.ToString();

        isReloading = false;
    }

    public void OnPointerDown(PointerEventData eventData) {
        isShooting = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        isShooting = false;
    }

    private void Update() {
        if (isShooting && GameManager.Instance.playerInfo.health > 0) {
            Shoot();
        }

        if (!isReloading) {
            Reload().Forget();
        }
    }

    private void Shoot() {
        if (shootTime <= 0) {
            if(bulletCount > 0) {
                AudioManager.Instance.PlayOneShot("shooting");
                Instantiate(bulletPrefab, barrel.position, Quaternion.identity);
                bulletCountTxt.text = (--bulletCount).ToString();
            }

            else {
                AudioManager.Instance.PlayOneShot("emptyShooting");
            }

            shootTime = startShootTime;
        }

        else {
            shootTime -= Time.deltaTime;
        }

    }

    private async UniTaskVoid Reload() {
        if (bulletCount <= 0) {
            isReloading = true;

            await UniTask.Delay((int)(magazineReloadTime * 1000f));
            bulletCount = maxBulletCount;
            AudioManager.Instance.PlayOneShot("reload");
            bulletCountTxt.text = bulletCount.ToString();

            isReloading = false;
        }
    }
}
