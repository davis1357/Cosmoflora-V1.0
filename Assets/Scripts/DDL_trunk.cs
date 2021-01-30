using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDL_trunk : MonoBehaviour
{
    public TreeMaster tm;
    private Dropdown myDDl; 
    // Start is called before the first frame update
    private void Awake() {
        myDDl = GetComponent<Dropdown>();
        //myDDl.options.Add(new Dropdown.OptionData("None"));
        foreach(TreeShape a in System.Enum.GetValues(typeof(TreeShape))) {
            myDDl.options.Add(new Dropdown.OptionData(a.ToString()));
        }
    }
    private void Start() {
        myDDl.SetValueWithoutNotify((int)tm.GetShape());
    }

    public void MySelect(Dropdown a){
        if (myDDl.value >= 0){
            tm.SetShape((TreeShape)myDDl.value);
            tm.SetBase();
        }
        
    }
}
