using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private GameObject _efect;
    [SerializeField]
    private GameObject _point;

    public void TekaDamage(int damage)
    {
        _health -= damage;
        Instantiate(_efect,_point.transform.position,Quaternion.identity);
        if (_health <= 0)
        {
            Debug.Log(_health);
            //‚±‚±‚ÉŽ€‚Êˆ—
        }
    }
}
