using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaScript : MonoBehaviour
{

    public ParticleSystem particles; 
    ParticleSystem.Particle[] particle;
    public GameObject Liquid;
    public GameObject Glass;

    
    bool glassIsFull = false;
    bool glassIsUpright = true;

    // Start is called before the first frame update
    void Start()
    {
        Liquid.GetComponent<Renderer>().enabled = false;
        AllGlassesFilledScript.everyGlassToFill++;

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

            if (Vector3.Distance(particle[i].position, Glass.transform.position) <= 0.2 && !glassIsFull)
            {
                
                Liquid.GetComponent<Renderer>().enabled = true;

                Liquid.transform.Translate(new Vector3 (0, + 0.001f, 0) * Time.deltaTime * 2 ,Space.Self);
             
                Vector3 size = Liquid.transform.localScale;
                size.y += 0.1f * Time.deltaTime * 2;
                Liquid.transform.localScale = size;


                if (Liquid.transform.localScale.y >= 5.0f)
                {
                    glassIsFull = true;
                    AllGlassesFilledScript.everyFilledGlass++;
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
        AllGlassesFilledScript.everyFilledGlass--;

        if (Liquid.transform.localScale.y >= 0.06f)
        {
            
        Liquid.transform.Translate(new Vector3 (0, - 0.001f, 0) * Time.deltaTime * 16.5f ,Space.Self);

        Vector3 size = Liquid.transform.localScale;
        size.y -= 0.1f * Time.deltaTime * 20;
        Liquid.transform.localScale = size;

        }
        else
        {
             Liquid.GetComponent<Renderer>().enabled = false;
        }
    }

    bool checkIfGlassUpright(){
        if (Vector3.Dot(Glass.transform.up, Vector3.up) >= 0.5f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
