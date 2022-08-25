using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private float _time;
    [SerializeField] private float _repeatRate;
 

    private PlayerController _playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnerObstacle", _time, _repeatRate);
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

   void SpawnerObstacle()
    {
       
        if (_playerControllerScript.GameOver == false)
        {
            Instantiate(_obstacle, transform.position, transform.rotation);
        }
    }
    
}
