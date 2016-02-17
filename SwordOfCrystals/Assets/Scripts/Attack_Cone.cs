using UnityEngine;
using System.Collections;

public class Attack_Cone : MonoBehaviour {

	public Turret turrAI;

	public bool isLeft = false;

	void Awake(){

		turrAI = gameObject.GetComponentInParent<Turret> ();
	}

	void OnTriggerStay2D(Collider2D col){

		if (col.CompareTag ("Player")) {

			if(isLeft){

				turrAI.Attack(false);
			}else{

				turrAI.Attack(true);
			}
		}
	}
}
