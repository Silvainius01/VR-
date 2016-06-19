using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    //If there is a delay before the object can start fading
    public bool HadDelay = false;

    //True = fade in, False = fade out
    public bool FadeIn = true;
    public float FadeSpeed = 0.3f;
    public float Delay = 5;
    private float Timer = 0;

    //Used for if you want to chain a bunch of fades together
    //Example: black box fades out, then you want the text to fade in after that
    public Transform ChainTarget;
    [HideInInspector]
    public bool FinishedFading = false;

    void Update()
    {
        GameObject tracker = GameObject.Find("LevelTracker");

        if (HadDelay == true)
        {
            Timer += Time.deltaTime;
            if (Timer >= Delay) HadDelay = false;
        }

        if (FinishedFading == false)
        {
            //Fade In
            if (FadeIn == true)
            {
                if (HadDelay == false)
                {
                    //If ChainTarget doesn't have a parameter, go with the normal fading, else wait for
                    //ChainTarget to finish fading then the object can start fading
                    if (ChainTarget == null) StartFadeIn();
                    else
                    {
                        if (ChainTarget.GetComponent<FadeInOut>().FinishedFading == true) StartFadeIn();
                    }
                }
            }
            //Fade Out
            else
            {
                if (HadDelay == false)
                {
                    //If ChainTarget doesn't have a parameter, go with the normal fading, else wait for
                    //ChainTarget to finish fading then the object can start fading
                    if (ChainTarget == null) StartFadeOut();
                    else
                    {
                        if (ChainTarget.GetComponent<FadeInOut>().FinishedFading == true) StartFadeOut();
                    }
                }
            }
        }
    }

    void StartFadeIn()
    {
        //If the object is a sprite
        if (GetComponent<Image>() != null)
        {
            //Less than alpha 0.98
            if (GetComponent<Image>().color.a < 0.98f)
            {
                Color newAlpha = new Vector4(0, 0, 0, FadeSpeed) * Time.deltaTime;
                GetComponent<Image>().color += newAlpha;
            }

            //Greater than alpha 0.98
            if (GetComponent<Image>().color.a >= 0.98f)
            {
                GetComponent<Image>().color = new Vector4(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
                FinishedFading = true;
            }
        }
        //If the object is a text
        else if (GetComponent<Text>() != null)
        {
            //Less than alpha 0.98
            if (GetComponent<Text>().color.a < 0.98f)
            {
                Color newAlpha = new Vector4(0, 0, 0, FadeSpeed) * Time.deltaTime;
                GetComponent<Text>().color += newAlpha;
            }

            //Greater than alpha 0.98
            if (GetComponent<Text>().color.a >= 0.98f)
            {
                GetComponent<Text>().color = new Vector4(GetComponent<Text>().color.r, GetComponent<Text>().color.g, GetComponent<Text>().color.b, 1);
                FinishedFading = true;
            }
        }
    }

    void StartFadeOut()
    {
        //If the object is a sprite
        if (GetComponent<Image>() != null)
        {
            //Greater than alpha 0.02f
            if (GetComponent<Image>().color.a >= 0.02f)
            {
                Color newAlpha = new Vector4(0, 0, 0, FadeSpeed) * Time.deltaTime;
                GetComponent<Image>().color -= newAlpha;
            }

            //less than alpha 0.02f
            if (GetComponent<Image>().color.a < 0.02f)
            {
                GetComponent<Image>().color = new Vector4(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
                FinishedFading = true;
            }
        }
        //If the object is a text
        else if (GetComponent<Text>() != null)
        {
            //Greater than alpha 0.02f
            if (GetComponent<Text>().color.a >= 0.02f)
            {
                Color newAlpha = new Vector4(0, 0, 0, FadeSpeed) * Time.deltaTime;
                GetComponent<Text>().color -= newAlpha;
            }

            //less than alpha 0.02f
            if (GetComponent<Text>().color.a < 0.02f)
            {
                GetComponent<Text>().color = new Vector4(GetComponent<Text>().color.r, GetComponent<Text>().color.g, GetComponent<Text>().color.b, 0);
                FinishedFading = true;
            }
        }
    }
}
