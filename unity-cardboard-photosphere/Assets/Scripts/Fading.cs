using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	public float alpha = 1.0f; 
	public int fadeDir = -1; // direction to fade: in = -1, out = 1

	void OnGUI(){
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	public IEnumerator beginFade(){
		while (alpha != 1) {
			fadeDir = 1;
			yield return null;
		}
		while (alpha != 0) {
			fadeDir = -1;
			yield return null;
		}
	}

	//	void OnTriggerEnter(Collider other) {		
	//		if (other.CompareTag("Sphere")){
	//			StartCoroutine (beginFade());
	//		}
	//	}
}