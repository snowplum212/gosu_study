using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum CardType // CardType�� public���� �����Ͽ� �� ī���� Type�� Inspector���� ����
{
    Heart, Spade, Diamond
}

public class Card : MonoBehaviour
{
    public CardType cardType;
    public Dictionary<CardType, List<Card>> inventory = new Dictionary<CardType, List<Card>>(); // �ӱ���
    private bool isOnCard = false; // ī�尡 �÷��̾�� �ݶ��̵� ������ Ȯ���ϴ� bool ��

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

        Debug.Log("�迭���� " + type.ToString() + "�� ���� " + inventory[type].Count);
    }
}