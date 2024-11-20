using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System;

public class ReviewButton : MonoBehaviour
{
    public static Action onRewied;

    [SerializeField] private Button button;

    private YandexGameProvider _ygProvider;
    private bool isInited;

    [Inject]
    private void Construct(YandexGameProvider ygProvider)
    {        
        _ygProvider = ygProvider;
        _ygProvider.onRewiewEvent += Reviewed;
        isInited = true;
    }

    private void Start()
    {
        CheckActive();
        button.onClick.AddListener(ClickReview);
    }

    private void CheckActive()
    {
        if (_ygProvider.IsCanRewiew())
        {
            button.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(false);
        }
    }

    private void ClickReview()
    {
        _ygProvider.GoToRewiew();
    }

    private void Reviewed()
    {
        Debug.Log("Rewiewed");
    }
}
