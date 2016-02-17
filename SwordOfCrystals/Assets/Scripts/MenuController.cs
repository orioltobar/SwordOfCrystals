using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {


	public GameObject greenGem, redGem, blackGem;
	public GameObject panelError;

	// Use this for initialization

	void Awake() {

		panelError.SetActive (false);

		if (PlayerPrefs.GetInt ("GreenGem") == 1) {

			greenGem.SetActive (true);
		} else {
			greenGem.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("RedGem") == 1) {
			
			redGem.SetActive (true);
		} else {
			redGem.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("BlackGem") == 1) {
			
			blackGem.SetActive (true);
		} else {
			blackGem.SetActive (false);
		}
	}

	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BossLevel(){

		if (PlayerPrefs.GetInt ("GreenGem") == 1 && PlayerPrefs.GetInt ("RedGem") == 1 && PlayerPrefs.GetInt ("BlackGem") == 1) {

			Application.LoadLevel ("BossLevel");
		} else {

			panelError.SetActive(true);
		}


	}

	public void CloseErrorPanel(){

		panelError.SetActive (false);
	}
}
