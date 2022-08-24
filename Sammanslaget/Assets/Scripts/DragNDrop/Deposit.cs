using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Drop
{
    public class Deposit : DropPoint, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] ClothingType type;
        Image image;

        void Awake()
        {
            image = GetComponent<Image>();
            image.color = new Color(1, 1, 1, 0);
        }

        public override void OnDrop(PointerEventData eventData)
        {
            Clothing data = eventData.pointerDrag.GetComponent<ArticleHolder>().data;
            Destroy(eventData.pointerDrag.gameObject);

            if(data.clothingType == type) {
                if(type == ClothingType.Trend && data.trendType != TrendChanger.GetTrend) {
                    GameStats.RemoveHealth();
                    return;
                }

                GameStats.AddPoint();
                return;
            }
 

            GameStats.RemoveHealth();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) { return; }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }
    }
}

