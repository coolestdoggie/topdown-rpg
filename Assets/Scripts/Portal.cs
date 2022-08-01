using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    [SerializeField] private string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
        SceneManager.LoadScene(sceneName);
    }
}
