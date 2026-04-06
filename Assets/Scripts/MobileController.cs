using UnityEngine;

public class MobileController : MonoBehaviour
{
    [Header("References")]
    public InputReader inputReader;

    // --- Movement buttons ---
    public PlayerController playerController; // optional if using D-Pad

    public void OnMoveUp(bool pressed) => SetMove(Vector2.up, pressed);
    public void OnMoveDown(bool pressed) => SetMove(Vector2.down, pressed);
    public void OnMoveLeft(bool pressed) => SetMove(Vector2.left, pressed);
    public void OnMoveRight(bool pressed) => SetMove(Vector2.right, pressed);

    private void SetMove(Vector2 dir, bool pressed)
    {
        if (playerController == null) return;

        if (pressed)
            playerController.SetMoveInput(dir);
        else
            playerController.SetMoveInput(Vector2.zero);
    }

    // --- Button Events ---

    public void OnJumpButton()
    {
        Debug.Log("MobileController: Jump button clicked");
        inputReader?.PressJumpButton();
    }

    public void OnFireButton()
    {
        Debug.Log("MobileController: Fire button clicked");
        inputReader?.PressFireButton();
    }

    public void OnSaveButton()
    {
        SaveManager.instance?.SaveGame();
    }
}