using UnityEngine;

public class HeadCollision : MonoBehaviour
{   
    GameObject Snake;
    GameObject Head;
    [SerializeField] GameObject Ground;
    [SerializeField] GameObject Enemy;
    [SerializeField] public static bool collide;
    bool ending;
    void Start()
    {   
        collide=false;
        ending=true;
        Head=this.gameObject;
        Snake=transform.parent.gameObject;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Finish")
        {
            HeadMovement.inGame = false;
            GetComponent<HeadMovement>().enabled = false;
            Ground.transform.parent.GetComponent<FoodSpawn>().enabled = false;
            Score.winNext=true;
        }
        if (other.gameObject.tag!="Tail")
        {
            HeadMovement.inGame = false;
            GetComponent<HeadMovement>().enabled = false;
            Ground.transform.parent.GetComponent<FoodSpawn>().enabled = false;
            collide=true;
        }
        
    }
    private void Update() {
        if(TailMovement.endingAnimation&&collide)
        {
            EndingSequence();
        }
    }
    private void EndingSequence()
    {
        if (ending)
        {
            for (int i = Snake.transform.childCount - 1; i > 0; i--)
            {
                Destroy(Snake.transform.GetChild(i).gameObject);
            }
            Enemy.transform.GetChild(0).GetComponent<TailMovement>().enabled=false;
            Head.GetComponent<BoxCollider2D>().enabled = false;
            Head.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Head.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
            Head.GetComponent<Rigidbody2D>().gravityScale = 1;
            ending=false;
            
        }
    }
}
