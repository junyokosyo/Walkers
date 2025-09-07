
using UnityEngine;


public class Playermove : MonoBehaviour
{
    [SerializeField]
    private float _moveSpead;


    Rigidbody rb;




    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMove();

    }

    // Update is called once per frame


    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * _moveSpead;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.right * -_moveSpead;
        }

    }
}
