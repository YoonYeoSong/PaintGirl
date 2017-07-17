using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenItemBox : MonoBehaviour {

	bool Up = true;
	float CurTime = 0.0f;
	float GoalTime = 2.0f;
	Vector3 OriPos = Vector3.zero;
	ItemGenerator ItemGen = null;
	// Use this for initialization
	void Start () {
		OriPos = transform.localPosition;
		ItemGen = GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>();

		if (ItemGen == null)
			Debug.Log("ItemGen is null");
	}

	// Update is called once per frame
	void Update() {
		transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 70.0f);

		CurTime += Time.deltaTime;
		if (Up == true)
		{
			this.gameObject.transform.localPosition = Vector3.Lerp(OriPos, OriPos + new Vector3(0, 0.3f, 0), CurTime / GoalTime);

			if (transform.localPosition == (OriPos + new Vector3(0, 0.3f, 0)))
			{
				CurTime = 0.0f;
				Up = false;
			}
		}

		else if (Up == false)
		{
			this.gameObject.transform.localPosition = Vector3.Lerp(OriPos + new Vector3(0, 0.3f, 0), OriPos, CurTime / GoalTime);
			if (transform.localPosition == OriPos)
			{
				CurTime = 0.0f;
				Up = true;
			}
		}
	}
}
