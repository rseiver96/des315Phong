using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{

	public float speed = 600f;

    // Start is called before the first frame update
    void Start()
    {
		float sX = Random.Range(-2, 2) == 0 ? -1 : 1;
		float sZ = Random.Range(-2, 2) == 0 ? -1 : 1;
		GetComponent<Rigidbody>().velocity = new Vector3(speed * sX, 0f, speed * sZ);
    }
		
}

// from this script: https://youtu.be/jKbZM3KLqVI



//OLD: 

//private Rigidbody rb;
//private int startDirection;
//public float speed = 500;
//private Vector3 moveDir; 
//
//// Start is called before the first frame update
//void Start()
//{
//	if (gameObject.GetComponent<Rigidbody>() != null){
//		rb = gameObject.GetComponent<Rigidbody>();
//	}
//
//	randomDirection();
//}
//
//// Update is called once per frame
//void FixedUpdate()
//{
//	moveDir = new Vector3(1f, 0f, 0f);
//	rb.MovePosition(transform.position + moveDir * speed * startDirection * Time.deltaTime);
//}
//
//
//void randomDirection(){
//	int startNum = Random.Range(1, 4);
//	if ((startNum == 1) || (startNum == 3)){
//		startDirection = 1;
//	}
//	else if ((startNum == 2) || (startNum == 4)){
//		startDirection = -1;
//	}
//}
//
//
//void OnCollisionEnter(Collision other){
//	startDirection = startDirection * -1;
//
//}
