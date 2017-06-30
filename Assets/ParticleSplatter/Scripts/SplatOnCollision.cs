using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatOnCollision : MonoBehaviour {

	public ParticleSystem particleLauncher;
	public Gradient particleColorGradient;
	//public ParticleDecalPool dropletDecalPool;

	List<ParticleCollisionEvent> collisionEvents;


	void Start () 
	{
		collisionEvents = new List<ParticleCollisionEvent> ();
	}

	void OnParticleCollision(GameObject other)
	{
		int numCollisionEvents = ParticlePhysicsExtensions.GetCollisionEvents (particleLauncher, other, collisionEvents);

		int i = 0;
		while (i < numCollisionEvents) 
		{
            //	dropletDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
            i++;
		}

	}
    void OnTriggerEnter(Collider other)
    {       //기본 게임시작시 아무것도 칠하지않는 상태에서 바닥 
        if (gameObject.tag == "APlayer")
        {
            if (other.gameObject.tag == "Coll")
            {
                other.gameObject.tag = "A";
            }
            //}
            //상대가 칠한 바닥을 덧칠할때 다시 내것으로 바꿈
            else if (other.gameObject.tag == "B")
            {
                other.gameObject.tag = "A";
            }
        }
        //상대 플레이어
        else if (gameObject.tag == "Bplayer")
        {
            if (other.gameObject.tag == "Coll")
            {
                other.gameObject.tag = "B";
            }
            //}
            //상대가 칠한 바닥을 덧칠할때 다시 내것으로 바꿈
            else if (other.gameObject.tag == "A")
            {
                other.gameObject.tag = "B";
            }
        }


    }

    void Update()
    {   //발사체가 충돌되고 그위치에 그대로 있어서 움직일때마다 바닥과 충돌되어 위치 갱신 
        transform.position = new Vector3(5, 5, 5);
    }
}
