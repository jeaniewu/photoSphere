using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	public bool isNarrativePlaying = false;

	void OnTriggerEnter(Collider other) {		
		if (other.CompareTag("Sphere")){
			// Play Narrative
			AudioSource narrative = other.GetComponentsInChildren<AudioSource> ()[0];
			AudioSource background = other.GetComponentsInChildren<AudioSource> ()[1];


			narrative.Play();
			isNarrativePlaying = true;
			StartCoroutine(waitForNarrative(narrative, background));

			//Play Background noise, lowered volume when narrative is playing
			background.volume = 0.6f;
			background.Play ();
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag("Sphere")){
			// Disable audio when exiting sphere
			other.GetComponentsInChildren<AudioSource> ()[0].Stop ();
			other.GetComponentsInChildren<AudioSource> ()[1].Stop ();
		}
	}

	private IEnumerator waitForNarrative(AudioSource narrative, AudioSource background){
		while (narrative.isPlaying) {
			yield return null;
		}
		isNarrativePlaying = false;
		background.volume = 1.0f;
	}


}
