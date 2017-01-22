using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

    public Vector2 Height;

    public class Platform
    {
        public Transform Prefab;

    }

    public class Bonus
    {
        public Transform Prefab;
    }

	// Use this for initialization
	void Start () {
        GameObject obj = GameObject.FindGameObjectWithTag("MainLoop");
        manager = obj.GetComponent<GameFlowManager>();

        Platforms = new Transform[] { Platform1, Platform2, Platform3 };
    }

    float timePast = 0.0f;

    public Vector2 SpawnTime = new Vector2(8.0f, 16.0f);
    public Vector2 SpawnHeight = new Vector2(0.0f, 2.0f);
    public float SpwanX = 30.0f;

    float TimeToSpawn = 10.0f;

    public Transform Platform1;
    public Transform Platform2;
    public Transform Platform3;

    public Transform[] Platforms;

    System.Random random = new System.Random();

    GameFlowManager manager;

    // Update is called once per frame
    void Update () {

        if (manager.GetGameState() != GameFlowManager.GameState.GS_Play)
            return;

        TimeToSpawn -= Time.deltaTime;

        if (TimeToSpawn < 0.0f)
        {
            Vector3 pos = new Vector3(SpwanX, Mathf.Lerp(SpawnHeight.x, SpawnHeight.y, (float)random.NextDouble()), 0.0f);

            Transform plat = Instantiate(Platforms[random.Next() % Platforms.Length], pos, Quaternion.identity);

            TimeToSpawn = Mathf.Lerp(SpawnTime.x, SpawnTime.y, (float)random.NextDouble());
        }
	}
}
