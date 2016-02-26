using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	int numBGPanels = 6;

	float pipeMax = 0f;
	float pipeMin = -1.2f;
	
	float cloudMax = 0.6f;
	float cloudMin = 0.1f;
	
	float wcloudMax = 0f;
	float wcloudMin = 0f;
	
	float heartMax = 0.2f;
	float heartMin = -0.05f;

	void Start() {
		GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
		
		GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");
		
		GameObject[] wclouds = GameObject.FindGameObjectsWithTag("WhiteCloud");
		
		GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");

		foreach(GameObject pipe in pipes) {
			Vector3 pos = pipe.transform.position;
			pos.y = Random.Range(pipeMin, pipeMax);
			pipe.transform.position = pos;
		}
		
		foreach(GameObject cloud in clouds) {
			Vector3 pos = cloud.transform.position;
			pos.y = Random.Range(cloudMin, cloudMax);
			cloud.transform.position = pos;
		}
		
		foreach(GameObject wcloud in wclouds) {
			Vector3 pos = wcloud.transform.position;
			pos.y = Random.Range(wcloudMin, wcloudMax);
			wcloud.transform.position = pos;
		}
		
		foreach(GameObject heart in hearts) {
			Vector3 pos = heart.transform.position;
			pos.y = Random.Range(heartMin, heartMax);
			heart.transform.position = pos;
		}
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Triggered: " + collider.name);

		float widthOfBGObject = ((BoxCollider2D)collider).size.x;

		Vector3 pos = collider.transform.position;

		pos.x += widthOfBGObject * numBGPanels;

		if(collider.tag == "Pipe") {
			pos.y = Random.Range(pipeMin, pipeMax);
		}
		
		if(collider.tag == "Cloud") {
			pos.y = Random.Range(cloudMin, cloudMax);
		}
		
		if(collider.tag == "WhiteCloud") {
			pos.y = Random.Range(wcloudMin, wcloudMax);
		}

		collider.transform.position = pos;

	}
}
