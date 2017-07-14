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
	bool AirPlaneUpCheck = false;
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

		if (AirPlane != null)
		{
			if (AirPlane.transform.localPosition.x < -22)
			{
				AirPlaneDown();
			}
			if (0 > AirPlane.transform.localPosition.x  && AirPlane.transform.localPosition.x >= -22)
			{
				

					AirPlane.transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 20 - (CurTime / 1.0f * 15), 0);
					AirPlaneStraight();

				if (AirPlane.transform.FindChild("bomb_plane 1").localRotation.y <= 0)
				{ 
					AirPlane.transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 0, 0);
				}
			}
			if (AirPlane.transform.localPosition.x >= 0.0f && AirPlaneUpCheck == false)
			{
				CurTime = 0.0f;
				AirPlaneUpCheck = true;
			}
			if (AirPlane.transform.localPosition.x > 0 && AirPlaneUpCheck == true)
			{
				if ((0 >= AirPlane.transform.FindChild("bomb_plane 1").localRotation.y) && ( AirPlane.transform.FindChild("bomb_plane 1").localRotation.y >= -10.0f))
				{
					AirPlane.transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 0 - (CurTime / 1.0f * 15), 0);

				}

				AirPlaneUp();
			}
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
		AirPlane.transform.localPosition = new Vector3(-40, 15.1f, -8.42f);
		AirPlane.transform.localRotation = Quaternion.Euler(-90,0,0);
		AirPlane.transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 20, 0);
	}


	void AirPlaneDown()
	{
		Transform temp;
		CurTime = 0.0f;
		AirPlane.transform.localPosition += new Vector3(0.1f, -0.05f, 0);
		//AirPlane.transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 30 - (CurTime / 1.0f * 15), 0);
		//temp.localRotation = 30 - (CurTime / 1.0f * 15);
	}

	void AirPlaneStraight()
	{
		AirPlane.transform.localPosition += new Vector3(0.1f, 0, 0);

	}

	void AirPlaneUp()
	{
		AirPlane.transform.localPosition += new Vector3(0.1f, 0.02f, 0);
		
	}

}
