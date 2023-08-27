using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinViewer : MonoBehaviour {

    [SerializeField]
    List<Image> _stars;
    [SerializeField] Sprite _starSprite;
    [SerializeField]
    Text _moneyText;

    
    // Use this for initialization
    void Start () {
        Utility.ApplyStars(_stars, LevelController.Instance.LevelModel.starsCount, _starSprite);
        _moneyText.text = LevelController.Instance.EarnedMoney() + "$";
	}
}
