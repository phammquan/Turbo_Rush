using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogoLoop : MonoBehaviour
{

    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(1.1f, 1.1f, 1.1f), 1f).setEase(LeanTweenType.pingPong).setLoopPingPong();
    }

}
