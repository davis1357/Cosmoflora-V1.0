using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(TreeMaster master){
        transform.parent = master.transform;
        this.GetComponent<SpriteRenderer>().sprite = master.trunk.GetComponent<SpriteRenderer>().sprite;
        foreach(Leaf cur in this.GetComponentsInChildren<Leaf>()){
            cur.SetLeaf(master.leaf);
        }
    }
}
