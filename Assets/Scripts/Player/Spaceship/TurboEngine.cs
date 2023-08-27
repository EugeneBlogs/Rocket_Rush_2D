using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboEngine : BaseEngine {


    [SerializeField]
    float waste;

    public override void Acelerate(bool isAcel)
    {
        if (Player.Instance.HasFuel()&&isAcel)
        {
            base.Acelerate(isAcel);
            Player.Instance.WasteFuel(waste);
        }
        else
        {
            base.Acelerate(false);
        }
    }

   
}
