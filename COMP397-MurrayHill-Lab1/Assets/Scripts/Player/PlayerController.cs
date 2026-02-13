using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private CharacterController controller;
    private Vector2 moveInput;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Convert input into movement direction
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);

        // Convert to local space so movement follows player rotation
        move = transform.TransformDirection(move);

        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    public void SetMoveInput(Vector2 input)
    {
        moveInput = input;
    }
}
