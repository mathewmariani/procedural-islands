using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {
	
	[SerializeField] 
	private GameObject[] targets;

	void Awake () {
		targets = GameObject.FindGameObjectsWithTag("Target");
	}
	
	void LateUpdate() {
		float posx = 0;
		float posy = 0;

		foreach (GameObject target in targets) {
			if (target == null)
				continue;

			posx += target.GetComponent<Renderer>().bounds.center.x;
			posy += target.GetComponent<Renderer>().bounds.center.y;
		}

		transform.position = new Vector3(
			posx/targets.Length,
			posy/targets.Length,
			transform.position.z
			);
	}
}