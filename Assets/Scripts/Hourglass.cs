using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets._2D;

public class Hourglass : MonoBehaviour
{
    public Image Top;
    public Image Bot;
    public Image HourglassAnim;

    public Slider slid;

    GameObject Player;

    public float AncienneVie;
    public float t = 0.0f;
    public bool Lerp;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        AncienneVie = Player.GetComponent<PlatformerCharacter2D>().Life/100;
    }

    // Update is called once per frame
    void Update()
    {

        if (Lerp)
        {
            HourglassAnim.gameObject.SetActive(true);
            Top.fillAmount = Mathf.Lerp(AncienneVie, Player.GetComponent<PlatformerCharacter2D>().Life / 100, t);
            t += 0.3f * Time.deltaTime;
        }
        else
        {
            t = 0.0f;
            HourglassAnim.gameObject.SetActive(false);
        }

        if (t > 1.0f)
        {
            Debug.Log("Stop");
            Lerp = false;
            t = 0.0f;
            AncienneVie = Player.GetComponent<PlatformerCharacter2D>().Life/100;
            HourglassAnim.gameObject.SetActive(false);
        }

        Bot.fillAmount = 1 - Top.fillAmount;
    }
}
