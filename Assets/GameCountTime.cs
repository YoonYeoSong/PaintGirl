using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameCountTime : MonoBehaviour {
    UILabel label = null;
    public float Seconds = 30;
    public float Minutes = 1;



    void Start () {
        label = GameObject.Find("GameOverLabel").GetComponent<UILabel>();
        StartCoroutine(remainderTimer());
       
    }

    IEnumerator remainderTimer()
    {
        do
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
            label.text = string.Format("{0:D2}:{1:D2}",
                     (int)Minutes, (int)Seconds);


            //180초 받아서 분,초 계산
            //TimeSpan ts = new TimeSpan(0,0, 150);
            //label.text = string.Format("{0:HH:mm:ss}", ts);
            yield return null;
        } while (Minutes >= 0);


    }



}
