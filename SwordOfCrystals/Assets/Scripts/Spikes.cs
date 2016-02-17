using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {
	
	private Player player;

	public bool hit = false;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.CompareTag ("Player")) {


			player.TakeDamage (1);

			if (player.doubleJump == false) {

				StartCoroutine (player.Knockback (0.02f, 300, player.transform.position, false));
			} else {

				StartCoroutine (player.Knockback (0.02f, 300, player.transform.position, true));

			}
		}
	}


}
