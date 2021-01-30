using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

#region Enums
public enum TreeShape{zero, fortyfive, ninety};
    public enum Colors{B, G, O, P, R, Y};
    public enum LeafShape{fall, round, stringy};
#endregion

public class TreeMaster : MonoBehaviour
{
    // Publics

    // Privates
    [SerializeField]
    private List<AssetReference> _prefabs;
    private TreeShape _myShape;
    private Colors _myColor;
    private LeafShape _myLeaf;
    private TreeBase _myBase;


    private void Awake() {
        foreach (AssetReference _prefab in _prefabs){
            _prefab.LoadAssetAsync<GameObject>().Completed += (operation) =>
                {
                    //Debug.Log($"{operation.Result.name} is done");
                };
        }
        SetShape(TreeShape.zero);
        SetColor(Colors.B);
        SetLeaf(LeafShape.fall);
    }
    // Start is called before the first frame update
    void Start()
    {
        SetBase();
    }

    internal async void SetBase(){
        if (!(_myBase == null)){
            Destroy(_myBase.gameObject);
        }
        Debug.Log($"ifman {!(_myBase == null)}");
        int index = (int)_myShape;
        //Debug.Log(_prefabs.Count);
        if (_prefabs.Count <= index)
            return;
        AssetReference baseAsset = _prefabs[index];
        await baseAsset.OperationHandle.Task;
        if (!baseAsset.RuntimeKeyIsValid())
            return;
        //Instantiate(this.treeFab, Vector3.zero, Quaternion.identity).AddComponent<TreeBase>().Init(this);
        baseAsset.InstantiateAsync(Vector3.zero, Quaternion.identity, this.transform).Completed += (operation) => {
            _myBase = operation.Result.GetComponent<TreeBase>();
            _myBase.Init(this);
        };
    }

    public void SetShape(TreeShape shape){
        _myShape = shape;
    }
    public TreeShape GetShape(){
        return _myShape;
    }
    public void SetColor(Colors color){
        _myColor = color;
    }
    public Colors GetColor(){
        return _myColor;
    }
    public void SetLeaf(LeafShape leaf){
        _myLeaf = leaf;
    }
    public LeafShape GetLeaf(){
        return _myLeaf;
    }

}
