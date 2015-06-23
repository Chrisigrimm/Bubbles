using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    #region Variables
    public Camera playerCamera;
    #region Public
    #endregion
    #region Private
    private Rigidbody rigBody;
    private bool test = false;
    #endregion
    #endregion

    #region Unity-Events
    void OnCollisionEnter(Collision collision)
    {
        test = true;
    }

    void Awake()
    {
        rigBody = GetComponent<Rigidbody>();
    }
    #endregion

    #region Methods
    #region Public
    public void movePlayer(Vector2 toPosition, float speed)
    {
        if (!test)
        {
            rigBody.velocity = toPosition * (speed / rigBody.mass);
        }
        else
        {
            test = false;
        }
    }
    #endregion

    #region Private
    #endregion
    #endregion
}
