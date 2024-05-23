using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    [SerializeField] GameObject GameplayUI;

    void OnEnable()
    {
        GameplayUI.SetActive(false);
        SoundManager.Instance.PlayScrimmerSound();
        SoundManager.Instance.PlayPlayerStepSound(false);
    }
}
