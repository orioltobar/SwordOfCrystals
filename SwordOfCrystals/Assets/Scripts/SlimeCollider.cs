using UnityEngine;
using System.Collections;

public class SlimeCollider : MonoBehaviour {


	private Player player;
	
	
	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){


		if (col.CompareTag ("Player")) {


			player.TakeDamage(1);
			StartCoroutine (player.Knockback (0.02f, 300, player.transform.position, false));

		}


	}

}
