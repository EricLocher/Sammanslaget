using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Essentials;

namespace Drop
{
    public class Deposit : DropPoint
    {
        [SerializeField] ArticleType type;

        public override void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.GetComponent<ArticleHolder>().data.type == type) {
                Destroy(eventData.pointerDrag);
            }
        }

    }
}

