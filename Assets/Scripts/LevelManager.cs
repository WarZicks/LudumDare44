using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region
    public static LevelManager instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public Transform LevelSelected, StartPosition;
    [SerializeField]public int CurrentLevel = 0;

    public List<GameObject> Plateforme;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateLevelSelected();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevel(int OffsetLevel)
    {
        CurrentLevel += OffsetLevel;
        UpdateLevelSelected();
        GameObject.FindGameObjectWithTag("Player").transform.position = StartPosition.position;
    }

    private void UpdateLevelSelected()
    {
        Transform FormerLevel;
        LevelSelected = transform.GetChild(CurrentLevel);
        FormerLevel = transform.GetChild(CurrentLevel - 1);
        LevelSelected.gameObject.SetActive(true);
        FormerLevel.gameObject.SetActive(false);
    }

    public void ResetNiv()
    {
        foreach(GameObject go in Plateforme)
        {
            Destroy(go);
        }
    }
}
