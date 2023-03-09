using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] int speed = 3;
    float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement();
    }

    public void CharacterMovement()
    {
        //inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Direction
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        //Camera Rotaion
        direction = Quaternion.AngleAxis(Camera.main.transform.rotation.eulerAngles.y, Vector3.up) * direction;

        Vector3 velocity = direction * speed;

        //gravity
        velocity.y += gravity;

        //Move
        characterController.Move(velocity * Time.deltaTime);

        //Rotation
        if (direction != Vector3.zero)
        {
            //transform.forward = direction;
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 700f * Time.deltaTime);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
