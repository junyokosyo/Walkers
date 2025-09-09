using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
        private GameObject _bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BulletInstantiate()
    {
        Debug.Log(this);
        Instantiate(_bullet,this.gameObject.transform.position,Quaternion.identity);
    }
}
