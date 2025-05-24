using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GuerreiroGameOver : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

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
                Destroy(gameObject);
            } else {
                Debug.Log("Player derrotado!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}