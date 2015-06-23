//using System;
using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour 
{
    #region Variables
    #region Public
    public int mapSizeX, mapSizeY;
    public GameObject prefabBubble;
    public int maxBubbles = 2048;
    #endregion
    #region Private
    private int bubbleCounter;
    #endregion
    #endregion

    #region Unity-Events
    void Awake()
    {
        generateMap();
    }
    #endregion

    #region Methods
    #region Public
    #endregion

    #region Private
    private void generateMap()
    {
        generateWalls();
        generateBubbles();
    }

    private void generateBubbles()
    {
        for (int i = 0; i < maxBubbles; i++)
        {
            generateBubble();
        }
    }

    private void generateBubble()
    {
        if (bubbleCounter < maxBubbles)
        {
            int plusMinusX = Random.Range(-mapSizeX, mapSizeX);
            int plusMinusY = Random.Range(-mapSizeY, mapSizeY);
            if (plusMinusX < 0)
            {
                plusMinusX = -1;
            }
            else
            {
                plusMinusX = 1;
            }
            if (plusMinusY < 0)
            {
                plusMinusY = -1;
            }
            else
            {
                plusMinusY = 1;
            }
            GameObject bubble = (GameObject)Instantiate(prefabBubble, new Vector3(Random.value * mapSizeX * plusMinusX, Random.value * mapSizeY * plusMinusY, 0), Quaternion.identity);
            bubble.transform.SetParent(transform,true);
            bubbleCounter++;
        }
    }

    private void generateWalls()
    {

    }
    #endregion
    #endregion
}
