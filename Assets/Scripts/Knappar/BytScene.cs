using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BytScene : MonoBehaviour
{
    public string scene;
    public AudioClip pop;

    // Start is called before the first frame update
    void OnMouseUpAsButton() {
        GetComponent<AudioSource>().PlayOneShot(pop);
        SceneManager.LoadScene(scene);
    }
}
