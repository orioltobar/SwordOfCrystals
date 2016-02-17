using UnityEngine;
using System.Collections;

public class RecoverController : MonoBehaviour {


	private Player pl;


	void Start () {
	
		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){


		if (col.CompareTag ("Player")) {

			if(gameObject.CompareTag("ManaPotion")){

				pl.currentMana = 3;
				Destroy(gameObject);

			}

			if(gameObject.CompareTag("Heart")){

				pl.currentHealth += 1;
				Destroy (gameObject);

			}

		}

	}
}
