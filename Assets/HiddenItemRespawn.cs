using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenItemRespawn : MonoBehaviour {

    int Team; // 1= A, 2= B
    //플레이어충돌태그 가지고있음 
    SplatOnCollision sp = null;
	ParticleDecalPool DecalPool = null;
    ItemGenerator Hidden = null; 

    //거대화 초기화 
    Player PlayerA = null;
    Player PlayerB = null;
    ParticleLauncher Launcher = null;
    public bool tickuse = false;
    //거대화 시간 초기화 
    float tick = 0;

    // 컴퍼넌트 받아올 리스트 
    List<Collider> testList;
    List<Collider> testList2;

    //점유율관련 초기화 
    public bool CheckColliderUse = false;

    void Start () {
        //점유율과 색깔바꾸기 초기화 
        DecalPool = GameObject.Find("SplatterDecalParticle").GetComponent<ParticleDecalPool>();
        testList = new List<Collider>();
        testList2 = new List<Collider>();

        //거대화관련 초기화 
        PlayerA = GameObject.Find("PlayerA").GetComponent<Player>();
        PlayerB = GameObject.Find("PlayerB").GetComponent<Player>();
        Launcher = GameObject.Find("ParticleLauncher").GetComponent<ParticleLauncher>();
        Hidden = GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>();


    }
    
    // Update is called once per frame
    void Update () {

       // 거대화 크기 복구
        

        //팀색상바꾸기
        //if(CheckColliderUse ==true)
        //{
        //    DecalPool.swapColorA();
        //    DecalPool.swapColorB();
        //   // CheckColliderUse = false;
        //}

    }

    //태그찾기 함수 
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
		int random = -1;
<<<<<<< HEAD
		//random = Random.Range(0, 2);

		//점유율이 낮은 플레이어가 히든아이템을 먹었을떄 작용  
		//a,b 태그를 뒤바꾼다. 
		if (random == -1)  // 점유율 바꾸기
		{
			if (other.CompareTag("APlayer"))
			{
				//if (testList.Count > testList2.Count)
				//{
				//	Debug.Log("a점유율이 더 큼");
				//}
				//else
				//{
					for (int i = 0; i < testList.Count; i++)
					{
						testList[i].tag = "B";
					}
=======
		random = Random.Range(0, 3);

>>>>>>> c7df9cf5ab3813dd4ba35984b2fc51209513a558

        if (other.CompareTag("AChar"))
        {
            Team = 1;
        }
        else if (other.CompareTag("BChar"))
        {
            Team = 2;
        }


<<<<<<< HEAD
				//}
			}
			else if (other.CompareTag("BPlayer"))
			{
				//if (testList2.Count > testList.Count)
				//{
				//	Debug.Log("B점유율이 더 큼");
				//}
				//else
				//{
					for (int i = 0; i < testList.Count; i++)
=======

        if (random == 0)  // 점유율 바꾸기
		{
            testList = Finding("A");
            testList2 = Finding("B");

            //점유율이 낮은 플레이어가 히든아이템을 먹었을떄 작용  
            //a,b 태그를 뒤바꾼다. 

            //if (other.CompareTag("AChar"))
            //{
            //if (testList.Count > testList2.Count)
            //{
            //	Debug.Log("a점유율이 더 큼");
            //}
          // }
            //else if (other.CompareTag("BChar"))
            //  {
            //    if (testList2.Count > testList.Count)
            //    {
            //        Debug.Log("B점유율이 더 큼");
            //    }
            //}
            for (int i = 0; i < testList.Count; i++)
>>>>>>> c7df9cf5ab3813dd4ba35984b2fc51209513a558
					{
						testList[i].tag = "B";
					}
					for (int i = 0; i < testList2.Count; i++)
					{
						testList2[i].tag = "A";
					}
<<<<<<< HEAD
					s2.swapColorA();
					s2.swapColorB();
					//CheckColliderUse = true;
				//}
=======
					CheckColliderUse = true;
>>>>>>> c7df9cf5ab3813dd4ba35984b2fc51209513a558
			}
		else if (random == 1) // 거대화 

		{
            Hidden.ScaleTime = 0.0f;
            Hidden.ChangeScale(Team);
            //if (other.CompareTag("AChar"))
            //{
            //    changeScale(PlayerA);
            //}
            //else if (other.CompareTag("BChar"))
            //{
            //    changeScale(PlayerB);
            //}
        }

        //비행기
        else if(random == 2)
        {

            Hidden.GenAirPlane(Team);
        }


    }
    //충돌후에 나갔을때 
    private void OnTriggerExit(Collider other)
    {
<<<<<<< HEAD
        //CheckColliderUse = false;
        Destroy(this.gameObject, 0.2f);
=======
       CheckColliderUse = false;
        // Destroy(gameObject, 0.5f);
    }


    void changeScale(Player player)
    {
        tickuse = true;
        player.FindInChild("SD_Basic_Change").transform.localScale = new Vector3(3, 3, 3);
        //    player.transform.localScale = new Vector3(3, 3, 3);
        //  player.GetComponentInChildren<ParticleLauncher>().ParticleSize = 0.5f;
        player.GetComponentInChildren<SplatOnCollision>().GetComponent<BoxCollider>().size = new Vector3(0.3f, 0.3f, 0.05f);
        player.GetComponentInChildren<ParticleDecalPool>().decalSizeMin = 6f;
        player.GetComponentInChildren<ParticleDecalPool>().decalSizeMax = 6f;
    }

    void BackScale(Player player)
    {
        player.FindInChild("SD_Basic_Change").transform.localScale = new Vector3(1, 1, 1);
        //   player.transform.localScale = new Vector3(1, 1, 1);
        //   player.GetComponentInChildren<ParticleLauncher>().ParticleSize = 0.2f;
        player.GetComponentInChildren<SplatOnCollision>().GetComponent<BoxCollider>().size = new Vector3(0.05f, 0.05f, 0.05f);
        player.GetComponentInChildren<ParticleDecalPool>().decalSizeMin = 1f;
        player.GetComponentInChildren<ParticleDecalPool>().decalSizeMax = 3f;
    }
    //거대화 크기 복구
  public  void ExitChangeScale()
    {
        tick += Time.deltaTime;
        if (tick >= 5)
        {
            Debug.Log("5s" + tick);
            //5초뒤 원상복귀
            BackScale(PlayerA);
            BackScale(PlayerB);
            tickuse = false;
        }
    }





    public void swapColorA()
    {

        for (int i = 0; i < DecalPool.particleData.Length; i++)
        {

            DecalPool.particleData[i].color = Color.green;
        }
        Debug.Log("swapColorA");
    }


    public void swapColorB()
    {
>>>>>>> c7df9cf5ab3813dd4ba35984b2fc51209513a558

        for (int i = 0; i < DecalPool.particleData2.Length; i++)
        {
            DecalPool.particleData2[i].color = Color.yellow;
        }
        Debug.Log("swapColorB");
    }

}
