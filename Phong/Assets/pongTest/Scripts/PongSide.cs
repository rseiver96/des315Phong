using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongSide : MonoBehaviour
{
	public string PlayerOtherSideName; //Player1 or Player 2
	private GameRunner gameRunner;

	public int scoreNum = 1;

	public Animator MonkeyToDrop;
	// Start is called before the first frame update
    void Start()
    {
		if (GameObject.FindWithTag ("GameRunner") != null){
			gameRunner = GameObject.FindWithTag ("GameRunner").GetComponent<GameRunner>();
		}
    }
		

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PongBall")
		{
			gameRunner.playerScore(PlayerOtherSideName, scoreNum);
			StartCoroutine(gameRunner.PitchDown());
			MonkeyToDrop.Play("Drop");
			Debug.Log("" + PlayerOtherSideName + "scored.");
			Destroy(other.gameObject);
			gameRunner.makeNewBall();
		}
	}


}
