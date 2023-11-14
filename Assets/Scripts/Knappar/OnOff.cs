using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    public bool isOn = true; 
    public AudioSource music;
    public AudioClip pop;

    void OnMouseUpAsButton() {
        isOn = !isOn;
        on.SetActive(isOn);
        GetComponent<AudioSource>().PlayOneShot(pop);
        off.SetActive(!isOn);
        if (isOn)
        music.Play();
        else
        music.Stop();
    }
}
