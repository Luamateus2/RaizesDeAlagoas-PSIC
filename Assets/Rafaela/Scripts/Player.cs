using UnityEngine;

public class Player : MonoBehaviour
{
    // controles da movimenta��o do player
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rigid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    // Movimenta��o na Horizontal
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }

    // Pulo e pulo duplo
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                // aqui ele consegue d� o 2� pulo
                rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                //para ele n�o pular infinitamente, ele para depois do 2� pulo
                if(doubleJump)
                {
                    rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); //caso queira aumentar a for�a do pulo duplo � so *2 o JumpForce
                    doubleJump = false;
                }
            }
        }
    }

    // M�todo chamado toda vez que o player toca alguma coisa, desde que tenha um ridigbody e um colisor
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }
    // M�todo chamado toda vez que o player PARA de tocar alguma coisa, desde que tenha um ridigbody e um colisor
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
