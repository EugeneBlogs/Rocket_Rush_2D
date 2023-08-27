using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public static LevelController Instance;

    public event Action onFinished = delegate { };
    public event Action onLoose = delegate { };
    public event Action onCollectStar = delegate { };

    public LevelModel LevelModel;
    
    int _index;
    [SerializeField]
    List<int> _moneyForStars;

    void Awake()
    {
        Instance = this;
        LevelModel.starsCount = 1;
    }

    private void Start()
    {
        _index = GlobalLevelController.Instance.GetIndex();
    }

    public void FinishLevel()
    {
        if (LevelModel.loosed)
            return;
        onFinished();
        LevelModel.complited = true;
        ApplyStars();
        Money.AddMoney(EarnedMoney());
    }

    void ApplyStars()
    {
        if (LevelTimer.Instance.HasTime()) ++LevelModel.starsCount;
        InformationAboutLevels.SetStarCount(_index,LevelModel.starsCount);
    }

    public void CollectStar()
    {
        onCollectStar();
        LevelModel.starsCount = 2;
    }
    public void LooseLevel()
    {
        if (!LevelModel.complited)
        {
            onLoose();
            LevelModel.loosed = true;
        }
            
    }

    public int EarnedMoney()
    {
        return _moneyForStars[Mathf.Min(LevelModel.starsCount - 1,2)];
    }

    int st = 0;
    //для промо, не используй его
    public void AddStar()
    {
         ++st;
        InformationAboutLevels.SetStarCount(_index, st);
    }
}
