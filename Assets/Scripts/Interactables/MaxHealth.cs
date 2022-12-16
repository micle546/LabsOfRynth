using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealth : Interactable
{

    public float amount = 10f;

    protected override void Interact()
    {
        PlayerUI.instance.maxHealth += amount;
        PlayerUI.instance.RestoreHealth(amount);
    }
}
