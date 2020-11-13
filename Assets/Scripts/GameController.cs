using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<GameObject> players;
    public List<GameObject> enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(fooObj);
        }
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(fooObj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (enemies.Count == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
