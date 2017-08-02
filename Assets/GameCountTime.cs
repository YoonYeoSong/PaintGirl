using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameCountTime : MonoBehaviour {
    UILabel label = null;
    public float Seconds = 30;
    public float Minutes = 0;
	float CurTime = 0.0f;
	GameObject GO = null;
	int OnceCheck = 0;

    HiddenItemBox HiddenBox = null;
    public bool HiddenTime = false;
    public bool check = false;
    bool Notice = false;
    void Start () {
        label = transform.GetComponent<UILabel>();
        HiddenBox = GameObject.Find("HiddenBox").GetComponent<HiddenItemBox>();
        //StartCoroutine(remainderTimer());

    }

	

private void Update()
	{
		//CurTime += Time.deltaTime;
	if (Minutes >= 0)
		{
            if (Seconds <= 0)
            {
                Seconds = 60;
      
                if (Minutes >= 1)
                {
                    Minutes = (Minutes - 1);
                }
                else
                {
                    Minutes = 0;
                    Seconds = 0;
                }
            }
            else
            {
                Seconds -= Time.deltaTime;

         


            }



            //180초 받아서 분,초 계산
            //TimeSpan ts = new TimeSpan(0,0, 150);
            //label.text = string.Format("{0:HH:mm:ss}", ts);


        }
      

   
        label.text = string.Format("{0:D2}:{1:D2}",
				   (int)Minutes, (int)Seconds);


        if ((int)Minutes == 0 && (int)Seconds == 40 && Notice == false)

        {
            Notice = true;
            CreateHiddenNotice();
        }
        if ((int)Minutes == 0 && (int)Seconds == 30 && check == false)
        {
            HiddenTime = true;
            Debug.Log("30check");
            HiddenBox.gameObject.SetActive(true);
           // HiddenBox.setfree();
            check = true;
            CreateHiddenCreateNotice();
        }


        if (Minutes == 0 && Seconds == 0 && OnceCheck == 0)
		{
			
			CreateGameResult();

			OnceCheck = 1;
		}


      


    }

	void CreateGameResult()
	{
		//GameObject.Find("Main Camera").GetComponent<ThirdPersonCamera>().enabled = false;

		GO = Resources.Load("Prefabs/UI/PF_UI_RESULT") as GameObject;
		
		GameObject Trans = Instantiate(GO, gameObject.transform.parent).gameObject;
		Trans.transform.localScale = Vector3.one;
		Trans.transform.localPosition = Vector3.zero;

		//Time.timeScale = 0.02f;

	}
    void CreateHiddenNotice()
    {
        GO = Resources.Load("Prefabs/Game/UI/HiddenNotice") as GameObject;
        GameObject Trans = Instantiate(GO, gameObject.transform.parent).gameObject;
        Trans.transform.localScale = Vector3.one;
        Trans.transform.localPosition = new Vector3(0,155,0);

    }

    void CreateHiddenCreateNotice()
    {
        GO = Resources.Load("Prefabs/Game/UI/HiddenCreateNotice") as GameObject;
        GameObject Trans = Instantiate(GO, gameObject.transform.parent).gameObject;
        Trans.transform.localScale = Vector3.one;
        Trans.transform.localPosition = new Vector3(0, 155, 0);
    }
}
