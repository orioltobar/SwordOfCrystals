using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private bool attacking = false;
	private bool magic = false;
	public bool magicTouch, attackTouch;

	private float attackTimer = 0;
	private float attackCoolDown = 0.3f;
	private float magicTimer = 0;
	private float magicCoolDown = 0.5f;

	public Collider2D attackTrigger;

	private Animator atkAnim;

	private Player pl;

	public GameObject magicBall;

	public Transform magicPoint,target;

	void Awake(){

		atkAnim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;
		pl = gameObject.GetComponent<Player> ();
	}
	void Start () {
	
	}
	

	void Update () {


		//if (Input.GetKeyDown ("f") && !attacking && pl.damaged == false) {
		if (attackTouch && !attacking && pl.damaged == false) {

			attacking = true;
			attackTimer = attackCoolDown;
			attackTouch = false;

			attackTrigger.enabled = true;
		}

		if (attacking) {

			if(attackTimer > 0){
			
				attackTimer -= Time.deltaTime;
			}else {

				attacking = false;
				attackTrigger.enabled = false;
			}
		}

		//if (Input.GetKeyDown ("g") && !magic && pl.damaged == false && pl.currentMana > 0) {
		if (magicTouch && !magic && pl.damaged == false && pl.currentMana > 0) {

			magicTouch = false;
			pl.currentMana -= 1;

			magicTimer = magicCoolDown;

			atkAnim.SetBool ("Magic", true);

			if(pl.facingRight == true){

				GameObject magicShoot;

				Vector2 direction = target.transform.position - transform.position;
				direction.Normalize();

				magicShoot = Instantiate(magicBall, magicPoint.position, magicPoint.rotation) as GameObject;
				magicShoot.GetComponent<Rigidbody2D>().velocity = direction * 5;
				magic = true;
			}else{

				GameObject magicShoot;
				
				Vector2 direction = target.transform.position - transform.position;
				direction.Normalize();
				
				magicShoot = Instantiate(magicBall, magicPoint.position, magicPoint.rotation) as GameObject;
				magicShoot.transform.localScale = new Vector3(-1,1,1);
				magicShoot.GetComponent<Rigidbody2D>().velocity = direction * 5;
				magic = true;
			}

		}

		if (magic) {

			if(magicTimer > 0){

				magicTimer -= Time.deltaTime;

			} else {
				atkAnim.SetBool ("Magic", false);
				magic = false;
			}
		}
		atkAnim.SetBool ("Attacking", attacking);
	}

	public void AttackTouch(bool b){

		attackTouch = b;
	}

	public void MagicTouch(bool b){

		magicTouch = b;
	}
}
