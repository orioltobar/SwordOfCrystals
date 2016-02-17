using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 50f;
	public float jumpPower = 2000f;
	public float maxSpeed = 3;
	public float dmgAnim = 0.5f;
	public float doubleJumpSpeed;

	public bool grounded;
	public bool doubleJump;
	public bool dmgAnimBool = false;
	public bool wallSliding;
	public bool facingRight = true;
	public bool damaged = false;
	public bool touchJump = false;

	private Rigidbody2D rb2d;
	private Animator myAnimator;
	public Transform wallCheckPoint;
	public bool wallCheck;
	public LayerMask wallLayerMask;
	 
	public int currentHealth;
	public int maxHealth = 4;
	public int currentMana;
	public int maxMana = 3;
	public int touchMov = 0;


	void Start () {

		grounded = true;
		currentHealth = maxHealth;
		currentMana = maxMana;
		rb2d = gameObject.GetComponent<Rigidbody2D> ();

		myAnimator = gameObject.GetComponent<Animator> ();
		myAnimator.SetBool ("Damaged", false);


	}
	
	void Update () {


		myAnimator.SetBool ("Grounded", grounded);
		myAnimator.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));

		//if (Input.GetAxis ("Horizontal") < -0.1f) {
		if (touchMov < -0.1f) {

			transform.localScale = new Vector3 (-1, 1, 1);
			facingRight = false;

		}

		//if (Input.GetAxis ("Horizontal") > 0.1f) {
		if (touchMov > 0.1f) {
			
			transform.localScale = new Vector3 (1, 1, 1);
			facingRight = true;

		}

		//if (Input.GetButtonDown ("Jump") && !wallSliding) {
		if (touchJump && !wallSliding) {
			if (grounded) {

				rb2d.AddForce ((Vector2.up * jumpPower));
				doubleJump = false;
				touchJump = false;
			} else {

				if (!doubleJump) {

					doubleJump = true;
					rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
					rb2d.AddForce ((Vector2.up * jumpPower / 1.25f));
					touchJump = false;
				}
			}



		}

		if (currentHealth <= 0) {

			Die ();
		}

		if (currentHealth > maxHealth) {

			currentHealth = maxHealth;
		}

		if (dmgAnimBool == true) {

			myAnimator.SetBool ("Damaged", false);
			dmgAnimBool = false;
			damaged = false;

		}


		if (!grounded) {

			wallCheck = Physics2D.OverlapCircle (wallCheckPoint.position, 0.29f, wallLayerMask);

			if (facingRight && Input.GetAxis ("Horizontal") > 0.1f || !facingRight && Input.GetAxis ("Horizontal") < 0.1f) {

				if (wallCheck) {

					//myAnimator.SetBool("Grounded", false);
					//myAnimator.SetBool("GroundCheck", true);
					HandleWallSliding ();
				}
			}
		}

		if (wallCheck == false || grounded) {


			wallSliding = false;
			//myAnimator.SetBool("GroundCheck", false);
		}

		if (myAnimator.GetBool ("Damaged") == true) {

			dmgAnim -= Time.deltaTime;
			//print (dmgAnim);
		}
	
		if(dmgAnim <= 0){

			dmgAnimBool = true;
			dmgAnim = 0.5f;
		}

	}

	void FixedUpdate(){

		//float h = Input.GetAxis ("Horizontal");
		float h = touchMov;


		Vector3 fakeFriction = rb2d.velocity;
		
		fakeFriction.y = rb2d.velocity.y;
		fakeFriction.z = 0.0f;
		fakeFriction.x *= 0.75f;

		if (grounded) {

			rb2d.AddForce ((Vector2.right * speed) * h);

		} else {

			rb2d.AddForce ((Vector2.right * speed/2) * h);
		}

		if (rb2d.velocity.x > maxSpeed) {

			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.x < -maxSpeed) {
			
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}

		if (grounded) {

			rb2d.velocity = fakeFriction;

		}

	}
	

	void Die(){

		Application.LoadLevel (Application.loadedLevel);
	}

	public void TakeDamage(int dmg){


		damaged = true;
		currentHealth = currentHealth - dmg;
		myAnimator.SetBool ("Damaged", true);

		if (myAnimator.GetBool ("Damaged") == true) {

			myAnimator.Play ("Elkyy_Damage", -1, 0f);
		}

	}

	public IEnumerator Knockback(float duration, float back, Vector3 direction, bool dblJmp){
		
		float timer = 0;


		if (dblJmp == false) {
			while (duration > timer) {

				timer += Time.deltaTime;
				rb2d.velocity = new Vector2(0,0);
				rb2d.AddForce (new Vector3 (direction.x * -50, direction.y + back, transform.position.z));

			}
		} else {
			while (duration > timer) {
				
				timer += Time.deltaTime;
				rb2d.velocity = new Vector2(0,0);
				rb2d.AddForce (new Vector3 (direction.x * -50, direction.y + back, transform.position.z));
				doubleJump = false;
				
			}

		}

		yield return 0;
		
	}

	void HandleWallSliding(){


		//rb2d.velocity = new Vector2 (rb2d.velocity.x, -0.7f);
		wallSliding = true;

		//if (Input.GetButtonDown ("Jump")) {
		if (touchJump) {
			if(facingRight){

				if(rb2d.velocity.y < 3.5f){
					rb2d.AddForce(new Vector2(-1.5f,3f) * 70);
				}else{
					rb2d.AddForce(new Vector2(rb2d.velocity.x, 3.5f));
				}

				touchJump = false;
			}else{

				if(rb2d.velocity.y < 3.5f){
					rb2d.AddForce(new Vector2(1.5f,3f) * 70);
				}else{
					rb2d.AddForce(new Vector2(rb2d.velocity.x, 3.5f));
				}
				touchJump = false;
			}
		}
	}


	public void TouchJump(bool b){

		touchJump = b;

	}

	public void TouchMovement(int i){

		touchMov = i;
	}



}
