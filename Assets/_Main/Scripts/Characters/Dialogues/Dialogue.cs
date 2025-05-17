using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {
    public Sprite profile;
    public string[] speechTxt; //transformado em um array para colocar varias frases
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    //chamar o metodo de dialoguecontrol

    private DialogueControl dc;
    public bool onRadious;
    public bool podeIniciar = true;
    private bool estaAberto = false;

    private void Start() {   //find qdo iniciar o jogo ele procura na cena o lugar que tem o dialoguecontrol
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate() {
        Interact();
    }

    private void Update() //ultimo a ser colocado no video, devido a repeticao do mesmo texto
    {
        if (onRadious) {
            if (podeIniciar && dc.complete) {
                dc.Speech(profile, speechTxt, actorName);
            } else if (Input.GetKeyDown(KeyCode.Space))
                dc.NextSentence();
            podeIniciar = false;
        }
    }
    public void Interact() { //interacao do npc com o player, vou criar um colisor invisivel no contorno do npc
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer); //vai criar um colisor invisivel circular

        if (hit != null) {
            onRadious = true;
            //dc.Speech(profile, speechTxt, actorName); // aqui vai ficar chamando sem parar, temos que atualizar isso no update
        } else if (onRadious) {
            onRadious = false;
            podeIniciar = true;
            dc.Complete();
        }
    }


    //para mostrar o raio de alcance da colisao   
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
