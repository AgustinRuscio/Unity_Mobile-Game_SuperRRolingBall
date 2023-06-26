using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ShowAdds : MonoBehaviour, IUnityAdsListener
{
    [SerializeField]
    private string _adId = "Rewarded_Android";

    [SerializeField]
    private string _gameId = "5298345";

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId);
    }

    public void ShowAd()
    {
        if (!Advertisement.IsReady()) return;
        Advertisement.Show(_adId);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _adId) Debug.Log("Ad is ready!");
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        if (placementId == _adId) Debug.Log("Ad is Showing!");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == _adId)
        {
            if (showResult == ShowResult.Finished)
            {
                StaminaSystem.instance.AddStamina(1);
                Debug.Log("Take your currency!");
            }
            else if (showResult == ShowResult.Skipped)
            {
                Debug.Log("Take your half currency!");
            }
            else
            {
                Debug.Log("Something is wrong!");
            }
        }
    }




}
 
