using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;        // 床の移動速度
    [SerializeField] private float groundLength = 10f; // 床1枚の長さ
    [SerializeField] private Transform player;        // プレイヤーのTransform

    void Update()
    {
        // 床をプレイヤー方向に移動
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // プレイヤーより手前まで来たら
        if (transform.position.z < player.position.z - 5f) // -5fは少し余裕を持たせる
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        // 同じタグの床をすべて取得
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");

        // 一番後ろのZ座標を探す
        float maxZ = float.MinValue;
        foreach (GameObject g in grounds)
        {
            if (g.transform.position.z > maxZ)
            {
                maxZ = g.transform.position.z;
            }
        }

        // 自分を最後尾の後ろに移動
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            maxZ + groundLength
        );
    }
}
