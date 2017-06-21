using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * 70.0f);
		//transform.rotation = Quaternion.Euler(0, 0.01f, 0);
	}
}
