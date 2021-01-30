using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Enums
    public enum TreeShape{zero, fortyfive, ninety};
    public enum Colors{B, G, O, P, R, Y};
    public enum LeafShape{Fall, Round, Drapes};
#endregion

#region Consts
public static class MyConstants {
    public const string pathPrefabs="";
    public const string pathTrunks="";
    public const string pathLeaves="";
}
#endregion

public class TreeMaster : MonoBehaviour
{
    // Publics
    public GameObject treeFab;
    public GameObject leaf, trunk;

    protected Dictionary<TreeShape, GameObject> dict;
    // Privates


    private void Awake() {
        dict = new Dictionary<TreeShape, GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetBase();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetBase(){
        Instantiate(this.treeFab, Vector3.zero, Quaternion.identity).AddComponent<TreeBase>().Init(this);
    }
}
