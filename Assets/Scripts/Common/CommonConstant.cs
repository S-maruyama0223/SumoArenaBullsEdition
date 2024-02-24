using System;
using System.Collections.Generic;
using UnityEngine;

public class CommonConstant {

    public const string GAME_MANAGER_TAG = "GameManager";
    public const string CANVAS_MANAGER_TAG = "CanvasManager";
    public const string PLAYER1_PREVIEWS_TAG = "Player1Previews";
    public const string PLAYER2_PREVIEWS_TAG = "Player2Previews";
    public const string PLAYER1_SCORE_TAG = "Player1Score";
    public const string PLAYER2_SCORE_TAG = "Player2Score";

    public const string PLAYER1_NAME = "Player1";
    public const string PLAYER2_NAME = "Player2";

    public const string SMALL_SHEEP_PREFAB = "SmallSheepPrefab";
    public const string MIDIUM_SHEEP_PREFAB = "MidiumSheepPrefab";
    public const string LARGE_SHEEP_PREFAB = "LargeSheepPrefab";

    public static readonly List<Color32> bullColors = new List<Color32> {
        new Color32(0, 0, 122, 100), // 青
        new Color32(0, 122, 0, 100), // 緑
        new Color32(122, 0, 0, 100), // 赤
    };

    // 0.015のスピードで推してるからサイズ3の牛は遅いという考えかた
    public static float BASE_SPEED = 0.015F;
    public static float LARGE_SHEEP_SPEED = (BASE_SPEED / 3) * 1;  // 1/3
    public static float MIDIUM_SHEEP_SPEED = (BASE_SPEED / 3) * 2; // 2/3 
    public static float SMALL_SHEEP_SPEED = (BASE_SPEED / 3) * 3;  // 3/3 = 1 
}
