using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int _health;

    public void TekaDamage(int damage)
    {
        _health -= damage;
        Debug.Log(damage);

        if (_health <= 0)
        {
            Debug.Log(_health);
            //‚±‚±‚ÉŽ€‚Êˆ—
        }
    }
}
