using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class TriggerEnd : MonoBehaviour
{
    GameObject Player;

    [Tooltip("Le premier est le canavs actif")]
    public GameObject[] CanvasZone;

    public GameObject[] Capacite;

    public enum spelll { None, Jump, DoubleJump, Wall }; //Will be used to keep track of what's selected
    public spelll currentSel; // Create a Selection object that will be used throughout script

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

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
            if(currentSel == spelll.Jump)
            {
                Player.GetComponent<PlatformerCharacter2D>().Jump = true;
            }
            if (currentSel == spelll.DoubleJump)
            {
                Player.GetComponent<PlatformerCharacter2D>().DoubleJump = true;
            }
            if (currentSel == spelll.Wall)
            {
                Player.GetComponent<PlatformerCharacter2D>().WallJumpb = true;
            }
        }
    }
}
