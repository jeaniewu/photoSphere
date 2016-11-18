using UnityEngine;
using System.Collections;

public class TextBoxAdder : MonoBehaviour {

    public GameObject textBox;
    private GameObject currentTextBox;
    public string[] sentences;
    private int currentSentence;
	// Use this for initialization
	void Start () {
       
        currentSentence = -1;
        sentences = new string[3];
        sentences[0] = "sentence1";
        sentences[1] = "2 beep boop";
        sentences[2] = "last sentence";
	}

    void setTextOfCurrentTextBox(string newText)
    {
        Transform boxTextTransform = currentTextBox.transform.GetChild(1);
        TextMesh boxTextTextMesh = boxTextTransform.GetComponent<TextMesh>();
        boxTextTextMesh.text = newText;
    }

    public bool gotoNextSentence()
    {
        currentSentence++;
        if (currentSentence > sentences.Length - 1)
        {
            currentSentence = -1;
            TextboxController currentTextBoxController = currentTextBox.GetComponent<TextboxController>();
            currentTextBoxController.FadeOutTextBox();
        } else
        {
            

            if (currentSentence != 0)
            {
                TextboxController currentTextBoxController = currentTextBox.GetComponent<TextboxController>();
                currentTextBoxController.FadeOutTextBox();
            }
            currentTextBox = (GameObject)Instantiate(textBox, this.transform);
            currentTextBox.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 12f, this.transform.position.z);
            setTextOfCurrentTextBox(sentences[currentSentence]);
            TextboxController newCurrentTextBoxController = currentTextBox.GetComponent<TextboxController>();
            newCurrentTextBoxController.SetInvisible();
            newCurrentTextBoxController.FadeInTextBox();


        }


        if (currentSentence != -1)
        {
            return true;
        } else
        {
            return false;
        }
    }
    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X) == true)
        {
            gotoNextSentence();
        }

    }
}
