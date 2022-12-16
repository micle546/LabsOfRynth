using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour
{
    public float damageAmount = 10f;
    [SerializeField]
    private bool collideLava = false;
    
    private int lavaFloorLayer = 11;

    public float damageTime = 1.0f; //How often you want to damage to be done to the player
                                    //change to 0.25f for every quarter second/0.5f for half
    [SerializeField]
    private float currentDamageTime;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            collideLava = true;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
            collideLava = false;
    }

    void OnCollisionStay(Collision other)
    {
        if (collideLava)
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                PlayerUI.instance.TakeDamage(damageAmount);
                currentDamageTime = 0.0f;
            }
        }
    }

}
