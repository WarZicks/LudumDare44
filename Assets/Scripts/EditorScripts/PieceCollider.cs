using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCollider : MonoBehaviour
{

    public bool Actif;

    bool collidertrigger = true;

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
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (!Actif)
        {
            Destroy(gameObject);
        }
    }

    public void Desact()
    {
        GetComponent<Collider2D>().isTrigger = false;
        Destroy(this);
    }
}
