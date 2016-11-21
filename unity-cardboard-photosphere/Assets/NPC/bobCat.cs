using UnityEngine;
using System.Collections;

public class bobCat : MonoBehaviour {
	float currY;
	float amplitude;
	float speed;

	// Use this for initialization
	void Start () {
		currY = transform.position.y;
		amplitude = 0.01f;
		speed = 1.8f;

	}
	// Update is called once per frame
	void Update () {
		currY = currY+amplitude*Mathf.Sin(speed*Time.time);
		transform.position = new Vector3 (transform.position.x, currY, transform.position.z);
	}
}
