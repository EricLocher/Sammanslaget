using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArticleQueue : MonoBehaviour
{
    [SerializeField] public ArticleHolder dragPrefab;
    [SerializeField] int maxShowAmount;

    public int GetCount() { return visableArticles.Count + articles.Count; }

    List<ArticleHolder> visableArticles;
    Queue<Clothing> articles;

    void Awake()
    {
        articles = new Queue<Clothing>();
        visableArticles = new List<ArticleHolder>();
        AddArticle();
    }

    void Update()
    {
        for (int i = 0; i < visableArticles.Count; i++) {
            visableArticles[i].SetDragActive((i == 0));
            if(visableArticles[i] == null) { visableArticles.RemoveAt(i); i--; }
        }

        if (visableArticles.Count < maxShowAmount) {
            AddVisableArticle();
        }
    }

    public void AddArticle()
    {
        articles.Enqueue(ClothingFactory.GetRandomclothing());
    }

    private void AddVisableArticle()
    {
        if(articles.Count == 0) { return; }
        ArticleHolder article = Instantiate(dragPrefab, transform);
        article.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        article.GetComponent<ArticleHolder>().data = articles.Dequeue();
        article.transform.SetSiblingIndex(0);

        visableArticles.Add(article);
    }

}
