using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour 
{
    public bool Resume;
    public string LastCheckPointName;
    public GameObject[] SpawnPoints;
    private GameObject _player;
    private int _spawnManagers;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Awake()
    {     
       _spawnManagers = FindObjectsOfType<SpawnManager>().Length;
        if (_spawnManagers != 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        
        TeleportPlayer();
    }
    private void TeleportPlayer()
    {
         
        _player = GameObject.Find("Player");
        _player.GetComponent<CharacterController>().enabled = false;
        if (Resume)
        {
            
            _player.transform.position = GameObject.Find(FindLastCheckPoint()).gameObject.transform.position;
            Resume = false;

        }
        else
        {
            _player.transform.position = GameObject.Find("CheckPoint_0").gameObject.transform.position;
        }
        _player.GetComponent<CharacterController>().enabled = true;
    }

    private string FindLastCheckPoint()
    {
        var res = string.Empty;
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            if (SpawnPoints[i].name == LastCheckPointName)
            {
                res = SpawnPoints[i].name;
                break;
            }
        }
        return res;

    }

}
