using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float speed = 100f;

	public GameObject spheresObject;
	public int index = 0;

	private GameObject[] spheres;
	private AudioController audio;
	private Fading fade;

	void Start () {
		fade = GetComponent<Fading> ();
		spheres = spheresObject.GetComponent<LoaderController> ().spheres;
		audio = GetComponent<AudioController> ();
	}

	public void PointerDown(){
		if (!audio.isNarrativePlaying) {
			StartCoroutine (fade.beginFade ());
			Invoke ("move", 0.5f);
		}
	}

	void move(){
			if (index > spheres.Length)
				index = 0;
		
			transform.position = spheres [index].transform.position;
			index = (index + 1) % spheres.Length;
	}

	//	IEnumerator move(){
	//			while (transform.position.z <= target.z) {
	//				float step = speed * Time.deltaTime;
	//				transform.position = Vector3.MoveTowards (transform.position, target, step);
	//				yield return null;
	//			}
	//	}
}