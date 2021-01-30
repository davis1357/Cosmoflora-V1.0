using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    public PlanetConfig planetConfig;

    private void Start()
    {
        planetConfig.SetAnimals();
        planetConfig.SetAtmosphere();
        planetConfig.SetBackground();
        planetConfig.SetFlora();
        planetConfig.SetTerrain();

        GetComponentInChildren<Atmosphere>().SetAtmosphere(planetConfig.GetAtmosphere());
        GetComponentInChildren<Core>().SetCore(planetConfig.GetTerrain());
    }
}
