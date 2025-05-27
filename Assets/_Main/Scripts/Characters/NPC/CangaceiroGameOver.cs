using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CangaceiroGameOver : MonoBehaviour {
    // Start é chamado antes da primeira atualização do frame
    void Start() {

    }

    // Update é chamado uma vez por frame
    void Update() {

    }
    
    
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("A");
        if (collision.gameObject.name == "Player") {
            Debug.Log("B");
            float playerPosY = collision.transform.position.y;
            float cangaceiroPosY = transform.position.y;

            // Jogador está acima do guerreiro o suficiente para derrotá-lo
            if (playerPosY > cangaceiroPosY + 0.5f) {
                Debug.Log("Guerreiro derrotado!");
                Destroy(gameObject);
            } else {
                Debug.Log("Player derrotado!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}

