using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public static class Loader
{
    private const int LEVEL_SIZE = 2;
    
    private static int i = 0;

    public enum Scene
    {
        MainMenu,
        Level_1,
        ScoreBoard,
        Ending,
    }

    public static void PlayGame()
    {
        i = 0;
        SceneManager.LoadScene(Scene.Level_1.ToString());
    }

    public static void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public static void NextLevel()
    {
        i++;
        if (i < LEVEL_SIZE)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            ToScoreBoard();
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void ToScoreBoard()
    {
        SceneManager.LoadScene(Scene.ScoreBoard.ToString());
    }

    public static void EndGame()
    {
        SceneManager.LoadScene(Scene.Ending.ToString());
    }

    public static void ToMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }
}
