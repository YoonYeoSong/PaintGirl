using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour {
	public ParticleSystem particleLauncher;
	public ParticleSystem splatterParticles;
	public Gradient particleColorGradient;
	public ParticleDecalPool splatDecalPool;



	List<ParticleCollisionEvent> collisionEvents;
    List<ParticleCollisionEvent> collisionEventsB;
    //플레이어충돌태그 가지고있음 
    SplatOnCollision sp = null;
    HiddenItemRespawn s1 = null;
    void Start()
	{
		collisionEvents = new List<ParticleCollisionEvent>();
       collisionEventsB = new List<ParticleCollisionEvent>();
        sp = GameObject.Find("SplatterParticles").GetComponent<SplatOnCollision>();
        s1 = GameObject.Find("box").GetComponent<HiddenItemRespawn>();

    }



    //콜라이더와 파티클이 충돌될때마다 생성 
    void OnParticleCollision(GameObject other)
    {  
            ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);
            for (int i = 0; i < collisionEvents.Count; i++)
            {
                splatDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
                EmitAtLocation(collisionEvents[i]);


            }





        //if (sp.tag == "BPlayer")
        //{
        //    ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEventsB);
        //    for (int i = 0; i < collisionEventsB.Count; i++)
        //    {
        //        splatDecalPool.ParticleHitB(collisionEventsB[i], particleColorGradient);
        //        EmitAtLocation(collisionEventsB[i]);

        //    }
        //}
        //if (s1.checkusetag == true)
        //{
        //    for (int i = 0; i < collisionEvents.Count; i++)
        //    {
        //        splatDecalPool.ParticleHitB(collisionEvents[i], particleColorGradient);
        //        EmitAtLocation(collisionEvents[i]);

        //    }

        //    for (int i = 0; i < collisionEventsB.Count; i++)
        //    {
        //        splatDecalPool.ParticleHit(collisionEventsB[i], particleColorGradient);
        //        EmitAtLocation(collisionEventsB[i]);

        //    }

        //    Debug.Log("CHECK TAG");

        //}


        //if (sp.CompareTag("APlayer"))
        //{
        //    for (int i = 0; i < collisionEvents.Count; i++)
        //    {
        //        //if(sp.tag=="APlayer")
        //        splatDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);

        //        //if (sp.tag == "BPlayer")
        //        //splatDecalPool.ParticleHitB(collisionEvents[i], particleColorGradient);

        //        EmitAtLocation(collisionEvents[i]);
        //    }
        //}

        //if (sp.CompareTag("BPlayer"))
        //{
        //    for (int i = 0; i < collisionEventsB.Count; i++)
        //    {
        //        //if(sp.tag=="APlayer")
        //        splatDecalPool.ParticleHitB(collisionEventsB[i], particleColorGradient);
        //        //if (sp.tag == "BPlayer")
        //        //splatDecalPool.ParticleHitB(collisionEvents[i], particleColorGradient);
        //        EmitAtLocation(collisionEventsB[i]);
        //    }
        //}



    }


    //콜라이더와 충돌후 분산되는 파티클 설정
	void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
	{   //위치
		splatterParticles.transform.position = particleCollisionEvent.intersection;
        //회전
        splatterParticles.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);
		ParticleSystem.MainModule psMain = splatterParticles.main;
        
        //콜라이더와 충돌후 분산되는 파티클 색상 
		psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
        //하나씩
		splatterParticles.Emit(1);
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			ParticleSystem.MainModule psMain = particleLauncher.main;
            //발사중에 있는 파티클 색상 
            psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
			particleLauncher.Emit(1);
		}

      



    }






	//public void Shoot()
	//{
	//	if (Input.GetButton("Fire1"))
	//	{
	//		ParticleSystem.MainModule psMain = particleLauncher.main;
	//		psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
	//		particleLauncher.Emit(1);
	//	}
	//}
}
