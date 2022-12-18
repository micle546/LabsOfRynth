using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour
{
    public float damageAmount = 10f;

    public float damageTime = 0.5f; //How often you want to damage to be done to the player
                                    //change to 0.25f for every quarter second/0.5f for half
    [SerializeField]
    private float currentDamageTime;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if (hit.gameObject.tag == "test")
        if (hit.gameObject.layer == 11)
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                PlayerUI.instance.TakeDamage(damageAmount);
                currentDamageTime = 0.0f;
                Debug.Log("lave hit");
            }
        }
    }

}
