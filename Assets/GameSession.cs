using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    Player player;
    Vector3 playerPosition;
    List<Transform> planetList = new List<Transform>();
    [SerializeField] GameObject planets;

    private void Awake()
    {
        SetUpSingleton();
        FindObjectOfType<Player>().enabled = false;
    }

    private void SetUpSingleton()
    {
        int numOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        foreach (Transform child in planets.transform)
        {
            planetList.Add(child.transform);
        }
    }
}
