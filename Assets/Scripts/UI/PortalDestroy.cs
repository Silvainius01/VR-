using UnityEngine;
using System.Collections;

public class PortalDestroy : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    // CACHE THIS STUFF
    // CALLING GAMEOBJECT FIND A LOT IS BAD FOR PERF :(
    GameObject controllerLeft;
    GameObject controllerRight;

    void Awake()
    {
        controllerLeft = GameObject.FindGameObjectWithTag("LeftShark");
        controllerRight = GameObject.FindGameObjectWithTag("RightShark");
    }

	void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hand"))
        {
            if(controllerRight.GetComponent<StickController>().Controller.GetPressDown(triggerButton)) Destroy(controllerLeft.GetComponent<TeleportPoint>().daPortal);
        }
    }
}
