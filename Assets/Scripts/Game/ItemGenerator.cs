using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    Player APlayer = null;
    //PlayerB BPlayer = null;
    
    public GameObject ItemBoxGO = null;

    public GameObject HiddenItem = null;

    bool tickuse = false;
    GameCountTime HiddenTimeCheck = null;
    HiddenItemRespawn HiddenItembox = null;


    ParticleDecalPool DecalPool = null;

    float CurTime = 0.0f;
	float XPos = 0.0f;
	float ZPos = 0.0f;
    // Use this for initialization
    bool HiddenCreate = false;
	GameObject AirPlane = null;
   public float ScaleTime = 0.0f;
    int TeamNum = 0;


    void Start () {

        HiddenTimeCheck = GameObject.Find("Timer").GetComponent<GameCountTime>();
        HiddenItembox = GameObject.Find("HiddenBox").GetComponent<HiddenItemRespawn>();
        //DecalPool = GameObject.Find("SplatterDecalParticle").GetComponent<ParticleDecalPool>();

        if (ItemBoxGO == null)
			Debug.Log("ItemBox가 NUll입니다.");
		InvokeRepeating("ItemRegen", 2.0f, 4.0f);

        //GenAirPlane();

        APlayer = GameObject.Find("PlayerA").GetComponent<Player>();
        //BPlayer = GameObject.Find("PlayerB").GetComponent<PlayerB>();


    }
	
	// Update is called once per frame
	void Update () {
        ScaleTime += Time.deltaTime;
        CurTime += Time.deltaTime;
        //if (HiddenItembox.CheckColliderUse == true)
        //{
        //    DecalPool.swapColorA();
        //    DecalPool.swapColorB();
        //    Debug.Log("swap success");
        //}

  

        if (CurTime >= 6.0f && HiddenCreate == false)
		{
            //Vector3(-8.81f, 3.43f, -1.388f)
            Instantiate(HiddenItembox, new Vector3(0, 0, 0), Quaternion.Euler(0, 180, 0));

            HiddenCreate = true;

        }
        if (ScaleTime >= 5.0f && TeamNum != 0)
        {

            BackScale(TeamNum);
        }


	}

	void ItemRegen()
	{
		XPos = Random.Range(-21.0f, 3.5f);
		ZPos = Random.Range(-12.0f, 11.0f);

		Instantiate(ItemBoxGO,new Vector3(XPos,0.5f,ZPos),Quaternion.Euler(0,0,45));
	}

	public void GenAirPlane(int Team)
	{
<<<<<<< HEAD
<<<<<<< HEAD
		int RandomPos = -1 ;

		RandomPos = Random.Range(0, 6);
		
		GameObject temp = Resources.Load("Prefabs/Game/YellowAirPlane") as GameObject;
=======
		int RandomPos;
		GameObject Go = null;
		GameObject temp = Resources.Load("Prefabs/Game/AirPlane") as GameObject;
		//Go = Instantiate(temp,)
	}
>>>>>>> fa12a8a1ce1eb42594f2049f34ef12bcdf1e99bb

		if (RandomPos >= 3)
			RandomPos++;
	
=======
		int RandomPos = -1 ;
        GameObject temp = null; //비행기 프리팹

        RandomPos = Random.Range(0, 6);

        if (Team == 1) //A팀
        {
             temp = Resources.Load("Prefabs/Game/YellowAirPlane") as GameObject;
           
        }
        else if (Team == 2) // B팀
        {
             temp = Resources.Load("Prefabs/Game/GreenAirPlane") as GameObject;
           
        }
		if (RandomPos >= 3)
			RandomPos++;
>>>>>>> c7df9cf5ab3813dd4ba35984b2fc51209513a558
		AirPlane = Instantiate(temp, new Vector3(-40, 15.1f, -13.42f + RandomPos * 4.25f), Quaternion.identity);
		AirPlane.name = "AirPlane";
	}

    public void ChangeScale(int Team)
    {
        TeamNum = Team;
        if (Team == 1)
        {
            tickuse = true;
            APlayer.FindInChild("SD_Basic_Change").transform.localScale = new Vector3(3, 3, 3);
            //    player.transform.localScale = new Vector3(3, 3, 3);
            //  player.GetComponentInChildren<ParticleLauncher>().ParticleSize = 0.5f;
            APlayer.GetComponentInChildren<SplatOnCollision>().GetComponent<BoxCollider>().size = new Vector3(0.3f, 0.3f, 0.05f);
            APlayer.GetComponentInChildren<ParticleDecalPool>().decalSizeMin = 6f;
            APlayer.GetComponentInChildren<ParticleDecalPool>().decalSizeMax = 6f;
        }
        else if (Team == 2)
        {
            tickuse = true;
            //BPlayer.FindInChild("SD_Basic_Change").transform.localScale = new Vector3(3, 3, 3);
            
            //BPlayer.GetComponentInChildren<SplatOnCollision>().GetComponent<BoxCollider>().size = new Vector3(0.3f, 0.3f, 0.05f);
            //BPlayer.GetComponentInChildren<ParticleDecalPool>().decalSizeMin = 6f;
            //BPlayer.GetComponentInChildren<ParticleDecalPool>().decalSizeMax = 6f;
        }

    }
    void BackScale(int Team)
    {
        if (Team == 1)
        {
            APlayer.FindInChild("SD_Basic_Change").transform.localScale = new Vector3(1, 1, 1);
            //   player.transform.localScale = new Vector3(1, 1, 1);
            //   player.GetComponentInChildren<ParticleLauncher>().ParticleSize = 0.2f;
            APlayer.GetComponentInChildren<SplatOnCollision>().GetComponent<BoxCollider>().size = new Vector3(0.05f, 0.05f, 0.05f);
            APlayer.GetComponentInChildren<ParticleDecalPool>().decalSizeMin = 1f;
            APlayer.GetComponentInChildren<ParticleDecalPool>().decalSizeMax = 3f;
        }
        else if (Team == 2)
        {
            //BPlayer.FindInChild("SD_Basic_Change").transform.localScale = new Vector3(1, 1, 1);
            
            //BPlayer.GetComponentInChildren<SplatOnCollision>().GetComponent<BoxCollider>().size = new Vector3(0.05f, 0.05f, 0.05f);
            //BPlayer.GetComponentInChildren<ParticleDecalPool>().decalSizeMin = 1f;
            //BPlayer.GetComponentInChildren<ParticleDecalPool>().decalSizeMax = 3f;
        }
    }
}
