using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScheduler : MonoBehaviour {


    public Queue<float> Events;

    GameFlowManager manager;

    // Use this for initialization
    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("MainLoop");
        manager = obj.GetComponent<GameFlowManager>();

        Events = new Queue<float>();
        GenerateEvents();
    }

    // Update is called once per frame
    void Update()
    {
        if (Events.Count == 0)
        {
            GenerateEvents();
        }
    }

    public float GetNext()
    {
        if(Events.Count == 0)
        {
            GenerateEvents();
        }
        return Events.Peek();
    }

    public void Consume ()
    {
        Events.Dequeue();
    }

    private void GenerateEvents ()
    {
        if (manager.GetGameState() == GameFlowManager.GameState.GS_Play)
        {
            for (int i = 0; i < 30; i++)
            {
                Events.Enqueue(Time.realtimeSinceStartup + i * 3.0f);
            }
        }
    }
}
