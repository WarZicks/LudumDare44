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
    public bool Wait;

    [SerializeField]
    bool Go;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = GetComponent<RectTransform>().position.y;
        target += 200;
        if (Wait)
        {
            Invoke("ChangeReady", 5);
        }
        else
        {
            ready = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ready && Go)
        {
            t += Time.deltaTime / timeToReachTarget;
            if (Scroll)
            {
                GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, Mathf.Lerp(StartPos, target, t), GetComponent<RectTransform>().position.z);
                StartCoroutine(FadeTo(1.0f, GetComponent<CanvasGroup>(), true));
            }
            else
            {
                if(t >1)
                {
                     StartCoroutine(FadeTo(1.0f, GetComponent<CanvasGroup>(), true));
                }
            }
        }
    }

    void ChangeReady()
    {
        ready = true;
        Go = true;
    }

    IEnumerator FadeTo(float aTime, CanvasGroup a, bool In)
    {
        if (In)
        {
            float alpha = a.alpha;
            for (float t = 1f; t > 0f; t -= Time.deltaTime / aTime)
            {
                a.alpha = t;
                yield return null;
            }

            t = 0;
            Go = false;
            if (Next != null)
            {
                StartCoroutine(FadeTo(1.0f, Next.GetComponent<CanvasGroup>(), false));
            }  
        }
        else
        {
            float alpha = a.alpha;
            for (float x = 0; x < 1f; x += Time.deltaTime / aTime)
            {
                a.alpha = x;
                yield return null;
            }
            Next.GetComponent<CanvasGroup>().alpha = 1;
            Next.GetComponent<ScrollingText>().Go = true;
        }
    }
}
