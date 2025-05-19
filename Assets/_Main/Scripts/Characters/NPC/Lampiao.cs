using UnityEngine;

public class Lampiao : MonoBehaviour {
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade = 2f;

    private Vector3 alvoAtual;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start() {
        alvoAtual = pontoB.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (animator != null) {
            animator.Play("Lampiao");
        }
    }

    void Update() {
        alvoAtual.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, alvoAtual, velocidade * Time.deltaTime);

        if (Vector2.Distance(transform.position, alvoAtual) < 0.1f) {
            // Alterna entre ponto A e ponto B
            alvoAtual = (alvoAtual.x == pontoA.position.x) ? pontoB.position : pontoA.position;



            // Espelha o sprite horizontalmente
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
