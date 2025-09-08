using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroyer : MonoBehaviour
{
    private void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        other.transform.position=new Vector3(0.9134874f, -0.01606563f, 48.0954f);


    }
}
