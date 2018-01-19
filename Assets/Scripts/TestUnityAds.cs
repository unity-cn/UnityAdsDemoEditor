using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


[RequireComponent(typeof(Button))]
public class TestUnityAds : MonoBehaviour {

	//---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//

	#if UNITY_IOS
	private string gameId = Configuration.myGameIdiOS;
	#elif UNITY_ANDROID
	private string gameId = Cofiguration.myGameIdAndroid;
	#endif

	//-------------------------------------------------------------------//

	// 观看视频广告后获得的硬币奖励 -- Rewarded Coin Amount Text
	public Text m_CoinText;
	// Game ID
	public Text m_GameIDText;
	// Replacement ID
	public Text m_ReplacementIDText;
	// Stats输出信息 -- Stats Text
	public Text m_StatsText;
	// 奖励视频按钮提示 -- Button info
	public Text m_ButtonText;

	// 奖励视频按钮 -- Show Ads Button
	Button m_Button;
	// 奖励硬币 -- RewardedCoin Amount
	int m_RewardedCoin = 0;
	// 奖励视频是否可用 -- Rewarded Video Available
	bool m_IsVideoAvailable = false;

	public string placementId = "rewardedVideo";

	void Start ()
	{  
		m_CoinText.text = m_RewardedCoin.ToString ();
		m_GameIDText.text = Configuration.myGameIdiOS;
		m_ReplacementIDText.text = Configuration.unskippablePlacementId;
		m_StatsText.gameObject.SetActive(false);

		m_Button = GetComponent<Button>();
		if (m_Button) m_Button.onClick.AddListener(ShowAd);

		if (Advertisement.isSupported) {
			Advertisement.Initialize (gameId, true);
		}

	}

	void Update ()
	{
		if (m_Button) {
			m_IsVideoAvailable = Advertisement.IsReady(placementId);

			m_Button.interactable = m_IsVideoAvailable;
			m_ButtonText.text = m_IsVideoAvailable ? Configuration.videoAvailable : Configuration.videoUnavailable; 
		}
	}

	void ShowAd ()
	{
		var options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show(placementId, options);
	}

	void RewardPlayer()
	{
		m_RewardedCoin += Configuration.rewardedCoinAmount;
		m_CoinText.text = m_RewardedCoin.ToString ();
	}

	void HandleShowResult (ShowResult result)
	{
		m_StatsText.gameObject.SetActive(true);
		if(result == ShowResult.Finished) {
			RewardPlayer ();
			m_StatsText.text = Configuration.videoCompleted;

		}else if(result == ShowResult.Skipped) {

			m_StatsText.text = Configuration.videoSkipped;

		}else if(result == ShowResult.Failed) {
			m_StatsText.text = Configuration.videoError;
		}
	}
}
