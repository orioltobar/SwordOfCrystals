using UnityEngine;
using System.Collections;

public class YggdrasilAttack : MonoBehaviour {

	public bool attacking = false;
	public bool attack = false;
	public bool attacked = false;
	private bool firedSpell = false;
	private bool isFired = false;

	private float attackTimer = 0;
	private float attackCoolDown = 0.3f;
	private float magicTimerYgg = 1.2f;
	private float magicCoolDownYgg = 0.5f;

	public Collider2D attackTriggerYgg;
	public Collider2D swordTriggerYgg;


	private Animator atkAnimYgg;

	public Transform magicPointYgg,targetYgg;

	public GameObject magicSpell;

	private YggdrasilController yggdrasilito;

	void Start () {

		atkAnimYgg = gameObject.GetComponent<Animator> ();
		attackTriggerYgg.enabled = false;
		yggdrasilito = GameObject.FindGameObjectWithTag ("Yggdrasil").GetComponent<YggdrasilController> ();
	}
	
	void Update () {
	


		if (attack & !attacking) {


			attacking = true;
			attackTimer = attackCoolDown;
			//attackTriggerYgg.enabled = true;
			//swordTriggerYgg.enabled = false;
			//attacked = true;
			atkAnimYgg.SetBool ("Attack", true);

		}

		if (attacking) {
			
			if(attackTimer > 0){
				//print ("entra");
				//print(attackTimer);
				attackTimer -= 0.2f;
			}else {
				attackTriggerYgg.enabled = true;
				attacking = false;
				attackTriggerYgg.enabled = false;
				//swordTriggerYgg.enabled =true;
				//attacked = false;
				atkAnimYgg.SetBool ("Attack", false);


			}
		}

		//atkAnimYgg.SetBool ("Attack", attacking);


		if (yggdrasilito.magic && !firedSpell) {

			atkAnimYgg.SetBool("Magic", true);

			isFired = true;
		}


		if (isFired) {


			if(magicTimerYgg > 0f){
				
				magicTimerYgg -= Time.deltaTime;
				
			} else {

				if(yggdrasilito.facingRight == true){
					
					GameObject magicShoot;
					
					Vector2 direction = targetYgg.transform.position - transform.position;
					direction.Normalize();
					
					magicShoot = Instantiate(magicSpell, magicPointYgg.position, magicPointYgg.rotation) as GameObject;
					magicShoot.transform.localScale = new Vector3(-1,1,1);
					magicShoot.GetComponent<Rigidbody2D>().velocity = direction * 5;
					
					firedSpell = true;

					
				}else{
					
					GameObject magicShoot;
					
					Vector2 direction = targetYgg.transform.position - transform.position;
					direction.Normalize();
					
					magicShoot = Instantiate(magicSpell, magicPointYgg.position, magicPointYgg.rotation) as GameObject;
					
					magicShoot.GetComponent<Rigidbody2D>().velocity = direction * 5;
					
					firedSpell = true;
					
				}

				atkAnimYgg.SetBool ("Magic", false);
				isFired = false;
				magicTimerYgg = magicCoolDownYgg;
				yggdrasilito.magic = false;
				firedSpell = false;

			}
		}
	}
}
