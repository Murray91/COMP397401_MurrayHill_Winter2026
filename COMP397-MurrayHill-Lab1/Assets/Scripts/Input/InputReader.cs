using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public PlayerController playerController;
    public CameraManager cameraManager;
    public PlayerShoot playerShoot;

    private PlayerInputActions inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        if (playerController == null) Debug.LogError("InputReader: playerController not assigned!");
        if (cameraManager == null) Debug.LogError("InputReader: cameraManager not assigned!");
        if (playerShoot == null) Debug.LogError("InputReader: playerShoot not assigned!");

        inputActions.Player.Enable();

        if (playerController != null)
        {
            inputActions.Player.Move.performed += ctx => playerController.SetMoveInput(ctx.ReadValue<Vector2>());
            inputActions.Player.Move.canceled += ctx => playerController.SetMoveInput(Vector2.zero);
        }

        if (cameraManager != null)
        {
            inputActions.Player.Look.performed += ctx => cameraManager.SetLookInput(ctx.ReadValue<Vector2>());
            inputActions.Player.Look.canceled += ctx => cameraManager.SetLookInput(Vector2.zero);
        }

        if (playerShoot != null)
        {
            inputActions.Player.Shoot.performed += ctx => playerShoot.Shoot();
        }
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
    }
}

