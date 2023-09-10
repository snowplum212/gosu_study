using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum CardType // CardType을 public으로 선언하여 각 카드의 Type을 Inspector에서 선언
{
    Heart, Spade, Diamond
}

public class Card : MonoBehaviour
{
    public CardType cardType;
    public Dictionary<CardType, List<Card>> inventory = new Dictionary<CardType, List<Card>>(); // 머광이
    private bool isOnCard = false; // 카드가 플레이어와 콜라이딩 중인지 확인하는 bool 값

    void Update()
    {
        Debug.Log(isOnCard);

        if (Input.GetKeyDown(KeyCode.Space) && isOnCard)
        {
            AddCard(cardType);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnCard = true;
        }
    }
    private void AddCard(CardType type)
    {
        if (!inventory.ContainsKey(type))
        {
            inventory[type] = new List<Card>();
        }
        inventory[type].Add(this);
        isOnCard = false;

        Debug.Log("배열안의 " + type.ToString() + "의 수는 " + inventory[type].Count);
    }
}