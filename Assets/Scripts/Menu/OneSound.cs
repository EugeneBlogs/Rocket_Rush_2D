using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSound : MonoBehaviour {

    public static OneSound Instance;
    [SerializeField] int type;

    private void Awake()
    {

        if (Instance == null)
        {
            ChangeInstance();
        }
        else
        {
            if (type == Instance.type)
                Destroy(gameObject);
            else
            {
                Destroy(Instance.gameObject);
                ChangeInstance();
            }
                
        }

    }

    private void ChangeInstance()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
}
