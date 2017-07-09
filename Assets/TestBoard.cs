using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoard : MonoBehaviour
{
    [SerializeField]
    UIProgressBar ProgressBar = null;
    [SerializeField]
    UILabel HPLabel = null;

    GameObject[] ACheck;
    GameObject[] BCheck;
    float holdTime = 0.2f;

    //총 충돌갯수
    const int ColiderSize = 210;



    // Use this for initialization
    void Start()
    {
        StartCoroutine(checkTag(holdTime));
    }


    public IEnumerator checkTag(float timer)
    {
        yield return new WaitForSeconds(0.1f);
        //게임오브젝트에서 태그가 A, B인것을 0.1초마다 반복 실행하면서 배열에 저장
        ACheck = GameObject.FindGameObjectsWithTag("A");
        BCheck = GameObject.FindGameObjectsWithTag("B");


    
        //배열의 길이로 점유율 계산 
        ProgressBar.value = ((float)ACheck.Length / ((float)ACheck.Length + (float)BCheck.Length));

		if (ACheck.Length != 0 || BCheck.Length != 0)
		{
			HPLabel.text = (((float)ACheck.Length / ((float)ACheck.Length + (float)BCheck.Length)) * 100).ToString("N0") + "%" + " / " +
				(((float)BCheck.Length / ((float)ACheck.Length + (float)BCheck.Length)) * 100).ToString("N0") + "%";

		}

		//HPLabel.text = ACheck.Length + "/" + BCheck.Length;


        //0.2초마다 코루틴실행
        StartCoroutine(checkTag(timer));
    }
    
  //public  void ChangeTag(string strTag)
  //  {
  //         if(strTag == "APlayer")
  //      {
  //          for(int i = 0; i < BCheck.Length; i++)
  //          {
  //              if (ACheck[i] != null)
  //              ACheck[i] = BCheck[i];
  //          }
  //      }
  //      else if(strTag == "Bplayer")
  //      {
  //          for (int i = 0; i < ACheck.Length; i++)
  //          {
  //              if (BCheck[i] != null)
  //                  BCheck[i] = ACheck[i];

  //              Debug.Log(ACheck[i]);
  //          }

  //      }
  //  }


        
}
