using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
        private int _hp;

    [SerializeField] 
        private int _atk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TekaDamage(int damage)
    {
        Debug.Log(damage);
        _hp -= damage;
        if (_hp <= 0)
        {
            Debug.Log(_hp);
            //�����Ɏ��ʏ���
        }
    }
}
