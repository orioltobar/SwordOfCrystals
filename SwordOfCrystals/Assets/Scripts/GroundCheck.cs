﻿using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private Player player;

	void Start(){

		player = gameObject.GetComponentInParent<Player> ();

	}

//	void OnTriggerEnter2D(Collider2D col){
//
//
//		player.grounded = true;
//	}
//
//	void OnTriggerStay2D(Collider2D col){
//
//		player.grounded = true;
//	}
//
//	void OnTriggerExit2D(Collider2D col){
//
//		player.grounded = false;
//	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.isTrigger) {
			player.grounded = true;
		}
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if (!col.isTrigger) {
			player.grounded = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{

		if (!col.isTrigger) {
			player.grounded = false;
		}
	}
}
