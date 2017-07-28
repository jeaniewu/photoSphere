using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveGroups : MonoBehaviour {
	
	void Start(){

	}
	// Update is called once per frame
	public void ChangeScene (Collider other) {
		SceneManager.LoadScene (other.tag);

		if(other.CompareTag("Sphere"))
			SceneManager.LoadScene("DemoFair");
	}
}
