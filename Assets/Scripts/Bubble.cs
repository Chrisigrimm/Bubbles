using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using System;
using System.Collections;

public class Bubble : MonoBehaviour
{
    #region Variables
    #region Public
    public int BubblePoints = 1;
    public MapGenerator mapGenerator;
    #endregion
    #region Private
    private bool applicationRunning = true;
    #endregion
    #endregion

    #region Events
    [Serializable]
    public class BubbleEvent : UnityEvent { }
    [FormerlySerializedAs("Bubble destroyed")]
    [SerializeField]
    private BubbleEvent m_bubbleDestroyed = new BubbleEvent();
    public BubbleEvent bubbleDestroyed
    {
        get { return m_bubbleDestroyed; }
        set { m_bubbleDestroyed = value; }
    }
    #endregion

    #region Unity-Events
    void OnEnable()
    {
        GetComponent<SpriteRenderer>().color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    void OnDisable()
    {
        if (applicationRunning)
        {
            bubbleDestroyed.Invoke();
        }
    }

    void OnApplicationQuit()
    {
        applicationRunning = false;
    }
    #endregion

    #region Methods
    #region Public
    #endregion

    #region Private
    #endregion
    #endregion
}
