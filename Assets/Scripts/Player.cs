using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float mouseSensivity = 1f;
    private float gravity = 9.81f;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement();
        MouseMovement();
        CursorEnableCheck();
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(rayOrigin, out RaycastHit hitInfo))
            {
                Debug.Log(hitInfo.transform.name);
                hitInfo.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }

    private void CharacterMovement()
    {
        //Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Direction
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * speed;
        //Gravity;
        velocity.y -= gravity;
        velocity = transform.TransformDirection(velocity);
        //Move
        characterController.Move(velocity * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5f;
        }
        else
        {
            speed = 2;
        }
    }

    private void MouseMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotationX = transform.localEulerAngles;
        newRotationX.y += mouseX * mouseSensivity;
        transform.localEulerAngles = newRotationX;

        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotationY = camera.transform.localEulerAngles;
        newRotationY.x -= mouseY * mouseSensivity;
        camera.transform.localEulerAngles = newRotationY;
    }

    private void CursorEnableCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
