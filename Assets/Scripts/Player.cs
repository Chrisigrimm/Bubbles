using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    #region Variables
    public Camera playerCamera;
    #region Public
    #endregion
    #region Private
    private Rigidbody2D rigBody;
    private bool test = false;
    #endregion
    #endregion

    #region Unity-Events
    void OnCollisionEnter(Collision collision)
    {
        //test = true;
    }

    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region Methods
    #region Public
    public void movePlayer(Vector2 toPosition, float speed)
    {
        rigBody.velocity = toPosition * (speed / rigBody.mass);
    }
    #endregion

    #region Private
    private void eatBubble()
    {
        rigBody.mass += 2;
    }
    #endregion
    #endregion
}
