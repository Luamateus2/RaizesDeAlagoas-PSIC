using UnityEngine;
using UnityEngine.SceneManagement;

public class ViuvaTrigger : MonoBehaviour
{
    public static int viuvaCount = 0;
    private bool jaContada = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!jaContada && collision.CompareTag("Player"))
        {
            jaContada = true;
            viuvaCount++;
            Debug.Log("Player passou por uma Viuva. Total: " + viuvaCount);

            if (viuvaCount >= 3)
            {
                Debug.Log("Player passou por 3 Viuvas! Indo para CutSceneFinal.");
                //SceneManager.LoadScene("Assets/_Main/Scenes/Level1/CutSceneFinal.unity");
                FindObjectOfType<LevelController>().CompleteLevel();
            }
        }
    }

    public static void ResetarContador()
    {
        viuvaCount = 0;
    }
}
