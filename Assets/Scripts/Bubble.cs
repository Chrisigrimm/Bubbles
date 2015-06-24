using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour
{
    #region Variables
    #region Public
    public int BubblePoints = 1;
    #endregion
    #region Private
    #endregion
    #endregion

    #region Unity-Events
    void FixedUpdate()
    {

    }
    #endregion

    #region Methods
    #region Public
    #endregion

    #region Private
    private void slowBubble()
    {
        if(tag == "shootBubble"){
            Rigidbody2D rigBody = GetComponent<Rigidbody2D>();
            if (rigBody.velocity.magnitude > 0)
            {
                rigBody.velocity = Vector2.ClampMagnitude(rigBody.velocity, rigBody.velocity.magnitude / 2);
            }
        }
    }
    #endregion
    #endregion
}
