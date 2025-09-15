using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] 
        private float _speed;
    [SerializeField]
    public int _enemyAtk;

    private Vector3 moveDirection = new Vector3(0, 0, -1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * _speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHP player = other.GetComponent<PlayerHP>();
            if (player != null) player.TekaDamage(_enemyAtk);
            Destroy(gameObject);
        }
        if (other.CompareTag("Destroy")) Destroy(gameObject);
    }
}
