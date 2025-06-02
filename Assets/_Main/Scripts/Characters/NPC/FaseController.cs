using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseController : MonoBehaviour
{
    private int guerreirosMortos = 0;
    private int totalGuerreiros = 34; // Fixar a quantidade total aqui

    void Start()
    {
        Debug.Log("Total de guerreiros para eliminar: " + totalGuerreiros);
    }

    // Chamada quando um guerreiro morrer
    public void GuerreiroEliminado()
    {
        guerreirosMortos++;
        int restantes = totalGuerreiros - guerreirosMortos;
        Debug.Log("Guerreiro eliminado! Restam: " + restantes);

        if (guerreirosMortos >= totalGuerreiros)
        {
            ProximaFase();
        }
    }

    void ProximaFase()
    {
        Debug.Log("Todos os 36 guerreiros eliminados! Indo para a próxima fase...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
