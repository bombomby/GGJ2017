using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour {


    public GameObject Prefab_001;
    public GameObject Prefab_002;
    public GameObject Prefab_003;
    public GameObject Prefab_004;

    public IList<GameObject> Prefabs;
    public IList<GameObject> Cubes;
    public float YOffset;

    // Use this for initialization
    void Start () {
        Prefabs = new List<GameObject>();
        Cubes = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void Generate(int index)
    {
        GameObject cube = null;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + Cubes.Count, transform.position.z);
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

        Cubes.Add(cube);

        /*
        GameObject cube = null;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + Cubes.Count, transform.position.z);

        if (index < Prefabs.Count)
        {
            cube = Instantiate(Prefabs[index], pos, Quaternion.identity);
        }
        else
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = pos;
        }

        if(cube != null)
        {
           
            Cubes.Add(cube);
        }
        */
    }
}
