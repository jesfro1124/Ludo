using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    static public int lag = 2;

    public GameObject[] lagMarkeringar;

    void Start()
    {
        lagMarkeringar[lag - 1].SetActive(true);
    }

}
