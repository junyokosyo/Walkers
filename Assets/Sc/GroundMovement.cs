using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] float _spead;
    private Vector3 moveDirection = new Vector3(0,0,-1);
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
    transform.Translate(moveDirection*_spead*Time.deltaTime);
    }
}
