using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrain : MonoBehaviour
{
    //TODO: Change Color to sprite when possible and make it seen in inspector, putting the spirtes in the *LIST* there
    [SerializeField] List<Sprite> terrainSprites = new List<Sprite>();


    public void SetAtmosphere(int index)
    {
        //TODO: make it work with the first change
        GetComponent<SpriteRenderer>().sprite = terrainSprites[index];
    }
}
