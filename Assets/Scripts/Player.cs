using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    private void Awake()
    {
        SetUpSingleton();
    }

    void Start()
    {
        enabled = true;
    }

    private void SetUpSingleton()
    {
        int numOfGameSessions = FindObjectsOfType<Player>().Length;
        if (numOfGameSessions > 1 || SceneManager.GetActiveScene().name != "Space Screen")
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name=="Space Screen")
        {
            Move();
        }
        if(SceneManager.GetActiveScene().name=="Planet")
        {
          //  transform.position = transform.InverseTransformPoint(new Vector2(0.5f, 0.5f));
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = new Vector2(transform.position.x + deltaX, transform.position.y + deltaY);

        transform.position = newXPos;
    }
}
