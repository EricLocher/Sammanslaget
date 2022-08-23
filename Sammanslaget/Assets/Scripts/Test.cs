using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<Article> testArt;

    public Article randomArt()
    {
        return testArt[Random.Range(0, testArt.Count)];
    }
}
