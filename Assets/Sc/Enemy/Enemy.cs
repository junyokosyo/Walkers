using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
        private int _hp;
    [SerializeField]
        private float _atkTIme;
    float _count;
    EnemyBullet _bullet;
    // Start is called before the first frame update
    void Start()
    {
        _bullet = GetComponent<EnemyBullet>();
    }

    // Update is called once per frame
    void Update()
    {
        _count += Time.deltaTime;
        if (_count > _atkTIme)
        {
            _count = 0;
            _bullet.BulletInstantiate();  
        }
    }

    public void TekaDamage(int damage)
    {
        Debug.Log(damage);
        _hp -= damage;
        if (_hp <= 0)
        {
            Debug.Log(_hp);
            //‚±‚±‚ÉŽ€‚Êˆ—
        }
    }
}
