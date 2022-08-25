using UnityEngine;
using UnityEngine.UI;

public class QueueAmountCounter : MonoBehaviour
{
    Slider queueAmount;
    [SerializeField] ArticleQueue articleQueue;

    [SerializeField] private int maxAmountQueuedClothing;

    private void Start()
    {
        queueAmount = GetComponent<Slider>();
    }

    private void Update()
    {
        SetQueueAmountCounterBar();
        CheckMaxAmount();
    }

    private void SetQueueAmountCounterBar()
    {
        float barPercentage = (float)articleQueue.GetCount() / (float)maxAmountQueuedClothing;
        queueAmount.value = barPercentage;
    }

    private void CheckMaxAmount()
    {
        if (queueAmount.value >= 1)
        {
            GameStats.RemoveHealth();
            articleQueue.ClearQueue();
        }
    } 
}
