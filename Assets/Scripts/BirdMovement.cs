using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float flapSpeed    = 0.01f;
	public float forwardSpeed = 0;
	
	public bool sawOnce = false;
	public GUISkin skin;
	public float startTime;
	
	public int highScore;
	public int fontSize;
    public static bool running = false;
	public int start = 0;
	
	
	
	bool didFlap = false;

	Animator animator;

	public bool dead = false;
	float deathCooldown;

	public bool coolMode = false;
	public AudioClip myclip;

	// Use this for initialization
	void Start () {

	
			
		GetComponent<Animation>().Play ("PlaneFly");
			
		GetComponent<Animation>()["PlaneFly"].wrapMode = WrapMode.Loop;

		animator = transform.GetComponentInChildren<Animator>();

		
		if(animator == null) {
			Debug.LogError("Didn't find animator!");
		}
	}

	// Do Graphic & Input updates here
	void Update() {
	
	
	if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
			GetComponent<Animation>().Stop("PlaneFly");
	running = true;
	}
	
	
	
		if(running){
	if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
	Vector3 position = this.transform.position;
	position.y = position.y + 0.015f;
	position.x = position.x + 0.02f;
	this.transform.position = position;
	transform.Rotate(0.0f, 0.0f, 0.7f); 
	}
	else{
	Vector3 position = this.transform.position;
	position.y = position.y - 0.015f;
	position.x = position.x + 0.02f;
	this.transform.position = position;
	transform.Rotate(0.0f, 0.0f, -0.7f); 
	}
	}
	}

	void FixedUpdate(){
	if(dead){
	Vector3 position = this.transform.position;
	    position.y = position.y - 0.01f;
		this.transform.position = position;
	   if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
	      Application.LoadLevel(0);
	   }
	}
		
	}
	

	void OnCollisionEnter2D(Collision2D collision) {
		
        running = false;
		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 0.5f;
		Vector3 position = this.transform.position;
	    position.y = position.y - 0.01f;
		this.transform.position = position;
	}
	
	private void OnGUI () {	
	    
		GUI.skin = skin;

		
		GUI.backgroundColor = Color.yellow;
		
		
        GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;
       
	
		 if(Screen.height>1500&&Screen.height<2000){
		 fontSize = 75;
		 }
		 if(Screen.height>1000&&Screen.height<1500){
		 fontSize = 55;
		 }
		 if(Screen.height>700&&Screen.height<1000){
		 fontSize = 35;
		 }
		 else {
		 fontSize = 25;
		 }
		 
	
	    if(dead){
	    GUI.Box(new Rect (Screen.width/4, Screen.height/3.3f, Screen.width/2, Screen.height/5), "Highscore " + PlayerPrefs.GetInt("highScore") +  "\n\nTap to Restart");
	    }
	}
}
