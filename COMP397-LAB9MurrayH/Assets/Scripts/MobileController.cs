using UnityEngine;

public class MobileController : MonoBehaviour
{
    [Header("References")]
    public InputReader inputReader;
    public PlayerController playerController;

    private Vector2 currentMove;

    // --- Movement buttons ---
    public void OnMoveUp(bool pressed) => SetMove(Vector2.up, pressed);
    public void OnMoveDown(bool pressed) => SetMove(Vector2.down, pressed);
    public void OnMoveLeft(bool pressed) => SetMove(Vector2.left, pressed);
    public void OnMoveRight(bool pressed) => SetMove(Vector2.right, pressed);

    private void SetMove(Vector2 dir, bool pressed)
    {
        if (playerController == null) return;

        if (pressed)
            currentMove += dir;
        else
            currentMove -= dir;

        currentMove = Vector2.ClampMagnitude(currentMove, 1f);
        playerController.SetMoveInput(currentMove);
    }

    // --- Buttons ---
    public void OnJumpButton()
    {
        inputReader?.PressJumpButton();
    }

    public void OnFireButton()
    {
        inputReader?.PressFireButton();
    }

    public void OnSaveButton()
    {
        SaveManager.instance?.SaveGame();
    }
}