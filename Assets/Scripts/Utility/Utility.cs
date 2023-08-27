using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Utility {

	public static void ApplyStars(List<Image> stars,int cnt,Sprite star){
		for(int i = 0;i<cnt;++i){
			stars[i].sprite = star;
		}
	}
}
