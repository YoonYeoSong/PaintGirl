using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
	public GameObject ItemBoxGO = null;

    public GameObject HiddenItem = null;

    GameCountTime HiddenTimeCheck = null;


	float CurTime = 0.0f;
	float XPos = 0.0f;
	float ZPos = 0.0f;
	// Use this for initialization

	GameObject AirPlane = null;
	
	void Start () {

        HiddenTimeCheck = GameObject.Find("Timer").GetComponent<GameCountTime>();


        if (ItemBoxGO == null)
			Debug.Log("ItemBox가 NUll입니다.");
		InvokeRepeating("ItemRegen", 2.0f, 4.0f);
		GenAirPlane();



	}
	
	// Update is called once per frame
	void Update () {

		CurTime += Time.deltaTime;

		if (HiddenTimeCheck.HiddenTime == true)
		{
			Instantiate(HiddenItem, new Vector3(-8.81f, 3.43f, -1.388f), Quaternion.Euler(0, 180, 0));
			HiddenTimeCheck.HiddenTime = false;
		}


	}

	void ItemRegen()
	{
		XPos = Random.Range(-21.0f, 3.5f);
		ZPos = Random.Range(-12.0f, 11.0f);

		Instantiate(ItemBoxGO,new Vector3(XPos,0.5f,ZPos),Quaternion.Euler(0,0,45));
	}

	public void GenAirPlane()
	{
		int RandomPos = -1 ;

		RandomPos = Random.Range(0, 6);
		
		GameObject temp = Resources.Load("Prefabs/Game/YellowAirPlane") as GameObject;

		if (RandomPos >= 3)
			RandomPos++;
		RandomPos = 6;
		AirPlane = Instantiate(temp, new Vector3(-40, 15.1f, -13.42f + RandomPos * 4.25f), Quaternion.identity);
		AirPlane.name = "AirPlane";
	}

}
