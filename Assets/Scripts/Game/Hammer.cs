using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

	float CurTime = 0.0f; //현재 시간
	float LandTime = 0.2f; //내려가는시간 
	float FlyTime = 0.3f; // 올라가는 시간

	int check = 0;

	Vector3 FirstPosition = Vector3.zero;
	Vector3 LandPostion = Vector3.zero;
	private void Awake()
	{
		FirstPosition = this.gameObject.transform.position;
		FirstPosition += new Vector3(0, 9, 0);
		Debug.Log("position 위치 값 :" + FirstPosition);
		Destroy(this.gameObject, 1.8f);
	}

	private void Update()
	{
		CurTime += Time.deltaTime;
		
		transform.position = Vector3.Lerp(FirstPosition, FirstPosition - new Vector3(0, 5, 0), CurTime / LandTime);

		if (transform.position == (FirstPosition - new Vector3(0, 5, 0)) && check == 0)
		{
			LandPostion = transform.position;
			Debug.Log("랜드 포지션" + LandPostion);
			StartCoroutine("StayLand");
		}
		if (check == 1)
		{
			StopCoroutine("StayLand");
			transform.position = Vector3.Lerp(LandPostion, LandPostion + new Vector3(0, 9, 0), CurTime / FlyTime);
			Debug.Log("랜드 포지션" + LandPostion);

		}

		Debug.Log(transform.position);

	}


	IEnumerator StayLand()
	{
		Debug.Log("코루틴 들어옴 " );
		yield return new WaitForSeconds(1.3f);
		
		Debug.Log("1.2초 후");
		CurTime = 0.0f;
		check = 1;
		//StopCoroutine
	}


}
