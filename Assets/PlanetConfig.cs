using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Planet Config")]

public class PlanetConfig : ScriptableObject
{
    public int terrain;
    public int animals;
    public int background;
    public int flora;
    public int atmosphere;

    public void SetTerrain() { terrain = Random.Range(0, 6); }
    public void SetAnimals() { animals = Random.Range(0, 6); }
    public void SetBackground() { background = Random.Range(0, 6); }
    public void SetFlora() { flora = Random.Range(0, 3); }
    public void SetAtmosphere() { atmosphere = Random.Range(0, 3); }

    public int GetTerrain() { return terrain; }
    public int GetAnimals() { return animals; }
    public int GetBackground() { return background; }
    public int GetFlora() { return flora; }
    public int GetAtmosphere() { return atmosphere; }

}
