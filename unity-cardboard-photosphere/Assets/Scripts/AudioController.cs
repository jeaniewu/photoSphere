using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	public bool isNarrativePlaying = false;

	public void OnTriggerEnter(Collider other) {
			// Play Narrative
		if (!isNarrativePlaying) {
			AudioSource narrative = other.GetComponentsInChildren<AudioSource> () [0];
			AudioSource background = other.GetComponentsInChildren<AudioSource> () [1];

			narrative.Play ();
			isNarrativePlaying = true;
			StartCoroutine (waitForNarrative (narrative, background));

			//Play Background noise, lowered volume when narrative is playing
			background.volume = 0.3f;
			background.Play ();
		}
	}

	public void OnTriggerExit(Collider other) {
			// Disable audio when exiting sphere
		if (!isNarrativePlaying) {
			other.GetComponentsInChildren<AudioSource> () [0].Stop ();
			other.GetComponentsInChildren<AudioSource> () [1].Stop ();
		}
	}

	private IEnumerator waitForNarrative(AudioSource narrative, AudioSource background){
		while (narrative.isPlaying) {
			yield return null;
		}
		isNarrativePlaying = false;
		IEnumerator bgAudio = beginFadeIn(background);

		StartCoroutine (bgAudio);
		yield return new WaitForSeconds(0.7f);
		StopCoroutine (bgAudio);

	}

	public IEnumerator beginFadeIn(AudioSource background){
		while (background.volume <= 1.0f) {
			background.volume += 0.01f;
			yield return null;
		}
	}


}