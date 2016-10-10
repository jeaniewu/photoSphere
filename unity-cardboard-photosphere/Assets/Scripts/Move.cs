using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public float TapDelay = 5.0f;
	private float _tapCountdown;

	private Vector3 target;
	public float speed = 100f;

	public GameObject[] spheres;
	public int index = 0;

	void Start () {
	
	}
	
	void Update () {
		if (GvrViewer.Instance.Triggered && _tapCountdown <= 0)
		{
			target = spheres[index].transform.position;
			index = (index + 1) % spheres.Length;
			StartCoroutine (move());
			_tapCountdown = TapDelay;
		}
		else
		{
			_tapCountdown -= Time.deltaTime;
		}
	}

	IEnumerator move(){
		while (transform.position.z <= target.z) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target, step);
			yield return null;
		}
	}
}
