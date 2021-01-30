using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    enum SpinStrat{none, tilted, threequart, fullrange};
    enum ScaleStrat{none, preset, random, shrinkacsend, shrinkdescend};
    enum PositionStrat{fall, round, stringy};

public class Leaf : MonoBehaviour
{
    private GameObject myLeaf;
    private SpriteRenderer myRenderer;
    private SpinStrat howDoISpin;
    private ScaleStrat howDoIGrow;
    private PositionStrat howDoIFit;
    // Start is called before the first frame update
    void Awake()
    {
        myRenderer = this.GetComponent<SpriteRenderer>();
        howDoIGrow = ScaleStrat.shrinkacsend;
        howDoISpin = SpinStrat.tilted;
    }

    private void Start() {
        AmIMirror();
        switch(howDoIGrow){

            case(ScaleStrat.preset):
                IHavePresetScaling();
                break;
            case(ScaleStrat.random):
                IScaleRandomly();
                break;
            case(ScaleStrat.shrinkacsend):
                IGoInOrder();
                break;
            case(ScaleStrat.shrinkdescend):
                IGoInOrder(false);
                break;
            default:
                break;
        }
        switch(howDoISpin){
            case(SpinStrat.tilted):
                ITiltAbit();
                break;
            case(SpinStrat.threequart):
                IPivotAlot();
                break;
            case(SpinStrat.fullrange):
                IHaveFullRange();
                break;
            default:
                break;
        }
        switch(howDoIFit){
            case(PositionStrat.fall):
                IAmFall();
                break;
            case(PositionStrat.round):
                IAmRound();
                break;
            case(PositionStrat.stringy):
                IAmStringy();
                break;
        }
        IHaveFullRange();        
    }

    #region I decide what kind of leaf I am

        void AmIMirror(){
            int i = Random.Range(0, 100);
            transform.localRotation = Quaternion.AngleAxis(180 * (i%2), Vector3.up);
        }

        #region I decide how I scale
            void IHavePresetScaling(){}

            void IScaleRandomly(){
                float scale = Random.Range(0.3f, 1.2f);
                transform.localScale = Vector3.one * scale;
            }

            void IGoInOrder(bool asc = true){
                transform.localScale = Vector3.one * transform.localPosition.y;
            }
        #endregion

        #region I decide how I spin
            void ITiltAbit(){
                int tilt = Random.Range(0, 60);
                transform.localRotation = Quaternion.AngleAxis(tilt, Vector3.forward);
            }
            void IPivotAlot(){
                int tilt = Random.Range(0, 270);
                transform.localRotation = Quaternion.AngleAxis(tilt, Vector3.forward);}

            void IHaveFullRange(){
                int tilt = Random.Range(0, 360);
                transform.localRotation = Quaternion.AngleAxis(tilt, Vector3.forward);}
        
        #endregion

        #region I decide how I am placed
            void IAmFall(){}
            void IAmRound(){}
            void IAmStringy(){}

        #endregion


    #endregion

    private void SpinMe(float yAxis){this.transform.localRotation = Quaternion.Euler(0f, 0f, yAxis);}
    private void SclaeMe(float scale){this.transform.localScale = Vector3.one * scale;}
}
