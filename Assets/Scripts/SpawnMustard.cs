using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMustard : MonoBehaviour
{

    public ParticleSystem Mustard;
    ParticleSystem.Particle[] m_Particle;

    public GameObject MustardSquiggle;
    public GameObject MustardGoesHere;

    Renderer rendererForMustardGoesHere;
    float mustardHereHeight;
    float mustardHereDepth;
    bool noMustardYet = true;

    // Start is called before the first frame update
    void Start()
    {

        rendererForMustardGoesHere = MustardGoesHere.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mustardHereHeight = rendererForMustardGoesHere.bounds.size.y;
        mustardHereDepth = rendererForMustardGoesHere.bounds.size.z;


        spawnCondiment();

    }

    void spawnCondiment()
    {

        InitializeIfNeeded();

        int numParticlesAlive = Mustard.GetParticles(m_Particle);



        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {

            if (Vector3.Distance(m_Particle[i].position, MustardGoesHere.transform.position) <= 0.1 && noMustardYet)
            {

                if (FindCondimentScript.IsThereCondiment("ketchup"))
                {
                    Instantiate(MustardSquiggle, new Vector3(MustardGoesHere.transform.position.x, MustardGoesHere.transform.position.y + mustardHereHeight / 2, 
                    MustardGoesHere.transform.position.z - mustardHereDepth / 4), Quaternion.identity);

                    noMustardYet = false;
                }
                else
                {
                    Instantiate(MustardSquiggle, new Vector3(MustardGoesHere.transform.position.x, MustardGoesHere.transform.position.y + mustardHereHeight / 2, 
                    MustardGoesHere.transform.position.z), Quaternion.identity);
                    noMustardYet = false;
                    FindCondimentScript.SetCondiment("mustard");
                }
            }
        }

    }

    void InitializeIfNeeded()
    {
        if (Mustard == null)
            Mustard = GetComponent<ParticleSystem>();

        if (m_Particle == null || m_Particle.Length < Mustard.main.maxParticles)
            m_Particle = new ParticleSystem.Particle[Mustard.main.maxParticles];
    }
}
