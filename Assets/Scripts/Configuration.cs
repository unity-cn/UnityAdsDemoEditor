using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuration {

	/// <summary>
	/// Game ID
	/// </summary>
	public static string snakeGameId = "1210390";
	// android, useless
	public static string crossyRoadGameId = "131624390"; 
	// project name : Unity Ads Demo Editor
	public static string myGameIdiOS = "1544006"; 
	public static string myGameIdAndroid = "1544208"; 
	public static string tempGameId = "1394428";

	/// <summary>
	/// Replacement ID
	/// </summary>
	public static string skippablePlacementId = "video";
	public static string unskippablePlacementId = "rewardedVideo";
	public static string unskippablePlacementId2 = "rewardedVideoZone";
	public static string longTimeSkippablePlacementId = "defaultVideoAndPictureZone";

	/// <summary>
	/// Video Stats
	/// </summary>
	public static string videoCompleted = "Video completed - Offer a reward to the player";
	public static string videoSkipped = "Video was skipped - Do NOT reward the player";
	public static string videoError = "Video failed to show";
	public static string videoAvailable = "Get free coins";
	public static string videoUnavailable = "Free coins not available yet";

	/// <summary>
	/// The rewarded coin amount.
	/// </summary>
	public static int rewardedCoinAmount = 7;

}
