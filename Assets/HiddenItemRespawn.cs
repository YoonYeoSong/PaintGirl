using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenItemRespawn : MonoBehaviour {


    //플레이어충돌태그 가지고있음 
    SplatOnCollision sp = null;

	ParticleDecalPool s2 = null;


    // 컴퍼넌트 받아올 리스트 
    List<Collider> testList;
    List<Collider> testList2;
    public string m3;
    public bool CheckColliderUse = false;

    void Start () {
         //sp = GameObject.Find("SplatterParticles").GetComponent<SplatOnCollision>();
		//s2 = GameObject.Find("SplatterDecalParticle").GetComponent<ParticleDecalPool>();

       //s1 = GameObject.Find("PF_UI_SCORE").GetComponent<TestBoard>();


        testList = new List<Collider>();
        testList2 = new List<Collider>();


    }
    
    // Update is called once per frame
    void Update () {

    //    testList = Finding("A");
      //  testList2 = Finding("B");

    
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

        testList = Finding("A");
        testList2 = Finding("B");
        m3 = other.tag;
        //점유율이 낮은 플레이어가 히든아이템을 먹었을떄 작용  
        //a,b 태그를 뒤바꾼다. 

        if (other.CompareTag("APlayer")){
            if (testList.Count > testList2.Count)
            {
                Debug.Log("a점유율이 더 큼");
                
            }
            else
            {
                for (int i = 0; i < testList.Count; i++)
                {
                    testList[i].tag = "B";
                }

                for (int i = 0; i < testList2.Count; i++)
                {
                    testList2[i].tag = "A";
                }
                CheckColliderUse = true;
            }
        }
        else if(other.CompareTag("BPlayer"))
        {
            if (testList2.Count > testList.Count)
            {
                Debug.Log("B점유율이 더 큼");
            }
            else
            {
                for (int i = 0; i < testList.Count; i++)
                {
                    testList[i].tag = "B";
                }

                for (int i = 0; i < testList2.Count; i++)
                {
                    testList2[i].tag = "A";
                }
                CheckColliderUse = true;
            }
        }
    
    }
    //충돌후에 나갔을때 
    private void OnTriggerExit(Collider other)
    {
        CheckColliderUse = false;
        Destroy(this.gameObject, 0.2f);

    }
}
