using UnityEngine;
using System.Collections;

public class YggdrasilCollider : MonoBehaviour {
	

	private Player player;
	private YggdrasilController yggdrasil;

	private bool dmg = false;
	
	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		yggdrasil = GameObject.FindGameObjectWithTag ("Yggdrasil").GetComponent<YggdrasilController> ();
	}
	
	
	void Update () {



	}
	
	void OnTriggerEnter2D(Collider2D col){
		
		
		if (col.CompareTag ("Player")) {

			player.TakeDamage(1);

			if(yggdrasil.facingRight == true){

				StartCoroutine (player.Knockback (-0.02f, -300, player.transform.position, false));
			}else{
				StartCoroutine (player.Knockback (0.02f, 300, player.transform.position, false));
			}
			
		}
		
		
	}


	
}
