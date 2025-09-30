using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UmbrellasSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _unbrellas;
    [SerializeField] private GameObject _spanpoint;
    [SerializeField] private float _atkCount = 2f; // クールタイム（秒）
    [SerializeField] private Image _cooldownUI;   // UIのImage

    private float _atkTime;

    void Update()
    {
        _atkTime += Time.deltaTime;

        // UIの更新（0～1で進行度を表現）
        if (_cooldownUI != null)
        {
            _cooldownUI.fillAmount = _atkTime / _atkCount;
        }

        if (_atkTime >= _atkCount)
        {
            Instantiate(_unbrellas, _spanpoint.transform.position, Quaternion.Euler(new Vector3(89, 0, 0)));
            _atkTime = 0;
        }
    }
}
