using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private GameObject greatText;
    // Start is called before the first frame update
    void Start()
    {
        greatText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Ksquare.locked && Square.locked && Circle.locked && Hexagon.locked)
        {
            greatText.SetActive(true);
            Invoke("Res",1f);
        }
    }

    void Res()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        greatText.SetActive(false);
    }
}
