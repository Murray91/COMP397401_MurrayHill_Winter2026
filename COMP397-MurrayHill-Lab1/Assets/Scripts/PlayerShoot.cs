using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 20f;

    // Make Shoot() public so other scripts can call it
    public void Shoot()
    {
        if (bulletPrefab == null || shootPoint == null)
        {
            Debug.LogError("PlayerShoot: bulletPrefab or shootPoint not assigned!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootPoint.forward * bulletSpeed;
            rb.WakeUp();
            rb.useGravity = false;
            rb.isKinematic = false;
        }
    }
}

