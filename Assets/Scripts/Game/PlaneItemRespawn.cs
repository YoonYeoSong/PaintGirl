using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneItemRespawn : MonoBehaviour {

    Player s1 = null;
    Player s2 = null;

    ParticleLauncher s3 = null;

    SplatOnCollision s4 = null;
    bool tickuse = false;

    bool changeCheck = false;
    float tick = 0;

    // Use this for initialization
    void Start()
    {
        s1 = GameObject.Find("PlayerA").GetComponent<Player>();
        s2 = GameObject.Find("PlayerB").GetComponent<Player>();
        s3 = GameObject.Find("ParticleLauncher").GetComponent<ParticleLauncher>();
        s4 = GameObject.Find("SplatterParticles").GetComponent<SplatOnCollision>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (tickuse == true)
        {
            tick += Time.deltaTime;

            if (tick >= 10)
            {
                Debug.Log("10s" + tick);
                //5초뒤 원상복귀
                BackScale(s1);
                BackScale(s2);
                tickuse = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("APlayer")) {
            changeScale(s1);
        }
        else if (other.CompareTag("BPlayer"))
        {
            changeScale(s2);
        }

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

}
