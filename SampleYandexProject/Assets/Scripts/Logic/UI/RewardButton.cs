using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System;

public class RewardButton : MonoBehaviour
{
    public static Action <RewardVideoType> onRewarded;

    [SerializeField] private Button button;
    [SerializeField] private RewardVideoType rewardType;

    private YandexGameProvider _ygProvider;
    private bool isInited;

    [Inject]
    private void Construct(YandexGameProvider ygProvider)
    {
        
        _ygProvider = ygProvider;
        _ygProvider.onRewardedEvent += Rewarded;
        isInited = true;
    }


    private void Start()
    {
        button.onClick.AddListener(ClickReward);
    }

    private void ClickReward()
    {
        _ygProvider.ShowReward(rewardType);
    }

    private void Rewarded(RewardVideoType rewardType)
    {
        Debug.Log("reward" + rewardType);
    }    
    private void OnDestroy()
    {
        if (isInited)
        {
            _ygProvider.onRewardedEvent -= Rewarded;
            isInited= false;
        }
    }
}
