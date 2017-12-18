using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class MarkingBehavior : MonoBehaviour {

	public KeyCode markingKey = KeyCode.DownArrow;
	public KeyCode swapKey = KeyCode.E;
	public float maxMarkableDistance = 2.0f;

	public Color[] markingColors = {Color.blue, Color.red};

	public List<TerrainChunk> selections = new List<TerrainChunk> ();


	//private LineRenderer lineRenderer;

	void Start(){
		//lineRenderer = gameObject.GetComponent<LineRenderer> ();
	}

	void Update(){
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyUp(markingKey)){
			Debug.DrawLine (transform.position, transform.position+ Vector3.down, Color.red,2,false);
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, maxMarkableDistance + 0.1f,LayerMask.NameToLayer("Ground"));
			if(hit.collider!=null){
				Vector2 markPosition = hit.collider.gameObject.transform.position;
				TerrainChunk tc = TerrainSelector.SelectSquare (new Vector2(markPosition.x-1,markPosition.y),new Vector2(markPosition.x+2,markPosition.y+3));
				if (selections.Count <= 0) {
					tc.MarkChunk (GetColour());
					selections.Add (tc);
				} else if (selections.Count == 1) {
					if (tc.isMarked) {
						foreach(Markable mkble in tc.terrains){
							TerrainChunk wasIn = SelectedTerrainWasIn (mkble);
							if (wasIn != null) {
								wasIn.UnMarkChunk ();
								selections.Remove (wasIn);
							}
						}
					} else {
						tc.MarkChunk (GetColour());
						selections.Add (tc);
					}
				} else if (selections.Count == 2) {
					if (tc.isMarked) {
						foreach(Markable mkble in tc.terrains){
							TerrainChunk wasIn = SelectedTerrainWasIn (mkble);
							if (wasIn != null) {
								wasIn.UnMarkChunk ();
								selections.Remove (wasIn);
							}
						}
					} else {
						selections [0].UnMarkChunk ();
						selections.RemoveAt (0);
						tc.MarkChunk (GetColour());
						selections.Add (tc);
					}
				}
			}
		}
		if(Input.GetKeyUp(swapKey)){
			Swap ();
		}
	}

	private Color GetColour(){
		if (selections.Count <= 0) {
			return Color.blue;
		} else {
			foreach(TerrainChunk tc in selections){
				if(tc.MarkedColour == Color.red){
					return Color.blue;
				}
			}
			return  Color.red;
		}
	}

	private TerrainChunk SelectedTerrainWasIn(Markable marked){
		foreach(TerrainChunk tc in selections){
			if(tc.Contains(marked)){
				return tc;
			}
		}
		return null;
	}

	private void Swap(){
		if(selections.Count>1){
			for(int i=0;i<selections[0].terrains.Count;i++){
				Vector2 temp = new Vector2 (selections [0].terrains [i].gameObject.transform.position.x, selections [0].terrains [i].gameObject.transform.position.y);
				selections [0].terrains [i].gameObject.transform.position = selections [1].terrains [i].gameObject.transform.position;
				selections[1].terrains [i].gameObject.transform.position = temp;
			}
		}
	}


}
