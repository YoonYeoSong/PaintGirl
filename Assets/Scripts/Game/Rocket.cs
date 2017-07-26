using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	float CurTime = 0.0f;
	Vector3 OriPos = Vector3.zero;





    // Use this for initialization
    void Start () {

        Destroy(gameObject, 1.5f);
		OriPos = gameObject.transform.localPosition;//GameObject.Find("AirPlane").gameObject.transform.localPosition;

		transform.localRotation = Quaternion.Euler(90, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		CurTime += Time.deltaTime;

	
		gameObject.transform.localPosition = Vector3.Lerp(OriPos, OriPos - new Vector3(0, 6, 0), CurTime/1.3f);
	}
    void OnTriggerEnter(Collider other)
    {

        if (gameObject.CompareTag("APlayer"))
        {

            if (other.gameObject.CompareTag("Coll"))
            {
                other.gameObject.tag = "A";
                //바닥에 칠해질때마다 배열에 넣어놓음 /  카운트? 
            }
            //}
            //상대가 칠한 바닥을 덧칠할때 다시 내것으로 바꿈
            else if (other.gameObject.CompareTag("B"))
            {
                other.gameObject.tag = "A";
            }
        }
        //상대 플레이어
        else if (gameObject.CompareTag("BPlayer"))
        {

            if (other.gameObject.CompareTag("Coll"))
            {
                other.gameObject.tag = "B";
            }
            //}
            //상대가 칠한 바닥을 덧칠할때 다시 내것으로 바꿈
            else if (other.gameObject.CompareTag("A"))
            {
                other.gameObject.tag = "B";
            }
        }

    }



 
}
