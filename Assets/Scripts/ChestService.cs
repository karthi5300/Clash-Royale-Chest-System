using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : SingletonGeneric<ChestService>
{
    public ChestController chestController;

    public ChestController GetChest(ChestScriptableObject randomChestSO, ChestView chestView)
    {
        ChestModel chestModel = new ChestModel(randomChestSO);
        ChestController chestController = new ChestController(chestModel, chestView);
        return chestController;
    }
    
    public void OnClickStartTimerWithCoins()
    {
        if(ResourceHandler.Instance.coins < chestController.chestModel.CoinCost)
        {
            UIHandler.Instance.ToggleUnlockChestPopup(false);
            UIHandler.Instance.ToggleInsufficientResourcesPopup(true);
        }
        else
        {
            ResourceHandler.Instance.DecreaseCoins(chestController.chestModel.CoinCost);
            chestController.chestView.EnteringUnlockingState();
            UIHandler.Instance.ToggleUnlockChestPopup(false);
        }
    }

    public void OnClickOpenInstantlyWithGems()
    {
        if(ResourceHandler.Instance.gems < chestController.GetGemCost())
        {
            UIHandler.Instance.ToggleUnlockChestPopup(false);
            UIHandler.Instance.ToggleInsufficientResourcesPopup(true);
        }
        else
        {
            ResourceHandler.Instance.DecreaseGems(chestController.GetGemCost());
            chestController.chestView.OpenInstantly();
            UIHandler.Instance.ToggleUnlockChestPopup(false);
        }
    }

    public void ToggleRewardsPopup(bool setActive)
    {
        if(!setActive)
        {
            chestController = null;
        }
        else
        {
            UIHandler.Instance.rewardRecivedText.text = "You recived" + chestController.chestModel.CoinsReward + " coins and " + chestController.chestModel.GemsReward + " gems.";
        }
        UIHandler.Instance.rewardPopup.SetActive(setActive);
    }
}
