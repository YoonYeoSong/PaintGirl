using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public ParticleSystem particleLauncher;
    public Gradient particleColorGradient;
    public ParticleDecalPool splatDecalPool;
    public ParticleSystem splatterParticles;

    JoyStick joystick = null;
    List<ParticleCollisionEvent> collisionEvents;
    void Start()
    {
        joystick = GameObject.Find("JoyStick").GetComponent<JoyStick>();
        collisionEvents = new List<ParticleCollisionEvent>();

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

        //콜라이더와 충돌후 분산되는 파티클 색상 
        psMain.startColor = particleColorGradient.Evaluate(0f);
        //하나씩
        splatterParticles.Emit(1);
    }


    void Update()
    {

        //if(joystick.IsPressed == true)
        //{ 
        if (Input.GetButtonDown("Fire1"))
        {
            ParticleSystem.MainModule psMain = particleLauncher.main;
            //발사중에 있는 파티클 색상 
            psMain.startColor = particleColorGradient.Evaluate(0f);
            particleLauncher.Emit(1);

        }

    }



}