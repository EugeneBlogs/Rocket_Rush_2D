using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEngine : MonoBehaviour {


    [SerializeField]
    protected float a_power = 1;

    protected PlayerLogic a_player;

    protected Rigidbody2D a_rig;

    public bool IsAcelerate;

    public virtual void Acelerate(bool isAcel)
    {
        if (isAcel)
        {
            a_rig.AddForceAtPosition(transform.up * a_power*Time.deltaTime*50, transform.position);
        }
        IsAcelerate = isAcel;
       
    }

   

    public void SetPlayer(PlayerLogic pl)
    {
        a_player = pl;
        a_rig = pl.GetComponent<Rigidbody2D>();
    }

}
