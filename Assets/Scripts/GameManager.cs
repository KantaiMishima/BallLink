using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        GameObject obj = (GameObject)Resources.Load("Sphere");
        GameObject dot = (GameObject)Resources.Load("dot");
        GameObject target = GameObject.Find("EventSystem");
        ClickBall clickball = target.GetComponent<ClickBall>();

        // プレハブを元にオブジェクトを生成する
        for (int x = 0; x < 7; x++)
        {
            GameObject instance = (GameObject)Instantiate(obj,
                                                          new Vector3(Random.Range(-5f, 5.0f), 0.5f, Random.Range(-4.5f, 4.5f)),
                                                          Quaternion.identity);
            //Eventtrigger関数を呼ぶ
            EventTrigger eventtrigger = instance.GetComponent<EventTrigger>();

            List<EventTrigger.Entry> triggers = new List<EventTrigger.Entry>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((data) => { clickball.OnClickBall(instance); });
            triggers.Add(entry);

            eventtrigger.triggers = triggers;
        }
        for (int x = 0; x < 15; x++)
        {
            GameObject instance = (GameObject)Instantiate(dot,
                                                          new Vector3(Random.Range(-5f, 5.0f), 0.5f, Random.Range(-4.5f, 4.5f)),
                                                          Quaternion.identity);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
