using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSpeedIncrease : Interactable
{
    [SerializeField]
    private float amount = 0.5f;
    [SerializeField]
    private bool isReuseable = false;


    protected override void Interact()
    {
        PlayerMotor.instance.speedUpgrade += amount;
        if (!isReuseable)
            this.gameObject.SetActive(false);

    }
}
