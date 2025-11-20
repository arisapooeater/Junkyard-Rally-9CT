using UnityEngine;

public class Player : MonoBehaviour
{   
    private CharacterController _controller;
    private Camera _mainCam;

    [Header("Character Settings")]
    [SerializeField]
    private float _speed = 7.5f;
    [SerializeField]
    private float _gravity = 15.0f;
    [SerializeField]
    private float _jump = 5.0f;
    [SerializeField]
    private Vector3 _startingPosition;
    private Vector3 dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        Move();
        CheckForOutOfBounds();
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

            dir = new Vector3(verticalInput, 0, -horizontalInput);
            dir = transform.TransformDirection(dir);  

            if (Input.GetKeyDown(KeyCode.Space))
            {
                dir.y = _jump;
            }
        }

        dir.y -= _gravity * Time.deltaTime;
        _controller.Move(dir * _speed * Time.deltaTime);
    }
}
