using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource backGroundMusic;
    private int SceneIndex; 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            backGroundMusic = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
        
       
    }
    private void Update()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneIndex == 1)
        {
            LowerVolume(0.4f);
        }
        else
        {
            LowerVolume(1f);
        }
    }
    public void LowerVolume(float volume)
    {

        if (backGroundMusic != null  )
        {
            backGroundMusic.volume = volume;
        }
    }




   
}
