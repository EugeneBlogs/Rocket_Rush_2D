using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : BaseTrigger {
    protected override void PlayerEnter()
    {
        Player.Instance.Kill();
    }

}
