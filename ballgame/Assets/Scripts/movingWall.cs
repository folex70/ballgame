using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWall : MonoBehaviour {

	public Transform tf;

	public float upVal ;

	public bool upping = true;

	// Use this for initialization
	void Start () {
		upVal = tf.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (upping) {
			upVal += 0.05f;
		} else {
			upVal -= 0.05f;
		} 

		if(tf.position.y < 4){
			upping = true;
		}else if(tf.position.y > 5){
			upping = false;
		}


		tf.position = new Vector3 (tf.position.x, upVal, 0);	


	}


}
