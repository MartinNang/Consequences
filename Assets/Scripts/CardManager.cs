using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;

    public static Card[] cards = new Card[3];
    public GameObject card1GameObject, card2GameObject, card3GameObject;

    public GameObject card1TopIcon, card2TopIcon, card3TopIcon;

    public GameObject card1BottomIcon, card2BottomIcon, card3BottomIcon;

    public GameObject card1TopName, card2TopName, card3TopName;

    public GameObject card1BottomName, card2BottomName, card3BottomName;

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
        showCards();

        // load top icons
        card1TopIcon.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(cards[0].getPositiveCardEffect().getIconPath());
        card2TopIcon.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(cards[1].getPositiveCardEffect().getIconPath());
        card3TopIcon.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(cards[2].getPositiveCardEffect().getIconPath());

        // load top names
        card1TopName.GetComponent<TextMeshProUGUI>().text = cards[0].getPositiveCardEffect().getName();
        card2TopName.GetComponent<TextMeshProUGUI>().text = cards[1].getPositiveCardEffect().getName();
        card3TopName.GetComponent<TextMeshProUGUI>().text = cards[2].getPositiveCardEffect().getName();

        // load bottom icons
        card1BottomIcon.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(cards[0].getNegativeCardEffect().getIconPath());
        card2BottomIcon.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(cards[1].getNegativeCardEffect().getIconPath());
        card3BottomIcon.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(cards[2].getNegativeCardEffect().getIconPath());

        // load bottom names
        card1BottomName.GetComponent<TextMeshProUGUI>().text = cards[0].getNegativeCardEffect().getName();
        card2BottomName.GetComponent<TextMeshProUGUI>().text = cards[1].getNegativeCardEffect().getName();
        card3BottomName.GetComponent<TextMeshProUGUI>().text = cards[2].getNegativeCardEffect().getName();
    }

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
        validNegativeCardEffects.RemoveAll(cardEffect => (cardEffect.getName().Equals(randomValidPositiveCardEffect.getName()))
                                                    || (cardEffect.getName().Equals("Max HP+") && randomValidPositiveCardEffect.getName().Equals("Max HP-"))
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

    public void SelectCard(int cardIndex)
    {
        Card selectedCard = cards[cardIndex];
        switch (selectedCard.getPositiveCardEffect().getName())
        {
            case "Max HP+":
                PlayerDamage.playerMaxHP += PlayerDamage.playerMaxHPIncrease;
                break;
            case "Long Range":
                PlayerStatus.hasLongRange = true;
                break;
            case "x-Axis":
                PlayerStatus.hasXAxis = true;
                break;
            case "y-Axis":
                PlayerStatus.hasYAxis = true;                
                break;
            case "Dash":
                PlayerStatus.hasDash = true;
                break;
        }
        switch (selectedCard.getNegativeCardEffect().getName())
        {
            case "Max HP-":
                PlayerDamage.playerMaxHP -= PlayerDamage.playerMaxHPIncrease;
                break;
            case "Long Range":
                PlayerStatus.hasLongRange = false;
                break;
            case "x-Axis":
                PlayerStatus.hasXAxis = false;
                break;
            case "y-Axis":
                PlayerStatus.hasYAxis = false;
                break;
            case "Dash":
                PlayerStatus.hasDash = false;
                break;
        }
        GameManager.destinityChosen = true;
        hideCards();
    }

    private void showCards()
    {
        card1GameObject.SetActive(true);
        card2GameObject.SetActive(true);
        card3GameObject.SetActive(true);
    }
    private void hideCards()
    {
        card1GameObject.SetActive(false);
        card2GameObject.SetActive(false);
        card3GameObject.SetActive(false);
    }
}

