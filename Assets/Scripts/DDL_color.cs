using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDL_color : MonoBehaviour
{
    public TreeMaster tm;
    private LeafMap lm;
    private Dropdown myDDl; 
    // Start is called before the first frame update
    private void Awake() {
        myDDl = GetComponent<Dropdown>();
        //myDDl.options.Add(new Dropdown.OptionData("None"));
        foreach(Colors a in System.Enum.GetValues(typeof(Colors))) {
            myDDl.options.Add(new Dropdown.OptionData(a.ToString()));
        }
    }
    private void Start() {
        myDDl.SetValueWithoutNotify((int)tm.GetColor());
    }

    public void MySelect(Dropdown a){
        lm = tm.GetComponentInChildren<LeafMap>();
        if (myDDl.value >= 0){
            tm.SetColor((Colors)myDDl.value);
            tm.GetComponentInChildren<TreeBase>().ApplyColor((Colors)myDDl.value);
            lm.ApplyColor((Colors)myDDl.value);
        }
        
    }
}
