﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic; //For List

public class Grab : MonoBehaviour
{
    //The object that is grabed
    public GameObject GrabedObject;
    public GameObject GrabedObjectChild;

    //Maintaining physics for grabed objects
    public float FollowSmoothness = 0.01f;
    private Vector3 GrabedObjectStart;
    private Vector3 FollowVelocity = Vector3.zero;
    private bool SetOnce = true;

    //Keep track of throw velocity
    private Vector3 lastPos;
    [HideInInspector]
    public Vector3 vel;

    //Get access to the controller
    [HideInInspector]
    public StickController Stick;

    void Start()
    {
        Stick = GetComponent<StickController>();
        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        //Tracks the velocity in which will be applied to the throw
        vel = (transform.position - lastPos) / Time.fixedDeltaTime;
        lastPos = transform.position;

        UpdateGrab();
    }

    void UpdateGrab()
    {
        if (GrabedObject != null)
        {
            if (Stick.Controller.GetPress(Stick.GripyButton))
            {
                //Unequip
                GrabedObjectChild.GetComponent<EquipObject>().isHeld = true;
                if(GrabedObjectChild.GetComponent<EquipObject>().isEquiped == true)
                {
                    GrabedObject.GetComponent<Rigidbody>().isKinematic = false;
                    GrabedObjectChild.GetComponent<EquipObject>().isEquiped = false;
                }
                //Turns to a child
                GrabedObject.transform.parent = transform;
                //Set the point of collision at the start of the new child
                if(SetOnce == true)
                {
                    GrabedObjectStart = GrabedObjectChild.GetComponent<EquipObject>().FixedEquipedPosition;
                    GrabedObject.transform.localRotation = Quaternion.Euler(GrabedObjectChild.GetComponent<EquipObject>().FixedEquipedRotation.x, GrabedObjectChild.GetComponent<EquipObject>().FixedEquipedRotation.y, GrabedObjectChild.GetComponent<EquipObject>().FixedEquipedRotation.z);
                    SetOnce = false;
                }
                //Clamps 0 - 1
                FollowSmoothness = Mathf.Clamp01(FollowSmoothness);
                Vector3.SmoothDamp(GrabedObject.transform.position, transform.position - GrabedObjectStart, ref FollowVelocity, FollowSmoothness);


                GrabedObject.GetComponent<Rigidbody>().useGravity = false;
                GrabedObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                GrabedObject.GetComponent<Rigidbody>().velocity = FollowVelocity;
                GrabedObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            }

            if (Stick.Controller.GetPressUp(Stick.GripyButton))
            {
                GrabedObject.transform.SetParent(null);  
                GrabedObject.GetComponent<Rigidbody>().useGravity = true;
                GrabedObject.GetComponent<Rigidbody>().AddForce(vel * 100);
                SetOnce = true;
                GrabedObjectChild.GetComponent<EquipObject>().isHeld = false;
                GrabedObject = null;
                GrabedObjectChild = null;
            }
        }
    }

    //Collisions
    void OnTriggerEnter(Collider other)
    {
        //Take in even if its a child
        if (other.gameObject.layer == LayerMask.NameToLayer("Grabable"))
        {
            //Set the object's root as GrabedObject
            if (other.GetComponent<EquipObject>().Root.GetComponent<Rigidbody>() != null && GrabedObject == null)
            {
                GrabedObject = other.GetComponent<EquipObject>().Root.gameObject;
                GrabedObjectChild = other.gameObject;
            }
        }
    }
}
