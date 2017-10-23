using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalPlataform : MonoBehaviour {
	public Transform plataformaHorizontal;
	public bool volta = false;
	public float xVal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (volta) {
			xVal += 0.05f;
		} else {
			xVal -= 0.05f;
		}
		plataformaHorizontal.position = new Vector3 (xVal,plataformaHorizontal.position.y,0);
	}

	void OnCollisionEnter2D (Collision2D col){
		Debug.Log (col.gameObject.tag);
		if(col.gameObject.tag == "Volta"){
			volta = true;
		}
	}
}
