using UnityEngine;

public class Playermove : MonoBehaviour
{
    [SerializeField]
    private float _moveSpead = 5f;

    private Rigidbody rb;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ���͂� Update �Ŏ��
        moveInput = 0;
        if (Input.GetKey(KeyCode.D)) moveInput = 1;
        if (Input.GetKey(KeyCode.A)) moveInput = -1;
    }

    void FixedUpdate()
    {
        // Rigidbody ����� FixedUpdate �ōs��
        rb.velocity = new Vector3(moveInput * _moveSpead, rb.velocity.y, 0f);
    }
}
