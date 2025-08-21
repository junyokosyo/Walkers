using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Playermove : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float _moveSpead;

    float _inputX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * _moveSpead;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.right *- _moveSpead;
        }
        
    }
}
