using UnityEngine;
using System.Collections.Generic;

public class NPCDetector : MonoBehaviour
{
    [Header("Detection Settings")]
    public float detectionRadius = 5f;
    public LayerMask npcLayer;
    public AudioClip detectionSound;   // sound to play when NPC detected
    public float soundCooldown = 1f;  // prevent spamming sound

    private float lastSoundTime = 0f;
    public List<GameObject> detectedNPCs = new List<GameObject>();

    void Update()
    {
        DetectNPCs();
        PlayDetectionSound();
    }

    void DetectNPCs()
    {
        Collider[] npcsInRange = Physics.OverlapSphere(transform.position, detectionRadius, npcLayer);

        detectedNPCs.Clear();
        foreach (Collider npc in npcsInRange)
        {
            detectedNPCs.Add(npc.gameObject);
        }
    }

    void PlayDetectionSound()
    {
        if (detectedNPCs.Count > 0 && Time.time - lastSoundTime > soundCooldown)
        {
            if (detectionSound != null)
                AudioSource.PlayClipAtPoint(detectionSound, transform.position);

            lastSoundTime = Time.time;
        }
    }

    public void RemoveNPC(GameObject npc)
    {
        if (detectedNPCs.Contains(npc))
        {
            detectedNPCs.Remove(npc);
            Debug.Log("NPC removed from detector: " + npc.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}