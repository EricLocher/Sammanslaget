using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArticleHolder : DragItem
{
    public Clothing data;

    private void Start()
    {
        GetComponent<Image>().sprite = data.sprite;
    }

}