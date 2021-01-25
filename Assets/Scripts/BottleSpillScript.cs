/** This script must be attached to a ParticleSystem, which has to be a child of a GameObject
This script handles when to play the ParticleSystem and when to stop it 

created with the help of: https://www.infogamerhub.com/spill-effect-script/ 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpillScript : MonoBehaviour
{
    ParticleSystem particles; 

    /// Start is called before the first frame update
    void Start()
    {
        ///Gets the PArticleSystem this script is attached to 
        particles = GetComponent<ParticleSystem>(); 
    }

    /// Update is called once per frame
    void Update()
    {

        ///if the angle of the GameObject the ParticleSystem is attached to is below 90 the ParticleSystem is active, otherwise it's stopped
        if (Vector3.Angle(Vector3.down, transform.up) <= 90f)
        {
            particles.Play();
        }

        else
        {
            particles.Stop();
        }
    }
}
