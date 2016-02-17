using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.isTrigger != true && col.CompareTag("Turret")) {
			
			col.GetComponentInParent<Turret>().Damage(1);
			Destroy (gameObject);
		}

		if (col.isTrigger != true && col.CompareTag("Slime")) {
			
			col.GetComponentInParent<Slime>().Damage(1);
			Destroy (gameObject);
		}

		if (col.isTrigger != true && col.CompareTag("Yggdrasil")) {
			
			col.GetComponent<YggdrasilController>().Damage(1);
			Destroy (gameObject);
		}
	}
}
