using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameCanvasManager gameCanvasManager;
    [SerializeField] ResultCanvasManager resultCanvasManager;
    GameController gameController;
    void Awake()
    {
        QualitySettings.vSyncCount = 0; // VSyncをOFFにする
        Application.targetFrameRate = 60; // ターゲットフレームレートを60に設定
    }

    void Start()
    {
        gameController = GetComponent<GameController>();
        gameController.OnStart();
        gameCanvasManager.OnStart();
        resultCanvasManager.OnStart();
        Variables.screenState = ScreenState.INITIALIZE;
    }


    void Update()
    {
        switch (Variables.screenState)
        {
            case ScreenState.INITIALIZE:
                gameController.OnInitialize();
                gameCanvasManager.OnInitialize();
                resultCanvasManager.OnInitialize();
                Variables.screenState = ScreenState.GAME;
                break;
            case ScreenState.GAME:
                gameController.OnUpdate();
                break;
            case ScreenState.RESULT:
                break;
            default:
                break;
        }
    }
}
