using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAttactor : MonoBehaviour
{
    public Rigidbody rb;

    private const float G = 6.67f;

    public static List<PlanetAttactor> pAttactors;

    void AttractorFormular(PlanetAttactor other)
    {


        Rigidbody rb0ther = other.rb;

        Vector3 direction = rb.position - rb0ther.position;

        float distance = direction.magnitude;

        //F = G * (m1*m2)//d^2;
        float forceMagnitude = G * (rb.mass * rb0ther.mass) / Mathf.Pow(distance, 2);

        Vector3 forceDir = direction.normalized * forceMagnitude;

        rb0ther.AddForce(forceDir);

    }//AttractorFormular




    void FixedUpdate()
    {
        foreach (var attactor in pAttactors)
        {
            if (attactor != this)
            {
                AttractorFormular(attactor);
            }
        }


    }//FixedUpdate

    private void OnEnable()
    {
        if (pAttactors == null)
        {
            pAttactors = new List<PlanetAttactor>();
        }
        pAttactors.Add(this);
    }//OnEnable

}//PlanetAttactor
