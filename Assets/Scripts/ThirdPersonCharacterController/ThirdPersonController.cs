using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    CharacterController characterController;
    int speed = 0;
    [SerializeField] int walkingSpeed = 3;
    [SerializeField] int runningSpeed = 5;
    float gravity = -9.81f;
    [SerializeField] float pushPower = 5f;
    //Animation
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
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

        Animation(direction);

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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody hitRigibody = hit.collider.attachedRigidbody;
        if(hitRigibody == null || hitRigibody.isKinematic)
        {
            return;
        }
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        hitRigibody.velocity = pushDirection * pushPower;
    }

    void Animation(Vector3 direction) {
        if (direction.magnitude != 0)
        {
            //character is walking
            speed = walkingSpeed;
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && direction.magnitude != 0)
        {
            speed = runningSpeed;
            animator.SetBool("IsRunning", true);
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = walkingSpeed;
            animator.SetBool("IsRunning", false);
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
