using UnityEngine;
using System.Collections;

public class dialogueTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrViewer.Instance.Triggered && this.gameObject.activeSelf) {
			this.gameObject.SetActive (false);
		}
	}
}
