using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnxietyBar : MonoBehaviour
{
    Slider anxietySlider;
    AudioSource BeepSound;
    [SerializeField] AudioClip Beep;

    public void DecreaseAnxietyLevel(int number)
    {
        anxietySlider.value -= number;
    }

    void Start()
    {
        BeepSound = GetComponent<AudioSource>();
        anxietySlider = GetComponent<Slider>();
        
        InvokeRepeating("IncreaseAnxietySlider", 50, Random.Range(50, 100));  
    }

    public void IncreaseAnxietySlider()
    {
        anxietySlider.value += Random.Range(0, 3);
        PlayBeep();
    }

    public void ScanForStress()
    {
        anxietySlider.value = Random.Range(60, 100);
        PlayBeep();
    }

    public void PlayBeep()
    {
        BeepSound.PlayOneShot(Beep);
    }

}
