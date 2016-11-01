using UnityEngine;
using System.Collections;

public class catWave : MonoBehaviour {

	public float rotateSpeed;
	public float currentRotation;
	public float limitRotation;
	// Use this for initialization
	void Start () {
		currentRotation = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if ((transform.position.y != limitRotation)||
			(transform.position.y != currentRotation - 1)) {
			transform.Rotate (new Vector3 (0, rotateSpeed * Time.deltaTime, 0));
		}
		else {
			rotateSpeed = rotateSpeed * (-1);
		}
	}
}
