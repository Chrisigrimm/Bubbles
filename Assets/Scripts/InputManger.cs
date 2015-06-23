using UnityEngine;
using System.Collections;

public class InputManger : MonoBehaviour
{
    #region Variables
    #region Public
    public Player player;
    public float minSpeed = 1;
    public float maxSpeed = 5;
    public float radiusMouse = 2;
    #endregion
    #region Private
    #endregion
    #endregion

    #region Unity-Events
    void Update()
    {
        control();
    }
    #endregion

    #region Methods
    #region Public
    #endregion

    #region Private
    private void control()
    {
        playerControl();
    }

    private void playerControl()
    {
        Vector2 mousePos = player.playerCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = player.transform.position;
        Vector2 differenceVector = mousePos - playerPos;

        float speed = 0;

        if (differenceVector.sqrMagnitude > radiusMouse * radiusMouse)
        {
            speed = maxSpeed;
        }
        else
        {
            if ((maxSpeed * (differenceVector.sqrMagnitude / (radiusMouse * radiusMouse))) < minSpeed)
            {
                speed = minSpeed;
            }
            else
            {
                speed = maxSpeed * (differenceVector.sqrMagnitude / (radiusMouse * radiusMouse));
            }
        }

        player.movePlayer(differenceVector, speed);
    }
    #endregion
    #endregion
}
