/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;

    public static Card[] cards = new Card[3];
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;

    public GameObject card1TopIcon;
    public GameObject card2TopIcon;
    public GameObject card3TopIcon;

    public GameObject card1BottomIcon;
    public GameObject card2BottomIcon;    
    public GameObject card3BottomIcon;

    public GameObject card1TopName;
    public GameObject card2TopName;
    public GameObject card3TopName;

    public GameObject card1BottomName;
    public GameObject card2BottomName;
    public GameObject card3BottomName;

    void Start()
    {
    }

    public void showRandomCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i] = getRandomCard();         
        }

        // display UI card elements 
        card1.SetActive(true);
        card2.SetActive(true);
        card3.SetActive(true);


        // load top icons
        card1TopIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>(cards[0].getPositiveCardEffect().getIconPath());
        card1TopIcon.SetActive(true);
        card2TopIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>(cards[1].getPositiveCardEffect().getIconPath());
        card2TopIcon.SetActive(true);
        card3TopIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>(cards[2].getPositiveCardEffect().getIconPath());
        card3TopIcon.SetActive(true);

        // load top names
        /*card1TopName.SetActive(true);
        card2TopName.SetActive(true);
        card3TopName.SetActive(true);*/

        // load bottom icons
        /*card1BottomIcon.SetActive(true);
        card2BottomIcon.SetActive(true);
        card3BottomIcon.SetActive(true);*/

        // load bottom names
        /*card1BottomName.SetActive(true);
        card2BottomName.SetActive(true);
        card3BottomName.SetActive(true);*/
    /*}

    public static Card getRandomCard()
    {
        // get positive card effect
        // create copy of all positive card effects array
        List<CardEffect> validPositiveCardEffects = new List<CardEffect>();
        validPositiveCardEffects.AddRange(Card.allPositiveCardEffects);

        // filter out card effects that are invalid for current player state
        validPositiveCardEffects.RemoveAll(cardEffect => (cardEffect.getName().Equals("Melee") && PlayerStatus.hasMelee)
                                                    || (cardEffect.getName().Equals("Long Range") && PlayerStatus.hasLongRange)
                                                    || (cardEffect.getName().Equals("x-Axis") && PlayerStatus.hasXAxis)
                                                    || (cardEffect.getName().Equals("y-Axis") && PlayerStatus.hasYAxis)
                                                    || (cardEffect.getName().Equals("Dash") && PlayerStatus.hasDash)
                                                        );

        // randomly draw valid card effect
        var random = new System.Random();
        int index = random.Next(0, validPositiveCardEffects.Count);
        CardEffect randomValidPositiveCardEffect = validPositiveCardEffects[index];

        // get negative card effect
        // create copy of all negative card effects array
        List<CardEffect> validNegativeCardEffects = new List<CardEffect>();
        validNegativeCardEffects.AddRange(Card.allNegativeCardEffects);

        // filter out card effects that are invalid for current player state
        validNegativeCardEffects.RemoveAll(cardEffect => (cardEffect.getName().Equals("Melee") && !PlayerStatus.hasMelee)
                                                    || (cardEffect.getName().Equals("Long Range") && !PlayerStatus.hasLongRange)
                                                    || (cardEffect.getName().Equals("x-Axis") && !PlayerStatus.hasXAxis)
                                                    || (cardEffect.getName().Equals("y-Axis") && !PlayerStatus.hasYAxis)
                                                    || (cardEffect.getName().Equals("Dash") && !PlayerStatus.hasDash)
                                                        );

        // randomly draw valid card effect
        index = random.Next(0, validNegativeCardEffects.Count);
        CardEffect randomValidNegativeCardEffect = validNegativeCardEffects[index];
        Debug.Log("positive: " + randomValidPositiveCardEffect);
        Debug.Log("negative: " + randomValidNegativeCardEffect);

        // create random card
        Card randomCard = new Card(randomValidPositiveCardEffect, randomValidNegativeCardEffect);

        return randomCard;

    }

    // Update is called once per frame
    void Update()
    {

    }
}*/