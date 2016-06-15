using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartingScript : MonoBehaviour
{
    public float timer;

    public GameObject portalPrefab;
    public GameObject head;
    public GameObject eyes;

	// Update is called once per frame
	void Update ()
	{
	  timer += Time.deltaTime;
	  if (timer >= 10)
	  {
	    GetComponent<TeleportPoint>().daPortal =
	      (GameObject)
	      Instantiate(portalPrefab, new Vector3(head.transform.position.x, eyes.transform.position.y / 1.7f,
	                                  head.transform.position.z) + (eyes.transform.forward * 0.8f),
	        eyes.transform.rotation);

	  }
	}
}
