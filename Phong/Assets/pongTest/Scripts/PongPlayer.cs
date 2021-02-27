using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PongPlayer : MonoBehaviour
{

	public string playerName; // Player1 or Player2
	public string upKey; // w or up arrow
	public string downKey; // s or down arrow

	public float speed = 80000.0f;

	private GameRunner gameRunner;
	private Rigidbody rb;

	public float upLimit = 360f;
	public float downLimit = -360f;

	private KeyCode upKeyCode;
	private KeyCode downKeyCode;

	public GameObject BlockParticles;
	private GameObject FullParent;

	private AudioSource blockSfx;
    // Start is called before the first frame update
    void Start(){
        
		upKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), upKey.ToString()) ;
		downKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), downKey.ToString()) ; 

		if (GameObject.FindWithTag ("GameRunner") != null){
			gameRunner = GameObject.FindWithTag ("GameRunner").GetComponent<GameRunner>();
		}
		
		FullParent = GameObject.Find("FullPongGame");
		
		if (gameObject.GetComponent<Rigidbody>() != null){
			rb = gameObject.GetComponent<Rigidbody>();
		}

		blockSfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate(){

		Vector3 changeZ = new Vector3(0f, 0f, 0.01f);

		if (gameObject.transform.position.z <= upLimit){ 
			if (Input.GetKey(upKeyCode)){
				rb.MovePosition(transform.position + changeZ * speed * Time.deltaTime);
				//Debug.Log("I am trying to move up " + playerName);
			}
		}

		if (gameObject.transform.position.z >= downLimit){ 
			if (Input.GetKey(downKeyCode)){
				rb.MovePosition(transform.position + changeZ * speed * -1 * Time.deltaTime);
				//Debug.Log("I am trying to move down " + playerName);
			}
		}

    }
		
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("PongBall"))
		{
			
			blockSfx.PlayOneShot(blockSfx.clip);
			
			gameRunner.playerBlocks (playerName, 1);
			var particles = Instantiate(BlockParticles, other.GetContact(0).point, BlockParticles.transform.rotation);
			particles.SetActive(true);
			particles.GetComponent<ParticleSystem>().Play();
			
		}
	
	}


}
