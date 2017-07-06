using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
	public GameObject ItemBoxGO = null;

	float XPos = 0.0f;
	float ZPos = 0.0f;
	// Use this for initialization
	void Start () {
		if (ItemBoxGO == null)
			Debug.Log("ItemBox가 NUll입니다.");
		InvokeRepeating("ItemRegen", 2.0f, 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ItemRegen()
	{
		XPos = Random.Range(-21.0f, 3.5f);
		ZPos = Random.Range(-12.0f, 11.0f);

		Instantiate(ItemBoxGO,new Vector3(XPos,0.5f,ZPos),Quaternion.Euler(0,0,45));
	}
}
