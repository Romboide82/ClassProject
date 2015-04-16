using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}

	void ToGame(){
		GameObject.Find ("GameController").GetComponent<SceneTransition> ().invokeMethod ("ToGame", 0);
	}
}
