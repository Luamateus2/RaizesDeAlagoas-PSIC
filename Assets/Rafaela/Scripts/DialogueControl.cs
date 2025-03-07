using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //biblioteca de interface da unity, para acessar alguns elementos do canvas

public class DialogueControl : MonoBehaviour {
    // Teremos informações gerais do nosso diálogo
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed; //controlar a velocidade do texto, letra por letra por exemplo

    public void Speech(Sprite p, string txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        speechText.text = txt;
        actorNameText.text = actorName;
    }

}
