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
    private float moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        // Captura o input de movimento
        moveInput = Input.GetAxis("Horizontal");

        // Movimentação e animação
        Move();
        Jump();
        CheckFall();
    }

    void FixedUpdate() {
        // Aplica o movimento usando o Rigidbody2D
        rigid.linearVelocity = new Vector2(moveInput * Speed, rigid.linearVelocity.y);
    }

    // Movimentação na Horizontal
    void Move() {
        //andando pra direita
        if (moveInput > 0f) {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        //andando pra esquerda
        else if (moveInput < 0f) {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        //volta pro idle
        else {
            anim.SetBool("walk", false);
        }
    }

    // Pulo e pulo duplo
    void Jump() {
        if (Input.GetButtonDown("Jump")) {
            if (!isJumping) {
                rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, JumpForce);
                doubleJump = true;
                anim.SetBool("jump", true);
                anim.SetBool("walk", false);
            } else {
                if (doubleJump) {
                    rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, JumpForce);
                    doubleJump = false;
                }
            }
        }
    }

    // Verifica se o player caiu
    void CheckFall() {
        if (transform.position.y < -10f) {
            Debug.Log("Player caiu do mapa!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Método chamado toda vez que o player toca alguma coisa
    void OnCollisionEnter2D(Collision2D collision) {
        // Verifica se está tocando o chão (Tilemap)
        if (collision.gameObject.layer == LayerMask.NameToLayer("chao geral (1)")) {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }

    // Método chamado toda vez que o player PARA de tocar alguma coisa
    void OnCollisionExit2D(Collision2D collision) {
        // Verifica se saiu do chão (Tilemap)
        if (collision.gameObject.layer == LayerMask.NameToLayer("chao geral (1)")) {
            isJumping = true;
        }
    }
}
