using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {


	public float fireLife;
	public bool fired;

	void Start(){


	}


	void OnTriggerEnter2D(Collider2D col){


		if (col.isTrigger != true) {

			if(col.CompareTag("Player")){

				col.GetComponent<Player>().TakeDamage(1);
				Destroy (gameObject);
			}
		}
	}
}
