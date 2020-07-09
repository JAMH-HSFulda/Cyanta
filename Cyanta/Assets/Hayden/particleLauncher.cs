using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleLauncher : MonoBehaviour
{
    public ParticleDecalPool splatDecalPool;

    public ParticleSystem particleLaunch;

    public Color color;

    List<ParticleCollisionEvent> CollisionEvents;

    // Start is called before the first frame update
    void Start()
    {
        CollisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ParticleSystem.MainModule psMain = particleLaunch.main;
            color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            psMain.startColor = color;
            particleLaunch.Emit(1);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLaunch, other, CollisionEvents);

        for (int i = 0; i < CollisionEvents.Count; i++) {
            splatDecalPool.ParticleHit(CollisionEvents[i], color);
        }
    }
}
