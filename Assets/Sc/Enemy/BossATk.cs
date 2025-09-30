using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossATk : MonoBehaviour
{
    [SerializeField]
    private Transform[] _muzzle;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _atkTIme;
    float _atkCount;
    System.Random _random;
    private void Update()
    {
        _atkCount += Time.deltaTime;
        if (_atkCount >= _atkTIme)
        {
            _random = new System.Random();
             var muzzle = _random.Next(0,_muzzle.Length);
            Instantiate(_bullet, _muzzle[muzzle].position, Quaternion.Euler(0f, 180f, 0f));
            _atkCount = 0;
        }

    }
}
