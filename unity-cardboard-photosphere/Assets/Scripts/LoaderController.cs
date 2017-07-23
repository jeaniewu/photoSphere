using UnityEngine;
using System.Collections;

public class LoaderController : MonoBehaviour {

	public GameObject[] spheres;

	// Use this for initialization
	void Start () {
		//StartCoroutine (loader());
	}

	public IEnumerator loader()
	{
		for (int i = 0; i < spheres.Length; i++) {
			yield return new WaitForSeconds (0.1f);
			spheres [i].GetComponent<Loader> ().startLoading ();
			yield return new WaitForSeconds (1.0f);
		}
	}

}
