using UnityEngine;

public class DialogueViuva : MonoBehaviour
{
    
    [Header("Fala do NPC")]
    public Sprite profile;
    public string[] speechTxt; // transformado em um array para colocar várias frases
    public string actorName;

    [Header("Fala do Player")]
    public Sprite playerProfile;
    public string[] playerSpeechTxt;
    public string playerName = "Player";

    [Header("Configuração de Interação")]
    public LayerMask playerLayer;
    public float radious;

    // Referência ao DialogueControl
    private DialogueControl dc;

    // Controle de estados
    public bool onRadious;
    public bool podeIniciar = true;
    private bool playerFalou = false;

    private void Start() {
        // Encontra o DialogueControl na cena
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate() {
        Interact();
    }

    private void Update() {
        if (onRadious) {
            if (!playerFalou && podeIniciar && dc.complete) {
                // Player fala primeiro
                dc.Speech(playerProfile, playerSpeechTxt, playerName);
                playerFalou = true;
            }
            else if (playerFalou && podeIniciar && dc.complete) {
                // Depois o NPC fala
                dc.Speech(profile, speechTxt, actorName);
                podeIniciar = false;
            }
            else if (Input.GetKeyDown(KeyCode.Space)) {
                dc.NextSentence();
            }
        }
    }

    public void Interact() {
        // Cria um colisor invisível circular ao redor do NPC
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

        if (hit != null) {
            onRadious = true;
        } 
        else if (onRadious) {
            onRadious = false;
            podeIniciar = true;
            playerFalou = false; // reseta para o próximo encontro
            dc.Complete();
        }
    }

    // Para mostrar o raio de alcance da colisão na cena
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
