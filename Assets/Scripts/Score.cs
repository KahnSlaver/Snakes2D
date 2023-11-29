using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    [SerializeField] GameObject Snake;
    public TMP_Text scoreText;
    public TMP_Text gameOver_text;
    public TMP_Text level_text;
    public TMP_Text win_text;
    [SerializeField]GameObject back_Button;
    [SerializeField]GameObject winning;
    public static bool winNext;
    int score;

    [SerializeField]int winScore;
    
    private void Start() {
        winNext=false;
        back_Button.SetActive(false);
        gameOver_text.SetText("");
        level_text.SetText("Level: "+(SceneManager.GetActiveScene().buildIndex-1));
    }
    public void Update()
    {   
        if (!TailMovement.endingAnimation)
        {
            score = (Snake.transform.childCount)-3;
            scoreText.SetText("Score: " + score);
            if (winScore!=0)
            {
                win_text.SetText("Collect " + winScore + " points");
            }
            else{
                win_text.SetText("Survive!");
            }
        }
        if (TailMovement.endingAnimation)
        {
            gameOver_text.SetText("GameOver");
            back_Button.SetActive(true);
        }
        if (score>=winScore&&winScore>0)
        {   
            winning.SetActive(true);
        }
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
