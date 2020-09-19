using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClickBall : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameObject gameobject1;
    public static GameObject gameobject2;
    void Start()
    {
        gameobject1 = null;
        gameobject2 = null;
    }

    public void OnClickBall(GameObject Ball)
    {
        if (gameobject1 == null)
        {
            gameobject1 = Ball;
            //Debug.Log(data);
            
        }
        else if (gameobject2 == null)
        {
            gameobject2 = Ball;
            
        }
    }
    public GameObject getgameobject1()
    {
        return gameobject1;
    }
    public GameObject getgameobject2()
    {
        return gameobject2;
    }

}
