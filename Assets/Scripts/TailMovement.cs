using UnityEngine;
using UnityEngine.SceneManagement;
public class TailMovement : MonoBehaviour
{   
    GameObject Head;
    public static bool endingAnimation;
    void Start()
    {
        endingAnimation = false;
        Head = transform.GetChild(0).gameObject;
        InvokeRepeating("Movement", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Movement()
    {
        GameObject abdomen = transform.GetChild(transform.childCount - 1).gameObject;
        abdomen.tag="Tail";
        abdomen.transform.position= Head.transform.position;
        abdomen.transform.SetSiblingIndex(1);
        transform.GetChild(2).gameObject.tag="Untagged";
        if (gameObject.tag=="Player")
        {
            
            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color=new Color(0.09622639f,0.1627304f,0.5f);
            transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color=new Color(0.1176471f,0.1607843f,0.5529412f);

            if(Time.time>0.3f&&
                transform.GetChild(0).position==transform.GetChild(transform.childCount-1).position&&
                transform.GetChild(transform.childCount-1).position==transform.GetChild(transform.childCount-2).position)
                {
                    CancelInvoke();
                    endingAnimation=true;
                }
            if(Score.winNext&&
                Time.time>0.3f&&transform.GetChild(0).position==transform.GetChild(transform.childCount-1).position&&
                transform.GetChild(transform.childCount-1).position==transform.GetChild(transform.childCount-2).position)
            {   
                int nextScene  = SceneManager.GetActiveScene().buildIndex+1;
                if (nextScene == SceneManager.sceneCountInBuildSettings)
                {
                    nextScene = 0;
                }
                SceneManager.LoadScene(nextScene);
            }
        }
        else
        {
            if(HeadCollision.collide)
            {
                CancelInvoke();
            }
        }
    }
}