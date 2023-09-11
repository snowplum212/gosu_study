using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum CardType // CardType을 public으로 선언하여 각 카드의 Type을 Inspector에서 선언
{
    Heart, Spade, Diamond
}

public class Card : MonoBehaviour
{
    public CardType cardType;
    public static Dictionary<CardType, List<Card>> inventory = new Dictionary<CardType, List<Card>>(); // 머광이
    private bool isOnCard = false; // 카드가 플레이어와 콜라이딩 중인지 확인하는 bool 값
    public TMP_Text heartText;
    public TMP_Text diamondText;
    public TMP_Text spadeText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnCard)
        {
            AddCard(cardType);
        }

        /* 여기는 출력문 */
        if (!inventory.ContainsKey(CardType.Heart))
        {
            Debug.Log("하트의 수는 0개");
        }
        else
        {
            Debug.Log("하트의 수는 " + inventory[CardType.Heart].Count.ToString() + "개");
        }
        if (!inventory.ContainsKey(CardType.Spade))
        {
            Debug.Log("스페이드의 수는 0개");
        }
        else
        {
            Debug.Log("스페이드의 수는 " + inventory[CardType.Spade].Count.ToString() + "개");
        }
        if (!inventory.ContainsKey(CardType.Diamond))
        {
            Debug.Log("다이아몬드의 수는 0개");
        }
        else
        {
            Debug.Log("다이아몬드의 수는 " + inventory[CardType.Diamond].Count.ToString() + "개");
        }
    }
    private void LateUpdate()
    {
        heartText.text = "heart Card : " + inventory[CardType.Heart].Count;
        spadeText.text = "sapde Card : " + inventory[CardType.Spade].Count;
        diamondText.text = "diamond Card : " + inventory[CardType.Diamond].Count;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnCard = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnCard = false;
        }
    }
    private void AddCard(CardType type)
    {
        if (!inventory.ContainsKey(type)) // inventory에 넣으려고 할때 CardType이 딕셔너리에 없으면
        {
            inventory[type] = new List<Card>(); // type에 넣는거임
        }
        inventory[type].Add(this);
        gameObject.SetActive(false);
        isOnCard = false;
    }
}