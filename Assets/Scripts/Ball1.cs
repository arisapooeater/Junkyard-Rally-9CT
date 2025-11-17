using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody _rb;
    [SerializeField]
    private Vector3 _startingPosition;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if(_rb == null){
            Debug.Log("Rigidbody is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForOutOfBounds();
    }

    void CheckForOutOfBounds(){
        if(transform.position.y < -20){
            _rb.linearVelocity = Vector3.zero;
            transform_position = _startingPosition;
        }
    }
}

