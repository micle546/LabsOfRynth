using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealth : Interactable
{

    public float amount = 10f;
    public bool isReuseable = false;

    protected override void Interact()
    {
        PlayerUI.instance.maxHealth += amount;
        PlayerUI.instance.RestoreHealth(amount);
        if (!isReuseable)
            this.gameObject.SetActive(false);

    }
}
