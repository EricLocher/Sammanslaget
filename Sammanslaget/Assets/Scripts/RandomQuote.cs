using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomQuote : MonoBehaviour
{
    [SerializeField] List<string> quotes;
    TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        NewQuote();
    }

    public void NewQuote()
    {
        string quote = quotes[Random.Range(0, quotes.Count)];

        if (quote == text.text) { NewQuote(); return; }

        text.text = quote;
    }
}
