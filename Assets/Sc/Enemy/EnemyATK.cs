using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyATK : MonoBehaviour
{
    [SerializeField]
        private Transform _muzzle;
    [SerializeField]
        private GameObject _bullet;

    public void BulletInstantiate()
    {
      
        Instantiate(_bullet,_muzzle.gameObject.transform.position,Quaternion.identity);
    }
}
