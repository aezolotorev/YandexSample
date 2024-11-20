using System;
using System.Diagnostics;
using System.Linq;
using YG;

public class YandexGameProvider: IDisposable
{
    public Action<RewardVideoType> onRewardedEvent;
    public Action onRewiewEvent;
    public bool isMobile;
    
    private bool isInitialized = false;    
    private RewardData _rewards;

   

    public YandexGameProvider(IAssetService assetService) 
    {         
        YandexGame.SDKEnabledEvent += ProviderReady;
        YandexGame.RewardVideoEvent += Rewarded;
        YandexGame.ReviewSentEvent += Rewiewed;
        GetReward(assetService);       
    }

    private void CheckPlatform()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            isMobile = false;
        }
        else
        {
            isMobile = true;
        }
    }

    private async void  GetReward(IAssetService assetService)
    {
        _rewards = await assetService.GetAssetAsync<RewardData>("RewardData");
    }

    public void Dispose()
    {
        YandexGame.SDKEnabledEvent -= ProviderReady;
        YandexGame.RewardVideoEvent -= Rewarded;
        YandexGame.ReviewSentEvent -= Rewiewed;
    }

    private void ProviderReady()
    {
        isInitialized = true;
        CheckPlatform();
    }

    #region ADS
    private void Rewarded(int id)
    {
       onRewardedEvent?.Invoke(GetRewardTypeById(id));       
    }

    public void ShowReward(RewardVideoType type)
    {
        YandexGame.RewVideoShow(GetIdRewardByType(type));
    }

    public void ShowFullScreen()
    {
        YandexGame.FullscreenShow();
    }

    private int GetIdRewardByType(RewardVideoType type)
    {
        return _rewards.rewards.FirstOrDefault(x => x.type == type).id;
    }

    private RewardVideoType GetRewardTypeById(int id)
    {
        return _rewards.rewards.FirstOrDefault(x => x.id == id).type;
    }
    #endregion

    #region Rewie
    public void GoToRewiew()
    {
        YandexGame.ReviewShow(true);
    }

    private void Rewiewed(bool isSend)
    {
        if (isSend)
        {            
           onRewiewEvent?.Invoke();
        }

        YandexGame.SaveProgress();
    }

    public bool IsCanRewiew()
    {        
       return YandexGame.EnvironmentData.reviewCanShow;        
    }

    #endregion

    #region SaveData
    public void Save()
    {
        YandexGame.SaveProgress();
    }

    public int GetMoneySave(string key)
    {
        return YandexGame.savesData.money;
    }

    public void SetMoney(int value)
    {
        YandexGame.savesData.money = value;
    }

    public void AddMomey(int valueChange)
    {
        YandexGame.savesData.money += valueChange;
    }  


    #endregion
}

[Serializable]
public class Rewards
{
    public RewardVideoType type;
    public int id;
}

public enum RewardVideoType
{
    Get1000Coins=0,
    Get1Cristall=1,
}
