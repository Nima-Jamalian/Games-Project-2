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
    [SerializeField] bool isPlayerMoving = false;
    [SerializeField] bool isPlayerRunning = false;
    [SerializeField] private Weapon weapon;
    [SerializeField] private string UserName;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        UserName = UserData.name;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement();
        FootstepSoundEffect();
        MouseMovement();
        CursorEnableCheck();
        Shooting();
        Realoding();
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

        if(horizontalInput > 0 || verticalInput > 0)
        {
            isPlayerMoving = true;
        } else
        {
            isPlayerMoving = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5f;
            isPlayerRunning = true;
        }
        else
        {
            speed = 2;
            isPlayerRunning = false;
        }
    }

    float playRate = 0.5f;
    float time = 0f;
    void FootstepSoundEffect()
    {
        if(isPlayerMoving == true)
        {
            if(isPlayerRunning == true)
            {
                playRate = 0.4f;
            } else
            {
                playRate = 0.6f;
            }
            if(Time.time >= time)
            {
                time = Time.time + playRate;
                audioSource.Play();
            }
   
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

    private void Shooting()
    {
        if (Input.GetMouseButton(0))
        {
            weapon.Shooting();
        }
    }

    private void CursorEnableCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Realoding()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(weapon.Realod());
        }
    }
}
