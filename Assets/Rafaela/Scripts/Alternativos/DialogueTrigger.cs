using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter {
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine {
    public DialogueCharacter character;
    [TextArea(3, 10)] //coloca as linhas de diálogo
    public string line;
}

[System.Serializable]
public class DialogueActor {
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}
public class DialogueTrigger : MonoBehaviour {

    public DialogueActor dialogue;

}