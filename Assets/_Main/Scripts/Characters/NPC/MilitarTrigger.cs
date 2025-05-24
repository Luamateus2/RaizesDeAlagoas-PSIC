using UnityEngine;
using UnityEngine.SceneManagement;

public class MilitarTrigger : MonoBehaviour
{
    private static int militarCount = 0;
    private bool jaContado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!jaContado && collision.CompareTag("Player"))
        {
            jaContado = true;
            militarCount++;
            Debug.Log("Player passou por um Militar. Total: " + militarCount);

            if (militarCount >= 3)
            {
                Debug.Log("Player passou por 3 Militares! Indo para CutSceneFinal.");
                SceneManager.LoadScene("CutSceneFinal");
            }
        }
    }

    public static void ResetarContador()
    {
        militarCount = 0;
    }
}
