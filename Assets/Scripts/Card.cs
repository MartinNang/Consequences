using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardEffect positiveEffect, negativeEffect;

    public static CardEffect[] allPositiveCardEffects =
    {
        new CardEffect(CardEffectType.POSITIVE, "Melee Boost", "",)
    }

    public static CardEffect[] allNegativeCardEffects =
    {
        new CardEffect(CardEffectType.NEGATIVE, "Melee Loss", "",)
    }

    public Card (CardEffect positiveEffect, CardEffect negativeEffect)
    {
        if ((positiveEffect.type != CardEffectType.POSITIVE || negativeEffect.type != CardEffectType.NEGATIVE))            
        {
            throw new System.Exception("Incorrect usage: effects must be of different type.");
        }
        if (positiveEffect == null || negativeEffect == null)
        {
            throw new System.Exception("Incorrect usage: effects cannot be null");
        }

            this.positiveEffect = positiveEffect;
            this.negativeEffect = negativeEffect;    
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Destiny Cards_0");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public CardEffect getPositiveCardEffect()
    {
        return positiveEffect;
    }

    public void setPositiveCardEffect(CardEffect effect)
    {
        positiveEffect = effect;
    }

    public CardEffect getNegativeCardEffect()
    {
        return negativeEffect;
    }
    public void setNegativeCardEffect(CardEffect effect)
    {
        negativeEffect = effect;
    }
}

public class CardEffect
{
    public CardEffectType type;
    public string name;
    public string description;
    public string iconPath;
    public

    public CardEffect(CardEffectType type, string name, string description, string iconPath)
    {
        this.type = type;
        this.name = name;
        this.description = description;
        this.iconPath = iconPath;
    }

    public void setType(CardEffectType type)
    {
       this.type = type;
    }
    public CardEffectType getType()
    {
        return this.type;
    }
    public void setName(string name)
    {
        this.name = name;
    }
    public string getName()
    {
        return this.name;
    }
    public void setDescription(string description)
    {
        this.description = description;
    }
    public string getDescription()
    {
        return this.description;
    }

    public void setIconPath(string iconPath)
    {
        this.iconPath=iconPath;
    }

    public string getIconPath()
    {
        return this.iconPath;
    }
}

public enum CardEffectType
{
    POSITIVE,
    NEGATIVE
}

public enum CardEffectName
{

}