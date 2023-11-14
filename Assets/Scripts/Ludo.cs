using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ludo : MonoBehaviour
{
    public int lagPåTur = 1;
    public int antalLag = 4;
    public Spelare[] allaSpelare;
    public string[] lagNamn;
    public int tärning = 0;
    public string winscene;

    void Start()
    {
        lagPåTur = Random.Range(1, antalLag);
        Debug.Log("Lag " + lagNamn[lagPåTur - 1] + " börjar");
    }

    public void TärningenÄrKastad(int slag)
    {
        if (tärning == 0)
        {
            Debug.Log("Tärning: " + slag);

            tärning = slag;
            if (tärning != 1 && tärning != 6)
            {
                bool allaInne = true;
                foreach (Spelare s in allaSpelare) {
                    if (s.lag == lagPåTur && !s.ruta.start && !s.ruta.mål) {
                        allaInne = false;
                        break;
                    }
                }
                if (allaInne) {
                    Debug.Log("Lag " + lagNamn[lagPåTur - 1] + " är fast");
                    NästaLag();
                    return;
                }
            }
            Debug.Log("Välj en " + lagNamn[lagPåTur - 1] + " pjäs");
        }
    }

    public void Drag(Spelare spelare)
    {
        if (spelare.lag == lagPåTur && tärning > 0 &&
            !spelare.ruta.mål && 
            (!spelare.ruta.start || tärning == 1 || tärning == 6))
        {
            for (int i = 0; i < tärning; i++)
                spelare.GåEttSteg();
            spelare.GåttKlart();
            if (Win()) {
                Debug.Log("Lag " + lagNamn[lagPåTur - 1] + " vinner");
                Winner.lag = lagPåTur;
                StartCoroutine(WinScene());    
            }
            else if (tärning == 6)
            {
                Debug.Log("Lag " + lagNamn[lagPåTur - 1] + " slår igen!");
                tärning = 0;
            }
            else
                NästaLag();
        }
    }

    private void NästaLag()
    {
        lagPåTur = lagPåTur + 1;
        if (lagPåTur > antalLag) lagPåTur = 1;
        tärning = 0;
        Debug.Log("Lag " + lagNamn[lagPåTur - 1] + "s tur");
    }

    private bool Win()
    {
        foreach (Spelare s in allaSpelare) {
            if (s.lag == lagPåTur && !s.ruta.mål) {
                return false;
            }
        }
        return true;
    }

    IEnumerator WinScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(winscene);
    }
}
