using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        Variables.screenState = ScreenState.GAME;
    }


    void Update()
    {
        switch (Variables.screenState)
        {
            case ScreenState.GAME:
                gameController.OnUpdate();
                break;
            default:
                break;
        }
    }
}
