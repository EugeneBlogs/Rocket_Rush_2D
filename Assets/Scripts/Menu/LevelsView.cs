using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsView : MonoBehaviour
{

    [SerializeField]
    int index;
    [SerializeField]
    GameObject _lock;


    [SerializeField]
    List<Image> _stars;

    [SerializeField]
    Sprite _starSprite;

    [SerializeField]
    bool forseOpened = false;

    // Use this for initialization
    void Start()
    {
        bool opened = InformationAboutLevels.CheckIsOpened(index);
        if (!forseOpened)
        {
            _lock.SetActive(!opened);
            foreach (var s in _stars)
            {
                s.gameObject.SetActive(opened);
            }
        }
            
        int starsCount = InformationAboutLevels.GetStarsCount(index);

        Utility.ApplyStars(_stars, starsCount, _starSprite);
        GetComponent<Button>().onClick.AddListener(LoadLevelWithIndex);
    }

    public void LoadLevelWithIndex()
    {
        Menu.LoadLevel(index);
    }

}