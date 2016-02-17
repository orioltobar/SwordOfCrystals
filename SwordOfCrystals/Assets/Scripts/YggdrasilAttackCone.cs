using UnityEngine;
using System.Collections;

public class YggdrasilAttackCone : MonoBehaviour {

	private YggdrasilAttack yggdrasil;
	private YggdrasilController yggController;

	private float insideColTimer = 1.5f;

	private bool insideCol = false;
	

	// Use this for initialization
	void Start () {
	
		yggdrasil = GameObject.FindGameObjectWithTag ("Yggdrasil").GetComponent<YggdrasilAttack> ();
		yggController = GameObject.FindGameObjectWithTag ("Yggdrasil").GetComponent<YggdrasilController> ();
	}
	
	// Update is called once per frame
	void Update () {

//		print (insideColTimer);
		if (insideCol) {

			insideColTimer -= Time.deltaTime;
		}

		if (insideColTimer <= 0) {

			if(!yggController.facingRight){
			
				yggController.ChangeDirection("right");
			}else{

				yggController.ChangeDirection("left");
			}

			insideColTimer = 1.5f;
		}
	}

	void OnTriggerEnter2D(Collider2D col){


		if (col.CompareTag ("Player")) {
			print (col.tag);
			yggdrasil.attack = true;
			//insideCol = true;
		}

	}

	void OnTriggerStay2D(Collider2D col){
		
		if (col.CompareTag ("Player")) {

			insideCol = true;
			//print ("atk true");
			//yggController.ChangeDirection("right");
			//yggdrasil.attacking = false;
			//yggdrasil.attack = true;
		} else {

			//yggdrasil.attack = false;
		}
	}

	void OnTriggerExit2D(Collider2D col){

		if (col.CompareTag ("Player")) {
			print ("sale");
			yggdrasil.attack = false;
			insideCol = false;

		}

	}
}
