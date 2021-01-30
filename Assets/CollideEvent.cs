using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideEvent : MonoBehaviour
{
    //TODO: Add planets fade out!

    [SerializeField] float speed = 4f;
    // float padding = 2f;
    bool trigger = false;
    float padding = 1f;

    private void Update()
    {
        if (trigger)
        {
            float xTarget = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
            float yTarget = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
            Vector3 destination = new Vector3(xTarget, yTarget, 0);
            FindObjectOfType<Player>().gameObject.transform.position = Vector2.MoveTowards(FindObjectOfType<Player>().gameObject.transform.position, destination, speed * Time.deltaTime);
            if (FindObjectOfType<Player>().gameObject.transform.position == destination)
            {
                FindObjectOfType<GameSession>().isSpace = false;
                trigger = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Player>().enabled = false;
        trigger = true;
        StartCoroutine(SwitchView());
    }

    IEnumerator SwitchView()
    {
        yield return new WaitWhile(() => trigger == true);
        var allPlanets = FindObjectsOfType<Planet>();
        
        for (int i = 0; i < allPlanets.Length; i++)
        {
            allPlanets[i].gameObject.SetActive(false);
        }
    }
}
