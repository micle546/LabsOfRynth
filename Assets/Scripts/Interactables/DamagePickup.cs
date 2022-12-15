using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickup : Interactable
{

    public float damageAmount = 10f;

    [SerializeField]
    //private GameObject door;
    private PlayerUI playerUI;


    public void Start()
    {
        playerUI = GameObject.FindWithTag("Player").GetComponent<PlayerUI>();
    }
    protected override void Interact()
    {
        playerUI.TakeDamage(damageAmount);
    }
}
