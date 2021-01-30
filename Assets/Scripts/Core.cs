using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    //TODO: Change Color to sprite when possible and make it seen in inspector, putting the spirtes in the *LIST* there
    Color[] coreColor = new Color[] { Color.green, Color.red, Color.blue, Color.black, Color.cyan, Color.yellow };


    public void SetCore(int index)
    {
        //TODO: make it work with the first change
        GetComponent<SpriteRenderer>().color = coreColor[index];
    }
}
