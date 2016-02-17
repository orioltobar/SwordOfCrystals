using UnityEngine;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public GameObject panelError;

	// Use this for initialization
	void Awake(){

		panelError.SetActive (false);
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Reset(int i){

		if (i == 0) {
			panelError.SetActive(true);
		}

		if (i == 1) {

			PlayerPrefs.DeleteAll();
			panelError.SetActive(false);
		}

		if (i == 2) {

			panelError.SetActive(false);
		}

	}
}
