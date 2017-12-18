using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour {

	public Transform bossTransform;
	public bool volta = false;
	public float xVal;

	void Start(){
		volta = false;
	}
	// Update is called once per frame
	void Update () {

		if (volta) {
			xVal += 0.05f;
		} else {
			xVal -= 0.05f;
		}
			
			bossTransform.position = new Vector3 (xVal,bossTransform.position.y,0);
	}


	void OnCollisionEnter2D (Collision2D col){
		Debug.Log (col.gameObject.tag);
		if(col.gameObject.tag == "Volta"){
			if (volta) {
				volta = false;
			}else if(!volta){
				volta = true;
			}


		}
	}

}
