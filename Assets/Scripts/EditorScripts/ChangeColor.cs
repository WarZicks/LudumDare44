using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Renderer rend;

    [SerializeField]
    Color colorToTurn;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        rend.material.color = colorToTurn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
