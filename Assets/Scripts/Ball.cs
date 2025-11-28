using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private Vector3 _startingPosition;

    private float _speed = 10.0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
        {
            Debug.Log("Rigidbody is NULL");
        }
    }

    void Update()
    {
        CheckForOutOfBounds();
    }

    void CheckForOutOfBounds()
    {
        if (transform.position.y < -20)
        {
            _rb.linearVelocity = Vector3.zero;
            transform.position = _startingPosition;
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player"){
            float x = Random.Range(-0.05f, 0.05f);
            Vector3 velocity = new Vector3((transform.position.x - other.transform.position.x) + x, 30, (transform.position.z - other.transform.position.z) + 25);
            _rb.AddForce(velocity * _speed, ForceMode.Force);
        }

        if(other.gameObject.tag == "Opponent"){
            float x = Random.Range(-0.05f, 0.05f);
            Vector3 velocity = new Vector3((transform.position.x - other.transform.position.x) + x, 30, (transform.position.z - other.transform.position.z) -25);
            _rb.AddForce(velocity * _speed, ForceMode.Force);
        }
    }
}
