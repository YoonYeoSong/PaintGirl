using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleLauncher : MonoBehaviour {
	public ParticleSystem particleLauncher;
	public ParticleSystem splatterParticles;
	public Gradient particleColorGradient;
	public ParticleDecalPool splatDecalPool;
	int Team;
	JoyStick joystick = null;

	List<ParticleCollisionEvent> collisionEvents;
   // List<ParticleCollisionEvent> collisionEventsB;
    //플레이어충돌태그 가지고있음 
    //SplatOnCollision sp = null;
    //HiddenItemRespawn s1 = null;
    void Start()
	{

		//joystick = GameObject.Find("JoyStick").GetComponent<JoyStick>();
		collisionEvents = new List<ParticleCollisionEvent>();
		//collisionEventsB = new List<ParticleCollisionEvent>();
		// sp = GameObject.Find("SplatterParticles").GetComponent<SplatOnCollision>();
		// s1 = GameObject.Find("HiddenBox").GetComponent<HiddenItemRespawn>();
		if (transform.parent.parent.parent.gameObject.name == "PlayerA")
		{
			Team = 1; // A팀
		}
		

		if (transform.parent.parent.parent.gameObject.name == "PlayerB")
		{
			Team = 2; // A팀
		}

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

    }



	//콜라이더와 충돌후 분산되는 파티클 설정
	void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
	{   //위치
		splatterParticles.transform.position = particleCollisionEvent.intersection;
		//회전
		splatterParticles.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);
		ParticleSystem.MainModule psMain = splatterParticles.main;
	}
	void Update()
	{



		//if(joystick.IsPressed == true)
		//{ 
		ParticleSystem.MainModule psMain = particleLauncher.main;
		if (Input.GetButtonDown("Fire1"))
		{
			if (Team == 1)
			{
				if (transform.parent.parent.parent.gameObject.GetComponent<Player>().StunItem == false)
				{
					
					//발사중에 있는 파티클 색상 
					psMain.startColor = Color.yellow;
					particleLauncher.Emit(1);
				}
			}
			else if (Team == 2)
			{
				if (transform.parent.parent.parent.gameObject.GetComponent<PlayerB>().StunItem == false)
				{
					
					//발사중에 있는 파티클 색상 
					psMain.startColor = Color.green;
					particleLauncher.Emit(1);
				}
			}
		}
        //콜라이더와 충돌후 분산되는 파티클 색상 
        psMain.startColor = particleColorGradient.Evaluate(0f);
        //하나씩
        splatterParticles.Emit(1);
    }



}