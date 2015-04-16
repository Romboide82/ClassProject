using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {

	public void invokeMethod(string methodName, float second){
		Invoke (methodName, second);
	}

	public void ToStartMenu(){
		Application.LoadLevel ("StartMenu");
	}

	public void ToGame(){
		Application.LoadLevel ("InGame");
	}
}
