using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyTrigger : BaseTrigger {

    [SerializeField]
    int _cost;

    [SerializeField]
    TextMesh _costText;

   
    protected override void PlayerEnter()
    {
        base.PlayerEnter();
        Money.AddMoney(_cost);
        _costText.transform.parent = null;
        _costText.text = _cost + "$";
        _costText.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
