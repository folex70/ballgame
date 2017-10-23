using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour {

	public float vel;
	public Rigidbody2D rb;
	public Animator anim;
	public SpriteRenderer sprite;
	
	//--------Itens JOgo
	public bool hasKey = false;
	public GameObject Obkey;
	public GameObject ObGrid;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
		vel = 2;
	}

	// Update is called once per frame
	void Update () {
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
		
		if(col.gameObject.tag == "Exit"){
			//NextStage
			gameOver ();
		}
	}
}