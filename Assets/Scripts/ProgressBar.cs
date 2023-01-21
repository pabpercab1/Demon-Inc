using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float targetProgress = 0;
    private float fillTime = 0.5f;
    private ParticleSystem partSys;
    

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        partSys = GameObject.Find("Progress Particles").GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        increseProgress(0.7f);
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
        else
            partSys.Stop();
    }
    public void increseProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
        
    }
}
