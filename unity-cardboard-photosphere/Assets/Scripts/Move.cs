using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public float TapDelay = 5.0f;
	private float _tapCountdown;

	private Vector3 target;
	public float speed = 100f;

	public GameObject[] spheres;
	public int index = 0;

	private AudioController audio;
	private Fading fade;

	void Start () {
		audio = GetComponent<AudioController> ();
		fade = GetComponent<Fading> ();
	}
	
	void Update () {
		if (GvrViewer.Instance.Triggered && _tapCountdown <= 0 && !audio.isNarrativePlaying)
		{
			StartCoroutine (fade.beginFade());
			Invoke ("move", 0.5f);

//			target = spheres[index].transform.position;
//			index = (index + 1) % spheres.Length;
//			StartCoroutine (move());
			_tapCountdown = TapDelay;
		}
		else
		{
			_tapCountdown -= Time.deltaTime;
		}
	}

	void move(){
		transform.position = spheres[index].transform.position;
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
