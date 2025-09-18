using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;        // ���̈ړ����x
    [SerializeField] private float groundLength = 10f; // ��1���̒���
    [SerializeField] private Transform player;        // �v���C���[��Transform

    void Update()
    {
        // �����v���C���[�����Ɉړ�
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // �v���C���[����O�܂ŗ�����
        if (transform.position.z < player.position.z - 5f) // -5f�͏����]�T����������
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        // �����^�O�̏������ׂĎ擾
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");

        // ��Ԍ���Z���W��T��
        float maxZ = float.MinValue;
        foreach (GameObject g in grounds)
        {
            if (g.transform.position.z > maxZ)
            {
                maxZ = g.transform.position.z;
            }
        }

        // �������Ō���̌��Ɉړ�
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            maxZ + groundLength
        );
    }
}
