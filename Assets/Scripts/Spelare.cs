using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spelare : MonoBehaviour
{
    public Ruta hem;
    public Ruta ruta;
    public Ludo ludo;
    public int lag;
    public Vector3 moveToPosition;
    public Vector3 moveFromPosition;
    public float moveTime = 0;
    public AudioSource winmusic;

    private float moveCurrentTime = 0;

    void Start()
    {
        GåHem();
    }

    void Update()
    {
        if (moveTime > 0) {
            moveCurrentTime += Time.deltaTime;
            if (moveCurrentTime >= moveTime) {
                transform.position = moveToPosition;
                moveTime = 0;
                ruta.FixaPjäsPositioner();
                if (ruta.mål && ruta.målområdet == null)
                    transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true;
            }
            else
                transform.position = moveFromPosition + (moveToPosition - moveFromPosition) * moveCurrentTime / moveTime + 
                    Mathf.Sin(Mathf.PI * moveCurrentTime / moveTime) * Vector3.up * 1.2f;
        }
    }

    private void OnMouseUpAsButton() {
        ludo.Drag(this);
    }

    public void GåHem() {
        Gå(hem, 0.1f);
    }

    public void GåEttSteg() {
        if (ruta.målGångLag == lag)
            Gå(ruta.målGångRuta);
        else
            Gå(ruta.nastaRuta);
    }

    private void Gå(Ruta nyruta, float time = 0.3f)
    {
        // transform.position = nyruta.gameObject.transform.position;
        moveFromPosition = transform.position;
        moveToPosition = nyruta.gameObject.transform.position;
        moveTime = time;
        moveCurrentTime = 0;
        if(ruta != null){
            ruta.spelare.Remove(this);
            ruta.FixaPjäsPositioner();
        }
        ruta = nyruta;
        ruta.spelare.Add(this);
    }

    public void GåttKlart()
    {
        for (int i = ruta.spelare.Count - 1; i >= 0; i--) {
            if (ruta.spelare[i].lag != this.lag) {
                ruta.spelare[i].GåHem();
            }
        }

        if (ruta.mål && ruta.målområdet != null) {
            winmusic.Play();
            StartCoroutine(GåTillMål(ruta.målområdet));
        }
    }

    IEnumerator GåTillMål(Ruta målområdet)
    {
        yield return new WaitForSeconds(1f);
        Gå(målområdet, 2f);
    }

}
