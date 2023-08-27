using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour {

    public static PlayerLogic Instance;

    [SerializeField]
    List<TurboEngine> _turboEngines;

    [SerializeField]
    List<TurnEngine> _leftEngies;

    [SerializeField] List<TurnEngine> _rightEngines;

    [SerializeField]
    Transform _centerOfMass;

    void Awake()
    {
        Instance = this;
        GetComponent<Rigidbody2D>().centerOfMass = _centerOfMass.localPosition;
    }     

	void Start ()
    {
        ApplyAllEngines();
    }

    private void ApplyAllEngines()
    {
        ApplyEngine(_turboEngines.ConvertAll(x => (BaseEngine)x));
        ApplyEngine(_leftEngies.ConvertAll(x => (BaseEngine)x));
        ApplyEngine(_rightEngines.ConvertAll(x => (BaseEngine)x));
    }


    public void Acelerate(bool isAcel)
    {
        Acelerate(_turboEngines.ConvertAll(x=>(BaseEngine)x),isAcel);
    }


    public void Turn(int direction)
    {      
        Acelerate(_leftEngies.ConvertAll(x => (BaseEngine)x),direction == 1);
        Acelerate(_rightEngines.ConvertAll(x => (BaseEngine)x),direction == -1);
    }


    void Acelerate(List<BaseEngine> engines,bool isAcel)
    {
        foreach(var e in engines)
        {
            e.Acelerate(isAcel);
        }
    }

    void ApplyEngine(List<BaseEngine> engines)
    {
        foreach (var e in engines)
        {
            e.SetPlayer(this);
        }
    }
}