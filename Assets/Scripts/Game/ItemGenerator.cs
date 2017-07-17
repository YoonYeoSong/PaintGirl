using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
	public GameObject ItemBoxGO = null;

    public GameObject HiddenItem = null;

    GameCountTime HiddenTimeCheck = null;

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

        if (HiddenTimeCheck.HiddenTime == true)
        {
            Instantiate(HiddenItem, new Vector3(-8.81f, 3.43f, -1.388f), Quaternion.Euler(0, 180, 0));
            HiddenTimeCheck.HiddenTime = false;
        }

		if (AirPlane != null)
		{
			 AirPlane.transform.localPosition += new Vector3(0.2f,0,0);
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
		int RandomPos;
		GameObject temp = Resources.Load("Prefabs/Game/YellowAirPlane") as GameObject;
		AirPlane = Instantiate(temp, Vector3.zero,Quaternion.identity);
		AirPlane.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
		AirPlane.transform.localPosition = new Vector3(-100f, 6.1f, -8.42f);
		AirPlane.transform.localRotation = Quaternion.Euler(-90,0,0);
	}


}
