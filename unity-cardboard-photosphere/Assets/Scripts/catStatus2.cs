using UnityEngine;
using System.Collections;


public class catStatus2 : MonoBehaviour
{

    //Animation talk;
    Animator thisAnim;
    TextBoxAdder tbAdder;
    double timePassed;
    bool isTalking;

    // Use this for initialization
    void Start()
    {
        //	talk = GetComponent<Animation>();
        //talk ["talk"].wrapMode = WrapMode.Loop;

        thisAnim = GetComponent<Animator>();
        tbAdder = GetComponent<TextBoxAdder>();
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //AnimatorStateInfo thisState = thisAnim.GetCurrentAnimatorStateInfo (0);

		if (Input.GetKeyDown(KeyCode.T))
        {
            /*if (!talk.isPlaying) {
				talk.Play ("talk");
			} else {
				talk.Stop ();
			}*/

            thisAnim.CrossFade("talk", 0f);
            if (tbAdder.gotoNextSentence())
            {
                isTalking = true;
                thisAnim.CrossFade("talk", 0f);
            }
            else
            {
                isTalking = false;
                thisAnim.CrossFade("default", 0f);
            }
            timePassed = 0;
            isTalking = true;
        }

        if (isTalking)
        {
            timePassed += Time.deltaTime;

            if (timePassed > 3.0f)
            {
                isTalking = false;
                thisAnim.CrossFade("default", 0f);
                timePassed = 0;
            }
        }


        else if (Input.GetKeyDown("space"))
        {
            thisAnim.CrossFade("default", 0f);
        }
    }


}
