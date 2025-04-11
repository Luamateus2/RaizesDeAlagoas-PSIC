using UnityEngine;

public class Guerreiro3Walk : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade = 2f;

    private Vector3 alvoAtual;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        alvoAtual = pontoB.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (animator != null)
        {
            animator.Play("Guerreiro3walk");
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvoAtual, velocidade * Time.deltaTime);

        if (Vector3.Distance(transform.position, alvoAtual) < 0.1f)
        {
            // Alterna entre ponto A e ponto B
            alvoAtual = (alvoAtual == pontoA.position) ? pontoB.position : pontoA.position;

            // Espelha o sprite horizontalmente
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}