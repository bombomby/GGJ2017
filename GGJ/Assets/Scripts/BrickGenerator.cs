using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickGenerator : MonoBehaviour {

    // exposed parameters
    public GameObject Prefab_001;
    public GameObject Prefab_002;
    public GameObject Prefab_003;
    public GameObject Prefab_004;

    public Image Image_brick_001;
    public Image Image_brick_002;
    public Image Image_brick_003;
    public Image Image_brick_004;
    
    public GameObject AudioGeneratorObject;
    public GameObject AudioGeneratorObject_version2;
    public Canvas BrickCanvas;

    public float BrickLiveTimeInSecs = 5.0f;

    public float ImageSize = 50;

    // private parameters
    private IDictionary<GameObject, float> LifeTimePerImage;
    private IDictionary<GameObject, int> IndexPerBrick;
    private IList<GameObject> Bricks;
    
    // Use this for initialization
    void Start () {
        LifeTimePerImage = new Dictionary<GameObject, float>();
        IndexPerBrick = new Dictionary<GameObject, int>();
        Bricks = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {

        // check what needs to be destroyd
        List<GameObject> destroyList = new List<GameObject>();
        foreach(var current in LifeTimePerImage)
        {
            if (Time.time > current.Value)
            {
                destroyList.Add(current.Key);
            }
        }

        // destroy stuff
        foreach (var obj in destroyList)
        {
            LifeTimePerImage.Remove(obj);
            Bricks.Remove(obj);
            Destroy(obj);
        }

        // update positions
        for (int idx = 0; idx < Bricks.Count; idx++)
        {
            if (null == Bricks[idx]) continue;

            Bricks[idx].GetComponent<RectTransform>().position = CalculatePosition(idx);
        }

        // trigger destroy of the for bottom cubes
        for (int idx = 0; idx < Bricks.Count && idx < 4; idx++)
        {
            if (!LifeTimePerImage.ContainsKey(Bricks[idx]))
            {
                LifeTimePerImage.Add(Bricks[idx], Time.realtimeSinceStartup + BrickLiveTimeInSecs);
            }
        }

        // get active indexes
        IList<int> actives = new List<int>();
        for (int idx = 0; idx < Bricks.Count && idx < 4; idx++)
        {
            if(IndexPerBrick.ContainsKey(Bricks[idx])) { actives.Add(IndexPerBrick[Bricks[idx]]); }
        }

        // update audio
        // deal with audo sources
        if (AudioGeneratorObject != null)
        {
            AudioManager ag = AudioGeneratorObject.GetComponent<AudioManager>();
            if (ag != null) { 
                // end all loops
                ag.Loops(false);
                foreach (int index in actives) {
                    ag.ActivateAudio(index, true);
                }
                ag.DesacActivateAllBut(actives);
            }
        }

        // update effects
        if(AudioGeneratorObject_version2)
        {
            AudioManager_version2 ag = AudioGeneratorObject_version2.GetComponent<AudioManager_version2>();
            if (ag != null)
            {
                ag.ActivateEffects(actives);
            }
        }
    }

    /// <summary>
    /// Calculate Positon
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    Vector2 CalculatePosition(int index)
    {
        float pos_x = BrickCanvas.pixelRect.position.x + ImageSize;
        float pos_y = BrickCanvas.pixelRect.position.y + index * ImageSize*2 + ImageSize;

        return new Vector2(pos_x, pos_y);
    }

    /// <summary>
    /// Generates a brick in the canvas system
    /// </summary>
    /// <param name="index"></param>
    public void GenerateBrickInCanvas (int index)
    {
        // security check
        if (BrickCanvas == null) return;


        GameObject image = new GameObject();
        image.AddComponent<RectTransform>();
        image.transform.SetParent(BrickCanvas.transform);
        image.GetComponent<RectTransform>().position = CalculatePosition(BrickCanvas.transform.childCount);

        image.GetComponent<RectTransform>().rect.Set (image.GetComponent<RectTransform>().rect.x,
                                                      image.GetComponent<RectTransform>().rect.y,
                                                      ImageSize, ImageSize);
        
        switch (index)
        {
            case 0:
                image.AddComponent<Image>().sprite = Image_brick_001.sprite;
                break;
            case 1:
                image.AddComponent<Image>().sprite = Image_brick_002.sprite;
                break;
            case 2:
                image.AddComponent<Image>().sprite = Image_brick_003.sprite;
                break;
            case 3:
                image.AddComponent<Image>().sprite = Image_brick_004.sprite;
                break;
            default:
                break;
        }
        Bricks.Add(image);
        IndexPerBrick.Add(image, index);
        image.layer = Bricks.Count;
    }
}
