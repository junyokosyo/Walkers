using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syurikenMove : MonoBehaviour
{

    Vector3 roteta = new Vector3(0, -1, 0);
    
    void Update()
    {
        transform.Rotate(roteta);
    }
}
