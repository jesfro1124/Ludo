using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tärning : MonoBehaviour
{
    public Ludo ludo;
    public AudioClip Dice;

    private void OnMouseUpAsButton() {
        int sida = Random.Range(1, 6);
        ludo.TärningenÄrKastad(sida);

        if(sida == 1){
            transform.eulerAngles = new Vector3(40,20,17);
            transform.position = new Vector3(1,6,0);
        }

        if(sida == 2){
            transform.eulerAngles = new Vector3(40,50,60);
            transform.position = new Vector3(1,6,0);
        }

        if(sida == 3){
            transform.eulerAngles = new Vector3(46,30,24);
            transform.position = new Vector3(1,6,0);
        }

        if(sida == 4){
            transform.eulerAngles = new Vector3(-46,56,34);
            transform.position = new Vector3(1,6,0);
        }

        if(sida == 5){
            transform.eulerAngles = new Vector3(46,70,60);
            transform.position = new Vector3(1,6,0);
        }

        if(sida == 6){
            transform.eulerAngles = new Vector3(40,20,-17);
            transform.position = new Vector3(1,6,0);
        }
        

        StartCoroutine(PlayLater());
    }

    IEnumerator PlayLater()
    {

        yield return new WaitForSeconds(1f);
        GetComponent<AudioSource>().PlayOneShot(Dice);
    }
}
