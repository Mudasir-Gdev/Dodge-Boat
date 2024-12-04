using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System.Security.Cryptography;

public class UImanager : MonoBehaviour
{
    private MissilesSpawner MS;
    public Text T;
    public Text Score;
    public Text Star;
    public int score1; 
    public int star1;
    public int t;
    public bool scored=false;
    public static int countAd; 
    public  GameObject Double ;
    private void Start()
    {
        MS = GetComponent<MissilesSpawner>();
        StartCoroutine(timer());
        DontDestroyOnLoad(this.gameObject);
        Advertisement.Initialize("5740097");
    }
    private void Update()
    {
       
        if (scored)
        {
            StarUI(1);
            ScoreUI(16);
            scored = false;
        }
        if (countAd == 3)
        {
            Debug.Log("Ad called");
            Advertisement.Show("Interstitial_Android");
            countAd = 0;
        }
    }

    public void Play()
    {
        countAd++;
        SceneManager.LoadSceneAsync(1);
        MS.ResetTimer = true;
    }
    public void Restart()
    {
        countAd++;
        SceneManager.LoadSceneAsync(1);
        MS.ResetTimer = true;
        
    }
    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
    }
   
    public void StarUI(int star)
    {
        
        
            Debug.Log("Star");
            star1 += star;
            Star.text = star1 + "";
            
        
    }
    public void ScoreUI(int score)
    {
            score1 += score;
            Score.text = "Score " + score1 + t ;
            Debug.Log("Score");
                   
    }
     public void Ad()
    {
        Advertisement.Show("Rewarded_Android");
        Double.gameObject.SetActive(false);
    }
    IEnumerator timer()
    {
        t++;
        T.text = "" + t;
        yield  return new WaitForSeconds(1);
        StartCoroutine(timer());
    }
    
         
    
}
