using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour {

    //파티클제어 
    public ParticleSystem particleLauncher;
    //흩뿌려지는 파티클을 사용하기 위해 선언
    public ParticleSystem SplatterParticle;

    public Gradient particleColorGradient;

    public ParticalDecalPool SplatterDecalPool;

    
    List<ParticleCollisionEvent> collisonEvent;


    // Use this for initialization
    void Start () {
        collisonEvent = new List<ParticleCollisionEvent>();
	}
     void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher,other,collisonEvent);
        for(int i = 0; i < collisonEvent.Count; i++)
        {
            SplatterDecalPool.ParticleHit(collisonEvent[i], particleColorGradient);
            EmitAtLocation(collisonEvent[i]);

        }

    }


    void EmitAtLocation(ParticleCollisionEvent collisonEvents)
    {   //splatterparticle의 파티클발사위치를 월드 상에서 충돌될때에서 교차점으로 계속 적용시키기 위해 
        SplatterParticle.transform.position = collisonEvents.intersection;
        //회전 계산 
        SplatterParticle.transform.rotation = Quaternion.LookRotation(collisonEvents.normal);

        ParticleSystem.MainModule psMain = SplatterParticle.main;
        //발사될때 파티클의 첫번째컬러 
        psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));

        //각각  한 파티클이 충돌될때마다 하나씩
        SplatterParticle.Emit(1);
    }

 
	// Update is called once per frame
	void Update () {
        //프레임마다 하나의 파티클을 보내게 허용한다 
        //예외처리 플레이어 행위의 상관없이 파티클보내는것을 막기 위함
        //마우스 왼쪽버튼눌렀을 경우에
        if (Input.GetButton("Fire1"))
        {   
            //
            ParticleSystem.MainModule psMain = particleLauncher.main;
            //발사될때 파티클의 첫번째컬러 
            psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
            particleLauncher.Emit(1);
        }
    

    }




}
