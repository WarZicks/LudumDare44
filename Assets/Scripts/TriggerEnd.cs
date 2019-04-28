using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    [Tooltip("Le premier est le canavs actif")]
    public GameObject[] CanvasZone;

    public GameObject[] Capacite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CanvasZone[0].SetActive(false);

            if (CanvasZone[1] != null)
            {
                CanvasZone[1].SetActive(true);
            }
            LevelManager.instance.ChangeLevel(1);
            if(Capacite !=null)
            {
                foreach (GameObject go in Capacite)
                {
                    go.SetActive(true);
                }
            }
        }
    }
}
