using UnityEngine;
using System.Collections;

public class MinMapController : MonoBehaviour
{
    public Transform player;
    private Vector3 augooo;
	// Use this for initialization
	void Start ()
    {
        augooo = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.localPosition = -player.position + augooo;
	}
}
