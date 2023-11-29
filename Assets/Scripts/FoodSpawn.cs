using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] GameObject StaticFood;
    [SerializeField] GameObject MovingFood;
                     GameObject Food;
    [SerializeField]GameObject Head;
    [SerializeField] int[] xRange = new int[2];
    [SerializeField] int[] yRange = new int[2];
    int rNG;
    [SerializeField] int maxRNG;
    // Start is called before the first frame update
    void Start()
    {   
        InvokeRepeating("Spawn",0.015f,5f);
    }

    // Update is called once per frame
    void Spawn()
    {   
        Food = StaticFood;
        if(ToggleProp.movingFood)
        {
            rNG = Random.Range(1,maxRNG); //RNG use next time
            if(rNG==1)
            {
                Food = MovingFood;
            }
        }
        if (HeadMovement.inGame)
        {   
            if(ToggleProp.wall)
            {
                xRange[0]++;
                xRange[1]--;
                yRange[0]++;
                yRange[1]--;
            }
            int xNum = Random.Range(xRange[0],xRange[1]);
            int yNum = Random.Range(yRange[0],yRange[1]);
            Vector3 tempVector3 = new Vector3(xNum,yNum,Head.transform.position.z);
            while(true)
            {
                int Flags=0;
                if (Head.transform.position==tempVector3)
                {   
                    continue;
                }
                if (Flags==0)
                {
                    Instantiate(Food,tempVector3,Quaternion.identity);
                    break;
                }
            }
        }
        else if(Time.time>0.3f)
        {
            CancelInvoke();
        }
    }
}
