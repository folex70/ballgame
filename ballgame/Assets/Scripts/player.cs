using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {

	public float vel;
	public Rigidbody2D rb;
	public Animator anim;
	public SpriteRenderer sprite;
	public Text moedasText;
	public Text queijoText;
	//--------Itens JOgo
	public bool hasKey = false;
	public bool potion = false;
	public GameObject Obkey;
	public GameObject ObGrid;
	public float queijo = 0;
	public float moeda = 0;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
		vel = 2;
	}

	// Update is called once per frame
	void Update () {
		//-----textos
		queijoText.text = "Queijo: "+queijo;
		moedasText.text = "Moedas: "+moeda;
		//------------
		//vx = vel * Input.GetAxis ("Horizontal");
		//rb.velocity.x = vx;

		//anim.SetFloat("vel",Mathf.Abs(Input.GetAxis("Horizontal")));

		Vector2 temp = rb.velocity;
		temp.x = vel * Input.GetAxis("Horizontal");
		rb.velocity = temp;

		//virar 
		if(Input.GetAxis("Horizontal") != 0){
			if(Input.GetAxis("Horizontal") > 0){
				sprite.flipX = false;
			}
			else{

				sprite.flipX = true;
			}
		}

		if (Input.GetAxis ("Jump") != 0) {
			jump ();
		}

	}

	private void jump()
	{
		if (rb.velocity.y > 0) {
			rb.velocity = new Vector2(rb.velocity.x, 0);
		}
		rb.AddForce(Vector2.up * 50);
	}

	private void gameOver(){
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}

	void OnCollisionEnter2D (Collision2D col){
		if(col.gameObject.tag == "Key"){
			hasKey = true;
			Obkey.SetActive(false);
		}

		if(col.gameObject.tag == "Grid"){
			if(hasKey){
				ObGrid.SetActive(false);
			}
		}
		
		if(col.gameObject.tag == "Fall"){
			gameOver ();
		}

		if(col.gameObject.tag == "potion"){
			potion = true;
			col.gameObject.SetActive(false);
		}

		if(col.gameObject.tag == "boss"){
			if (!potion) {
				gameOver ();
			} else {
				col.gameObject.SetActive(false);
			}
		}
		
		if(col.gameObject.tag == "Exit"){
			//NextStage
			//gameOver ();
			Scene scene = SceneManager.GetActiveScene();

			if (scene.name == "fase1") {
				SceneManager.LoadScene ("fase2");  
			} else if (scene.name == "fase2") {
				SceneManager.LoadScene ("fase3");  
			} else if (scene.name == "fase3") {
				SceneManager.LoadScene ("creditos");  
			}
			else{			
				SceneManager.LoadScene ("fase1");  
			}

		}

		if(col.gameObject.tag == "queijo"){
			queijo++;
			col.gameObject.SetActive(false);
		}

		if(col.gameObject.tag == "moeda"){
			moeda++;
			col.gameObject.SetActive(false);
		}
	}
}
