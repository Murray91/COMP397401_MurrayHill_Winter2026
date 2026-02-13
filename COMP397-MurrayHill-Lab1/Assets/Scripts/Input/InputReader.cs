using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public PlayerController playerController;
    public CameraManager cameraManager;

    private PlayerInputActions inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();

        // Movement
        inputActions.Player.Move.performed += ctx =>
            playerController.SetMoveInput(ctx.ReadValue<Vector2>());

        inputActions.Player.Move.canceled += ctx =>
            playerController.SetMoveInput(Vector2.zero);

        // Look (store input only — CameraManager rotates in Update)
        inputActions.Player.Look.performed += ctx =>
            cameraManager.SetLookInput(ctx.ReadValue<Vector2>());

        inputActions.Player.Look.canceled += ctx =>
            cameraManager.SetLookInput(Vector2.zero);
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
    }
}
