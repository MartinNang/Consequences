/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static Card[] cards = new Card[3];

    public Card[] getRandomCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i] = getRandomCard();
        }
        return cards;
    }

    private Card getRandomCard()
    {
        return new Card.getRandomCard(Player);
    }

    // Start is called before the first frame update
    void Start()
    {
        getRandomCards();
    }

    // Update is called once per frame
    void Update()
    {

    }
}*/