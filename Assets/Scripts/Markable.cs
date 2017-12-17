using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Markable : MonoBehaviour {

	public bool isMarked = false;

	public GameObject UnMark(){
		isMarked = false;
		return ChangeColour (Color.white);
	}
	public GameObject Mark(Color toRender){
		isMarked = true;
		return ChangeColour (toRender);
	}

	private GameObject ChangeColour(Color toRender){
		//GetComponent<SpriteRenderer> ().color = toRender;
		return this.gameObject;
	}

}
