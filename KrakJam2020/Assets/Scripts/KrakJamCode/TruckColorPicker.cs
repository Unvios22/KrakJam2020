using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TruckColorPicker : MonoBehaviour {
    public enum TruckColor {
        Cyan,
        Red,
        Yellow
    }

    public TruckColor color = TruckColor.Cyan;
    public Material cyanMaterial, redMaterial, yellowMaterial;

    [Button("ClickMe")]
    void BamboozleButton() {
        Debug.Log("Debil");
    }

    void Awake(){
        ChangeTruckColour();
    }

    private void ChangeTruckColour(){
        switch (color){
            case TruckColor.Cyan:
                gameObject.GetComponent<Renderer>().material = cyanMaterial;
                break;
            case TruckColor.Red:
                gameObject.GetComponent<Renderer>().material = redMaterial;
                break;
            case TruckColor.Yellow:
                gameObject.GetComponent<Renderer>().material = yellowMaterial;
                break;
        }
    }

    public void ChangeColour(){
        ChangeTruckColour();
    }
}
