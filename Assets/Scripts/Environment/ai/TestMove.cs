using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour
{
    public Vector3 speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += speed * Time.deltaTime;
	}
}
