using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    [SerializeField] Button _btnMusic;
    [SerializeField] Button _btnSFX;
    [SerializeField] Slider _sliderMusic;
    [SerializeField] Slider _sliderSFX;
    void Start()
    {
        _btnMusic.onClick.AddListener(() =>
        {
            SoundController.Instance.MuteMusic();
        });
        _btnSFX.onClick.AddListener(() =>
        {
            SoundController.Instance.MuteSFX();
        });
        _sliderMusic.onValueChanged.AddListener(delegate { Musicvolume(); });
        _sliderSFX.onValueChanged.AddListener(delegate { SFXvolume(); });

    }

    public void Musicvolume()
    {
        SoundController.Instance.MusicVolume(_sliderMusic.value);
    }
    public void SFXvolume()
    {
        SoundController.Instance.SFXVolume(_sliderSFX.value);
    }
    
    
}
