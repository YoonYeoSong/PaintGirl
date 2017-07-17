using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	float CurTime = 0.0f;
	Vector3 OriPos = Vector3.zero;

	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 1.2f);

		OriPos = gameObject.transform.localPosition;//GameObject.Find("AirPlane").gameObject.transform.localPosition;

		transform.localRotation = Quaternion.Euler(90, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		CurTime += Time.deltaTime;

	
		gameObject.transform.localPosition = Vector3.Lerp(OriPos, OriPos - new Vector3(0, 6, 0), CurTime/1.3f);
	}
}
