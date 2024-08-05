using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform barrel;
    [SerializeField] private GameObject bulletPrefab;

    public void ShootButton() {
        GameObject bullet = Instantiate(bulletPrefab, barrel.position, Quaternion.identity);
    }
}
