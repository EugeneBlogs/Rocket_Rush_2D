using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersList : MonoBehaviour {


    public static void SetPlayerIndex(int index)
    {
        PlayerPrefs.SetInt("Player", index);
    }

    static int getIndex()
    {
        return PlayerPrefs.GetInt("Player");
    }

    [SerializeField]  List<GameObject> _players;
   

	void Awake () {

        foreach(var p in _players)
        {
            p.SetActive(false);
        }
      
        _players[getIndex()].SetActive(true);
        
	}


	
}
