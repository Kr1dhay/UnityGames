using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    bool GameEnded = false;

    #region Singleton

    public static PlayerManager instance;

    void Awake()
	{
        instance = this;
	}

    #endregion

    public GameObject player;

    public void Endgame()
	{
        if (GameEnded == false)
        {
            Debug.Log("GAME OVER");
            Invoke("Restart", 1f);

            GameEnded = true;
        }


    }

    void Restart()
    {
        SceneManager.LoadScene(2);
    }
}
