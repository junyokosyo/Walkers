using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlyingUmbrella : MonoBehaviour
{
    [SerializeField] int _atk;
  
    [SerializeField] float _speed;

    private Vector3 moveDirection= new Vector3(0,0,1);
    private Enemy enemy;

   
    void Start()
    {
      enemy = GetComponent<Enemy>();
    }

    
    void Update()
    {
        transform.Translate(moveDirection * _speed * Time.deltaTime, Space.World);//ˆÚ“®‚ğ‚·‚éˆ—
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("enemy")) enemy.TekeDamage(_atk); 
    }
}
