using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public Object scene;
	// Update is called once per frame
	void OnTriggerEnter2D () {
		SceneManager.LoadScene (scene.name);
	}
}
