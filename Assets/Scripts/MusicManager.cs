using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    #region
    public static MusicManager instance { get; private set; }

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
    private AudioSource AudioSource;
    public AudioClip Stage5Music, MainTheme;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        ChangeToMainTheme();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMusicLevel5()
    {
        AudioSource.clip = Stage5Music;
        AudioSource.Play();
    }

    public void ChangeToMainTheme()
    {
        AudioSource.clip = MainTheme;
        AudioSource.Play();
    }
}
