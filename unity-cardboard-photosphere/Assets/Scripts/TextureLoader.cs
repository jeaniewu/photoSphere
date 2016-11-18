using UnityEngine;
using System.Collections;

public class TextureLoader : MonoBehaviour {

	string pathPrefix = @"file://";
	string pathImageAssets;
	string pathSmall = @"/Textures/";
	string filename = @"Texture_";
	string fileSuffix = @".jpg";

	public Texture2D[] imageBuffer = new Texture2D[10];

	public GameObject[] spheres;

	// Use this for initialization
	void Start () {
		pathImageAssets = Application.dataPath;
		StartCoroutine(loadImages());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator loadImages()
	{

		//create filename index suffix "001",...,"027" (could be "999" either)
		for (int i = 0; i < 4; i++) {
			string indexSuffix = "";
			float logIdx = Mathf.Log10 (i + 1);
			if (logIdx < 1.0)
				indexSuffix += "00";
			else if (logIdx < 2.0)
				indexSuffix += "0";
			indexSuffix += (i + 1);
			string fullFilename = pathPrefix + pathImageAssets + pathSmall + filename + indexSuffix + fileSuffix;
			Debug.Log (fullFilename);
			WWW www = new WWW (fullFilename);
			yield return www;

			Texture2D texTmp = new Texture2D (1024, 1024, TextureFormat.DXT1, false);
			//LoadImageIntoTexture compresses JPGs by DXT1 and PNGs by DXT5     
			www.LoadImageIntoTexture (texTmp);
			imageBuffer[i] = texTmp;

			if (i < spheres.Length) {
				spheres[i].GetComponent<Renderer> ().material.mainTexture = texTmp;
			}
		}
	}
}
