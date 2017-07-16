using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlane : MonoBehaviour {

	float CurTime = 0.0f;
	bool AirPlaneUpCheck;
	// Use this for initialization
	void Start () {
		AirPlaneUpCheck = false;

		transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
		transform.localPosition = new Vector3(-40, 15.1f, -8.42f);
		transform.localRotation = Quaternion.Euler(-90, 0, 0);
		transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 20, 0);
		Destroy(gameObject, 15.0f);
	}
	
	// Update is called once per frame
	void Update () {
		CurTime += Time.deltaTime;



		//transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 20 - (CurTime / 1.0f * 15), 0);
		

		if (transform.localPosition.x < -22)
			{
				AirPlaneDown();
			}
			if (0 > transform.localPosition.x && transform.localPosition.x >= -22)
			{


				transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 20 - (CurTime / 1.0f * 15), 0);
				AirPlaneStraight();

				if (transform.FindChild("bomb_plane 1").localRotation.y <= 0)
				{
					transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 0, 0);
				}
			}
			if (transform.localPosition.x >= 0.0f && AirPlaneUpCheck == false)
			{
				CurTime = 0.0f;
				AirPlaneUpCheck = true;
			}
			if (transform.localPosition.x > 0 && AirPlaneUpCheck == true)
			{
				if (transform.localPosition.x <= 8.0f)
				{
					transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 0 - (CurTime / 1.0f * 15), 0);

				}

				AirPlaneUp();
			}
		}

	void AirPlaneDown()
	{
		Transform temp;
		CurTime = 0.0f;
		transform.localPosition += new Vector3(0.1f, -0.05f, 0);
		transform.FindChild("bomb_plane 1").localRotation = Quaternion.Euler(0, 20 - (CurTime / 2.0f * 15), 0);
		//temp.localRotation = 30 - (CurTime / 1.0f * 15);
	}

	void AirPlaneStraight()
	{
		transform.localPosition += new Vector3(0.1f, 0, 0);

	}

	void AirPlaneUp()
	{
		transform.localPosition += new Vector3(0.1f, 0.02f, 0);

	}

}
