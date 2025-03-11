using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string [] speechTxt; //transformado em um array para colocar várias frases
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    //chamar o método de dialoguecontrol

    private DialogueControl dc;
    bool onRadious;

    private void Start()
    {   //find qdo iniciar o jogo ele procura na cena o lugar que tem o dialoguecontrol
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void Update() //ultimo a ser colocado no vídeo, devido a repetição do mesmo texto
    {
        if(Input.GetKeyDown(KeyCode.Space) && onRadious) 
        {
            dc.Speech(profile, speechTxt, actorName);
        }
    }
    public void Interact() 
    { //interação do npc com o player, vou criar um colisor invisível no contorno do npc
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer); //vai criar um colisor invisível circular

        if ( hit != null)
        {
            onRadious = true;
            //dc.Speech(profile, speechTxt, actorName); // aqui vai ficar chamando sem parar, temos que atualizar isso no update
        } 
        else 
        {
            onRadious = false;
        }
    }

    //para mostrar o raio de alcance da colisão   
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
