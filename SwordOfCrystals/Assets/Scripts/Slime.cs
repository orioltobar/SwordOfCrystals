using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour {

	public int currHealth;
	public int maxHealth;

	private Rigidbody2D rb2d;

	private float maxSpeed = 2;
	private float speed = 50f;
	private float dmgTimer = 2.0f;
	private float lootChance;

	private bool facingRight = true;
	public bool dmgSlim;

	public GameObject triggerLeft, triggerRight;

	private Vector3 positionLeft, positionRight;

	public Animator slimAnim;

	public GameObject drop1,drop2,drop3;

	void Awake(){

		slimAnim = gameObject.GetComponent<Animator> ();
	}
	void Start () {
	
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		currHealth = maxHealth;
	}
	

	void Update () {
	
		if (currHealth <= 0) {

			Destroy (transform.parent.gameObject);

			lootChance = Random.Range(0.0f,1.0f);

			if(lootChance > 0.4f){
				
				Instantiate(drop1, transform.position, transform.rotation);
			}else if(0.2f < lootChance && lootChance < 0.39f){

				Instantiate(drop2, transform.position, transform.rotation);
			}else if(0.0f < lootChance && lootChance < 0.19f){

				Instantiate(drop3, transform.position, transform.rotation);
			}
		}

		if (dmgSlim == true && dmgTimer > 0) {

			dmgTimer -= Time.deltaTime;
		}

		if (dmgTimer <= 0) {

			slimAnim.SetBool("Damaged", false);
			dmgSlim = false;
			dmgTimer = 2.0f;
		}
	
	}

	void FixedUpdate(){

		Vector3 fakeFriction = rb2d.velocity;
		
		fakeFriction.y = rb2d.velocity.y;
		fakeFriction.z = 0.0f;
		fakeFriction.x *= 0.40f;

		if (facingRight) {

			float h = -1.0f;	
			rb2d.AddForce ((Vector2.right * speed) * h);
		} else {

			float h = 1.0f;	
			rb2d.AddForce ((Vector2.right * speed) * h);
		}
		
		
		if (rb2d.velocity.x > maxSpeed) {

			print ("entra");
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		
		if (rb2d.velocity.x < -maxSpeed) {
			
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
		

		rb2d.velocity = fakeFriction;

	}

	void OnTriggerEnter2D(Collider2D col){


			if (col.gameObject.name == "TriggerLeft") {

				transform.localScale = new Vector3 (-1, 1, 1);
				facingRight = false;
			}

			if (col.gameObject.name == "TriggerRight") {
			
				transform.localScale = new Vector3 (1, 1, 1);
				facingRight = true;
			}

	}

	public void Damage(int dmg){
		
		currHealth -= dmg;
		slimAnim.SetBool ("Damaged", true);
		dmgSlim = true;
		
	}
}
