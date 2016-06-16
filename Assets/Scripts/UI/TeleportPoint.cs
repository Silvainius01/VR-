using UnityEngine;
using System.Collections;

//device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad;


public class TeleportPoint : MonoBehaviour
{
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerPressed = false;
    public bool triggerPressedDown = false;
    public bool triggerPressedUp = false;

    private SteamVR_Controller.Device controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private SteamVR_TrackedObject trackedObj;

    public GameObject rig;
    public GameObject portalPrefab;
    public GameObject head;
    public GameObject eyes;
    public GameObject daPortal;
    public AudioSource audio;

    public Vector3 startingTeleportDot;
    public Vector3 endingTeleportDot;
    public float blinkTransitionSpeed = 0.6f;

    // TEST VECTORS
    public Vector3 pointCollide;
    public Vector3 rayCastPosition;
    public Vector3 rayCastPosition2;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller is not plugged in");
            return;
        }
        triggerPressedDown = controller.GetPressDown(triggerButton);
        triggerPressedUp = controller.GetPressUp(triggerButton);
        triggerPressed = controller.GetPress(triggerButton);

        if (triggerPressedDown)
        {
            startingTeleportDot = transform.position;
        }
        if (triggerPressedUp)
        {
            endingTeleportDot = transform.position;

            if (Vector3.Distance(startingTeleportDot, endingTeleportDot) >= 0.7f)
            {
                startingTeleportDot = Vector3.zero;
                endingTeleportDot = Vector3.zero;
                Teleport();
            }
            if (controller == null)
            {
                return;
            }

            triggerPressedDown = controller.GetPressDown(triggerButton);
            triggerPressedUp = controller.GetPressUp(triggerButton);
            triggerPressed = controller.GetPress(triggerButton);

            if (triggerPressedDown)
            {
                startingTeleportDot = transform.position;
            }
            if (triggerPressedUp)
            {
                endingTeleportDot = transform.position;

                if (Vector3.Distance(startingTeleportDot, endingTeleportDot) >= 0.7f)
                {
                    startingTeleportDot = Vector3.zero;
                    endingTeleportDot = Vector3.zero;
                    Teleport();
                }
            }
        }
    }

    protected virtual void Blink()
    {
        SteamVR_Fade.Start(Color.black, 0);
        SteamVR_Fade.Start(Color.clear, blinkTransitionSpeed);
    }

    void RayHitter()
    {
        Ray pointerRaycast = new Ray(eyes.transform.position, eyes.transform.forward);
        RaycastHit pointerCollidedWith;
        bool rayHit = Physics.Raycast(pointerRaycast, out pointerCollidedWith);
        if (rayHit == true)
        {
            if (pointerCollidedWith.transform.tag == "Teleportable")
            {
                GetComponent<Renderer>().enabled = true;
            }
            else
            {
                 GameObject[] node = GameObject.FindGameObjectsWithTag("Teleportable");
                for(int i = 0; i <= node.Length; ++i)
                {
                    node[i].GetComponent<Renderer>().enabled = false;
                }

            }
        }
    }

    void Teleport()
    {
        Blink();
        Ray pointerRaycast = new Ray(eyes.transform.position, eyes.transform.forward);
        rayCastPosition = eyes.transform.position;
        rayCastPosition2 = eyes.transform.forward;
        RaycastHit pointerCollidedWith;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(eyes.transform.forward, eyes.transform.forward + new Vector3(10, 0, 0));
        bool rayHit = Physics.Raycast(pointerRaycast, out pointerCollidedWith);
        if (rayHit == true)
        {
            if (pointerCollidedWith.transform.tag == "Teleportable")
            {
                if (FindObjectOfType<GlobalVars>().CurrentEnergy <= 24)
                {
                    audio.Play();
                }
                else
                {
                    FindObjectOfType<GlobalVars>().CurrentEnergy -= 25;

                    //rig.transform.position = pointerCollidedWith.point;
                    //Finds all existing portals
                    GameObject[] portals = GameObject.FindGameObjectsWithTag("Portal");
                    //Deletes all existing portals
                    if (portals.Length > 0) for (int i = 0; i < portals.Length; ++i) Destroy(portals[i]);

                    daPortal = (GameObject)Instantiate(portalPrefab, new Vector3(eyes.transform.position.x, eyes.transform.position.y / 1.7f,
                        eyes.transform.position.z) + (eyes.transform.forward * 0.8f), eyes.transform.rotation);
                    daPortal.GetComponentInChildren<PortalTeleport>().targetTeleport = new Vector3(pointerCollidedWith.point.x,
                        rig.transform.position.y, pointerCollidedWith.point.z);

                    daPortal.GetComponentInChildren<PortalTeleport>().targetTeleport = new Vector3(pointerCollidedWith.point.x,
                      rig.transform.position.y, pointerCollidedWith.point.z);
                    daPortal.transform.LookAt(rig.transform);
                }
            }
        }
    }
}