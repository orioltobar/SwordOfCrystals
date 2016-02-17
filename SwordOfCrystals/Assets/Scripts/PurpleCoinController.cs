using UnityEngine;
using System.Collections;

public class PurpleCoinController : MonoBehaviour {

	private GameMaster gm;

	
	void Start () {
		
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
	}
	
	
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col){
		
		
		if(col.CompareTag("Player")){
			
			Destroy (gameObject);
			
			gm.points +=10;
			
		}
	}
}
