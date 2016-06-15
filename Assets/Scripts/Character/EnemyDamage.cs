using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    public float CurrentHealth = 100;

	
	// Update is called once per frame
	void Update ()
    {
        if (CurrentHealth <= 0) Destroy(gameObject);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Weapon") CurrentHealth -= 25;
    }
}
