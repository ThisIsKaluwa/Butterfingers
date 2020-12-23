using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLiquidInCupScript : MonoBehaviour
{

    public ParticleSystem particles; 
    ParticleSystem.Particle[] particle;
    public GameObject Liquid;
    public GameObject glass;


    Vector3 startPos;
    Vector3 startSize; 
    bool glassIsFull = false;
    bool glassIsUpright = true;

    // Start is called before the first frame update
    void Start()
    {
        Liquid.GetComponent<Renderer>().enabled = false;
        startPos = Liquid.transform.position;
        startSize = Liquid.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {

        glassIsUpright = checkIfGlassUpright();

        if (glassIsUpright)
        {
            SpawnLiquid();
        }

        else
        {
            DespawnLiquid();
        }
        
    }

    void SpawnLiquid()
    {
        InitializeIfNeeded();

        // GetParticles is allocation free because we reuse the particle buffer between updates
        int numParticlesAlive = particles.GetParticles(particle);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {

            if (Vector3.Distance(particle[i].position, glass.transform.position) <= 0.2 && !glassIsFull)
            {
                
                Liquid.GetComponent<Renderer>().enabled = true;
                Liquid.transform.position += new Vector3(0, 0.0001f, 0);
                Liquid.transform.localScale += new Vector3(0, 0.01f, 0);

                 

                if (Liquid.transform.localScale.y >= 4.8f)
                {
                    glassIsFull = true;
                }
            }
        }

        // Apply the particle changes to the Particle System
        particles.SetParticles(particle, numParticlesAlive);
    }

    void InitializeIfNeeded()
    {
        if (particles == null)
            particles = GetComponent<ParticleSystem>();

        if (particle == null || particle.Length < particles.main.maxParticles)
            particle = new ParticleSystem.Particle[particles.main.maxParticles];
    }

    void DespawnLiquid(){

        glassIsFull = false;

        if (Vector3.Distance(Liquid.transform.position, startPos) >= 0.01f)
        {
            Liquid.transform.position += new Vector3(0, -0.0001f, 0);
            Liquid.transform.localScale += new Vector3(0, -0.01f, 0);
        }
        

        Liquid.GetComponent<Renderer>().enabled = false;
        
    }

    bool checkIfGlassUpright(){
        if (Vector3.Dot(glass.transform.up, Vector3.up) >= 0.5f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
