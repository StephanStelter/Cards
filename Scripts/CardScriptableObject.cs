using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card", order = 1)]
public class CardScriptableObject : ScriptableObject
{
    public string cardType;
    public string cardName;
    [TextArea]
    public string cardDiscription;   
    public string effectString;   

    public int cardLevel, costWood, costWool, costMetal, costStone, costGold, costPreciousMetal;

    public Sprite bgSprite, pictureSprite, woodSprite, woolSprite, metalSprite, stoneSprite, goldSprite, presiousMetalSprite;


}
