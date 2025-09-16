using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] 
        private int _hp;
    [SerializeField]
        private float _atkTIme;
    [SerializeField]
        private GameObject _dieEffect;
    [SerializeField]
        private GameObject _damageEffectTarget;

    float _count;
    EnemyATK _bullet;
  Rigidbody BulletBody;
    CapsuleCollider CapsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        _bullet = GetComponent<EnemyATK>();
        BulletBody = GetComponent<Rigidbody>();
        CapsuleCollider = GetComponent<CapsuleCollider>();
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
        Instantiate(_damageEffectTarget,this.gameObject.transform.position, Quaternion.identity);
        _hp -= damage;
        if (_hp <= 0)
        {
            Instantiate(_dieEffect,this.gameObject.transform.position,Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
