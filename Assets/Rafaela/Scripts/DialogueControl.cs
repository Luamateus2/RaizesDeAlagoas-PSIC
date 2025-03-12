using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; //biblioteca de interface da unity, para acessar alguns elementos do canvas

public class DialogueControl : MonoBehaviour {
    // Teremos informações gerais do nosso diálogo
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
        if(speechText.text == sentences[index]) // estou verificando o texto corresponde a frase completa para usar o botão
        {
            //ainda há textos
            if(index < sentences.Length -1)
            {
                index++; // pulo pra próxima fase
                speechText.text = ""; // limpo o texto
                StartCoroutine(TypeSentence()); //chamo a próxima frase
            }
            else //lido quando acaba os textos
            {
                complete = true;
                speechText.text = ""; //limpa o texto
                index = 0; // volta para o início dos diálogos
                dialogueObj.SetActive(false);

            }
        }
    }
}
