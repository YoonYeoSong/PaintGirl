using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoard : MonoBehaviour
{
    [SerializeField]
    UIProgressBar ProgressBar = null;
    [SerializeField]
    UILabel HPLabel = null;
    float holdTime = 2.0f;
    //총 충돌갯수
    const int ColiderSize = 210;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(checkTag(holdTime));
    }


    IEnumerator checkTag(float timer)
    {
        yield return new WaitForSeconds(2.0f);
        //게임오브젝트에서 태그가 A, B인것을 2초마다 반복 실행하면서 배열에 저장
        GameObject[] ACheck = GameObject.FindGameObjectsWithTag("A");
        GameObject[] BCheck = GameObject.FindGameObjectsWithTag("B");
        //APlyer 점유율 
        //배열의 길이로 점유율 계산 
        ProgressBar.value = ((float)ACheck.Length / ((float)ACheck.Length + (float)BCheck.Length));
        HPLabel.text = ACheck.Length.ToString()
        + " / " + BCheck.Length.ToString();




        //2초마다 코루틴실행
        StartCoroutine(checkTag(timer));
    }


}
