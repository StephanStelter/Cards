//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HandController : MonoBehaviour
//{
//    public List<Card> heldCards = new List<Card>();

//    public List<Vector3> cardPositions = new List<Vector3>();



//    private void Start()
//    {
//        SetupCardPositionsInHand();
//    }



//    public void SetupCardPositionsInHand()
//    {
//        cardPositions.Clear();

//        for (int i = 0; i < heldCards.Count; i++)
//        {
//            heldCards[i].transform.position = cardPositions[i];

//            heldCards[i].inHand = true;
//            heldCards[i].handPosition = i;
//        }
//    }

//}
