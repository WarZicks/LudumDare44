using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PieceCollider : MonoBehaviour
{
    GameObject Player;

    Renderer rend;

    [SerializeField]
    Color colorToTurn;

    [SerializeField]
    Color colorActif;

    [SerializeField]
    Color colorMainn;

    public bool Actif;

    bool collidertrigger = true;

    [HideInInspector]
    public float life;

    bool DoOnce;
    bool collid;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if(!Actif)
        {
            if(collidertrigger)
            {
                collidertrigger = false;
                Invoke("Desact", 0.1f);
            }
        }
        else
        {
            if(!collid)
            {
                rend.material.color = colorMainn;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!Actif)
        {
            if (!DoOnce)
            {
                Player.GetComponent<PlatformerCharacter2D>().Life += life;
                DoOnce = true;
            }
            Destroy(gameObject);
        }
        else
        {
            collid = true;
            rend.material.color = colorToTurn;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        collid = false;
        rend.material.color = colorMainn;
    }

    public void Desact()
    {
        rend.material.color = colorActif;
        GetComponent<Collider2D>().isTrigger = false;
        Destroy(this);
    }
}
