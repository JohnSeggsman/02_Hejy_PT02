using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState { GameOver, GameStart, GameIdle };
    public static GameState CurrentState = GameState.GameIdle;
    public static int Lives = 3;
    public static int Score = 0;

    void Start()
    {
        Lives = 3;
        Score = 0;
        Time.timeScale = 0;
        CurrentState = GameState.GameIdle;
    }

    void Update()
    {
        HUD.HUDManager.UpdateLives();
        HUD.HUDManager.UpdateScore();

        if (Lives <= 0 || Score >= 100)
            HUD.HUDManager.GameOver();

        if (CurrentState == GameState.GameIdle && Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            CurrentState = GameState.GameStart;
            HUD.HUDManager.DismissMessage();
        }
        else if (CurrentState == GameState.GameOver && Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(0);
    }
}