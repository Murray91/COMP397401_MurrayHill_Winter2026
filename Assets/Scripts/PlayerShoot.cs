using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Shoot Settings")]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 20f;

    // Public so InputReader can call it
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
            rb.linearVelocity = shootPoint.forward * bulletSpeed; // use linearVelocity
            rb.WakeUp();
            rb.useGravity = false;
            rb.isKinematic = false;
        }
    }
}
