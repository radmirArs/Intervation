using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    private List<MenuScreen> _otherScreens;

    private void Start()
    {
        _otherScreens = new List<MenuScreen>(transform.parent.GetComponentsInChildren<MenuScreen>());
        var index = _otherScreens.IndexOf(this);
        _otherScreens.Remove(this);

        if (index > 0) return;
        Show();
    }

    public void Show()
    {
        foreach(var screen in _otherScreens)
        {
            screen.gameObject.SetActive(false);
        }
        gameObject.SetActive(true);
    }
}
