using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public int currHealth;
	public int maxHealth;

	public float distance;
	public float wakeRange;
	public float shootInterval;
	public float fireSpeed = 100;
	public float fireTimer;


	public bool awake = false;
	private bool dmgTurret = false;


	public GameObject fire;
	public Transform target;
	public Animator turretAnim;
	public Transform fireLeft,fireRight;
	
	public GameObject drop;

	private float lootChance;

	void Awake(){

		turretAnim = gameObject.GetComponent<Animator> ();


	
	}

	void Start () {
	
		currHealth = maxHealth;
	}
	

	void Update () {




		turretAnim.SetBool ("Awake", awake);

		RangeCheck ();

		if (currHealth <= 0) {

			Destroy(gameObject);

			lootChance = Random.Range(0.0f,1.0f);

			if(lootChance > 0.3f){

				Instantiate(drop, transform.position, transform.rotation);
			}
		}

		if (dmgTurret == true) {

			turretAnim.SetBool("Damaged", false);
			dmgTurret = false;
		}

	}

	void RangeCheck(){

		distance = Vector3.Distance (transform.position, target.transform.position);

		if (distance < wakeRange) {

			awake = true;
		}

		if (distance > wakeRange) {
			
			awake = false;
		}
	}

	public void Attack(bool atkRight){

		fireTimer += Time.deltaTime;

		if (fireTimer >= shootInterval) {

			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize();

			if(!atkRight){

				GameObject fireClone;
				fireClone = Instantiate(fire, fireLeft.transform.position, fireLeft.transform.rotation) as GameObject;
				fireClone.transform.localScale = new Vector3(-1,1,1);
				fireClone.GetComponent<Rigidbody2D>().velocity = direction * fireSpeed;


				fireTimer = 0;
			}

			if(atkRight){

				GameObject fireClone;
				fireClone = Instantiate(fire, fireRight.transform.position, fireRight.transform.rotation) as GameObject;
				fireClone.GetComponent<Rigidbody2D>().velocity = direction * fireSpeed;


				fireTimer = 0;

			}

		}
	}

	public void Damage(int dmg){

		currHealth -= dmg;
		turretAnim.Play ("Enemy_Damage",-1,0f);
		turretAnim.SetBool ("Damaged", true);
		dmgTurret = true;

	}
}
