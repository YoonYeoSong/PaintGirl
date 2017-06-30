using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalDecalPool : MonoBehaviour {

    //
    public int MaxDecal = 10000000;
    //
    private int ParticalDecalIndex;




    public float DecalMinSize = 0.5f;

    public float DecalMaxSize = 1.5f;

    private ParticleDecalData[] particaldata; 


    private ParticleSystem.Particle[] Particles;

    private ParticleSystem decalParticleSystem;

	// Use this for initialization
	void Start () {

        decalParticleSystem = GetComponent<ParticleSystem>();

              //변수초기화
             particaldata = new ParticleDecalData[MaxDecal];
             Particles = new ParticleSystem.Particle[MaxDecal];

        for (int i = 0; i < MaxDecal; i++)
        {
             particaldata[i] = new ParticleDecalData();
        }
	}


   public void ParticleHit(ParticleCollisionEvent particlecollisionevenet, Gradient colorGradient)
    {   //데이터설정
        SetParticleData(particlecollisionevenet, colorGradient);
        //호출
        DisplayPartcle();

    }

    //파티클보여주는

    public void DisplayPartcle()
    {
        for(int i = 0; i < particaldata.Length; i++)
        {   //모든 paticaldata에 저장된 것을 옮김
            Particles[i].position = particaldata[i].Position;
            Particles[i].rotation3D = particaldata[i].Rotation;
            Particles[i].startColor = particaldata[i].color;
            Particles[i].startSize = particaldata[i].size;


        }


    }



    //충돌 포지션, 회전, 크기, 색상을 설정하여 ParticleDecalData배열에 저장 

    public void SetParticleData(ParticleCollisionEvent particlecollisionevenet, Gradient colorGradient) 
    {
        if (ParticalDecalIndex >= MaxDecal)
        {
            //최대100을 넘기면 다시 0으로 리셋시켜서 반복 
            ParticalDecalIndex = 0;
        }
        //충돌포지션
        particaldata[ParticalDecalIndex].Position = particlecollisionevenet.intersection;

        Vector3 particalRotationEuler = Quaternion.LookRotation(particlecollisionevenet.normal).eulerAngles;
        particalRotationEuler.z = Random.Range(0, 360);
        //충돌회전
        particaldata[ParticalDecalIndex].Rotation = particalRotationEuler;
        //사이즈를 랜덤하게 최소크기부터 최대크기까지 
        particaldata[ParticalDecalIndex].size = Random.Range(DecalMinSize, DecalMaxSize);
        //컬러
        particaldata[ParticalDecalIndex].color = colorGradient.Evaluate(Random.Range(0f, 1f));
        ParticalDecalIndex++;


        decalParticleSystem.SetParticles(Particles, Particles.Length);

    }
    

}
    
