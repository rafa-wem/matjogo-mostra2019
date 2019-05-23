using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Window_Graph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        // CreateCircle(new Vector2(200, 200));
        List<int> valueList = new List<int> { 5 ,2, 3, 15, 1, 2, 13, 8, 2, 98, 99, 12};
        showGraph(valueList);
    }

    private void CreateCircle (Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11,11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    private void showGraph(List<int> valueList)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 100f;
        float xSize = 50f;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = 20f + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            CreateCircle(new Vector2(xPosition, yPosition));
        }
    }
}
