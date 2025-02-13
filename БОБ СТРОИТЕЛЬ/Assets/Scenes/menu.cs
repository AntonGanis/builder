using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public void startGame(int level)
    {
        Application.LoadLevel(level);
    }
    public void exitGame()
    {
        Application.Quit();
    }
    //Настройки
    public void LowQuality()
    {
        QualitySettings.SetQualityLevel(0, true);
    }
    public void MediumQuality()
    {
        QualitySettings.SetQualityLevel(2, true);
    }
    public void UltraQuality()
    {
        QualitySettings.SetQualityLevel(4, true);
    }
}