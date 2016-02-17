using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	public int dmg = 1;


	void OnTriggerEnter2D(Collider2D col){

		if (col.isTrigger != true && col.CompareTag("Turret")) {

			col.SendMessageUpwards("Damage", dmg);
		}


		if(col.isTrigger && col.CompareTag("Chest")){
				
			col.SendMessageUpwards("OpenAnim", true);
		}

		if (col.isTrigger != true && col.CompareTag("Slime")) {
			
			col.SendMessageUpwards("Damage", dmg);
		}

		if (col.isTrigger != true && col.CompareTag("Yggdrasil")) {
			
			col.SendMessageUpwards("Damage", dmg);
		}

	}
}
