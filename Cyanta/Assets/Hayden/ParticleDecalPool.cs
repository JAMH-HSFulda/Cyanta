using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDecalPool : MonoBehaviour
{
    private int particleIndex;
    public int maxDecals = 100;

    public float min = .5f; //for random size
    public float max = 1.5f;

    private ParticleDecalData[] particleData;
    private ParticleSystem.Particle[] particles;

    private ParticleSystem decalPartSys;

    // Start is called before the first frame update
    void Start()
    {
        
        decalPartSys = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[maxDecals];
        particleData = new ParticleDecalData[maxDecals];
        for (int i = 0; i < maxDecals; i++) 
        {
            particleData[i] = new ParticleDecalData();
        }
    }

    public void ParticleHit(ParticleCollisionEvent particleCollisionEvent, Color colorGrad) 
    {
        SetParticleData(particleCollisionEvent, colorGrad);
        DisplayParticles();
    }


    void SetParticleData(ParticleCollisionEvent particleCollisionEvent, Color colorGrad) 
    {
        if (particleIndex >= maxDecals) {
            particleIndex = 0;
        }

        particleData[particleIndex].position = particleCollisionEvent.intersection;
        Vector3 particleRotationEuler = Quaternion.LookRotation(particleCollisionEvent.normal).eulerAngles;
        particleRotationEuler.z = Random.Range(0, 360);
        particleData[particleIndex].rotation = particleRotationEuler; 
        particleData[particleIndex].size = Random.Range(min, max); //to add some organics to the size
        particleData[particleIndex].color = colorGrad;

        particleIndex++;
    }

    void DisplayParticles() 
    {
        
        for (int i = 0; i < particleData.Length; i++) 
        {
            particles[i].position = particleData[i].position;
            particles[i].rotation3D = particleData[i].rotation;
            particles[i].startSize = particleData[i].size;
            particles[i].startColor = particleData[i].color;
        }

        decalPartSys.SetParticles(particles, particles.Length);
    }
}
