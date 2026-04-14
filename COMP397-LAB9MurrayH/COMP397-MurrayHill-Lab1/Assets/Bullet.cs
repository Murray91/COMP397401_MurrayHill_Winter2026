using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 3f;
    public AudioClip impactSound;
    public NPCDetector playerDetector;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet hit: " + other.name);

        if (impactSound != null)
            AudioSource.PlayClipAtPoint(impactSound, transform.position);

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit: " + other.name);

            if (playerDetector != null)
                playerDetector.RemoveNPC(other.gameObject);
            else
                Debug.LogWarning("PlayerDetector not assigned!");

            Destroy(other.gameObject);  // destroys the NPC
        }

        Destroy(gameObject);  // destroys the bullet
    }
}
