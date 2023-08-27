using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
       
        if(col.tag == "Player")
        {
            PlayerEnter();
        }
        if(col.tag == "Leg")
        {
            LegEnter();
        }
        if(col.tag == "Platform")
        {
            PlatformEnter();
        }
    }

    protected virtual void PlayerEnter()
    {

    }
    protected virtual void LegEnter()
    {

    }
    protected virtual void PlatformEnter()
    {

    }
}
