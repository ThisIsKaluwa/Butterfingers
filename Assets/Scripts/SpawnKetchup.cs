using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKetchup : MonoBehaviour
{

    public ParticleSystem Ketchup;
    ParticleSystem.Particle[] k_Particle;

    public GameObject KetchupSquiggle;
    public GameObject KetchupGoesHere;

    Renderer rendererForKetchupGoesHere; 
    float ketchupHereHeight;
    float ketchupHereDepth;
    bool noKetchupYet = true;

    // Start is called before the first frame update
    void Start()
    {

        rendererForKetchupGoesHere = KetchupGoesHere.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        ketchupHereHeight = rendererForKetchupGoesHere.bounds.size.y;
        ketchupHereDepth = rendererForKetchupGoesHere.bounds.size.z;

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
                if (Physics.CheckSphere(KetchupGoesHere.transform.position, 0.05f))
                {
                    Instantiate(KetchupSquiggle, new Vector3(KetchupGoesHere.transform.position.x, KetchupGoesHere.transform.position.y + ketchupHereHeight / 2, KetchupGoesHere.transform.position.z  - ketchupHereDepth / 4), Quaternion.identity);


                    noKetchupYet = false;
                }
                else
                {
                    Instantiate(KetchupSquiggle, new Vector3(KetchupGoesHere.transform.position.x, KetchupGoesHere.transform.position.y + ketchupHereHeight / 2, KetchupGoesHere.transform.position.z), Quaternion.identity);
                    noKetchupYet = false;
                }
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
