using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardOnMousePointer : MonoBehaviour, IPointerClickHandler
{
    private GameObject CardOnMousePointerObject;
    private Transform cardParent;
    private Transform cardFrameParent;
    private GameObject selectedCard;
    private Vector3 offset;
    public bool isSelected;
    private bool isConfirmationPending;

    public LayerMask cardFrame;

    private CardActionInHand cardActionInHand;
    public CardPlacePoint assignedPlace;
    public float scaleFactor;

    CardPlacePoint selectedPoint;


    //private HandControllerUI handControllerUI;

    private void Start()
    {
        CardOnMousePointerObject = null;
        scaleFactor = .3f;
        isSelected = false;
        selectedCard = null;
        cardParent = null;
        cardFrameParent = null;
        isConfirmationPending = false;

        cardActionInHand = GetComponent<CardActionInHand>();

        CardOnMousePointerObject = GameObject.Find("Card on Mouse Pointer"); // Passen Sie den Namen des Mouse Pointer-Objekts an.      
    }

    private void FixedUpdate()
    {
        if (isSelected && selectedCard != null && cardActionInHand.cardInSlot == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, cardFrame) && hit.collider != null)
            {
                selectedPoint = hit.collider.GetComponent<CardPlacePoint>();
                Debug.Log(selectedPoint);

                if (selectedPoint != null && selectedPoint.activeCard == null)
                {
                    if (!selectedPoint.isBlocked && isConfirmationPending)
                    {
                        // Setzen Sie das Elternobjekt der Karte auf das gewünschte Ziel.
                        SetParent(selectedCard.transform, selectedPoint.transform);

                        selectedPoint.activeCard = this;
                        selectedPoint.isBlocked = true;
                        assignedPlace = selectedPoint;

                        SlotedCard();

                        Reset();
                    }
                }
            }
        }
    }
    //Karte an Mauszeiger
    public void OnPointerClick(PointerEventData eventData)
    {
        if (cardActionInHand.cardInSlot == false)
        {
            if (eventData.button == PointerEventData.InputButton.Left && !isSelected)
            {
                    selectedCard = gameObject; // Das ausgewählte UI-Element aus dem Horzontal Layout (Hand).

                    cardParent = selectedCard.transform.parent;

                    // Berechnen Sie den Versatz, um den Klickpunkt auf der Karte zu berücksichtigen.
                    Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    offset = selectedCard.transform.position - clickPosition;

                    // Verschieben Sie die Karte zum Mouse Pointer.
                    selectedCard.transform.SetParent(CardOnMousePointerObject.transform, false);

                    //Bewegung mit Maus
                    transform.position = CardOnMousePointerObject.transform.position;

                    isSelected = true;

                    cardActionInHand.inHand = false;
                    cardActionInHand.hover = false;
                    cardActionInHand.isMoving = false;
                    cardActionInHand.moveUp = false;
            }

            else if (eventData.button == PointerEventData.InputButton.Left && isSelected && selectedPoint.isBlocked == false)
            {
                if (!isConfirmationPending)
                {
                    // Wenn bereits eine Auswahl getroffen wurde, ist ein erneuter Linksklick eine Bestätigung.
                    isConfirmationPending = true;
                }

                else
                {
                    // Hier können Sie die Logik für die Bestätigung und das Ändern des Elternobjekts einfügen.
                    if (selectedPoint != null)
                    {
                        // Setzen Sie das Elternobjekt der Karte auf das gewünschte Ziel.
                        SetParent(selectedCard.transform, selectedPoint.transform);

                        selectedPoint.activeCard = this;
                        selectedPoint.isBlocked = true;
                        assignedPlace = selectedPoint;
                        Debug.Log("Bestätigt und platziert");

                        SlotedCard();

                        Reset();
                    }

                    isConfirmationPending = false; // Setzen Sie die Bestätigung zurück.
                }
            }
        }
        //Karte zurück auf Hand
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (isSelected)
            {
                isSelected = false;

                selectedCard.transform.SetParent(cardParent, false);

                cardActionInHand.inHand = true;
            }
        }
    }

    private void SlotedCard()
    {
        NewPosition();

        ScaleCard();

        int handposition = cardActionInHand.handPosition;
        HandControllerUI.Instance.RemoveCard(handposition);

        cardActionInHand.cardInSlot = true;
        Debug.Log(cardActionInHand.cardInSlot);

        isSelected = false;

        selectedPoint.activeCard = null;
    }

    private void NewPosition()
    {
        transform.localPosition = Vector3.zero;
        selectedCard.transform.localRotation = Quaternion.identity;
    }

    private void ScaleCard()
    {
        selectedCard.transform.localScale *= scaleFactor;
    }

    private void Reset()
    {
        isSelected = false;
        selectedCard = null;
        cardParent = null;
        cardFrameParent = null;
        isConfirmationPending = false;
    }

    // Eine Hilfsmethode, um das Elternobjekt zu setzen und das ursprüngliche Parent-Objekt zu entfernen.
    private void SetParent(Transform child, Transform newParent)
    {
        child.SetParent(newParent, true);
    }
}
