using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class TerrainChunk : ScriptableObject {

	public List<Markable> terrains = new List<Markable>();
	public Color markedColour = Color.white;

	public Color MarkedColour {
		get {
			return markedColour;
		}
		set {
			markedColour = value;
		}
	}

	public TerrainChunk MarkChunk(Color toMark){
		markedColour = toMark;
		foreach(Markable terrain in terrains){
			terrain.Mark (toMark);
		}
		Glow(true,(toMark==Color.blue?1:2));
		return this;
	}

	public TerrainChunk UnMarkChunk(){
		markedColour = Color.white;
		foreach(Markable terrain in terrains){
			terrain.UnMark ();
		}
		Glow(false,0);
		return this;
	}

	public bool isMarked{
		get {
			foreach(Markable marked in terrains){
				if(marked.isMarked){
					return true;
				}
			}
			return false;
		}
	}

	public void Glow(bool set, int colour){
		foreach(Markable marked in terrains){
			if (set == false) {
				if (marked.gameObject.GetComponent<Outline> ()) {
					Destroy (marked.gameObject.GetComponent<Outline> ());
				}
			} else {
				if (!marked.gameObject.GetComponent<Outline> ()) {
					marked.gameObject.AddComponent<Outline> ();
				}
				marked.gameObject.GetComponent<Outline> ().color = colour;
			}
		}
	}

	public bool Contains(Markable toCheck){
		return terrains.Contains(toCheck);
	}


}
