using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject resume;
    public GameObject settings;
    public bool isOnM = true; 
    public AudioClip pop;

    void OnMouseUpAsButton() {
        isOnM = !isOnM;
        resume.SetActive(isOnM);
        GetComponent<AudioSource>().PlayOneShot(pop);
        settings.SetActive(!isOnM);
    }
}
