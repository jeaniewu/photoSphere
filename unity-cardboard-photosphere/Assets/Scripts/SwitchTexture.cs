using UnityEngine;
using System.Collections;

public class SwitchTexture : MonoBehaviour {

	public float TapDelay = 5.0f;
	private float _tapCountdown;
	private Texture2D[] textureArray;
	public int currTexture = 0;

	public GameObject sphere;

	// Use this for initialization
	void Start () {
		textureArray = GetComponent<TextureLoader> ().imageBuffer;
	}
	
	// Update is called once per frame
	void Update () {

		if (_tapCountdown <= 0)
		{
			sphere.GetComponent<Renderer> ().material.mainTexture = textureArray[currTexture];
			currTexture++;
			_tapCountdown = TapDelay;
		}
		else
		{
			_tapCountdown -= Time.deltaTime;
		}
	
	}
}
