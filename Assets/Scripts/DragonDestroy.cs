using UnityEngine;
using System.Collections;

public class DragonDestroy : MonoBehaviour {

	public int jumpLimit;

	void OnTriggerEnter2D(Collider2D collider) {

		if (jumpLimit == 0) {
			transform.GetChild (0).gameObject.SetActive(true);
		}

				if (collider.tag == "Player" && jumpLimit != 1) {
						jumpLimit = 1;
						Debug.Log (collider.tag);
						StartCoroutine ("wait");
						transform.GetChild (0).gameObject.SetActive (false);

						//activeAgain();
				}
				
		}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(2);
		jumpLimit=0;
	}
}
