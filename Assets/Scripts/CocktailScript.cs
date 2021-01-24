using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the 'mixing' of a cocktail (specifically a screwdriver), which contains two inedients  */
public class CocktailScript : MonoBehaviour
{


    public ParticleSystem Vodka;
    public ParticleSystem OrangeJuice;
    public GameObject Liquid;
    public GameObject Glass;
    public GameObject Umbrella;


    Collider collide;

    bool glassIsFull = false;
    bool glassIsUpright = true;

    Material material; //needed to determine what color the cocktail currently has

    ParticleSystem particles;
    ParticleSystem.Particle[] particle;

    bool containsOJ = false;
    bool containsVodka = false;

    bool onceFilled = false;

    AllGlassesFilledScript filledScript;
    // Start is called before the first frame update
    void Start()
    {
        filledScript = GameObject.Find("Scriptholder").GetComponent<AllGlassesFilledScript>();
        filledScript.everyGlassToFill++;
        Liquid.GetComponent<Renderer>().enabled = false;
        Umbrella.GetComponent<Renderer>().enabled = false;
        collide = Glass.transform.Find("PourCollider").GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {

        glassIsUpright = checkIfGlassUpright();

        if (glassIsUpright)
        {
            CheckWhichLiquid();

        }

        else
        {
            DespawnLiquid();
        }

    }

    /* Check which particle system is used to fill the glass to determine which color he Liquid will be */
    void CheckWhichLiquid()
    {

        if (OrangeJuice.isPlaying)
        {
            material = OrangeJuice.GetComponent<Renderer>().material;
            particles = OrangeJuice;
            SpawnLiquid();
        }

        if (Vodka.isPlaying)
        {
            if (!containsOJ)
            {
                material = Vodka.GetComponent<Renderer>().material;
            }
            else
            {
                material = OrangeJuice.GetComponent<Renderer>().material;
            }

            particles = Vodka;
            SpawnLiquid();
        }
    }

    /* Creates the 'liquid' inside the glass*/
    void SpawnLiquid()
    {
        InitializeIfNeeded();

        // GetParticles is allocation free because we reuse the particle buffer between updates
        int numParticlesAlive = particles.GetParticles(particle);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {

            if (Vector3.Distance(particle[i].position, collide.transform.position) <= 0.05 && !glassIsFull)
            {
                Liquid.GetComponent<Renderer>().enabled = true;
                Liquid.GetComponent<Renderer>().material = material;

                Liquid.transform.Translate(new Vector3(0, +0.001f, 0) * Time.deltaTime * 2, Space.Self);

                Vector3 size = Liquid.transform.localScale;
                size.y += 0.1f * Time.deltaTime * 2;
                Liquid.transform.localScale = size;


                if (Liquid.transform.localScale.y >= 5.0f)
                {
                    Umbrella.GetComponent<Renderer>().enabled = true;
                    glassIsFull = true;
                }

                if (particles == OrangeJuice)
                {
                    containsOJ = true;
                }
                if (particles == Vodka)
                {
                    containsVodka = true;
                }
            }
        }

        // Apply the particle changes to the Particle System
        particles.SetParticles(particle, numParticlesAlive);

        if (containsOJ && containsVodka && glassIsFull)
        {
            filledScript.everyFilledGlass++;
            onceFilled = true;
        }
    }

    /* Initialize the particle system with a set amount of particles if it doesn't exist correctly*/
    void InitializeIfNeeded()
    {
        if (particles == null)
            particles = GetComponent<ParticleSystem>();

        if (particle == null || particle.Length < particles.main.maxParticles)
            particle = new ParticleSystem.Particle[particles.main.maxParticles];
    }

    /* If the glass is tipped over more than a specific angle, 'empty' the cup, by diminishing the liquid inside */
    void DespawnLiquid()
    {

        glassIsFull = false;

        
        if (onceFilled)
        {
            filledScript.everyFilledGlass--;
            onceFilled = false;
        }

        Umbrella.GetComponent<Renderer>().enabled = false;

        if (Liquid.transform.localScale.y >= 0.06f)
        {

            Liquid.transform.Translate(new Vector3(0, -0.001f, 0) * Time.deltaTime * 16.5f, Space.Self);

            Vector3 size = Liquid.transform.localScale;
            size.y -= 0.1f * Time.deltaTime * 20;
            Liquid.transform.localScale = size;

        }
        else
        {
            Liquid.GetComponent<Renderer>().enabled = false;
        }
    }

    /* See if the glass can be filled with liquid, or if it is too tilted for that */
    bool checkIfGlassUpright()
    {
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
