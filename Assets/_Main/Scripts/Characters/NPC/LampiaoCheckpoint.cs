using UnityEngine;
using UnityEngine.SceneManagement;

public class LampiaoCheckpoint : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("A");
        if (collision.gameObject.name == "Player") {
            Debug.Log("B");
            float playerPosY = collision.transform.position.y;
            float lampiaoPosY = transform.position.y;

            // Jogador está acima do Lampião o suficiente para derrotá-lo
            if (playerPosY > lampiaoPosY + 0.5f)
            {
                Debug.Log("Lampião derrotado! Indo para a próxima cena...");
                Destroy(gameObject);
                FindObjectOfType<LevelController>().CompleteLevel();
            }
            else
            {
                Debug.Log("Player derrotado!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                FindObjectOfType<LevelController>().GameOver();
            }
        }
    }

    void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Verifica se a próxima cena existe no Build Settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(nextSceneIndex);
        } else {
            Debug.LogWarning("Não há próxima cena configurada no Build Settings.");
        }
    }
}
