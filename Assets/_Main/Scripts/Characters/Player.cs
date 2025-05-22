using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    // controles da movimentação do player
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rigid;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        Move();
        Jump();
        CheckFall();
    }

    // Movimentação na Horizontal
    void Move() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        //andando pra direita
        if (Input.GetAxis("Horizontal") > 0f) {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        //andando pra esquerda
        if (Input.GetAxis("Horizontal") < 0f) {
            anim.SetBool("walk", true);
            //rotacionar
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        //volta pro idle
        if (Input.GetAxis("Horizontal") == 0f) {
            anim.SetBool("walk", false);
        }
    }

    // Pulo e pulo duplo
    void Jump() {
        if (Input.GetButtonDown("Jump")) {
            if (!isJumping) {
                // aqui ele consegue dá o 2º pulo
                rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                //coloca a animação no player
                anim.SetBool("jump", true);
                anim.SetBool("walk", false);
            } else {
                //para ele não pular infinitamente, ele para depois do 2º pulo
                if (doubleJump) {
                    rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    // Verifica se o player caiu
    void CheckFall() {
        if (transform.position.y < -5f) { // Ajuste este valor conforme necessário
            Debug.Log("Player caiu do mapa!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Método chamado toda vez que o player toca alguma coisa, desde que tenha um ridigbody e um colisor
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 8) {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }

    // Método chamado toda vez que o player PARA de tocar alguma coisa, desde que tenha um ridigbody e um colisor
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.layer == 8) {
            isJumping = true;
        }
    }
}
