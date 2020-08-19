using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetSlider : MonoBehaviour
{
    Slider slider;
    DataController dataController;
    void Awake()
    {
        slider=gameObject.GetComponent<Slider>();
        dataController=FindObjectOfType<DataController>();
    }

    void Start()
    {
        SetVolumeSlider();
    }

    public void SetVolumeSlider()
    {
        slider.value=dataController.GetVolume();
    }
}
