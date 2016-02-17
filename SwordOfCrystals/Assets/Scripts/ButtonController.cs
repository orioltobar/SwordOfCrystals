using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Test(){

		print ("Test");

	}


	public void ChangeToScene(string s){


		Application.LoadLevel (s);

	}




}
