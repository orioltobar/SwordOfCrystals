using UnityEngine;
using System.Collections;

public class YggdrasilController : MonoBehaviour {

	public int maxHealth;
	public int currHealth;

	public bool facingRight;
	public bool magic;
	private bool damaged;

	private Rigidbody2D rb2d;

	private float maxSpeed = 2;
	private float speed = 50f;
	private float dmgCoolDown = 1.5f;

	public Animator yggAnim;

	private YggdrasilAttack yggCone;


	void Awake(){

		yggAnim = gameObject.GetComponent<Animator> ();
		yggCone = gameObject.GetComponentInChildren<YggdrasilAttack> ();
	}

	void Start () {
	
		currHealth = maxHealth;
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	void Update () {

		if (currHealth <= 0) {

			Destroy (transform.gameObject);
		}

		if (damaged) {

			dmgCoolDown -= Time.deltaTime;
		}

		if (dmgCoolDown <= 0) {

			damaged = false;
			dmgCoolDown = 1.5f;
		}

	

	}

	void FixedUpdate(){
		
		Vector3 fakeFriction = rb2d.velocity;
		
		fakeFriction.y = rb2d.velocity.y;
		fakeFriction.z = 0.0f;
		fakeFriction.x *= 0.40f;
		
		if (!yggCone.attack && !magic) {

			if (facingRight) {

				yggAnim.SetBool ("Walking", true);
				//transform.localScale = new Vector3 (-1, 1, 1);
				float h = -1.0f;	
				rb2d.AddForce ((Vector2.right * speed) * h);
			} else {

				yggAnim.SetBool ("Walking", true);
				//transform.localScale = new Vector3 (1, 1, 1);
				float h = 1.0f;	
				rb2d.AddForce ((Vector2.right * speed) * h);
			}

		} else {

			yggAnim.SetBool ("Walking", false);
			rb2d.AddForce ((Vector2.right * speed) * 0);

		}


		if (rb2d.velocity.x > maxSpeed) {
			

			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		
		if (rb2d.velocity.x < -maxSpeed) {
			
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
		
		
		rb2d.velocity = fakeFriction;
		
	}

	void OnTriggerEnter2D(Collider2D col){
		
		
		if (col.gameObject.name == "TriggerLeft") {
			
			transform.localScale = new Vector3 (1, 1, 1);
			facingRight = false;
			magic = true;
		}
		
		if (col.gameObject.name == "TriggerRight") {
			
			transform.localScale = new Vector3 (-1, 1, 1);
			facingRight = true;
			magic = true;

		}
		
	}

	public void Damage(int dmg){
		
		if (dmgCoolDown == 1.5f) {

			currHealth -= dmg;
			damaged = true;
		}

		
	}

	public void ChangeDirection(string s){

		if (s == "left") {

			transform.localScale = new Vector3 (1, 1, 1);
			facingRight = false;


		} else if (s == "right") {

			transform.localScale = new Vector3 (-1, 1, 1);
			facingRight = true;

		}

	}
}
