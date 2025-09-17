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
    [SerializeField]
    private GameObject _levelmane;
    float _count;

    float _atkTImeram;
    EnemyATK _bullet;
    LevelSystem _levelSystem;
    System.Random _random;
    void Start()
    {
        _bullet = GetComponent<EnemyATK>();

        GameObject obj = GameObject.Find("EXPManager"); // ヒエラルキー上の名前
        if (obj != null)
        {
            _levelSystem = obj.GetComponent<LevelSystem>();
        }

        _random = new System.Random();
        _atkTImeram = _atkTIme;
    }


    // Update is called once per frame
    void Update()
    {
        _count += Time.deltaTime;
        
        if (_count > _atkTImeram)
        {
            _count = 0;
            _bullet.BulletInstantiate();
            _atkTImeram = _atkTIme + _random.Next(2,6);
        }
    }

    public void TekaDamage(int damage)
    {
        Instantiate(_damageEffectTarget, this.gameObject.transform.position, Quaternion.identity);
        _hp -= damage;
        if (_hp <= 0)
        {
            Instantiate(_dieEffect, this.gameObject.transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);

            _levelSystem.AddExp(1);
        }
    }
}
