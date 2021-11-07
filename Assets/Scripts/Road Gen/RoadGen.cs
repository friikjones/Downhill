using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGen : MonoBehaviour
{
    public GameObject segmentPrefab;
    public float segmentSizeX, segmentSizeZ, segmentOffX, segmentOffY, segmentAngleY, segmentAngleX;
    public GameObject currentAnchor;

    private int[] sections, corners, elev;

    public int[] levelParameters = new int[7];


    void Start()
    {
        currentAnchor = new GameObject("startAnchor");
        float force = .2f + levelParameters[6] * .12f;
        // SectionPicker(300, 5, 15, 90, -15, -5, 1.5f);
        SectionPicker(levelParameters[0], levelParameters[1], levelParameters[2],
                        levelParameters[3], levelParameters[4], levelParameters[5], force);
    }

    void GenerateSection(float size, float angleX = 0, float angleY = 0)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject _temp = Instantiate(segmentPrefab, Vector3.zero, Quaternion.identity);
            SegmentGen _tempScript = _temp.GetComponent<SegmentGen>();
            _tempScript.startPoint = currentAnchor;
            _tempScript.angleX = angleX;
            _tempScript.angleY = angleY;
            currentAnchor = _tempScript.CreateAnchor();
        }
    }

    void SectionPicker(int minDist, int sectionSizeMin, int sectionsizeMax, int maxCorner,
                        int minSlope, int maxSlope, float cornerForce)
    {
        sections = new int[minDist / sectionSizeMin];
        corners = new int[minDist / sectionSizeMin];
        elev = new int[minDist / sectionSizeMin];
        int i = 0, currentSize = 0, currentCorner = 0, currentElev = 0;
        while (currentSize < minDist)
        {
            //Generate random sector size
            int secSize = Random.Range(sectionSizeMin, sectionsizeMax + 1);
            sections[i] = secSize;
            currentSize += secSize;

            //Generate random sector corner
            int secCorner = (int)Random.Range(-10 * cornerForce, 10 * cornerForce + 1);
            if (Mathf.Abs(currentCorner + secCorner * secSize) > maxCorner)
            {
                if (Mathf.Abs(currentCorner + (secCorner / 2 * secSize)) > maxCorner)
                    secCorner = 0;
                else
                    secCorner = secCorner / 2;
            }
            corners[i] = secCorner;
            currentCorner += secCorner * secSize;

            //Generate random sector elevation
            int secElev = Random.Range(maxSlope, minSlope + 1);
            elev[i] = secElev;
            currentElev += secElev;

            i++;
        }

        for (int j = 0; j < sections.Length; j++)
        {
            GenerateSection(sections[j], elev[j], corners[j]);
        }


    }
}
