using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKetchup : MonoBehaviour
{

    public ParticleSystem Ketchup;
    ParticleSystem.Particle[] k_Particle;

    public GameObject KetchupSquiggle;
    public GameObject KetchupGoesHere;

    bool noKetchupYet = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        spawnCondiment();

    }

    void spawnCondiment()
    {

        InitializeIfNeeded();

        int numParticlesAlive = Ketchup.GetParticles(k_Particle);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {

            if (Vector3.Distance(k_Particle[i].position, KetchupGoesHere.transform.position) <= 0.02 && noKetchupYet)
            {
                Instantiate(KetchupSquiggle, new Vector3(0, 0, 0), Quaternion.identity);


                noKetchupYet = false;
            }
        }
    }

    void InitializeIfNeeded()
    {
        if (Ketchup == null)
            Ketchup = GetComponent<ParticleSystem>();

        if (k_Particle == null || k_Particle.Length < Ketchup.main.maxParticles)
            k_Particle = new ParticleSystem.Particle[Ketchup.main.maxParticles];
    }
}
