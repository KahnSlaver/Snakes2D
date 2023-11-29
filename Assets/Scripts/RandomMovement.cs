using UnityEngine;
public class RandomMovement : MonoBehaviour
{

    float xSpeed=0;
    float ySpeed=1f;

    int RNG;
    [SerializeField]int MaxRNG;
    bool choice;

    
    // Start is called before the first frame update
    void Start()
    {   
        choice=true;
        InvokeRepeating("Mover",0,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Turns();
    }

    private void Mover()
    {   
        RNG = Random.Range(1,MaxRNG);
        if(HeadMovement.inGame)
        {
            float xNew = transform.position.x + xSpeed;
            float yNew = transform.position.y + ySpeed;
            if(true) //making so that alt snake would always be able to loop
            {
                if(xNew<=-33)
                    xNew=32;
                else if(xNew>=33)
                    xNew=-32;
                if(yNew<=-19)
                    yNew=18;
                else if(yNew>=19)
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
        if(RNG==1)
        {
            xSpeed=-1;
            ySpeed=0;
            choice=false;
        }
        else if(RNG==2)
        {
            xSpeed=1;
            ySpeed=0;
            choice=false;
        }
        
    }

    private void UpDown()
    {
        if(RNG==1)
        {
            ySpeed=1;
            xSpeed=0;
            choice=false;
        }
        else if(RNG==2)
        {
            ySpeed=-1;
            xSpeed=0;
            choice=false;
        }
    }
    
    
}
