using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPSCounter : MonoBehaviour {
	Text txt;
	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();
	}

	int frameCount = 0;
	float dt = 0.0f;
	float fps = 0.0f;
	float updateRate = 4.0f;  // 4 updates per sec.

	void Update()
	{
		frameCount++;
		dt += Time.deltaTime;
		if (dt > 1.0f/updateRate)
		{
			fps = frameCount / dt ;
			frameCount = 0;
			dt -= 1.0f/updateRate;
		}

		txt.text = Mathf.CeilToInt(fps).ToString();
	}
}
