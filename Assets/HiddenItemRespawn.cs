using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenItemRespawn : MonoBehaviour {


    //충돌태그 가지고있음 
    SplatOnCollision sp = null;
    //TestBoard s1;
    // 컴퍼넌트 받아올 리스트 
    List<Collider> testList;
    List<Collider> testList2;
    List<string> testList3;

    public string[] m1;

    GameObject[] Mob1;
    GameObject[] Mob2;

    // Use this for initialization
    void Start () {
        sp = GameObject.Find("SplatterParticles").GetComponent<SplatOnCollision>();
        //s1 = GameObject.Find("PF_UI_SCORE").GetComponent<TestBoard>();
        testList = new List<Collider>();
        testList2 = new List<Collider>();
        testList3 = new List<string>();
        m1 = new string[100];


    }
    
    // Update is called once per frame
    void Update () {

        testList = Finding("A");
        testList2 = Finding("B");

    }


    public List<Collider> Finding(string tagName)
    {
        GameObject[] Mob = GameObject.FindGameObjectsWithTag(tagName); //태그이름을 찾아내어 배열에 담습니다. 
        List<Collider> mobList = new List<Collider>(); //이곳에 오브젝트의 컴퍼넌트를 담을것입니다. 

        //배열을 탐색합니다. 
        foreach (GameObject temp in Mob)
            mobList.Add(temp.GetComponent<Collider>()); //오브젝트가 가지고있는 컴퍼넌트를 리스트에 담습니다. 

        return mobList; //리스트를 리턴합니다. 
    }

    void OnTriggerEnter(Collider other) {
            
        if(other.tag == "APlayer")
        {
            //for (int i = 0; i < testList2.Count; i++)
            //{

            //    //testList3.Add(testList2[i].tag);

            ////    testList[i].tag = testList2[i].tag;
            //  testList2.Clear();
            //     testList2[i].tag = m1[i];
            //    Debug.Log("achange");
            //}
            testList = Finding("A");
            testList2 = Finding("B");



            //  for(int i= 0; ;i++)
            //{

            //    if (i < sp.BCount)
            //    {
            //        testList[i].tag = testList2[i].tag;


            //    }


            //}




        }
        //else if(sp.tag == "Bplayer")
        //{
        //    for (int i = 0; i < testList.Count; i++)
        //    {
        //        m1[i] = testList2[i].tag;
        //        //testList3.Add(testList2[i].tag);
        //        testList[i].tag = testList2[i].tag;
        //        testList[i].tag = m1[i];
        //        Debug.Log("bchange");
        //    }

        //}

    }
}
