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

    [Header("Camera Settings")]
    [SerializeField]
    private float _cameraSensitivity = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
