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
	void Start () {

        HiddenTimeCheck = GameObject.Find("Timer").GetComponent<GameCountTime>();


        if (ItemBoxGO == null)
			Debug.Log("ItemBox가 NUll입니다.");
		InvokeRepeating("ItemRegen", 2.0f, 4.0f);

    

    }
	
	// Update is called once per frame
	void Update () {

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
		int RandomPos;
		GameObject Go = null;
		GameObject temp = Resources.Load("Prefabs/Game/AirPlane") as GameObject;
		//Go = Instantiate(temp,)
	}


}
