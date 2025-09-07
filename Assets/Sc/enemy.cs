using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] int _atk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TekeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            //‚±‚±‚ÉŽ€‚Êˆ—
        }
    }
}
