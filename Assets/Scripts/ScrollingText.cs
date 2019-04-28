using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    float t;
    public float target;
    public float timeToReachTarget;
    float StartPos;
    bool ready;

    public bool Scroll;
    public GameObject Next;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = GetComponent<RectTransform>().position.y;
        target += 200;
        Invoke("ChangeReady", 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            t += Time.deltaTime / timeToReachTarget;
            if (Scroll)
            {
                GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, Mathf.Lerp(StartPos, target, t), GetComponent<RectTransform>().position.z);
            }
            else
            {
                if(t >1)
                {
                    if(Next !=null)
                    {
                        gameObject.SetActive(false);
                        Next.SetActive(true);
                    }
                }
            }
        }
    }

    void ChangeReady()
    {
        ready = true;
    }
}
