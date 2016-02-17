using UnityEngine;
using System.Collections;

public class GemController : MonoBehaviour {

	private Animator gemAnim;

	private float shinningTimer = 2.0f;

	public GameObject GreenGem;
	public GameObject RedGem;
	public GameObject BlackGem;

	public bool isRed = false;
	public bool isGreen = false;
	public bool isBlack = false;

	void Start () {
	
		gemAnim = gameObject.GetComponent<Animator> ();
	}
	

	void Update () {
	
		if (shinningTimer > 0) {


			gemAnim.SetBool("Shinning", false);
			shinningTimer -= Time.deltaTime;
		}

		if (shinningTimer <= 0) {


			gemAnim.SetBool("Shinning", true);
			shinningTimer = 2.0f;

		}
	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.CompareTag("Player") && GreenGem){

			Destroy (gameObject);
			isGreen = true;
			print ("gema verde");
			PlayerPrefs.SetInt("GreenGemSinCo", 1);

		}

		if(col.CompareTag("Player") && RedGem){
			
			Destroy (gameObject);
			isRed = true;
			print ("gema roja");
			PlayerPrefs.SetInt("RedGemSinCo", 1);
		}

		if (col.CompareTag ("Player") && gameObject.CompareTag("BlackGem")) {
			print ("entra");
			Destroy (gameObject);
			isBlack = true;
			print ("gema negra");
			PlayerPrefs.SetInt("BlackGemSinCo", 1);
		}
	}
}
