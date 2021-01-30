using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class TreeBase : MonoBehaviour
{
    private Dictionary<Colors, Sprite> dict = new Dictionary<Colors, Sprite>();
    private AsyncOperationHandle opHandle;

    internal async void Init(TreeMaster master){
        var op = LoadVariants(master.GetShape().ToString());
        await op.Task;
        ApplyColor(master.GetColor());
        GetComponentInChildren<LeafMap>().Init(master);
    }

    private AsyncOperationHandle<IList<GameObject>> LoadVariants(string lbl){
        AsyncOperationHandle<IList<GameObject>> myOut;
        myOut = Addressables.LoadAssetsAsync<GameObject>(lbl, null);
        myOut.Completed += (operation) =>
        {
            Colors curClr;
            foreach(GameObject a in operation.Result){
                if (System.Enum.TryParse<Colors>(a.name.Substring(a.name.IndexOf('_') + 1), out curClr)){
                    dict.Add(curClr, a.GetComponent<SpriteRenderer>().sprite);
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

    internal void ApplyColor(Colors clr){
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        r.sprite = dict[clr];
        r.enabled = true;
    }

    private void OnDestroy() {
        UnloadVariant(opHandle);
    }
    
}
