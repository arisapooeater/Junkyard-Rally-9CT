using UnityEngine;

public class Player : MonoBehaviour
{   
    private CharacterController _controller;
    private Camera _mainCam;
    private float _rotationX; 

    [Header("Character Settings")]
    [SerializeField]
    private float _speed = 7.5f;
    [SerializeField]
    private float _gravity = 15.0f;
    [SerializeField]
    private float _jump = 5.0f;
    [SerializeField]
    private Vector3 _startingPosition;

    [Header("Camera Settings")]
    [SerializeField]
    private float _cameraSensitivity = 2;
    private Vector3 dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _controller = GetComponent<CharacterController>();
        if(_controller == null){
            Debug.Log("Controller is NULL");
        }
        _mainCam = Camera.main;
        if(_mainCam == null){
            Debug.Log("Main Camera is NULL");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.None;
        }
        Move();
        CheckForOutOfBounds();
        Look();
    }

    void CheckForOutOfBounds()
    {
        if(transform.position.y < -20){
            _controller.enabled = false;
            transform.position = _startingPosition;
            _controller.enabled = true;
        }

        if(transform.position.y > 20){
            _controller.enabled = false;
            transform.position = _startingPosition;
            _controller.enabled = true;
        }
    }
    void Move()
    {
        if (_controller.isGrounded == true)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            dir = new Vector3(horizontalInput, 0, verticalInput);
            dir = transform.TransformDirection(dir);  

            if (Input.GetKeyDown(KeyCode.Space))
            {
                dir.y = _jump;
            }
        }

        dir.y -= _gravity * Time.deltaTime;
        _controller.Move(dir * _speed * Time.deltaTime);
    }

    void Look(){
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y += mouseX * _cameraSensitivity;
        transform.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.up);

        _rotationX -= mouseY * _cameraSensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -30f, 60f);    
        _mainCam.transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
    }
}
