using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private CharacterController controller;
    private InputReader input;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<InputReader>();
    }

    private void Update()
    {
        Vector2 move = input.MoveInput;
        Vector3 direction = new Vector3(move.x, 0f, move.y);

        controller.Move(direction * moveSpeed * Time.deltaTime);
    }
}

