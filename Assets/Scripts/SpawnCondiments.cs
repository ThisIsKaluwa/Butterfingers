using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCondiments : MonoBehaviour
{

    public ParticleSystem Ketchup;
    public ParticleSystem Mustard;
    public GameObject CondimentsSpawnHere;

    bool noKetchupYet = true;
    bool noMustardYet = true;

    Renderer[] condiments;

    ParticleSystem particles;
    ParticleSystem.Particle[] particle;


    // Start is called before the first frame update
    void Start()
    {
        condiments = CondimentsSpawnHere.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < condiments.Length; i++)
        {
            if (i != 0)
            {
                condiments[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Ketchup.isPlaying)
        {
            particles = Ketchup;
            spawnCondiment();
        }

        if (Mustard.isPlaying)
        {
            particles = Mustard;
            spawnCondiment();
        }


    }

    void spawnCondiment()
    {

        InitializeIfNeeded();

        int numParticlesAlive = particles.GetParticles(particle);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {

            if (Vector3.Distance(particle[i].position, CondimentsSpawnHere.transform.position) <= 0.04)
            {

                if (particles == Ketchup && noKetchupYet)
                {
                    if ((Vector3.Dot(CondimentsSpawnHere.transform.up, Vector3.up)) <= 1.0f && (Vector3.Dot(CondimentsSpawnHere.transform.up, Vector3.up)) >= 0.8f)
                    {
                        condiments[1].enabled = true;
                        noKetchupYet = false;
                    }
                    else
                    {
                        condiments[3].enabled = true;
                        noKetchupYet = false;
                    }

                }

                if (particles == Mustard && noMustardYet)
                {

                    if ((Vector3.Dot(CondimentsSpawnHere.transform.up, Vector3.up)) <= 1.0f && (Vector3.Dot(CondimentsSpawnHere.transform.up, Vector3.up)) >= 0.8f)
                    {
                        condiments[2].enabled = true;
                        noMustardYet = false;
                    }

                    else
                    {
                        condiments[4].enabled = true;
                        noMustardYet = false;
                    }
                }
            }
        }
    }

    void InitializeIfNeeded()
    {
        if (particles == null)
            particles = particles.GetComponent<ParticleSystem>();

        if (particle == null || particle.Length < particles.main.maxParticles)
            particle = new ParticleSystem.Particle[particles.main.maxParticles];
    }
}
