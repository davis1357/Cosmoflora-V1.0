using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    float zoomIn = 1f;
    float zoomTime = 2f;
    float waitTime = 1f;
    float t = 0f;
    float lerpTime = 0.5f;
    public PlanetConfig planetConfig;

    private void Start()
    {
        planetConfig.SetAnimals();
        planetConfig.SetAtmosphere();
        planetConfig.SetBackground();
        planetConfig.SetFlora();
        planetConfig.SetTerrain();

        GetComponentInChildren<Atmosphere>().SetAtmosphere(planetConfig.GetAtmosphere());
        GetComponentInChildren<Core>().SetCore(planetConfig.GetTerrain());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float startTime = Time.time;
        float endTime = startTime + lerpTime;
        FindObjectOfType<Player>().enabled = false;
        //Camera.main.transform.LookAt(gameObject.transform);
    //    Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoomIn, 1);
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<Player>().gameObject.transform.position = new Vector3(
            transform.position.x + 1f,
            transform.position.y + 1f,
            transform.position.z);
        FindObjectOfType<SceneManagement>().IntoPlanet();
    }
}
