using UnityEngine;
using UnityEngine.UI;

public class GraphPlotter : MonoBehaviour
{
    public RectTransform graphContainer;
    public Sprite circleSprite;
    public Color lineColor = Color.black;
    public Color gridColor = Color.gray;
    public float circleSize = 5f;
    public int gridLinesCount = 10;
    public float[] values;

    private void FixedUpdate()
    {
        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;
        // Draw grid
        DrawGrid(graphWidth, graphHeight, gridLinesCount);
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

        rectTransform.sizeDelta = new Vector2(distance, 3f); // 3f is line thickness
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.anchoredPosition = pointA + direction * distance * 0.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }

    private void DrawGrid(float width, float height, int linesCount)
    {
        float spacingX = width / (linesCount - 1);
        float spacingY = height / (linesCount - 1);

        for (int i = 0; i < linesCount; i++)
        {
            float x = i * spacingX;
            CreateLine(new Vector2(x, 0), new Vector2(x, height), gridColor);
            float y = i * spacingY;
            CreateLine(new Vector2(0, y), new Vector2(width, y), gridColor);
        }
    }

    private void CreateLine(Vector2 pointA, Vector2 pointB, Color color)
    {
        GameObject lineObj = new GameObject("GridLine", typeof(Image));
        lineObj.transform.SetParent(graphContainer, false);
        Image lineImage = lineObj.GetComponent<Image>();
        lineImage.color = color;
        
        RectTransform rectTransform = lineObj.GetComponent<RectTransform>();
        Vector2 direction = (pointB - pointA).normalized;
        float distance = Vector2.Distance(pointA, pointB);

        rectTransform.sizeDelta = new Vector2(distance, 1f); // 1f is line thickness
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.anchoredPosition = pointA + direction * distance * 0.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }
}