using UnityEngine;
using System.Collections;

//  t_ denotes a timer
//  s_ denotes a state
// st_ denotes a statistic
// ro_ denotes a raw object. ro_ variables shouldn't be used outside of initialization, as they are broken down by functions for more intuitive use.

public class GuardBrain : MonoBehaviour
{ 
    public Vector3 target;
    public float damage; //Temporary
    public float portalDetectRad = 10.0f;
    public int startingIQ = 0;

    /* STATES */
    private bool s_ActivePortal;
    private bool s_IsAwareOfPlayer;
    private bool s_IsHostile;

    private bool s_IsPlayerInSight(float totalViewAngle)
    {
        Vector3 p = ro_Player.transform.position;
        Vector3 m = st_MyDirection();

        if (Mathf.Abs(Vector3.Angle(m, p)) <= 45.0f)
        {
            if (!s_IsAwareOfPlayer) s_IsAwareOfPlayer = true;
            return true;
        }

        return false;
    }
    private bool s_IsPortalActive(float detectionRadius)
    {
       // if(ro_LeftController.GetComponent<TeleportPoint>().rayHit)
            if(Vector3.Distance(GameObject.FindGameObjectWithTag("Portal").transform.position, transform.position) <= detectionRadius)
                return true;
        return false;
    }

    /* TIMERS */
    private float t_FightingPlayer;
    private float t_HasSeenPlayer;

    /* STATISTICS */
    private int st_CurrentIQ;

    private Vector3 st_MyDirection() { return ro_MyDirection.transform.forward; }
    private Vector3 st_PlayerDirection() { return ro_Player.transform.forward; }

    /* OTHER OBJECTS */
    private GameObject ro_LeftController;
    private GameObject ro_Player;
    private Transform ro_MyDirection;
    
    /* UPDATER FUNCTIONS */

	void Start()
    {
        st_CurrentIQ = startingIQ;
        s_IsAwareOfPlayer = false;
        s_IsHostile = false;
        t_FightingPlayer = 0.0f;
        t_HasSeenPlayer = 0.0f;

        ro_Player = GameObject.Find("Camera (head)");
        ro_LeftController = GameObject.Find("Controller (left)");
        ro_MyDirection = transform.FindChild("Forward");
	}
	
	void Update()
    {
       // if (s_IsPlayerInSight(45.0f)) ;
        //if (s_IsPortalActive(portalDetectRad)) ;
        //Find bodies?
        //Civillians report stolen goods?
    }


} 
