using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour{
    private TruckColorPicker _truckColorPicker;
    private void Start(){
        _truckColorPicker = GameObject.FindGameObjectWithTag(Tags.TRUCK_COLOR_CHANGER).GetComponent<TruckColorPicker>();
    }

    public void PickedCyanColour(){
        _truckColorPicker.color = TruckColorPicker.TruckColor.Cyan;
        _truckColorPicker.ChangeColour();
    }
    public void PickedRedColour(){
        _truckColorPicker.color = TruckColorPicker.TruckColor.Red;
        _truckColorPicker.ChangeColour();
    }
    public void PickedYellowColour(){
        _truckColorPicker.color = TruckColorPicker.TruckColor.Yellow;
        _truckColorPicker.ChangeColour();
    }
}
