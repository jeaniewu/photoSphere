using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Quit");
			Application.Quit (); 
		}
	}
}
