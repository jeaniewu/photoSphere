using UnityEngine;
using System.Collections;


public class catStatus : MonoBehaviour
{

    //Animation talk;
    Animator thisAnim;

    // Use this for initialization
    void Start()
    {
        //	talk = GetComponent<Animation>();
        //talk ["talk"].wrapMode = WrapMode.Loop;

        thisAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //AnimatorStateInfo thisState = thisAnim.GetCurrentAnimatorStateInfo (0);

        if (Input.GetMouseButtonDown(1))
        {
            /*if (!talk.isPlaying) {
				talk.Play ("talk");
			} else {
				talk.Stop ();
			}*/

            thisAnim.CrossFade("talk", 0f);
        }
        else if (Input.GetKeyDown("space"))
        {
            thisAnim.CrossFade("default", 0f);
        }
    }


}