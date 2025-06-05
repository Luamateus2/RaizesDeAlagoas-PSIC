using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private bool somOn;

    void Start()
    {
        somOn = true;
        AudioListener.volume = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            volumeDoJogo();
        }
    }

    public void volumeDoJogo() 
    {
        somOn = !somOn;
        if (somOn)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
}
