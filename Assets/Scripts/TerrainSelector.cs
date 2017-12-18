using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSelector : ScriptableObject {

	public static TerrainChunk SelectCircle(Vector2 center, float radius){
		TerrainChunk toReturn = TerrainChunk.CreateInstance<TerrainChunk>();

		return toReturn;
	}
	public static TerrainChunk SelectSquare(Vector2 from, Vector2 to){
		TerrainChunk toReturn = TerrainChunk.CreateInstance<TerrainChunk>();
		int gl1 = GridAligned.cells.GetLength (0);
		int gl2 = GridAligned.cells.GetLength (1);
		for(int x=(int)from.x;x<(int)to.x;x++){
			for(int y=(int)from.y;y<(int)to.y;y++){
				if (x > 0 && y > 0 && x < gl1 && y < gl2) {
					if(GridAligned.cells[x,y]!=null)
						if(GridAligned.cells [x, y].GetComponent<Markable> ())
							toReturn.terrains.Add (GridAligned.cells [x, y].GetComponent<Markable> ());
				}
			}
		}
		return toReturn;
	}


}
