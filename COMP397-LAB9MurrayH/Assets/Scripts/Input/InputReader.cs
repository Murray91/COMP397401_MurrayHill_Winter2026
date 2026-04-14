using UnityEngine;

public class InputReader : MonoBehaviour
{
    [Header("Player References")]
    public PlayerController playerController;
    public PlayerShoot playerShoot;

    // --- Jump Button ---
    public void PressJumpButton()
    {
        if (playerController != null)
        {
            Debug.Log("Jump button pressed!");
            playerController.Jump(); // Make sure Jump() exists in PlayerController
        }
        else
        {
            Debug.LogWarning("PlayerController not assigned in InputReader!");
        }
    }

    // --- Fire Button ---
    public void PressFireButton()
    {
        if (playerShoot != null)
        {
            Debug.Log("Fire button pressed!");
            playerShoot.Shoot(); // Make sure Shoot() is public
        }
        else
        {
            Debug.LogWarning("PlayerShoot not assigned in InputReader!");
        }
    }
}