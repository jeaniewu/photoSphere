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
        sentences[2] = "123456789123456789\n12495390459033045595";
	}

    void setTextOfCurrentTextBox(string newText)
    {

        //assume there is a newline every 20 chars

        Transform spriteTransform = currentTextBox.transform.GetChild(0);

        Transform boxTextTransform = currentTextBox.transform.GetChild(1);
       
        TextMesh boxTextTextMesh = boxTextTransform.GetComponent<TextMesh>();
        boxTextTextMesh.text = newText;

        int widthChars;
        if (newText.Length < 20)
        {
            widthChars = newText.Length;
        } else
        {
            widthChars = 20;
        }

        float textWidth = boxTextTextMesh.characterSize * widthChars * 12;
      
        float textHeight = boxTextTextMesh.characterSize * ((newText.Length / 20) + 1) * 18;
        spriteTransform.localScale = new Vector3(textWidth, textHeight, spriteTransform.localScale.z);
        //boxTextTransform.position = new Vector3(0 - textWidth / 2, 0 + textHeight / 2, 0);
        boxTextTransform.localPosition = new Vector3(0 - textWidth / 40, 0 + textHeight / 20, -3);



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
			currentTextBox = (GameObject)Instantiate(textBox, this.transform.position, this.transform.rotation);
			currentTextBox.transform.parent = this.transform;
            currentTextBox.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (12f * (this.transform.localScale.y / 5)), this.transform.position.z);
            currentTextBox.transform.rotation = transform.rotation;
            currentTextBox.transform.Rotate(new Vector3(0, 90, 0));
            currentTextBox.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
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

	void OnTriggerEnter(Collider other) {		
		if (other.CompareTag("Sphere")){
			sentences = other.gameObject.GetComponent<Loader> ().facts;
		}
	}
}
