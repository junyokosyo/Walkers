using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroyer : MonoBehaviour
{
 
    [SerializeField]
    private UnityEvent _generato = null;
    private void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        _generato.Invoke();
       
    }
}
