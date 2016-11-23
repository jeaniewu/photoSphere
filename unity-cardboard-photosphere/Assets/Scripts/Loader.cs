using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public int index = -1;
	public string[] facts;

	string filename = @"Texture_";
	string audioname = @"Audio_";
	string textname = @"Text_";
	private string indexSuffix = "";

	public Texture2D texture;
	public TextAsset textFile;
	public AudioClip narrativeClip;

	// Use this for initialization
	void Start () {

		// Load Statically
		this.gameObject.GetComponent<Renderer> ().material.mainTexture = texture;
		this.gameObject.GetComponentInChildren<AudioSource> ().clip = narrativeClip;
		if (textFile != null) {
			facts = textFile.text.Split ('\n');
		}

		// Load Dynamically
//		float logIdx = Mathf.Log10 (index);
//		if (logIdx < 1.0)
//			indexSuffix += "00";
//		else if (logIdx < 2.0)
//			indexSuffix += "0";
//		indexSuffix += index;
//
//		startLoading ();
	}
	
	public void startLoading(){
		StartCoroutine(loadImages());
		StartCoroutine(loadAudio());
		StartCoroutine(loadFacts());
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
		if (textFile != null) {
			facts = textFile.text.Split ('\n');
		}
		yield return null;
	}
		
}
