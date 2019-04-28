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
            GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, Mathf.Lerp(StartPos, target, t), GetComponent<RectTransform>().position.z);
        }
    }

    void ChangeReady()
    {
        ready = true;
    }
}
