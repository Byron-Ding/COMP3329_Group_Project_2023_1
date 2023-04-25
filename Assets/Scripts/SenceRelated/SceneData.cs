using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : PersistentSingleton<SceneData> {
    
    public const string SENCE_NAME_START_PAGE = "StartPage_Scene";
    public const string SENCE_NAME_GAME_PLAY_STORY_SCENE1 = "StoryTellingImage1_Scene";
    public const string SENCE_NAME_GAME_PLAY_STORY_SCENE2 = "StoryTellingImage2_Scene";
    public const string SENCE_NAME_GAME_PLAY_STORY_SCENE3 = "StoryTellingImage3_Scene";
    public const string SENCE_NAME_GAME_PLAY_MAIN_ENTRY_SCENE = "GamePlay";

    public GameObject Canvas_StartPage;
    public GameObject SenceRelated_StartPage;
    public GameObject Data_StartPage;

    public GameObject Cover_StartPage;
    public GameObject SettingPage_StartPage;
    public GameObject GuidePage_StartPage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
