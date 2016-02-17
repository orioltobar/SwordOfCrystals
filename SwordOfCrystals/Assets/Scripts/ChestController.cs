using UnityEngine;
using System.Collections;

public class ChestController : MonoBehaviour {

	public Animator chestAnim;
	public GameObject drop1,drop2,drop3;

	private float timer = 1.0f;

	private float lootChance;

	private bool dropped = false;
	void Start () {
	
		chestAnim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (chestAnim.GetBool ("Opened")) {

			timer -= Time.deltaTime;
		}

		if (timer <= 0 && dropped == false) {

			lootChance = Random.Range(0.0f,1.0f);

			if(lootChance > 0.5f){
				
				Instantiate(drop1, transform.position, transform.rotation);
			}else if(0.30f < lootChance && lootChance < 0.49f){
				
				Instantiate(drop2, transform.position, transform.rotation);
			}else if(0.0f < lootChance && lootChance < 0.29f){
				
				Instantiate(drop3, transform.position, transform.rotation);
			}
			dropped = true;
		}
	}

	public void OpenAnim(bool b){

		chestAnim.SetBool ("Opened", b);

	}
}
