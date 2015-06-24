using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Player : MonoBehaviour
{
    #region Variables
    public Camera playerCamera;
    public GameObject prefabBubble;
    public float moveSpeedMin = 1;
    public float moveSpeedMax = 10;
    public float shootSpeed = 10;
    public int massStepSlower = 10;
    public float setSpeedMult = 0.1f;
    public float cameraOutZoomMult = 0.08f;
    public float cameraOutZoomMultDur = 1f;
    public float ballGrowMult = 0.1f;
    public float ballGrowDur = 1f;
    public int shootBubblePoints = 10;
    public float durClearIgnBubble = 5;
    #region Public
    #endregion
    #region Private
    private Rigidbody2D rigBody;
    private bool test = false;
    private int massToSpeedCounter = 1;
    private float massToSpeedMult = 1;
    private GameObject ignoreBubble;
    #endregion
    #endregion

    #region Unity-Events
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject != ignoreBubble)
        {
            eatBubble(collider);
        }
    }
    #endregion

    #region Methods
    #region Public
    public void movePlayer(Vector2 toPosition, float speed)
    {
        rigBody.velocity = toPosition * massToSpeed(speed);
    }

    public void shootBubble(Vector3 targetPos)
    {
        if ((rigBody.mass/2) > shootBubblePoints)
        {
            transform.DOScale((transform.localScale.x - ballGrowMult * shootBubblePoints), ballGrowDur).OnComplete(shrinkCameraSizeShoot);
            rigBody.mass -= shootBubblePoints;
            GameObject bubble = (GameObject)Instantiate(prefabBubble, transform.position, Quaternion.identity);
            bubble.GetComponent<Rigidbody2D>().AddForce(targetPos * shootSpeed, ForceMode2D.Impulse);
            bubble.GetComponent<Bubble>().BubblePoints = shootBubblePoints;
            ignoreBubble = bubble;
            StartCoroutine(clearIgnoreBubble());
        }
    }
    #endregion

    #region Private
    private float massToSpeed(float speed)
    {
        if (rigBody.mass % (massStepSlower * massToSpeedCounter) == 0)
        {
            massToSpeedCounter++;
            massToSpeedMult += setSpeedMult;
        }
        return speed / massToSpeedMult;
    }

    private void colliderInteraction(Collider2D collider)
    {
        if (collider.tag == "bubble" && collider.gameObject != ignoreBubble)
        {
            eatBubble(collider);
        }
    }

    private void eatBubble(Collider2D collider)
    {
        Bubble bubble = collider.GetComponent<Bubble>();
        rigBody.mass += bubble.BubblePoints;
        Sequence growPlayer = DOTween.Sequence().Pause().OnComplete(() => growCameraSize(bubble.BubblePoints));
        growPlayer.Insert(0,transform.DOScaleX(transform.localScale.x + ballGrowMult * bubble.BubblePoints, ballGrowDur));
        growPlayer.Insert(0,transform.DOScaleY(transform.localScale.y + ballGrowMult * bubble.BubblePoints, ballGrowDur));
        growPlayer.Restart();
        Destroy(collider.gameObject);
    }

    private void growCameraSize(float growAmount)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
        playerCamera.DOOrthoSize(playerCamera.orthographicSize + cameraOutZoomMult * growAmount, 1);
    }

    private void shrinkCameraSizeShoot()
    {
        playerCamera.DOOrthoSize(playerCamera.orthographicSize - (cameraOutZoomMult * shootBubblePoints), 1);
    }

    IEnumerator clearIgnoreBubble()
    {
        yield return new WaitForSeconds(durClearIgnBubble);
        ignoreBubble = null;
    }
    #endregion
    #endregion
}
