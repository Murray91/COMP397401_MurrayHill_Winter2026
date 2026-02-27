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
        if (impactSound != null)
            AudioSource.PlayClipAtPoint(impactSound, transform.position);

        if (other.CompareTag("Enemy"))
        {
            if (playerDetector != null)
                playerDetector.RemoveNPC(other.gameObject);

            Destroy(other.gameObject);  // destroys the NPC
            Debug.Log("NPC destroyed: " + other.name);
        }

        Destroy(gameObject);  // destroys the bullet
    }
}
