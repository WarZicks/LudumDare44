using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    public void OnClickPlay()
    {
        SceneManager.LoadScene("GameScenes");
    }

    public void OnClickStory()
    {
        SceneManager.LoadScene("StoryScene");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
