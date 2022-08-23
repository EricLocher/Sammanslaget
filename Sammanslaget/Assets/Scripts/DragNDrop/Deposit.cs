using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Drop
{
    public class Deposit : DropPoint
    {
        [SerializeField] ClothingType type;

        public override void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.GetComponent<ArticleHolder>().data.clothingType == type) {
                Destroy(eventData.pointerDrag);
            }
        }

    }
}

