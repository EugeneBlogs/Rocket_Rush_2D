using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCard : MonoBehaviour {


    static string ROCKET = "FFDSD";
    public RocketModel parameters;
    public int index;

    [SerializeField]
    GameObject _openState;
    [SerializeField]
    GameObject _clouseState;
    [SerializeField]
    Text _costText;
    [SerializeField]
    Image _image;
    [SerializeField]
    Text _title;

    bool _opened;
    static int nextLevel = 2;
    void Start ()
    {
        CheckIsOppened();
        ApplyParameters();
        ApplyPanel();
    }

    private void ApplyParameters()
    {
        _costText.text = parameters.cost.ToString() + "$";
        _image.sprite = parameters.image;
        _title.text = parameters.title;
    }

    private void CheckIsOppened()
    {
        _opened = PlayerPrefs.GetInt(ROCKET + index) == 1;
        if (index == 0) _opened = true;
    }

    void Open()
    {
        _opened = true;
        PlayerPrefs.SetInt(ROCKET + index, 1);
        ApplyPanel();
    }

    void ApplyPanel()
    {
        _openState.SetActive(_opened);
        _clouseState.SetActive(!_opened);
    }

    public void Buy()
    {
        if (Money.CanBuy(parameters.cost))
        {
            Money.WasteMoney(parameters.cost);
            Open();
        }
    }

    public void Choose()
    {
        PlayersList.SetPlayerIndex(index);
        Menu.LoadNewLevelStatic(nextLevel);
    }
}
