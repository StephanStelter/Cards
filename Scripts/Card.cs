//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using Microsoft.Unity.VisualStudio.Editor;

//public class Card : MonoBehaviour
//{
//    public CardScriptableObject cardSO;

//    public int cardLevel, costWood, costWool, costMetal, costStone, costGold, costPreciousMetal;

//    //public TMP_Text cardLevelText, cardTypeText, cardNameText, cardDiscriptionText, costWoodText, costWoolText, costMetalText, costStoneText, costGoldText, costPreciousMetalText, costText, effectText;

//    //public Sprite bgSprite, pictureSprite, woodSprite, woolSprite, metalSprite, stoneSprite, goldSprite, presiousMetalSprite;

//    //public Image effectSprite, costSprite;



//    //Card Position
//    private Vector3 targetPoint;
//    public float moveSpeed = 15f, rotateSpeed = 540f;
//    private Quaternion targetRotation;

//    public bool inHand;
//    public int handPosition;

//    private HandController handController;

//    private bool isSelected;
//    private Collider cardCollider;

//    public LayerMask cardMask, whatIsPlacement;
//    private bool justPressed;

//    public CardPlacePoint assignedPlace;




//    private void Start()
//    {
//        handController = FindObjectOfType<HandController>();

//        cardCollider = GetComponent<Collider>();

//        SetupCard();
//    }



//    public void SetupCard()
//    {
//        costWood = cardSO.costWood;
//        costWool = cardSO.costWool;
//        costMetal = cardSO.costMetal;
//        costStone = cardSO.costStone;
//        costGold = cardSO.costGold;
//        costPreciousMetal = cardSO.costPreciousMetal;

//        //costWoodText.text = costWood.ToString();
//        //costWoolText.text = costWool.ToString();
//        //costMetalText.text = costMetal.ToString();
//        //costStoneText.text = costStone.ToString();
//        //costGoldText.text = costGold.ToString();
//        //costPreciousMetalText.text = costPreciousMetal.ToString();

//        //cardTypeText.text = cardSO.cardType;
//        //cardNameText.text = cardSO.cardName;
//        //cardDiscriptionText.text = cardSO.cardDiscription;
//        //cardLevelText.text = "Level: " + cardSO.cardLevel.ToString();
//        //effectText.text = cardSO.effectString.ToString();
//    }


//    //HandController------Mouse------

//    private void Update()
//    {
//        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);
//        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

//        //if (isSelected)
//        //{
//        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//        //    RaycastHit hit;
//        //    if (Physics.Raycast(ray, out hit, 1000f))
//        //    {
//        //        MoveToPoint(hit.point + new Vector3(0f, 2f, 0f), Quaternion.identity);
//        //    }

//        //    if (Input.GetMouseButtonDown(1))
//        //    {
//        //        ReturnToHand();
//        //    }

//        //    if (Input.GetMouseButtonDown(0) && !justPressed)
//        //    {
//        //        if (Physics.Raycast(ray, out hit, 1000f, whatIsPlacement))
//        //        {
//        //            CardPlacePoint selectedPoint = hit.collider.GetComponent<CardPlacePoint>();

//        //            if (selectedPoint.activeCard == null && selectedPoint.isPlayerPoint)
//        //            {
//        //                selectedPoint.activeCard = this;
//        //                assignedPlace = selectedPoint;

//        //                MoveToPoint(selectedPoint.transform.position, Quaternion.identity);

//        //                inHand = false;
//        //                isSelected = false;
//        //            }
//        //            else
//        //            {
//        //                ReturnToHand();
//        //            }
//        //        }
//        //        else
//        //        {
//        //            ReturnToHand();
//        //        }
//        //    }
//        //}

//        //justPressed = false;

       
//    }

//    public void MoveToPoint(Vector3 pointToMoveTo, Quaternion rotationToMatch)
//    {
//        targetPoint = pointToMoveTo;
//        targetRotation = rotationToMatch;
//    }

//    private void OnMouseOver()
//    {
//        if (inHand)
//        {
//            MoveToPoint(handController.cardPositions[handPosition] + new Vector3(0f, 5f, -5f), Quaternion.identity);
//        }
//    }

//    private void OnMouseExit()
//    {
//        if (inHand)
//        {
//            MoveToPoint(handController.cardPositions[handPosition], handController.minPos.rotation);
//        }
//    }

//    private void OnMouseDown()
//    {
//        if (inHand)
//        {
//            isSelected = true;
//            cardCollider.enabled = false;

//            justPressed = true;
//        }
//    }

//    public void ReturnToHand()
//    {
//        isSelected = false;
//        cardCollider.enabled = true;


//        MoveToPoint(handController.cardPositions[handPosition], handController.minPos.rotation);
//    }
//}
