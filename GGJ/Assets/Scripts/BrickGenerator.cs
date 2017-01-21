using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour {

    // exposed parameters
    public GameObject Prefab_001;
    public GameObject Prefab_002;
    public GameObject Prefab_003;
    public GameObject Prefab_004;
    public GameObject AudioGeneratorObject;
    public GameObject AudioGeneratorObject_version2;

    public float BrickLiveTimeInSecs = 5.0f;

    // private parameters
    private IDictionary<GameObject, float> LifeTimePerCube;
    private IDictionary<GameObject, int> IndexPerCube;

    // Use this for initialization
    void Start () {
        LifeTimePerCube = new Dictionary<GameObject, float>();
        IndexPerCube = new Dictionary<GameObject, int>();
    }
	
	// Update is called once per frame
	void Update () {
        // check what needs to be destroyd
        List<GameObject> destroyList = new List<GameObject>();
        foreach(var current in LifeTimePerCube)
        {
            if (Time.time > current.Value)
            {
                destroyList.Add(current.Key);
            }
        }

        // destroy stuff
        foreach (var obj in destroyList)
        {
            LifeTimePerCube.Remove(obj);
            IndexPerCube.Remove(obj);
            Destroy(obj);
        }

        // update positions
        for(int child=0; child<transform.childCount; child++)
        {
            transform.GetChild(child).transform.position = new Vector3(transform.position.x, transform.position.y + child, transform.position.z);
        }

        // trigger destroy of the for bottom cubes
        for (int child = 0; child < transform.childCount && child < 4 ; child++)
        {
            GameObject obj = transform.GetChild(child).gameObject;
            if(!LifeTimePerCube.ContainsKey(obj))
            {
                LifeTimePerCube.Add(obj, Time.realtimeSinceStartup + BrickLiveTimeInSecs);
            }
        }

        // update audio
        // deal with audo sources
        if (AudioGeneratorObject != null)
        {
            AudioManager ag = AudioGeneratorObject.GetComponent<AudioManager>();
            if (ag != null)
            {
                // end all loops
                ag.Loops(false);

                IList<int> actives = new List<int>();
                for (int child = 0; child < transform.childCount && child < 4; child++)
                {
                    GameObject obj = transform.GetChild(child).gameObject;
                    if(obj!=null)
                    {
                        ag.ActivateAudio(IndexPerCube[obj], true);
                        actives.Add(IndexPerCube[obj]);
                    }
                }

                ag.DesacActivateAllBut(actives);
            }
        }

        if(AudioGeneratorObject_version2)
        {
            AudioManager_version2 ag = AudioGeneratorObject_version2.GetComponent<AudioManager_version2>();
            if (ag != null)
            {
                IList<int> actives = new List<int>();
                for (int child = 0; child < transform.childCount && child < 4; child++)
                {
                    GameObject obj = transform.GetChild(child).gameObject;
                    if (obj != null)
                    {
                        actives.Add(IndexPerCube[obj]);
                    }
                }

                ag.ActivateEffects(actives);
            }
        }
    }

    public void Generate(int index)
    {
        GameObject cube = null;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + transform.childCount, transform.position.z);
        switch (index)
        {
            case 0:
                if(Prefab_001!= null) { cube= Instantiate(Prefab_001, pos, Quaternion.identity); }
                break;
           case 1:
                if (Prefab_002 != null) { cube = Instantiate(Prefab_002, pos, Quaternion.identity); }
                break;
           case 2:
                if (Prefab_003 != null) { cube = Instantiate(Prefab_003, pos, Quaternion.identity); }
                break;
           case 3:
                if (Prefab_004 != null) { cube = Instantiate(Prefab_004, pos, Quaternion.identity); }
                break;
            default:
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = pos;
                break;
        }
        if(cube == null)
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = pos;
        }

        cube.transform.SetParent(transform);

        // same data in dictionaries
        IndexPerCube.Add(cube, index);
    }
}
