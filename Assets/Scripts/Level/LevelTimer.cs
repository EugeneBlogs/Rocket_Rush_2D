using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

    public static LevelTimer Instance;

    [SerializeField] float _maxTime;
    float _currentTime;

    [SerializeField] Image _timer;
    [SerializeField] Image _arrow;
    [SerializeField] Sprite _timerWaste;
    [SerializeField] Sprite _arrowWaste;

    bool changed;

    void Awake()
    {
        Instance = this;
        _currentTime = _maxTime;
    }

    void Start()
    {
        LevelController.Instance.onFinished += Stop;
    }
	
    public bool HasTime()
    {
        return _currentTime > 0;
    }

    void Update()
    {
        if (!changed)
        {
            _currentTime -= Time.deltaTime;
            UpdateView();
        }
        
    }

    void UpdateView()
    {
        if (HasTime())
        {
            var rot = _arrow.transform.eulerAngles;
            rot.z = TimeAgo10() * 360;
            _arrow.transform.eulerAngles = rot;
        }
        else
        {
            Stop();
            var rot = _arrow.transform.eulerAngles;
            rot.z = 0;
            _arrow.transform.eulerAngles = rot;
            _timer.sprite = _timerWaste;
            _arrow.sprite = _arrowWaste;
        }
    }

    float TimeAgo10()
    {
        return _currentTime / _maxTime;
    }

    public void Stop()
    {
        changed = true;
    }
}
