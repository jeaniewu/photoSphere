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

            Transform textObjectTrans = transform.GetChild(1);
            GameObject textObject = textObjectTrans.gameObject;
            MeshRenderer mr = textObject.GetComponent<MeshRenderer>();
            Material newMaterial = mr.materials[0];
           
            SpriteRenderer sr = spriteObject.GetComponent<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, (float)(sr.color.a - 0.05));
            newMaterial.color = new Color(newMaterial.color.r, newMaterial.color.g, newMaterial.color.b, (float)(newMaterial.color.a - 0.1));

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

            Transform textObjectTrans = transform.GetChild(1);
            GameObject textObject = textObjectTrans.gameObject;
            MeshRenderer mr = textObject.GetComponent<MeshRenderer>();
            Material newMaterial = mr.materials[0];
          
            newMaterial.color = new Color(newMaterial.color.r, newMaterial.color.g, newMaterial.color.b, (float)(newMaterial.color.a + 0.05));


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

        Transform textObjectTrans = transform.GetChild(1);
        GameObject textObject = textObjectTrans.gameObject;
        MeshRenderer mr = textObject.GetComponent<MeshRenderer>();
        Material newMaterial = mr.materials[0];

        newMaterial.color = new Color(newMaterial.color.r, newMaterial.color.g, newMaterial.color.b, 0);

    }
}
