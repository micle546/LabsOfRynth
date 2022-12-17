using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Interactable
{
    [SerializeField]
    private float amount = 10f;
    [SerializeField]
    private float time = 10f;
    [SerializeField]
    private bool isReuseable = false;

    private float boostTimeRemaining = 0f;

    protected override void Interact()
    {
        boostTimeRemaining += time;
        if (!isReuseable)
            this.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (boostTimeRemaining > 0f)
        {
            PlayerMotor.instance.speedBoost = amount;
            boostTimeRemaining -= Time.deltaTime;
        }
        else
        {
            boostTimeRemaining = 0f;
            PlayerMotor.instance.speedBoost = 0f;
        }
    }
}
