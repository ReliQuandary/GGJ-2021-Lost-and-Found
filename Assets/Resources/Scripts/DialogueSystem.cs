using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueSystem : MonoBehaviour
{
    // Reference video
 //   https://www.youtube.com/watch?v=EYgHajlyRm4&list=PLGSox0FgA5B7mApF1vhbspLj5NpzKedU6&index=3
    // This'll be the sole DialogueSystem for the game
    public static DialogueSystem instance;
    public ELEMENTS elements;

    // Initialize dialogue system
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

	/// <summary>
	/// Say something and show it on the speech box.
	/// </summary>
	public void Say(string speech, string speaker = "")
	{
		StopSpeaking();

		speaking = StartCoroutine(Speaking(speech, false, speaker));
	}

	/// <summary>
	/// Say something to be added to what is already on the speech box.
	/// </summary>
	public void SayAdd(string speech, string speaker = "")
	{
		StopSpeaking();

		speechText.text = targetSpeech;

		speaking = StartCoroutine(Speaking(speech, true, speaker));
	}

	public void StopSpeaking()
	{
		if (isSpeaking)
		{
			StopCoroutine(speaking);
		}
		speaking = null;
	}

	public bool isSpeaking { get { return speaking != null; } }
	[HideInInspector] public bool isWaitingForUserInput = false;

	public string targetSpeech = "";
	Coroutine speaking = null;
	IEnumerator Speaking(string speech, bool additive, string speaker = "")
	{
		speechPanel.SetActive(true);
		targetSpeech = speech;

		if (!additive)
			speechText.text = "";
		else
			targetSpeech = speechText.text + targetSpeech;

		speakerNameText.text = DetermineSpeaker(speaker);//temporary

		isWaitingForUserInput = false;

		while (speechText.text != targetSpeech)
		{
			speechText.text += targetSpeech[speechText.text.Length];
			yield return new WaitForEndOfFrame();
		}

		//text finished
		isWaitingForUserInput = true;
		while (isWaitingForUserInput)
			yield return new WaitForEndOfFrame();

		StopSpeaking();
	}

	string DetermineSpeaker(string s)
	{
		string retVal = speakerNameText.text;//default return is the current name
		if (s != speakerNameText.text && s != "")
        {
			retVal = s;
        }
		return retVal;
	}

	[System.Serializable]
    public class ELEMENTS
    {
        /// <summary>
        /// The main panel containing all dialogue related elements on the UI
        /// </summary>
        public GameObject speechPanel;
        public TextMeshProUGUI speakerNameText;
        public TextMeshProUGUI speechText;
    }
    public GameObject speechPanel { get { return elements.speechPanel; } }
    public TextMeshProUGUI speakerNameText { get { return elements.speakerNameText; } }
    public TextMeshProUGUI speechText { get { return elements.speechText; } }
}


