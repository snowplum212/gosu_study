using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum CardType // CardType�� public���� �����Ͽ� �� ī���� Type�� Inspector���� ����
{
    Heart, Spade, Diamond
}

public class Card : MonoBehaviour
{
    public CardType cardType;
    public static Dictionary<CardType, List<Card>> inventory = new Dictionary<CardType, List<Card>>(); // �ӱ���
    private bool isOnCard = false; // ī�尡 �÷��̾�� �ݶ��̵� ������ Ȯ���ϴ� bool ��
    public TMP_Text heartText;
    public TMP_Text diamondText;
    public TMP_Text spadeText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnCard)
        {
            AddCard(cardType);
        }

        /* ����� ��¹� */
        if (!inventory.ContainsKey(CardType.Heart))
        {
            Debug.Log("��Ʈ�� ���� 0��");
        }
        else
        {
            Debug.Log("��Ʈ�� ���� " + inventory[CardType.Heart].Count.ToString() + "��");
        }
        if (!inventory.ContainsKey(CardType.Spade))
        {
            Debug.Log("�����̵��� ���� 0��");
        }
        else
        {
            Debug.Log("�����̵��� ���� " + inventory[CardType.Spade].Count.ToString() + "��");
        }
        if (!inventory.ContainsKey(CardType.Diamond))
        {
            Debug.Log("���̾Ƹ���� ���� 0��");
        }
        else
        {
            Debug.Log("���̾Ƹ���� ���� " + inventory[CardType.Diamond].Count.ToString() + "��");
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
        if (!inventory.ContainsKey(type)) // inventory�� �������� �Ҷ� CardType�� ��ųʸ��� ������
        {
            inventory[type] = new List<Card>(); // type�� �ִ°���
        }
        inventory[type].Add(this);
        gameObject.SetActive(false);
        isOnCard = false;
    }
}