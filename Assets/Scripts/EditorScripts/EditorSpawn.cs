using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets._2D;

public class EditorSpawn : MonoBehaviour
{
    GameObject Player;

    public GameObject[] Piece;

    [SerializeField]
    Camera camera;

    bool OnUI;

    [SerializeField]
    int Index;

    float lifemoins;

    [SerializeField]
    GameObject Clone;

    public float roundnb;

    public Hourglass HourglassScripts;

    public float RoundMultiple(float celui)
    {
        var resto = celui % roundnb;
        if (resto <= (roundnb / 2))
        {
            return (celui - resto);
        }
        else
        {
            return (celui + roundnb - resto);
        }
    }

    public bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }

    public List<RaycastResult> UIElement()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results;
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        HourglassScripts = GameObject.FindGameObjectWithTag("Hourglass").GetComponent<Hourglass>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnUI = IsPointerOverUIObject();
            if(OnUI)
            {
                foreach(RaycastResult result in UIElement())
                {
                    if(result.gameObject.GetComponent<IndexSpawn>())
                    {
                        Index = result.gameObject.GetComponent<IndexSpawn>().Index;
                        lifemoins = result.gameObject.GetComponent<IndexSpawn>().cout;
                        Clone = Instantiate(Piece[Index]);
                        Clone.GetComponent<PieceCollider>().Actif = true;
                        Clone.GetComponent<PieceCollider>().life = lifemoins;

                        Clone.transform.parent = GameObject.FindGameObjectWithTag("LevelController").transform.GetChild(LevelManager.instance.CurrentLevel);
                    }
                }


            }
        }

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            OnUI = false;
            Index = 0;
            if(Clone !=null)
            {
                Clone.transform.position = new Vector3(RoundMultiple(Clone.transform.position.x), RoundMultiple(Clone.transform.position.y), 0);
                Clone.GetComponent<PieceCollider>().Actif = false;
                Clone = null;
                Player.GetComponent<PlatformerCharacter2D>().Life -= lifemoins;
                Player.GetComponent<PlatformerCharacter2D>().CheckPlayerLife();
                HourglassScripts.Lerp = true;
            }
        }

        if (Input.GetMouseButton(0) && OnUI)
        {
            RaycastHit hit;
            Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 10);

            if (Physics.Raycast(ray, out hit))
            {
                if (Clone != null)
                {
                    Clone.transform.position = new Vector3(hit.point.x, hit.point.y, 0);
                }
            }
        }

    }
}
