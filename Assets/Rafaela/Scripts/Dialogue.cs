using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    //chamar o método de dialoguecontrol

    private DialogueControl dc;

    private void Start()
    {   //find qdo iniciar o jogo ele procura na cena o lugar que tem o dialoguecontrol
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    public void Interact() 
    { //interação do npc com o player, vou criar um colisor invisível no contorno do npc
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer); //vai criar um colisor invisível circular

        if ( hit != null)
        {
            dc.Speech(profile, speechTxt, actorName); 
        }
    }
}
