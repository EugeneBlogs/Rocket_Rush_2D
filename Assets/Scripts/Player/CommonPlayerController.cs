using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonPlayerController : MonoBehaviour {

    bool _isAcel;
    int _turnDirection;

    [SerializeField] AudioSource _engineSound;
    [SerializeField] float _engineStop = 2f;

    private void Start()
    {
        UIEvents.Instance.StartAcelerateEvent += StartAceleration;
        UIEvents.Instance.StopAcelerateEvent += FinishAceleration;
        UIEvents.Instance.TurnEvent += Turn;
    }

    void FixedUpdate () {
         _isAcel = Input.GetButton("Vertical");
        if (Input.GetKey(KeyCode.A))
        {
            _turnDirection = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _turnDirection = 1;
        }
        else
        {
            _turnDirection = 0;
        }
       
        PlayerLogic.Instance.Acelerate(_isAcel);
        PlayerLogic.Instance.Turn(_turnDirection);
	}

    bool dontUsed;
    int num = 0;
    public void StartAceleration()
    {
        _isAcel = true;
        if (!_engineSound.isPlaying) _engineSound.Play();
        dontUsed = false;
    }
   
    public void FinishAceleration()
    {
        _isAcel = false;
        dontUsed = true;
        StartCoroutine(StopEngineSound(++num));
    }

    IEnumerator StopEngineSound(int n)
    {
        yield return new WaitForSeconds(_engineStop);
        if(n==num && dontUsed)
            _engineSound.Stop();
    }

    public void Turn(int direction)
    {
        _turnDirection = direction;
    }
}
