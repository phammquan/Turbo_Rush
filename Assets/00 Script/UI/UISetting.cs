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
    [SerializeField] GameObject _muteMusic;
    [SerializeField] GameObject _muteSFX;
    void Start()
    {
        _btnMusic.onClick.AddListener(() =>
        {
            _muteMusic.SetActive(!_muteMusic.activeSelf);
            SoundController.Instance.MuteMusic();
        });
        _btnSFX.onClick.AddListener(() =>
        {
            _muteSFX.SetActive(!_muteSFX.activeSelf);
            SoundController.Instance.MuteSFX();
        });
        _sliderMusic.onValueChanged.AddListener(delegate { Musicvolume(); });
        _sliderSFX.onValueChanged.AddListener(delegate { SFXvolume(); });

    }

    public void Musicvolume()
    {
        if (_muteMusic.activeSelf)
        {
            _muteMusic.SetActive(false); 
            SoundController.Instance.MuteMusic();
        }
        SoundController.Instance.MusicVolume(_sliderMusic.value);
    }
    public void SFXvolume()
    {
        if (_muteSFX.activeSelf)
        {
            _muteSFX.SetActive(false);
            SoundController.Instance.MuteSFX();
        }
        SoundController.Instance.SFXVolume(_sliderSFX.value);
    }
    
    
}
