using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashMoveAni : MonoBehaviour {

	float CurTime = 0.0f;
	float ArrTime = 2.0f;

	UI_Store Store = null;
	Vector3 GoalPosition;
	// Use this for initialization
	void Awake()
	{
		GoalPosition = new Vector3(352, 304, 0);
		//Store = 
	}

	// Update is called once per frame
	void Update()
	{
		CurTime += Time.deltaTime;

		Transform Ho = transform;
		transform.localPosition = Vector3.Lerp(Ho.localPosition, GoalPosition, CurTime / ArrTime);

		if (transform.localPosition == GoalPosition)
		{
			//CurTime = 0.0f;
			Destroy(gameObject);

		}
	}
}
