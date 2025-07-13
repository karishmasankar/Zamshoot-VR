using UnityEngine;

public class CurvedUIPlacer : MonoBehaviour
{
    public float radius = 2f;
    public float angleRange = 90f; // degrees
    public Transform centerPoint;

    void Start()
    {
        int childCount = transform.childCount;
        float angleStep = angleRange / (childCount - 1);

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            float angle = -angleRange / 2f + i * angleStep;
            float rad = Mathf.Deg2Rad * angle;

            Vector3 pos = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
            child.localPosition = pos;

            if (centerPoint != null)
                child.LookAt(centerPoint.position);
            else
                child.LookAt(Vector3.zero);
        }
    }
}
