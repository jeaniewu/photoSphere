using UnityEngine;
using System.Collections;

public class TextboxController : MonoBehaviour {


    bool isFadingOut;
    bool isFadingIn;
    int fadingOutTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (isFadingOut)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            Transform spriteObjectTrans = transform.GetChild(0);
            GameObject spriteObject = spriteObjectTrans.gameObject;
            SpriteRenderer sr = spriteObject.GetComponent<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, (float)(sr.color.a - 0.05));
            fadingOutTime++;
            if (fadingOutTime > 30)
            {
                Destroy(transform.gameObject);
            }
        } else if (isFadingIn)
        {
            Transform spriteObjectTrans = transform.GetChild(0);
            GameObject spriteObject = spriteObjectTrans.gameObject;
            SpriteRenderer sr = spriteObject.GetComponent<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, (float)(sr.color.a + 0.02));
            if (sr.color.a >= 1.0f)
            {
                isFadingIn = false;
            }

        }
	}

    public void FadeOutTextBox()
    {
        isFadingOut = true;
        isFadingIn = false;
        fadingOutTime = 0;
    }

    public void FadeInTextBox()
    {
        isFadingIn = true;
        
    }

    public void SetInvisible()
    {
        Transform spriteObjectTrans = transform.GetChild(0);
        GameObject spriteObject = spriteObjectTrans.gameObject;
        SpriteRenderer sr = spriteObject.GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
    }
}
