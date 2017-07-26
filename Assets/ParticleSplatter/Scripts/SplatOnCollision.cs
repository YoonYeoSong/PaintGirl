using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatOnCollision : MonoBehaviour {

	public ParticleSystem particleLauncher;


    public int ACount = 0;
    public int BCount = 0;
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

		if (other.CompareTag("BPlayer"))
		{
			Debug.Log("B피격");
		}

		if (gameObject.CompareTag("APlayer"))
		{

			if (other.gameObject.CompareTag("Coll"))
			{
				other.gameObject.tag = "A";
				ACount++;


				//바닥에 칠해질때마다 배열에 넣어놓음 /  카운트? 
			}
			//}
			//상대가 칠한 바닥을 덧칠할때 다시 내것으로 바꿈
			else if (other.gameObject.CompareTag("B"))
			{
				other.gameObject.tag = "A";
				//ABcount++;
				ACount++;
				BCount--;
			}
		}
		//상대 플레이어
		else if (gameObject.CompareTag("BPlayer"))
		{

			if (other.gameObject.CompareTag("Coll"))
			{
				other.gameObject.tag = "B";
				BCount++;
			}
			//}
			//상대가 칠한 바닥을 덧칠할때 다시 내것으로 바꿈
			else if (other.gameObject.CompareTag("A"))
			{
				other.gameObject.tag = "B";
				BCount++;
				ACount--;
			}
		}
	}



	void Update()
    {   //발사체가 충돌되고 그위치에 그대로 있어서 움직일때마다 바닥과 충돌되어 위치 갱신 
		if(gameObject.transform.tag == "APlayer")
		transform.position = new Vector3(5, 5, 5);

		if (gameObject.transform.tag == "BPlayer")
			transform.position = new Vector3(15,15, 15);


		//Destroy(gameObject);
	}







}
