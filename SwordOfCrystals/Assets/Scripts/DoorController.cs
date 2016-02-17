using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoorController : MonoBehaviour {

	public int LevelToLoad;

	private GameMaster gm;

	private GemController gemCon;




	void Start () {

		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();

	}
	

	void Update () {
	

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.CompareTag ("Player")) {


		}


	}

	void OnTriggerStay2D(Collider2D col){
		
		if (col.CompareTag ("Player")) {

			if(PlayerPrefs.GetInt("GreenGemSinCo") == 1){

				PlayerPrefs.SetInt("GreenGem",1);
				PlayerPrefs.SetInt("GreenGemSinCo",0);
			}else{

				PlayerPrefs.SetInt("GreenGemSinCo",0);
			}

			if(PlayerPrefs.GetInt("RedGemSinCo") == 1){
				
				PlayerPrefs.SetInt("RedGem",1);
				PlayerPrefs.SetInt("RedGemSinCo",0);
			}else{
				
				PlayerPrefs.SetInt("RedGemSinCo",0);
			}

			if(PlayerPrefs.GetInt("BlackGemSinCo") == 1){
				
				PlayerPrefs.SetInt("BlackGem",1);
				PlayerPrefs.SetInt("BlackGemSinCo",0);
			}else{
				
				PlayerPrefs.SetInt("BlackGemSinCo",0);
			}


			Application.LoadLevel(LevelToLoad);

		}

		
	}

	void OnTriggerExit2D(Collider2D col){
		
		gm.inputText.text = "";

		
	}


}
