using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {

    public Text score;
    public Text timer;
    public Text finalScore;

    public float initialTime;
    public float maxTime;
    public float plusTime;

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject endGameMenu;
    

    private float runningTime;
    private bool isPause;
    private float pointCount;
    private float numOfTargets;
    private GameObject[] targets;
    
    // Use this for initialization
    void Start() {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        endGameMenu.SetActive(false);
        pointCount = 0;
        runningTime = initialTime;
        isPause = false;
        Time.timeScale = 1;

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

    public float getPointCount()
    {
        return this.pointCount;
    }
    public void addToPointCount()
    {
        pointCount++;
        score.text = "Score: " + pointCount.ToString();
        if(runningTime < maxTime)
        {
            runningTime += plusTime;
        }
        
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

    

    public void pauseGame()
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

    private void changeTime()
    {
        if(isPause)
        {
            Time.timeScale = 0;
        }
        else if (runningTime > 5)
        {
            if (Time.timeScale < 1)
            {
                Time.timeScale += .05f;
            }
        }
        else if (runningTime < 5)
        {
            if (Time.timeScale > .5)
            {
                Time.timeScale -= .005f;
            }
        }
        else Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update() {
        if (runningTime > 0)
        {
            runningTime -= Time.deltaTime;
            changeTime();
        }
        else
        { 
            finalScore.text = score.text;
            endGameMenu.SetActive(true);
            Time.timeScale = 0;
        }
        setTimer();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();             
        }
    }
}
