using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public int points;

	public Text pointsText;
	public Text inputText;

	void Start () {
	
	}
	

	void Update () {

		pointsText.text = ("Coins: " + points);
	
	}
}
