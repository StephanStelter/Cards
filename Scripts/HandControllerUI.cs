using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControllerUI : MonoBehaviour
{
    public static HandControllerUI Instance { get;  set; }

    public List<CardUI> cards = new List<CardUI>();
    public List<CardActionInHand> heldCardsInHandAction = new List<CardActionInHand>();

    private void Awake()
    {
        // Stellen Sie sicher, dass nur eine Instanz existiert
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Eine Instanz existiert bereits, diese sollte zerstört werden
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetupCardPositionsInHand();
    }

    public void SetupCardPositionsInHand()
    {
        //cards.Clear();
        //heldCardsMouseAction.Clear();

        for (int i = 0; i < heldCardsInHandAction.Count; i++)
        {
            heldCardsInHandAction[i].inHand = true;
            heldCardsInHandAction[i].handPosition = i;
        }
    }

    public void RemoveCard(int cardToRemove)
    {
        //Debug.Log(cardToRemove);
     
        heldCardsInHandAction.RemoveAt(cardToRemove);

    }
}
