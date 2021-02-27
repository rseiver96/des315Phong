using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameRunner : MonoBehaviour
{

	public static int player1score = 0;
	public static int player2score = 0;

	public static int player1blocks = 0;
	public static int player2blocks = 0;

	public GameObject textP1score;
	public GameObject textP2score;
	public GameObject textP1blocks;
	public GameObject textP2blocks;
	public GameObject textNewBall;

	public GameObject monkey;
	public GameObject ballPrefab;

	public AudioSource musicLoop;

	private Animator cameraShake;
	

	void Start(){
		textNewBall.SetActive(false);
		cameraShake = Camera.main.gameObject.GetComponent<Animator>();
		
		updateScore();
		makeNewBall(true);
		
	}

	private IEnumerator AnimateScore(Text txt)
	{
		yield return new WaitForSeconds(0.5f);

		Invoke(nameof(updateScore), 0.2f);
		
		int initSize = txt.fontSize;

		Color initColor = txt.color;
		
		txt.color = Color.black;
		
		for (int i = 0; i < 5; ++i)
		{
			txt.fontSize = 2 * initSize;
			txt.fontStyle = FontStyle.Bold;

			yield return new WaitForSeconds(0.1f);

			txt.fontSize = initSize;
			txt.fontStyle = FontStyle.Normal;
			
			yield return new WaitForSeconds(0.1f);
		}
		
		txt.color = initColor;
	}
	
	public void playerScore(string playerName, int scoreNum)
	{
		if (playerName == "Player1")
		{
			StartCoroutine(AnimateScore(textP1score.GetComponent<Text>()));
			player1score += scoreNum;
		}
		else if (playerName == "Player2")
		{
			StartCoroutine(AnimateScore(textP2score.GetComponent<Text>()));
			player2score += scoreNum;
		}
		
	}

	// Ball hasn't been blocked in sometime so get a new one
	void resetBall()
	{
		Destroy(GameObject.FindWithTag("PongBall"));
		makeNewBall(true);
	}
	
	public void playerBlocks(string playerName, int blockNum)
	{
		CancelInvoke(nameof(resetBall));
		
		
		if (playerName == "Player1"){
			player1blocks += blockNum;
		}
		else if (playerName == "Player2"){
			player2blocks += blockNum;
		}
		//updateScore();
		Invoke(nameof(resetBall), 8f);
	}

	void updateScore(){
		Text tP1sTemp = textP1score.GetComponent<Text>();
		Text tP2sTemp = textP2score.GetComponent<Text>();
		//Text tP1bTemp = textP1blocks.GetComponent<Text>();
		//Text tP2bTemp = textP2blocks.GetComponent<Text>();
		tP1sTemp.text = "P1 SCORE: " + player1score;
		tP2sTemp.text = "P2 SCORE: " + player2score;
		//tP1bTemp.text = "P1 blocked shots: " + player1blocks;
		//tP2bTemp.text = "P2 blocked shots: " + player2blocks;
	}

	public void makeNewBall(bool firstTime = false)
	{
		if (firstTime)
		{
			Instantiate (ballPrefab, monkey.transform.position, Quaternion.identity);
			textNewBall.SetActive(false);
			return;
		}

		StopCoroutine(MakeBall());
		StartCoroutine(MakeBall());
	}

	public IEnumerator PitchDown()
	{
		do
		{
			musicLoop.pitch *= 1 - Time.deltaTime;
			yield return new WaitForEndOfFrame();
			
		} while (musicLoop.pitch >= 0.8f);
	}
	
	public IEnumerator PitchUp()
	{
		while (musicLoop.pitch < 1f)
		{
			musicLoop.pitch *= 1f + Time.deltaTime;
			yield return new WaitForEndOfFrame();
			
		}

		musicLoop.pitch = 1f;
	}

	IEnumerator MakeBall()
	{
		cameraShake.Play("CameraShake");
		yield return new WaitForSeconds(0.30f);
		StopCoroutine(PitchDown());
		
		StartCoroutine(PitchUp());
		
		textNewBall.SetActive(true);
		monkey.SetActive(true);

		monkey.GetComponent<Animator>().SetBool("Walk", true);

		yield return new WaitForSeconds(1f);//Random.Range(0.4f, 1f));

		Instantiate (ballPrefab, monkey.transform.position, Quaternion.identity); 
		
		musicLoop.pitch = 1f;
		monkey.GetComponent<Animator>().SetBool("Walk", false);
		monkey.SetActive(false);
		textNewBall.SetActive(false);
	}

}
