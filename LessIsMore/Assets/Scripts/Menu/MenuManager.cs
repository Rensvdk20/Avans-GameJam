using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
public GameObject[] gameObjects;
    private int currentIndex = 0;
    private bool allObjectsShown = false;

    void Start()
    {
        // Show the first game object and hide others
        ShowCurrentGameObject();
    }

    void Update()
    {
        // Check if all game objects have been shown
        if (!allObjectsShown)
        {
            // Check for mouse click
            if (Input.GetMouseButtonDown(0))
            {
                // Increment index
                currentIndex++;

                // Show the current game object and hide others
                ShowCurrentGameObject();

                // Check if all game objects have been shown
                if (currentIndex >= gameObjects.Length)
                {
                    allObjectsShown = true;
                }
            }
        }
    }

    void ShowCurrentGameObject()
    {
        // Hide all game objects
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false);
        }

        // Show the current game object if it exists
        if (currentIndex < gameObjects.Length)
        {
            gameObjects[currentIndex].SetActive(true);
        }
    }
}
