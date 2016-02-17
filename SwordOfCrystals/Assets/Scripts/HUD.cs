using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;
	public Sprite[] GemSprites;
	public Sprite[] ManaSprites;
	public Sprite[] BossSprites;

	public Image HeartUI;
	public Image GemUI;
	public Image ManaUI;
	public Image BossUI;

	private Player player;
	private YggdrasilController ygg;
	private GemController green;
	private GemController red;
	private GemController black;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();



		if (Application.loadedLevelName == "FirstLevel") {

			green = GameObject.FindGameObjectWithTag ("GreenGem").GetComponent<GemController> ();
			red = GameObject.FindGameObjectWithTag ("RedGem").GetComponent<GemController> ();
			black = GameObject.FindGameObjectWithTag ("BlackGem").GetComponent<GemController> ();

		} else if(Application.loadedLevelName == "BossLevel"){

			ygg = GameObject.FindGameObjectWithTag ("Yggdrasil").GetComponent<YggdrasilController> ();
		}


	}
	

	void Update () {

		HeartUI.sprite = HeartSprites[player.currentHealth];
		ManaUI.sprite = ManaSprites [player.currentMana];

		if (Application.loadedLevelName == "BossLevel") {
			
			BossUI.sprite = BossSprites[ygg.currHealth];
		}

		if (Application.loadedLevelName == "FirstLevel") {
			//Green gem first
			if (green.isGreen == true) {
			
				GemUI.sprite = GemSprites [1];
			
				if (red.isRed == true) {
				
					GemUI.sprite = GemSprites [4];

				}
			
				if (black.isBlack == true) {
				
					GemUI.sprite = GemSprites [5];
	
				}
			
				if (red.isRed && black.isBlack) {
				
					GemUI.sprite = GemSprites [7];
		
				}
			}

			//RedGem first
			if (red.isRed == true) {
			
				GemUI.sprite = GemSprites [2];
			
				if (green.isGreen == true) {
				
					GemUI.sprite = GemSprites [4];
				}
			
				if (black.isBlack == true) {
				
					GemUI.sprite = GemSprites [6];
				}
			
				if (black.isBlack && green.isGreen) {
				
					GemUI.sprite = GemSprites [7];
				}
			}

			//BlackGem first
			if (black.isBlack == true) {
			
				GemUI.sprite = GemSprites [3];

				if (green.isGreen == true) {

					GemUI.sprite = GemSprites [5];
				}

				if (red.isRed == true) {
				
					GemUI.sprite = GemSprites [6];
				}

				if (red.isRed && green.isGreen) {

					GemUI.sprite = GemSprites [7];
				}
			}

		}

	}
}
