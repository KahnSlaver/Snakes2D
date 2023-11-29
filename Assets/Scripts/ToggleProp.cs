using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleProp : MonoBehaviour
{   
    [SerializeField]GameObject wallGroup;

    [SerializeField]Transform enemySnake;
    [SerializeField]GameObject enemyTail;
    [Range(3,1000)][SerializeField] int lengthSnake;
    
    [Range(0,1)][SerializeField] int wallBool;
    [Range(0,1)][SerializeField] int altBool;
    [Range(0,1)][SerializeField] int movingBool;

    public static bool wall;
    public static bool altSnake;
    public static bool movingFood;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex>1)
        {
            wall=false;
            altSnake=false;
            movingFood=false;
        }

        if(wallBool==1)
        {
            wall=true;
        }
        if(altBool==1)
        {
            altSnake=true;
        }
        if(movingBool==1)
        {
            movingFood=true;
        }

        ActivateBool(wallGroup,wall);
        ActivateBool(enemySnake.gameObject,altSnake);
        if(altSnake)
        {
            for(int i=3;i<lengthSnake;i++)
            {
                Instantiate(enemyTail,enemySnake.GetChild(0).position,Quaternion.identity,enemySnake); //This will make eTail profab spawn on head of enemy snake
            }
        } 
        //We can add moving food in Foodspawn.cs //Done
    }
    
    
    void ActivateBool(GameObject gameObj,bool val)
    {
        gameObj.SetActive(val);
    }    
        
}
