using UnityEngine;

public class Length : MonoBehaviour
{

    [SerializeField] GameObject tailending;
    [SerializeField] GameObject enemyTail;
    Transform Snake;
    [SerializeField] Transform AltSnake;
    private void Start() {
        Snake = transform.parent;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Food")
        {
            Instantiate(tailending,transform.parent.GetChild(transform.parent.childCount-1).position,Quaternion.identity,Snake);
            Destroy(other.gameObject);
            if(MainMenu.survival)
            {
                Instantiate(enemyTail,AltSnake.GetChild(0).position,Quaternion.identity,AltSnake);
            }
        }
        if(other.gameObject.tag=="MovingFood")
        {
            Instantiate(tailending,transform.parent.GetChild(transform.parent.childCount-1).position,Quaternion.identity,Snake);
            Instantiate(tailending,transform.parent.GetChild(transform.parent.childCount-1).position,Quaternion.identity,Snake);
            Instantiate(tailending,transform.parent.GetChild(transform.parent.childCount-1).position,Quaternion.identity,Snake);
            Destroy(other.gameObject);
            if(MainMenu.survival)
            {
                Instantiate(enemyTail,AltSnake.GetChild(0).position,Quaternion.identity,AltSnake);
                Instantiate(enemyTail,AltSnake.GetChild(0).position,Quaternion.identity,AltSnake);
                Instantiate(enemyTail,AltSnake.GetChild(0).position,Quaternion.identity,AltSnake);
            }
        }
    }
}
