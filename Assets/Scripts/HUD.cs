using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD HUDManager;
    public GameObject AudioBGM, AudioSFX;
    public AudioClip GameOverSFX;
    public bool PassAway = false;
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Image Image_Lives = null;
    [SerializeField] private Text Txt_Message = null;

    void Start()
    {
        HUDManager = this;
    }

    public void UpdateScore()
    {
        Txt_Score.text = "SCORE : " + GameManager.Score;
    }

    //updates the number of hearts for lives
    public void UpdateLives()
    {
        Image_Lives.rectTransform.sizeDelta = new Vector2(GameManager.Lives * 50, 30);
    }

    public void GameOver()
    {
        if(!PassAway)
        {
            PassAway = true;
            Time.timeScale = 0;
            AudioBGM.GetComponent<AudioSource>().Stop();
            AudioSFX.GetComponent<AudioSource>().PlayOneShot(GameOverSFX);
            GameManager.CurrentState = GameManager.GameState.GameOver;
            if (GameManager.Lives == 0 && GameManager.Score < 100)
            {
                Txt_Message.color = Color.red;
                Txt_Message.text = "GAME OVER! \n PRESS ENTER TO RESTART GAME.";
            }
            else
            {
                Txt_Message.color = Color.green;
                Txt_Message.text = "YOU WIN! \n PRESS ENTER TO RESTART GAME.";
            }
        }
    }

    public void DismissMessage()
    {
        Txt_Message.text = "";
    }
}