using UnityEngine;
using System.Collections;

public class MinMapController : MonoBehaviour
{
    public Transform player;
    private Vector3 augooo;
    private Vector3 playerstart;
	// Use this for initialization
	void Start ()
    {
        playerstart = player.position;
        augooo = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 apply = (player.position - playerstart) + augooo;
        apply.y = augooo.y;
        transform.localPosition = apply;
	}
}
