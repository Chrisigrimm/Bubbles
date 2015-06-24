using UnityEngine;
using System.Collections;

public class InputManger : MonoBehaviour
{
    #region Variables
    #region Public
    public Player player;
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
        playerControlPC();
    }

#region PC-Controls
    private void playerControlPC()
    {
        movePlayerPC();
        shootBubblePC();
    }

    private void movePlayerPC()
    {
        Vector2 mousePos = player.playerCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = player.transform.position;
        Vector2 differenceVector = mousePos - playerPos;

        float speed = 0;

        if (differenceVector.sqrMagnitude > radiusMouse * radiusMouse)
        {
            speed = player.moveSpeedMax;
        }
        else
        {
            if ((player.moveSpeedMax * (differenceVector.sqrMagnitude / (radiusMouse * radiusMouse))) < player.moveSpeedMin)
            {
                speed = player.moveSpeedMin;
            }
            else
            {
                speed = player.moveSpeedMax * (differenceVector.sqrMagnitude / (radiusMouse * radiusMouse));
            }
        }
        player.movePlayer(Vector3.ClampMagnitude(differenceVector, 0.1f), speed);
    }

    private void shootBubblePC()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector2 mousePos = player.playerCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerPos = player.transform.position;
            Vector2 differenceVector = mousePos - playerPos;
            player.shootBubble(Vector3.ClampMagnitude(differenceVector, 0.1f));
        }
    }
    #endregion
    #endregion
    #endregion
}
