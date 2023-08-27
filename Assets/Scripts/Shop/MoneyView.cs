using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour {

    [SerializeField]
    Text _moneyText;

    [SerializeField] 
    Text _cristalsText;


	// Use this for initialization
	void Start () {
        UpdateText();
        Money.onMoneyChanged += UpdateText;
	}
	
	void UpdateText () {
        _moneyText.text = Money.MoneyLeft().ToString();
        _cristalsText.text = Money.CristalsLeft().ToString();
	}

    void OnDestroy()
    {
        Money.onMoneyChanged -= UpdateText;
    }
}
