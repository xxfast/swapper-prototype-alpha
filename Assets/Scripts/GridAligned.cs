using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class GridAligned : MonoBehaviour
{

	public static GameObject[,] cells = new GameObject[100, 100];

	public float cell_size = 1f;
	private float x, y, z;

	void Update ()
	{
		x = Mathf.Round (transform.position.x / cell_size) * cell_size;
		y = Mathf.Round (transform.position.y / cell_size) * cell_size;
		z = transform.position.z;
		transform.position = new Vector3 (x, y, z);
		if (x > 0 && y > 0 && x < GridAligned.cells.GetLength (0) && y < GridAligned.cells.GetLength (1))
			cells [(int)x, (int)y] = this.gameObject;
	}
}
