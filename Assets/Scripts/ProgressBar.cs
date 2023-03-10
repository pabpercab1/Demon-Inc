using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float targetProgress = 0;
    private float fillTime = 0.5f;
    private ParticleSystem partSys;
    private bool decrease;


    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        partSys = GameObject.Find("Progress Particles").GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //increseProgress(0.65f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += fillTime * Time.deltaTime;
            if (!partSys.isPlaying)
                partSys.Play();
        }
        else if(slider.value > targetProgress && decrease)
        {
            slider.value =- fillTime * Time.deltaTime;
            if (!partSys.isPlaying)
                partSys.Play();
            decrease = false;
        }
        else
            partSys.Stop();
    }
    public void increseProgress(float newProgress)
    {
        if(newProgress + slider.value < 1f)
        {
            targetProgress = slider.value + newProgress;

        }
        else
        {
            targetProgress = 1f;
        }
    }
    public float getProgress()
    {
        return targetProgress;
    }

    public void decreaseProgress(float newProgress)
    {
        if(slider.value-newProgress < 0)
        {
            targetProgress = 0f;
        }
        else targetProgress = slider.value - newProgress;
        decrease = true;
    }
}
