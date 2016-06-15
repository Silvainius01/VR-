using UnityEngine;
using System.Collections;

/// <summary>
/// This class will evolve to encompass an entire entity. 
/// It the resulting entity should ALWAYS contain various body parts
/// (two arms, two legs, and main body) as well as access to their animations.
/// 
/// This IS NOT the brain of an AI, just it's bodily controller. Brain stem, not pre-frontal cortex.
/// </summary>
public class Test : MonoBehaviour
{
    public Vector3 RotationSpeed = new Vector3(0, 0, 0);
    void Start()
    {
    }

    void Update()
    {
       transform.Rotate(new Vector3(RotationSpeed.x, RotationSpeed.y, RotationSpeed.z));
    }
} 