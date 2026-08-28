using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    private ShipInput controls;
    public float mouseSensitivity = 100f; // Allows us to change the sensitivity
    private Vector2 mouseLook; // Holds where we are looking
    private float xRotation = 0f; // This is us rotating around the x axis
    public Transform playerBody;

    void Awake()
    {
        controls = new ShipInput();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        mouseLook = controls.Player.Look.ReadValue<Vector2>();
        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
        playerBody.Rotate(Vector3.up * mouseX);
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
