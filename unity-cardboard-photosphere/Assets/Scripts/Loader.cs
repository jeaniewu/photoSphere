using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public int index = -1;
	public string[] facts;

	string filename = @"Texture_";
	string audioname = @"Audio_";
	string textname = @"Text_";
	private string indexSuffix = "";

	// Use this for initialization
	void Start () {
		float logIdx = Mathf.Log10 (index + 1);
		if (logIdx < 1.0)
			indexSuffix += "00";
		else if (logIdx < 2.0)
			indexSuffix += "0";
		indexSuffix += (index + 1);

		StartCoroutine(loadImages());
		StartCoroutine(loadAudio());
		StartCoroutine(loadFacts());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateIndex(int newIndex){
		index = newIndex;
	}

	private IEnumerator loadImages()
	{
		Texture2D texTmp = (Texture2D) Resources.Load(filename + indexSuffix,  typeof(Texture2D));
		this.gameObject.GetComponent<Renderer> ().material.mainTexture = texTmp;
		yield return null;
	}

	private IEnumerator loadAudio()
	{
		AudioClip clip = (AudioClip) Resources.Load(audioname + indexSuffix,  typeof(AudioClip));
		this.gameObject.GetComponentInChildren<AudioSource> ().clip = clip;
		yield return null;
	}

	private IEnumerator loadFacts()
	{
		TextAsset textFile = (TextAsset) Resources.Load(textname + indexSuffix,  typeof(TextAsset));
		facts = textFile.text.Split('\n');
		Debug.Log (textFile.text);
		yield return null;
	}


//	public TextAsset textFile;
//	public string[] textArrays;
//
//	// Use this for initialization
//	void Start () {
//		if (textFile != null)
//		{
//			textArrays = new string[1];
//			textArrays = textFile.text.Split('\n');
//		}
//	}
//
//	// Update is called once per frame
//	void Update () {
//
//	}
//
//	public void playScript(int index){
//		GetComponent<TextBoxManager> ().textLines = new string[1];
//		GetComponent<TextBoxManager> ().textLines = textArrays [index].Split (';');
//	}
}
