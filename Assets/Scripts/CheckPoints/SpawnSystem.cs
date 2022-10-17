using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
     
    private SpawnManager _spawnManager;
    private int _lastCheckPoint;
    // Start is called before the first frame update
    void Start()
    {
        //_spawnManager = GameObject.Find("SpawnPointsManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CheckPoint point))
        {
            _spawnManager.LastCheckPointName = point.name;
        }
    }
}
