using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class LeafMap : MonoBehaviour
{
    private Dictionary<Colors, Sprite> dict;
    private AsyncOperationHandle opHandle;

    internal async void Init(TreeMaster master){
        var op = LoadVariants(master.GetLeaf());
        await op.Task;
        ApplyColor(master.GetColor());
    }


    private AsyncOperationHandle<IList<GameObject>> LoadVariants(LeafShape leaf){
        dict = new Dictionary<Colors, Sprite>();
        AsyncOperationHandle<IList<GameObject>> myOut;
        myOut = Addressables.LoadAssetsAsync<GameObject>(leaf.ToString(), null);
        myOut.Completed += (operation) =>
        {
            Colors curClr;
            foreach(GameObject a in operation.Result){
                if (System.Enum.TryParse<Colors>(a.name.Substring(a.name.IndexOf('_') + 1), out curClr)){
                    dict.Add( curClr, a.GetComponent<SpriteRenderer>().sprite);
                    //Debug.Log(curClr.ToString());
                }
            }
            if (opHandle.IsValid()){
                this.enabled = false;
                UnloadVariant(opHandle);
            }
            opHandle = operation; 
        };
        return myOut;
    }

    private void UnloadVariant(AsyncOperationHandle lastOp){
        Addressables.Release(lastOp);
    }
    private void OnDestroy() {
        UnloadVariant(opHandle);
    }

    internal void ApplyColor(Colors clr){
        List<Leaf> leaves = new List<Leaf>();
        GetComponentsInChildren<Leaf>(leaves);
        SpriteRenderer r;
        foreach (Leaf l in leaves){
            //Debug.Log($"leaf is {l.name} in {l.transform.localPosition.x}, {l.transform.localPosition.y}");
            r = l.GetComponentInChildren<SpriteRenderer>();
            r.sprite = dict[clr];
            r.color = new Color(r.color.r, r.color.g, r.color.b, Random.Range(0.5f, 0.9f));
            r.enabled = true;
        }
        this.enabled = true;
        //Debug.Log(dict.Keys.Count);
    }
}
