using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Fractal : MonoBehaviour
{
    //publics
    public Sprite frctSprite;
    [Range(1.0f, 40.0f)]
    public int maxDepth = 1;
    [Range(1.0f, 10.0f)]
    public int maxSplits = 1;
    
    [Range(0.0f, 180.0f)]
    public float maxRotation = 0.0f;
    [Range(1.0f, 2.0f)]
    public float maxScale = 1.0f;

    //privates
    private SpriteRenderer frctRender;
    private int depth, splits;
    private float rotation, scale;

    // Start is called before the first frame update
    void Start()
    {
       frctRender = gameObject.AddComponent<SpriteRenderer>();
       frctRender.sprite = frctSprite;
       if (depth < maxDepth){
           for (int i = 0; i <= splits; i++){
                // initiallize child using parent as reference
                new GameObject("SubFractal").AddComponent<Fractal>().Initialize(this);
           }
       }
    }

    // Child Making~<3
    private void Initialize (Fractal parent) {
        // Base Data
        frctSprite = parent.frctSprite;
        maxDepth = parent.maxDepth;
        depth = ++parent.depth;
        transform.parent = parent.transform;
        maxScale = parent.maxScale;
        maxRotation = parent.maxRotation;
        maxSplits = parent.maxSplits;

        // Randomization
        Randomize();

        // Manipulation
        transform.localScale = new Vector3(1f * (scale * 1.5f), 1f * scale, 1f );  
        transform.localPosition = Vector3.up * (0.5f + 0.5f * scale);
        transform.localRotation = Quaternion.Euler(0f, 0f, rotation); 
        Debug.Log($"Transofrm Position is {Vector3.up * (0.5f + 0.5f * scale)}");
    }

    private void Randomize (){
        scale = Random.Range(1.0f - (maxScale - 1.0f), maxScale);
        splits = Random.Range(1, maxSplits);
        rotation = Random.Range(-maxRotation, maxRotation);
        Debug.Log($"Scale is {scale}, split is {splits}, rotation is {rotation}");
    }
}
