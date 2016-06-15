using UnityEngine;
using System.Collections;

public class CivillianBrain : MonoBehaviour
{
    public s_CivType Behavior;
    public Animator THEanimator;








    /// <summary>
    ///     The civillian type controls the Behavior of any given civillian.
    ///          
    /// </summary>
    /*
     *  TRADER: Runs a market stall, "sells" various objects to WANDER civs.
     *  WANDER: Wanders around the city, gives to POOR civs, gets attacked by THEIF civs, and "buys" stuff from TRADER civs.
     *  POOR: Sits on varous corners, begging for food or coin.
     *  THEIF: Attacks WANDER civs and "steals" objects from them. Guards will attack them if they get seen or reported. Chance to turn a WANDER into a POOR civ.
     */
    public enum s_CivType { TRADER, WANDER, THEIF, POOR }

    void ai_Trader()
    {
        /* Animation Bullshit */ 
    }

    void ai_Wander()
    {
        /* Animation Wander */
        
        if (Input.GetKey("Down")) THEanimator.SetBool("s_IsWalking", true);
        else THEanimator.SetBool("s_IsWalking", false);

    }
    //void ai_Poor() { }
   // void ai_Theif() { }

    void Start() { }
    void Update() { }
}
