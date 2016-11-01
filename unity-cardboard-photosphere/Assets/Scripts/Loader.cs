using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public int index = -1;

	string filename = @"Texture_";
	string audioname = @"Audio_";
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

}
