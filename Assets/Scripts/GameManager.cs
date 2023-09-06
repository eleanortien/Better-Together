using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

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
        DontDestroyOnLoad(transform.root.gameObject);
    }
    public string currentScene = "Level1";
    public string lastScene = "Level1";

    public void NewScene(string newSceneRoom)
    {
        lastScene = SceneManager.GetActiveScene().name;
        currentScene = newSceneRoom;
        SceneManager.LoadScene(newSceneRoom);

    }

    public void GameOver ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
