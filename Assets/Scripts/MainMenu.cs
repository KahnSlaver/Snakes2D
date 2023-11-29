using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    [SerializeField] GameObject[] button1;
    [SerializeField] GameObject canva;
    public static bool survival;
    private void Start() {
        survival=false;
        ToggleProp.wall=false;
        ToggleProp.altSnake=false;
        ToggleProp.movingFood=false;
    }
    
    private void Update() 
    {
        ToggleButton(button1[0],survival);
        ToggleButton(button1[1],ToggleProp.wall);
        ToggleButton(button1[2],ToggleProp.altSnake);
        ToggleButton(button1[3],ToggleProp.movingFood);

        canva.SetActive(survival);
    }
    public static void StartButton()
    {
        if (survival)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    public static void QuitButton()
    {
        Application.Quit();
    }
    public static void WallButton()
    {
        ToggleProp.wall=!ToggleProp.wall;      
    }
    public static void SurvivalButton()
    {
        survival=!survival;      
    }
    public static void AltSnakeButton()
    {
        ToggleProp.altSnake=!ToggleProp.altSnake;      
    }
    public static void MovingFoodButton()
    {
        ToggleProp.movingFood=!ToggleProp.movingFood;      
    }
    
    void ToggleButton(GameObject button,bool active)
    {
        button.transform.GetChild(0).gameObject.SetActive(active);
        button.transform.GetChild(1).gameObject.SetActive(!active);
    }
}