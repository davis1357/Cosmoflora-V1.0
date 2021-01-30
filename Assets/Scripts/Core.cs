using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public float fadeSpeed;

    //TODO: Change Color to sprite when possible and make it seen in inspector, putting the spirtes in the *LIST* there
    Color[] coreColor = new Color[] { Color.green, Color.red, Color.blue, Color.black, Color.cyan, Color.yellow };


    public void SetCore(int index)
    {
        //TODO: make it work with the first change
        GetComponent<SpriteRenderer>().color = coreColor[index];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(FadeOut());
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(FadeIn());
        }
    }

    public IEnumerator FadeOut()
    {
        while (this.GetComponent<Renderer>().material.color.a > 0)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        while (this.GetComponent<Renderer>().material.color.a < 1)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;
            yield return null;
        }
    }
}
