using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {




	int TeamCheck = 0;

	private void Awake()
	{
	}
	// Use this for initialization
	void Start () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "AChar" || other.transform.tag == "BChar")
		{
			if (other.transform.tag == "AChar")
			{
				other.GetComponent<Player>().Buff();
			}
			if (other.transform.tag == "BChar")
			{
				other.GetComponent<PlayerB>().Buff();
			}
			//ItemBoxManager.Instance.ItemType();
			Debug.Log("아이템획득");
			//ItemType();
			Destroy(this.gameObject, 0.2f);
		}
	}


	// Update is called once per frame
	void Update()
	{

		transform.Rotate(new Vector3(1, 1, 0) * Time.deltaTime * 70.0f);

		//	BoxColor.r = 100;
	}



}
