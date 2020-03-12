using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGame : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject gicu;
    public static int[] Pairs = new int[16];
    public static Sprite[] SpriteList;
    private int pairsIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpriteList = Resources.LoadAll<Sprite>("cards");
        GenerateCards();
        DrawCards();
    }

    private void GenerateCards()
    {
        HashSet<int> cardNumers = new HashSet<int>();
        HashSet<int> pairOrder = new HashSet<int>();
        List<int> cardNumberList = new List<int>();
        List<int> pairOrderList = new List<int>();

        do
        {
            int rand = Random.Range(0, 52);
            if (!cardNumberList.Contains(rand))
                cardNumberList.Add(rand);
        }
        while (cardNumberList.Count < 8);

        do
        {
            int rand = Random.Range(0, 16);
            if (!pairOrderList.Contains(rand))
                pairOrderList.Add(rand);
        }
        while (pairOrderList.Count < 16);

        for (int i = 0; i < Pairs.Length; i++)
            Pairs[pairOrderList.IndexOf(i)] = cardNumberList[i / 2];
    }

    private void DrawCards()
    {
        SpriteRenderer sr = myPrefab.GetComponent<SpriteRenderer>();

        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                sr.sprite = SpriteList[54];
                myPrefab.name = (pairsIndex++).ToString();
                Instantiate(myPrefab, new Vector3(i * 1.5f - 2.25f, j * 2f - 3, 0), Quaternion.identity);
                myPrefab.transform.localScale = new Vector3(1.5f, 1.5f);
            }
    }
}
