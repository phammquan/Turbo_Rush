using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    float _timeConutDown = 3;
    [SerializeField] TextMeshProUGUI _countDown;

    void Start()
    {
        _countDown = GetComponent<TextMeshProUGUI>();
        _countDown.text = _timeConutDown.ToString();
        StartCoroutine(CountDownTime());
    }

    IEnumerator CountDownTime()
    {
        while (_timeConutDown > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            _timeConutDown--;
            _countDown.text = _timeConutDown.ToString();
        }
        _countDown.text = "GO!";
        Observer.Notify("ContinueGame");
        yield return new WaitForSeconds(.5f);
        this.gameObject.SetActive(false);
    }
}