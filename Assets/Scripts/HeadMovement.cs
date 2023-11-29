using UnityEngine;

public class HeadMovement : MonoBehaviour
{

    float xSpeed=0;
    float ySpeed=1f;

    bool choice;
    public static bool inGame;

    
    // Start is called before the first frame update
    void Start()
    {   
        choice=true;
        inGame=true;
        InvokeRepeating("Mover",0,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Turns();
    }

    private void Mover()
    {   
        if(inGame)
        {
            float xNew = transform.position.x + xSpeed;
            float yNew = transform.position.y + ySpeed;
            if(!ToggleProp.wall)
            {
                if(xNew==-33)
                    xNew=32;
                else if(xNew==33)
                    xNew=-32;
                if(yNew==-19)
                    yNew=18;
                else if(yNew==19)
                    yNew=-18;
            }
            transform.position= new Vector3(xNew,yNew,transform.position.z);
        choice=true;
        }
        else if(Time.time>0.3f)
        {
            CancelInvoke();
        }
    }

    private void Turns()
    {   
        if(xSpeed==0&&choice)
        {
            LeftRight();
        }
        else if(ySpeed==0&&choice)
        {
            UpDown();
        }
        
    }

    private void LeftRight()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            xSpeed=-1;
            ySpeed=0;
            choice=false;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            xSpeed=1;
            ySpeed=0;
            choice=false;
        }
        
    }

    private void UpDown()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            ySpeed=1;
            xSpeed=0;
            choice=false;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            ySpeed=-1;
            xSpeed=0;
            choice=false;
        }
    }
    
    
}
