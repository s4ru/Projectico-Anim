using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class SliderWeight : MonoBehaviour
{
    public Rig weightRig;
    public Slider weightSlider;


    
    void Update()
    {
        weightRig.weight = weightSlider.value;
    }
}
