using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {

    public Text score;
    public Text timer;
    public float initialTime;
    public GameObject pauseMenu;

    private float runningTime;
    private bool isPause;
    private float pointCount;
    private float numOfTargets;
    private GameObject[] targets;
    
    // Use this for initialization
    void Start() {
        pauseMenu.SetActive(false);
        pointCount = 0;
        runningTime = initialTime;
        isPause = false;
        targets = GameObject.FindGameObjectsWithTag("Target");
        numOfTargets = targets.Length;
        Debug.Log(numOfTargets);
        score.text = "Score: " + pointCount.ToString();
        setTimer();
    }

    private void setTimer()
    {
        timer.text = (Mathf.Round(runningTime * 100f) / 100f).ToString();
    }

    public float getTimer()
    {
        return this.runningTime;
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
        if(runningTime > 0)
        {
            runningTime -= Time.deltaTime;
        }
        setTimer();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            if (isPause)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }               
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }               
        }
    }
}
