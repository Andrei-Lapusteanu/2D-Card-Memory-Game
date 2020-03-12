using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    private SpriteRenderer sr;
    private static List<int> possiblePair = new List<int>();
    private static List<int> clickedCards = new List<int>();
    private int pressedCardNo;
    public static bool isWaiting = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (!isWaiting)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;

            sr = this.GetComponent<SpriteRenderer>();

            pressedCardNo = int.Parse(name.Split("(".ToCharArray())[0]);
            sr.sprite = CreateGame.SpriteList[CreateGame.Pairs[pressedCardNo]];

            clickedCards.Add(pressedCardNo);
            possiblePair.Add(CreateGame.Pairs[pressedCardNo]);

            if (possiblePair.Count == 2)
                CheckMatch();
        }
    }

    private void CheckMatch()
    {
        if (possiblePair.Count == 2 && possiblePair[0] == possiblePair[1])
        {
            Debug.Log("Match!");
            Stats.IncreaseScoreAndTries();
            ClearLists();
        }
        else
        {
            Debug.Log("Try again");
            Stats.IncreaseTries();
            StartCoroutine(ResetPair());
        }
    }

    private IEnumerator ResetPair()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1);

        for (int i = 0; i < clickedCards.Count; i++)
        {
            var cardObj = GameObject.Find(clickedCards[i] + "(Clone)");
            cardObj.GetComponent<BoxCollider2D>().enabled = true;
            sr = cardObj.GetComponent<SpriteRenderer>();
            sr.sprite = CreateGame.SpriteList[54];
        }
        ClearLists();

        isWaiting = false;
    }

    private void ClearLists()
    {
        possiblePair.Clear();
        clickedCards.Clear();
    }
}
