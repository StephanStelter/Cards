using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardActionInHand : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool inHand;
    public int handPosition;
    public float moveSpeed;

    public Vector3 cardPosition;
    public Vector3 cardPositionHover;
    public float hoverYPosition;
    public bool hover;

    public bool isMoving;
    private float journeyLength;
    private float startTime;
    private bool gotPosition;
    public bool moveUp;
    public bool cardInSlot;

    private HandControllerUI handControllerUI;
    private CardOnMousePointer cardOnMousePointer;

    public bool isSelected;
    public BoxCollider2D cardCollider;

    public CardPlacePoint assignedPlace;



    void Start()
    {
        cardPositionHover = new Vector3(0f, 200f, 0f);
        hoverYPosition = 200f;
        hover = false;
        isMoving = false;
        gotPosition = false;
        moveUp = false;
        cardInSlot = false;

        handControllerUI = FindObjectOfType<HandControllerUI>();
        cardOnMousePointer = FindObjectOfType<CardOnMousePointer>();

        cardCollider = GetComponent<BoxCollider2D>();

        StartCoroutine(GetCardPosition());

        journeyLength = Vector3.Distance(cardPosition, cardPosition + cardPositionHover);

        moveSpeed = 500f;
    }

    // Update is called once per frame
    void Update()
    {
        //Card moves up
        if (isMoving && gotPosition && moveUp && cardOnMousePointer.isSelected == false && !cardInSlot)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float journeyFraction = distanceCovered / journeyLength;

            float newY = Mathf.MoveTowards(transform.position.y, cardPosition.y + hoverYPosition, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Wenn die Karte die Ziel-Y-Position erreicht hat, setze isMoving auf false
            if (Mathf.Approximately(transform.position.y, cardPosition.y + hoverYPosition))
            {
                isMoving = false;
            }
        }

        //Card moves down
        if (isMoving && gotPosition && !moveUp && cardOnMousePointer.isSelected == false && !cardInSlot)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float journeyFraction = distanceCovered / journeyLength;

            float newY = Mathf.MoveTowards(transform.position.y, cardPosition.y, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Wenn die Karte die Ziel-Y-Position erreicht hat, setze isMoving auf false
            if (Mathf.Approximately(transform.position.y, cardPosition.y))
            {
                isMoving = false;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inHand && !hover && !cardInSlot)
        {
            // Starte die Bewegung und speichere die Startzeit, wenn die Maus über dem Objekt schwebt
            hover = true;
            isMoving = true;
            startTime = Time.time;
            moveUp = true;
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (inHand && hover && cardOnMousePointer.isSelected == false && !cardInSlot)
        {
            // Beende die Bewegung und setze isMoving auf false, wenn die Maus das Objekt verlässt
            if (!isMoving)
            {
                StartCoroutine(OnPoiterExitCo());
            }
        }
    }

    private IEnumerator OnPoiterExitCo()
    {
        yield return new WaitForSeconds(1f);

        hover = false;
        isMoving = true;
        startTime = Time.time;
        moveUp = false;
    }

    private IEnumerator GetCardPosition()
    {
        yield return new WaitForSeconds(0f);
        cardPosition = transform.position;
        gotPosition = true;
    }

}
