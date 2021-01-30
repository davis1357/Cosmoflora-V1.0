using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    Planet[] allPlanets;
    public bool isSpace = true;
    Player player;
    List<SurfaceActivation> zoomSurfaces = new List<SurfaceActivation>();
    SurfaceActivation surfaceActivation;

    private void Start()
    {
        allPlanets = FindObjectsOfType<Planet>();
        player = GetComponent<Player>();
        surfaceActivation = FindObjectOfType<SurfaceActivation>();
    }

    private void Update()
    {

        if (isSpace)
        {
            for (int i = 0; i < allPlanets.Length; i++)
            {
                allPlanets[i].gameObject.SetActive(true);
            }
            surfaceActivation.gameObject.SetActive(false);
            
        }
        else
        {  
            for (int i = 0; i < allPlanets.Length; i++)
            {
                allPlanets[i].gameObject.SetActive(false);
            }
            surfaceActivation.gameObject.SetActive(true);
        }
    }

    public void DontPlant()
    {
        isSpace = true;
        FindObjectOfType<Player>().enabled = true;
    }
}
