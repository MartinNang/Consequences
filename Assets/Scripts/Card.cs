using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardEffect positiveEffect, negativeEffect;

    // DO NOT CHANGE NAME IF NOT ABSOLUTELY NECESSARY
    public static CardEffect[] allPositiveCardEffects =
    {
        new CardEffect(CardEffectType.POSITIVE, "Max HP+", "Permanently adds Max HP to your Healthbar.", "Sprites/DestinyCards_13"),
        new CardEffect(CardEffectType.POSITIVE, "Melee", "Gain the ability to engage in close combat.", "Sprites/DestinyCards_12"),
        new CardEffect(CardEffectType.POSITIVE, "Long Range", "Gain the abilty to fire at enemies.", "Sprites/DestinyCards_2"),
        new CardEffect(CardEffectType.POSITIVE, "x-Axis", "Gain the ability to move horizontally.", "Sprites/DestinyCards_9"),
        new CardEffect(CardEffectType.POSITIVE, "y-Axis", "Gain the ability to move vertically.", "Sprites/DestinyCards_7"),
        new CardEffect(CardEffectType.POSITIVE, "HP-Regeneration", "Heal HP Damage per second.", "Sprites/DestinyCards_13"),
        new CardEffect(CardEffectType.POSITIVE, "Dash", "Gain the ability to dash.", "Sprites/DestinyCards_3")
    };

    public static CardEffect[] allNegativeCardEffects =
    {
        new CardEffect(CardEffectType.NEGATIVE, "Max HP-", "Permanently subtracts Max HP to your Healthbar.", "Sprites/DestinyCards_13"),
        new CardEffect(CardEffectType.NEGATIVE, "Melee", "Lose the ability to engage in close combat.", "Sprites/DestinyCards_12"),
        new CardEffect(CardEffectType.NEGATIVE, "Long Range", "Lose the abilty to fire at enemies.", "Sprites/DestinyCards_2"),
        new CardEffect(CardEffectType.NEGATIVE, "x-Axis", "Lose the ability to move horizontally.", "Sprites/DestinyCards_9"),
        new CardEffect(CardEffectType.NEGATIVE, "y-Axis", "Lose the ability to move vertically.", "Sprites/DestinyCards_7"),
        new CardEffect(CardEffectType.NEGATIVE, "HP-Degeneration", "Take HP Damage per second.", "Sprites/DestinyCards_13"),
        new CardEffect(CardEffectType.NEGATIVE, "Dash", "Lose the ability to dash.", "Sprites/DestinyCards_3")
    };

    public Card (CardEffect positiveEffect, CardEffect negativeEffect)
    {
        if (positiveEffect == null || negativeEffect == null)
        {
            throw new System.Exception("Incorrect usage: effects cannot be null");
        }
        if ((positiveEffect.type != CardEffectType.POSITIVE || negativeEffect.type != CardEffectType.NEGATIVE))            
        {
            throw new System.Exception("Incorrect usage: effects must be of different type.");
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

    CardEffect(CardEffectType type, string name, string description, string iconPath)
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