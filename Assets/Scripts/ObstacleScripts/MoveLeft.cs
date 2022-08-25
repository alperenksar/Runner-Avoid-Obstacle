using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField] private float _obstacleSpeed;
    private PlayerController _playerControllerScript;
    [SerializeField] private float _leftBound;
    // Start is called before the first frame update
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_playerControllerScript.GameOver == false)
        {
            transform.Translate(Vector3.left * _obstacleSpeed * Time.deltaTime);
        }
        if (gameObject.transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
