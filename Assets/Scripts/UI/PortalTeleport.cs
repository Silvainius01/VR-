using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
    public Vector3 targetTeleport;
    public string playScene = "Play Scene";
    public GameObject head;
    public GameObject ControllerL;

    private TeleportPoint tpPoint;

    void Awake()
    {
        ControllerL = GameObject.FindGameObjectWithTag("LeftShark");
        tpPoint = ControllerL.GetComponent<TeleportPoint>();
    }

    void Update()
    {
        if(tpPoint.daPortal != null)
        {
            tpPoint.daPortal.transform.LookAt(tpPoint.eyes.transform);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
          if (SceneManager.GetActiveScene().name == "Starting Scene")
          {
            SceneManager.LoadScene(playScene);
          }
          else
          {
            other.transform.root.transform.position = targetTeleport - head.transform.localPosition;
            Destroy(gameObject);
          }

        }
    }
}
