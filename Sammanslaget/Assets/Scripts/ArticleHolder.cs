using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Essentials;
using UnityEngine.UI;

public class ArticleHolder : DragItem
{
    public Article data;

    private void Start()
    {
        GetComponent<Image>().sprite = data.image;
    }

}