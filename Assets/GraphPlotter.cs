using UnityEngine;
using UnityEngine.UI;

public class GraphPlotter : MonoBehaviour
{
    public RectTransform graphContainer;
    public Sprite circleSprite;
    public Color lineColor = Color.black;
    public float circleSize = 5f;
    public float[] values;
    private void Awake()
    {
        float graphWidth = graphContainer.rect.width;
        float graphHeight = graphContainer.rect.height;
        print(graphWidth);

        float xSpacing = graphWidth / (values.Length - 1);
        float maxValue = Mathf.Max(values);

        Vector2 lastPoint = Vector2.zero;

        for (int i = 0; i < values.Length; i++)
        {
            float xPosition = i * xSpacing;
            float yPosition = (values[i] / maxValue) * graphHeight;
            Vector2 currentPoint = new Vector2(xPosition, yPosition);

            if (i > 0)
            {
                CreateLine(lastPoint, currentPoint);
            }

            lastPoint = currentPoint;
        }
    }
    private void CreateLine(Vector2 pointA, Vector2 pointB)
    {
        GameObject lineObj = new GameObject("Line", typeof(Image));
        lineObj.transform.SetParent(graphContainer, false);
        Image lineImage = lineObj.GetComponent<Image>();
        lineImage.color = lineColor;
        
        RectTransform rectTransform = lineObj.GetComponent<RectTransform>();
        Vector2 direction = (pointB - pointA).normalized;
        float distance = Vector2.Distance(pointA, pointB);

        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.anchoredPosition = pointA + direction * distance * 0.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }
}