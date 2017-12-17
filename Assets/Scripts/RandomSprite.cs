using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class RandomSprite : MonoBehaviour {

	public List<Sprite> toSwapAtRandom;

	void Awake () {
		if(toSwapAtRandom.Count>0)
			GetComponent<SpriteRenderer>().sprite = toSwapAtRandom[Random.Range(0,toSwapAtRandom.Count)];
	}

}
