using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    private ShipInput controls; // Our controls we defined
    private Vector3 velocity; // To hold our current velocity
    private Vector2 move; // To hold our move
    private CharacterController controller; // Character controller
    public float moveSpeed = 6f; // To calibrate our movement

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()

    {
        controls = new ShipInput();

        controller = GetComponent<CharacterController>();
    }



    void Update()

    {
        PlayerMovement();
        


    }


    private void PlayerMovement()

    {
        move = controls.Player.Movement.ReadValue<Vector2>();

        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    void OnEnable()

    {
        controls.Enable();
    }



    void OnDisable()

    {
        controls.Disable();
    }
}
