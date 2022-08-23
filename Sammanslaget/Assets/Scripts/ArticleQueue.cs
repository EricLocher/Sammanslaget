using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArticleQueue : MonoBehaviour
{
    [SerializeField] public GameObject dragPrefab;
    [SerializeField] int maxShowAmount;

    Queue<Clothing> articles;


    private void Awake()
    {
        articles = new Queue<Clothing>();
        AddArticle();

        StartCoroutine(TestRoutine());
    }

    public void GetArticle()
    {
  
    }

    public void AddArticle()
    {
        articles.Enqueue(ClothingFactory.GetRandomclothing());
        if(transform.childCount < maxShowAmount) {
            UpdateQueue();
        }
    }

    private void UpdateQueue()
    {
        GameObject temp = Instantiate(dragPrefab, transform);
        temp.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        temp.GetComponent<ArticleHolder>().data = articles.Dequeue();
        temp.transform.SetSiblingIndex(0);

    }

    IEnumerator TestRoutine()
    {
        yield return new WaitForSeconds(3);
        AddArticle();
        StartCoroutine(TestRoutine());
    }
}
