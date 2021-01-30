using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : MonoBehaviour
{
    //TODO: Change Color to sprite when possible and make it seen in inspector, putting the spirtes in the *LIST* there
    Color[] atmosphere = new Color[] { Color.green, Color.red, Color.blue };
    

    public void SetAtmosphere(int index)
    {
        //TODO: make it work with the first change
        GetComponent<SpriteRenderer>().color = atmosphere[index];
    }
}
