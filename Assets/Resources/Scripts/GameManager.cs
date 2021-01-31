using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton class that handles game state (keeps track of progress)
public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameManager>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGameStatus()
    {
        Destroy(gameObject);
    }
}
