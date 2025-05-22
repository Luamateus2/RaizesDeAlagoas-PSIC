using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GuerreiroGameOver : MonoBehaviour {
    // Referência ao SpriteRenderer do Guerreiro
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        // Pega o componente SpriteRenderer do Guerreiro
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player") {
            float playerPosY = collision.transform.position.y;
            float guerreiroPosY = transform.position.y;

            // Jogador está acima do guerreiro o suficiente para derrotá-lo
            if (playerPosY > guerreiroPosY + 0.5f) {
                Debug.Log("Guerreiro derrotado!");
                // Inicia o efeito de piscar
                StartCoroutine(BlinkAndDestroy());
            } else {
                Debug.Log("Player derrotado!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    // Coroutine para fazer o Guerreiro piscar duas vezes e sumir
    private IEnumerator BlinkAndDestroy() {
        // Número de piscadas (2 vezes)
        int blinkCount = 2;
        // Tempo de cada estado (visível ou invisível)
        float blinkDuration = 0.2f;

        for (int i = 0; i < blinkCount; i++) {
            // Desativa o sprite (invisível)
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(blinkDuration);
            // Ativa o sprite (visível)
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(blinkDuration);
        }

        // Destroi o objeto após as piscadas
        Destroy(gameObject);
    }
}