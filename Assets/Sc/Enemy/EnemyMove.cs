using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    private Vector3 moveDirection = new Vector3(0, 0, -1);

    void Update()
    {
        transform.Translate(moveDirection * _speed * Time.deltaTime, Space.World);
    }
}
