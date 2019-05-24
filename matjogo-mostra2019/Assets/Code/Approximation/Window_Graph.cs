using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Window_Graph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    protected Vector2 MaxXY(List<Vector2> list)
    {
        Vector2 max = list[0];
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i].x > max.x) max.x = list[i].x;
            if (list[i].y > max.y) max.y = list[i].y;
        }
        return max;
    }

    

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        // CreateCircle(new Vector2(200, 200));
        List<Vector2> valueList = new List<Vector2>();
        Vector2 v = new Vector2();
        for (int i = 0; i < 10; i++)
        {
            v.x = Random.Range(0f, 100f);
            v.y = Random.Range(0f, 300f);
            valueList.Add(v);
        }
      
        showGraph(valueList);
        //for(int i = 0; i < valueList.Count; i++)
        //{
        //    Debug.Log(valueList[i]);
        //}
        //Debug.Log(MaxXY(valueList));
    }

    private void Start()
    {
        
    }

    private void CreateCircle (Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        //Debug.Log(circleSprite.rect.height);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11,11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    private void showGraph(List<Vector2> coords)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;
        Vector2 maxCoords = MaxXY(coords);
        const float halfSpriteSize = 5f;
        for (int i = 0; i < coords.Count; i++)
        {
            float xPosition = (coords[i].x/maxCoords.x) * (graphWidth - halfSpriteSize);
            float yPosition = (coords[i].y/maxCoords.y) * (graphHeight- halfSpriteSize);
        CreateCircle(new Vector2(xPosition, yPosition));
        }
    }

    public void plotRandomFunction()
    {

    }
}
