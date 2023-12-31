using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{

    [SerializeField] private TMP_Text text;

    [SerializeField] private Slider slider;


    void Start()
    {

	

    }


    void Update()
    {

    }


    public void valueUpdate ()
    {

	text.SetText( slider.value + "%");

    }



}
