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
    public Transform mapBackGround;
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
        setMapBackGroundSize();
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
            int plusMinusX = Random.Range(-mapSizeX / 2, mapSizeX / 2);
            int plusMinusY = Random.Range(-mapSizeY / 2, mapSizeY / 2);
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
            GameObject bubble = (GameObject)Instantiate(prefabBubble, new Vector3(Random.value * (mapSizeX / 2) * plusMinusX, Random.value * (mapSizeY/2) * plusMinusY, 0), Quaternion.identity);
            bubble.GetComponent<Bubble>().bubbleDestroyed.AddListener(() => { generateBubbleEvent(); });
            bubble.transform.SetParent(transform,true);
            bubbleCounter++;
        }
    }

    private void generateBubbleEvent()
    {
        bubbleCounter--;
        generateBubble();
    }

    private void generateWalls()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject wall = new GameObject();
            BoxCollider2D collider = wall.AddComponent<BoxCollider2D>();
            wall.name = "wall"+i;
            if (i == 0)
            {
                wall.transform.position = new Vector2((mapSizeX / 2)+0.1f, 0);
                collider.size = new Vector2(0.1f, mapSizeY);
            }
            else if (i == 1)
            {
                wall.transform.position = new Vector2((-mapSizeX / 2) - 0.1f, 0);
                collider.size = new Vector2(0.1f, mapSizeY);
            }
            else if (i == 2)
            {
                wall.transform.position = new Vector2(0, (mapSizeY / 2) + 0.1f);
                collider.size = new Vector2(mapSizeX, 0.1f);
            }
            else if (i == 3)
            {
                wall.transform.position = new Vector2(0, (-mapSizeY / 2) - 0.1f);
                collider.size = new Vector2(mapSizeX, 0.1f);
            }

            wall.transform.SetParent(transform, true);
        }
    }

    private void setMapBackGroundSize()
    {
        mapBackGround.localScale = new Vector3(mapSizeX/4, 1, mapSizeY/4);
        mapBackGround.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(mapSizeX*2 , mapSizeY*2);
    }
    #endregion
    #endregion
}
