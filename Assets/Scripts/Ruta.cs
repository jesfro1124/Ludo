using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta : MonoBehaviour
{
    public Ruta nastaRuta;
    public bool start;
    public bool mål;
    public float radie = 0.2f;
    public Ruta målGångRuta;
    public int målGångLag;
    public Ruta målområdet;

    public List<Spelare> spelare;

    public void FixaPjäsPositioner()
    {
        if (spelare.Count >= 2)
        {
            for (int i = 0; i < spelare.Count; i++)
            {
                float v = i * 2 * Mathf.PI / spelare.Count + Mathf.PI / 4f;
                spelare[i].transform.position = gameObject.transform.position + 
                    radie * new Vector3(Mathf.Cos(v), 0, Mathf.Sin(v));  
            }
        }
        else if (spelare.Count > 0)
        {
            spelare[0].transform.position = gameObject.transform.position;
        } 

        //if (s.ruta.välja) {
          //      Gå(ruta.bmål);
           // }


    }
}
