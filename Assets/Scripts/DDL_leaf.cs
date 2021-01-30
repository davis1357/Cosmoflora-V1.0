using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDL_leaf : MonoBehaviour
{
    public TreeMaster tm;
    private LeafMap lm;
    private Dropdown myDDl; 
    // Start is called before the first frame update
    private void Awake() {
        myDDl = GetComponent<Dropdown>();
        //myDDl.options.Add(new Dropdown.OptionData("None"));
        foreach(LeafShape a in System.Enum.GetValues(typeof(LeafShape))) {
            myDDl.options.Add(new Dropdown.OptionData(a.ToString()));
        }
    }
    private void Start() {
        myDDl.SetValueWithoutNotify((int)tm.GetLeaf());
        Debug.Log((int)tm.GetLeaf());
    }

    public void MySelect(Dropdown a){
        lm = tm.GetComponentInChildren<LeafMap>();
        if (myDDl.value >= 0){
            tm.SetLeaf((LeafShape)myDDl.value);
            lm.Init(tm);
        }
        
    }
}
