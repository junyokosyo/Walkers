using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    private Vector3 moveDirection = new Vector3(0, 0, -1);

    void Update()
    {
        // ���[���h���W�ňړ�
        transform.Translate(moveDirection * _speed * Time.deltaTime, Space.World);
    }
}
