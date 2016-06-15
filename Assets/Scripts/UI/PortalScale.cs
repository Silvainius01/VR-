using UnityEngine;
using System.Collections;

public class PortalScale : MonoBehaviour {

    public Vector3 startingScale;

    void Start()
    {
        startingScale = transform.localScale;
        transform.localScale = new Vector3(0, 0, transform.localScale.z);
    }

    void Update()
    {
        if (transform.localScale.x < startingScale.x) transform.localScale += new Vector3(0.1f, 0, 0);
        if (transform.localScale.y < startingScale.y) transform.localScale += new Vector3(0, 0.1f, 0);
        //if (transform.localScale.z < startingScale.z) transform.localScale += new Vector3(0, 0, 0.01f);

    }
}
