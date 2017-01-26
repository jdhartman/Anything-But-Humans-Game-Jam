using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {

    public Text score;
    public Text timer;
    public Text finalScore;
    public Text countText;

    public float initialTime;
    public float maxTime;
    public float plusTime;

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject endGameMenu;
    

    private float runningTime;
    private float countdown;
    private bool isPause;
    private bool isCountdown;
    private float pointCount;
    private float numOfTargets;
    private GameObject[] targets;
    
    // Use this for initialization
    void Start() {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        endGameMenu.SetActive(false);
        pointCount = 0;
        countdown = 3;
        runningTime = initialTime;
        isPause = false;
        isCountdown = false;
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
        if (isPause || countdown > 0)
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

    IEnumerator removeCountdown()
    {
        
        if(!isCountdown)
        {
            Debug.Log("Remove Countdown");
            countText.text = "Go!";
            countdown = -1;
            yield return new WaitForSeconds(.5f);
            countText.CrossFadeAlpha(0, 1, false);
        }
        
    }

    public float getCountdown()
    {
        return this.countdown;
    }

    private void changeTime()
    {
        if(isPause)
        {
            Time.timeScale = 0;
        }
        else if (runningTime > 5)
        {
            timer.fontSize = 33;
        }
        else if (runningTime < 5)
        {
            timer.fontSize++;
        }
        else Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update() {
        if(countdown > .0001)
        {
            countdown -= (Time.deltaTime);
            if(Mathf.Round(countdown * 1f) / 1f > 0)
            {
                countText.text = (Mathf.Round(countdown * 1f) / 1f).ToString();
            }   
        }
        else
        {
            StartCoroutine(removeCountdown());
            isCountdown = true;       
        }

        if (runningTime > 0 && countdown < 0)
        {
            runningTime -= Time.deltaTime;
            changeTime();
        }
        else if(countdown < 0)
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
