using UnityEngine;


public class FlyingUmbrella : MonoBehaviour
{
    [SerializeField]
        private int _atk;

    [SerializeField] 
        private float _speed;

    private Vector3 moveDirection = new Vector3(0, 0, 1);

    void Update()
    {
        transform.Translate(moveDirection * _speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            EnemyHp enemy = other.GetComponent<EnemyHp>();
            if (enemy != null) enemy.TekaDamage(_atk);
            Destroy(gameObject);
        }
        if (other.CompareTag("Destroy")) Destroy(gameObject);
    }
}
