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
    public const string TITLE_SCENE_MANAGER_TAG = "TitleSceneManager";

    public const string PLAYER1_NAME = "Player1";
    public const string PLAYER2_NAME = "Player2";

    private const string PREFABS_DIRECTORY = "Prefabs/";
    public const string SMALL_ANIMAL_PREFAB = PREFABS_DIRECTORY + "SmallAnimalPrefab";
    public const string MEDIUM_ANIMAL_PREFAB = PREFABS_DIRECTORY + "MediumAnimalPrefab";
    public const string LARGE_ANIMAL_PREFAB = PREFABS_DIRECTORY + "LargeAnimalPrefab";

    private const string IMAGES_DIRECTORY = "Images/";
    public const string SMALL_IMAGE = IMAGES_DIRECTORY + "mouse1";
    public const string MEDIUM_IMAGE = IMAGES_DIRECTORY + "turtle1";
    public const string LARGE_IMAGE = IMAGES_DIRECTORY + "sheep1";

    public static readonly List<Color32> bullColors = new List<Color32> {
        new Color32(0, 0, 122, 100), // 青
        new Color32(0, 122, 0, 100), // 緑
        new Color32(122, 0, 0, 100), // 赤
    };

    // 0.015のスピードで推してるからサイズ3の牛は遅いという考えかた
    public static float BASE_SPEED = 0.015F;
    public static float LARGE_SHEEP_SPEED = (BASE_SPEED / 3) * 1;  // 1/3
    public static float MEDIUM_SHEEP_SPEED = (BASE_SPEED / 3) * 2; // 2/3 
    public static float SMALL_SHEEP_SPEED = (BASE_SPEED / 3) * 3;  // 3/3 = 1 

    public static float LIFE_TIME_PARAM = 20f;
    public static float BASE_LIFE_TIME = 10f;
}
