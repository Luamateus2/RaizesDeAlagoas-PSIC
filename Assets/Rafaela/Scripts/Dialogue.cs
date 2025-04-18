using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string [] speechTxt; //transformado em um array para colocar v�rias frases
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    //chamar o m�todo de dialoguecontrol

    private DialogueControl dc;
    public bool onRadious;
    public bool podeIniciar = true;
    private bool estaAberto = false;

    private void Start()
    {   //find qdo iniciar o jogo ele procura na cena o lugar que tem o dialoguecontrol
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void Update() //ultimo a ser colocado no v�deo, devido a repeti��o do mesmo texto
    {
        if(onRadious) 
        {
            if (podeIniciar && dc.complete) {
                dc.Speech(profile, speechTxt, actorName);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
                dc.NextSentence();
            podeIniciar = false;
        }
    }
    public void Interact() 
    { //intera��o do npc com o player, vou criar um colisor invis�vel no contorno do npc
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer); //vai criar um colisor invis�vel circular

        if ( hit != null)
        {
            onRadious = true;
            //dc.Speech(profile, speechTxt, actorName); // aqui vai ficar chamando sem parar, temos que atualizar isso no update
        } 
        else if (onRadious)
        {
            onRadious = false;
            podeIniciar = true;
            dc.Complete();
        }
    }


    //para mostrar o raio de alcance da colis�o   
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
