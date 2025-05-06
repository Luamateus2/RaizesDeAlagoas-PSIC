using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueCutScene : MonoBehaviour
{

    [Header("Configurações")]
    public string[] texts;
    public float[] timeout;
    public string nextScene;

    [Header("Componentes")]
    public TMP_Text myText;

    private int textIndex = 0;
    private float currentTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myText.text = texts[textIndex];
        currentTime = timeout[textIndex];
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0) {
            textIndex++;
            if (textIndex < texts.Length) {
                myText.text = texts[textIndex];
                currentTime = timeout[textIndex];
            } else {
                SceneManager.LoadScene(nextScene);
                //gameObject.SetActive(false);
                //this.enabled = false;
            }
        }

    }
}
