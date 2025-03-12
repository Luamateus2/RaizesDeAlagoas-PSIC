using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; //biblioteca de interface da unity, para acessar alguns elementos do canvas

public class DialogueControl : MonoBehaviour {
    // Teremos informa��es gerais do nosso di�logo
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public TMP_Text speechText;
    public TMP_Text actorNameText;

    [Header("Settings")]
    public float typingSpeed; //controlar a velocidade do texto, letra por letra por exemplo
    private string[] sentences;
    private int index;
    public bool complete = true;

    public void Speech(Sprite p, string [] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        complete = false;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence() // para as letras aparecerem uma a uma
    {
        speechText.text = "";
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index]) // estou verificando o texto corresponde a frase completa para usar o bot�o
        {
            //ainda h� textos
            if(index < sentences.Length -1)
            {
                index++; // pulo pra pr�xima fase
                speechText.text = ""; // limpo o texto
                StartCoroutine(TypeSentence()); //chamo a pr�xima frase
            }
            else //lido quando acaba os textos
            {
                complete = true;
                speechText.text = ""; //limpa o texto
                index = 0; // volta para o in�cio dos di�logos
                dialogueObj.SetActive(false);

            }
        }
    }
}
