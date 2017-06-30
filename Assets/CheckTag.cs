//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//public class CheckTag : MonoBehaviour
//{

//    float holdTime = 5.0f;

//    //GameObject[] m1 = GameObject.FindGameObjectsWithTag("A");


//    // Use this for initialization
//    void Start()
//    {
//        StartCoroutine(checkTag(holdTime));

//    }

//    // void FixedUpdate()
//    //{
//    //        //5초마다 반복실행 
//    //    InvokeRepeating("checkTag", 0, 10);

//    //}
//    //void checkTag()
//    //{
//    //    GameObject[] m1 = GameObject.FindGameObjectsWithTag("A");
//    //    foreach (GameObject goTemp in m1)
//    //    {
//    //        Debug.Log(m1.Length);
//    //    }

//    //}

//    IEnumerator checkTag(float timer)
//    {
//        yield return new WaitForSeconds(5.0f);

//        GameObject[] ACheck = GameObject.FindGameObjectsWithTag("A");
//        GameObject[] BCheck = GameObject.FindGameObjectsWithTag("B");
//        //1부터 충돌오브젝트수까지 
//        for (int i = 1; i < gameObject.transform.childCount; i++)
//        {       //배열길이
//            Debug.Log("Acheck" + ACheck.Length);
//            Debug.Log("Bcheck" + BCheck.Length);
//        }
//        //5초마다 코루틴실행
//        StartCoroutine(checkTag(timer));
//    }



//}
