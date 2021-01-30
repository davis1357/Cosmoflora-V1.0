using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    private GameObject myLeaf;
    private SpriteRenderer myRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        myRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetLeaf(GameObject parentLeaf){
        myRenderer.sprite = parentLeaf.GetComponent<SpriteRenderer>().sprite;
        
        SpinMe(Random.Range(0f, 360f));
        SclaeMe(Random.Range(0.3f, 0.8f));
    }

    private void SpinMe(float yAxis){this.transform.localRotation = Quaternion.Euler(0f, 0f, yAxis);}
    private void SclaeMe(float scale){this.transform.localScale = Vector3.one * scale;}
}
