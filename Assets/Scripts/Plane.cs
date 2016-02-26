using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Animation>().Play("PlaneAnimation");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
