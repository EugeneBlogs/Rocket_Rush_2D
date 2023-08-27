using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTrigger : BaseTrigger {

    protected override void PlayerEnter()
    {
        base.PlayerEnter();
        Player.Instance.Demage();
    }
}
