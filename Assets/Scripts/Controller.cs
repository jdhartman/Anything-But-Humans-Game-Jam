using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {

    public Text score;
    public Text timer;
    public float initialTime;
    private float pointCount;
    private float numOfTargets;
    private GameObject[] targets;
    
    // Use this for initialization
    void Start() {
        pointCount = 0;
        targets = GameObject.FindGameObjectsWithTag("Target");
        numOfTargets = targets.Length;
        Debug.Log(numOfTargets);
        score.text = "Score: " + pointCount.ToString();
        timer.text = initialTime.ToString();
    }

    public void addToPointCount()
    {
        pointCount++;
        score.text = "Score: " + pointCount.ToString();
    }

    public void moveObjective(Transform transform)
    {
        int i = (int) Random.Range(0, numOfTargets);
        while(targets[i].transform.position == transform.position)
        {
            i = (int)Random.Range(0, numOfTargets);
        }
        transform.position = targets[i].transform.position;
    }

    public float getPointCount()
    {
        return this.pointCount;
    }
    // Update is called once per frame
    void Update () {
        initialTime -= Time.deltaTime;
        timer.text = initialTime.ToString();
	}
}
