using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

    public Renderer rend;

	// Use this for initialization
	void Awake ()
    {
        GetComponent<Renderer>();
        rend.enabled = false;
	}

}
