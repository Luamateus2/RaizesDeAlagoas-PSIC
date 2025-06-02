using UnityEngine;
using UnityEngine.SceneManagement;

public class GuerreiroGameOver : MonoBehaviour
{
    private FaseController faseController;

    void Start()
    {
        faseController = FindObjectOfType<FaseController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            float playerPosY = collision.transform.position.y;
            float guerreiroPosY = transform.position.y;

            if (playerPosY > guerreiroPosY + 0.5f)
            {
                Debug.Log("Guerreiro derrotado!");
                faseController.GuerreiroEliminado();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Player derrotado!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // faseController.GameOver(); // Remova ou adicione se tiver esse método.
            }
        }
    }
}
