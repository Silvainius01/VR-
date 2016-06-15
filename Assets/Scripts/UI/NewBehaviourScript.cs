using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject leftStick;
    private StickController Controller;
    private GameObject minMap;
    private bool s_Current = false;
	// Use this for initialization
	void Start ()
    {
        if(leftStick != null) Controller = leftStick.GetComponent<StickController>();
        //minMap = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Controller != null)
        {
            if (Controller.Controller.GetPress(Controller.MenuButton))
            {
                switch (s_Current)
                {
                    case true:
                        s_Current = false;
                        break;
                    case false:
                        s_Current = true;
                        break;
                }

                this.gameObject.SetActive(s_Current);
            }
        }
	}
}
