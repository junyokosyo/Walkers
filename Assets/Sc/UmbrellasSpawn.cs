using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellasSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
        private GameObject _unbrellas;

    [SerializeField]
        private GameObject _spanpoint;

    [SerializeField] 
        private float _atkCount;

    float _atkTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _atkTime += Time.deltaTime;
        if (_atkTime > _atkCount)
        {
            Instantiate(_unbrellas, _spanpoint.transform.position, Quaternion.Euler(new Vector3(89, 0, 0)));
            _atkTime = 0;
        }
    }
}
