using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    DialogueSystem dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueSystem.instance;
        dialogue.speechText.SetText(s[0].Split(':')[0]);
    }


    public string[] s = new string[]
    {
        "Here is some test dialogue.:Ghost Lady",
        "More dialogue here.",
        "Okay, I'm done."
    };


    int index = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceDialogue();
        }
    }

    // This is connected to the Next button
    public void AdvanceDialogue()
    {
        if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
        {
            Debug.Log("Next index test: " + index + "\n");
            if (index >= s.Length - 1)
            {
                return;
            }
            //if (index <= 0)
            //{
            //    index = 1;
            //}
            index++;
            Say(s[index]);
            Debug.Log("Index after Say: " + index + "\n\n");
        }
    }

    // This is connected to the Back button
    public void ReverseDialogue()
    {
        if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
        {
            Debug.Log("Back index test: " + index + "\n");
            if (index <= 0)
            {
                return;
            }

            if (index == s.Length)
            {
                index--;
            }
            index--;
            Say(s[index]);
            //index++;
            Debug.Log("Index after Say: " + index + "\n\n");
        }
    }

    void Say(string s)
    {
        string[] parts = s.Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts[1] : "";

        dialogue.Say(speech, speaker);
    }
}
