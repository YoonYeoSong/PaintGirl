using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlane : MonoBehaviour {

	float CurTime = 0.0f;
	float RocketGenTime = 0.0f;
	bool AirPlaneUpCheck;
	GameObject temp;
	bool FireRight;
	// Use this for initialization
	void Start () {
		AirPlaneUpCheck = false;

		FireRight = true;

		transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
		//transform.localPosition = new Vector3(-40, 15.1f, -8.42f);
		transform.localRotation = Quaternion.Euler(-90, 0, 0);
		transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 20, 0);


        if(gameObject.CompareTag("APlayer"))
		 temp = Resources.Load("Prefabs/Game/YellowRocket") as GameObject;

        if(gameObject.CompareTag("BPlayer"))
            temp = Resources.Load("Prefabs/Game/GreenRocket") as GameObject;


        Destroy(gameObject, 15.0f);
	}
	
	// Update is called once per frame
	void Update () {
		CurTime += Time.deltaTime;
		RocketGenTime += Time.deltaTime;


		//transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 20 - (CurTime / 1.0f * 15), 0);


		if (transform.localPosition.x < -22)
			{
				AirPlaneDown();
			RocketGenTime = 0.6f;
			}
			if (5 > transform.localPosition.x && transform.localPosition.x >= -22)
			{


				transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 20 - (CurTime / 1.0f * 15), 0);
				AirPlaneStraight();

				if (transform.FindChild("bomb_plane 1").localRotation.y <= 0)
				{
					transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 0, 0);
				}
			}
			if (transform.localPosition.x >= 5f && AirPlaneUpCheck == false)
			{
				CurTime = 0.0f;
				AirPlaneUpCheck = true;
			}
			if (transform.localPosition.x > 5 && AirPlaneUpCheck == true)
			{
				if (transform.localPosition.x <= 10.0f)
				{
					transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 0 - (CurTime / 1.0f * 15), 0);

				}

				AirPlaneUp();
			}
		}

	void AirPlaneDown()
	{
		CurTime = 0.0f;
		transform.localPosition += new Vector3(0.1f, -0.05f, 0);
		transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 20 - (CurTime / 2.0f * 15), 0);
		//temp.localRotation = 30 - (CurTime / 1.0f * 15);
	}

	void AirPlaneStraight()
	{
		transform.localPosition += new Vector3(0.1f, 0, 0);
		if (RocketGenTime >= 0.3f)
		{
			CreateRocket();
		}
		
	}

	void AirPlaneUp()
	{
		transform.localPosition += new Vector3(0.1f, 0.02f, 0);
		//CancelInvoke("CreateRocket");
	}

	void CreateRocket()
	{

		if (FireRight == true)
		{
			Instantiate(temp, gameObject.transform.localPosition+ new Vector3(0,0,0.7f), Quaternion.identity);
			FireRight = false;
		}

		else if (FireRight == false)
		{
			Instantiate(temp, gameObject.transform.localPosition + new Vector3(0, 0, -0.7f), Quaternion.identity);
			FireRight = true;
		}
		RocketGenTime = 0.0f;
	}
}
