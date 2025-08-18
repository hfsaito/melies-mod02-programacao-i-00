using UnityEngine;

public class Army : MonoBehaviour
{
    public GameObject unit;

    private static readonly int N_UNITS = 10000;
    private static readonly int UNITS_PER_ROW = Mathf.FloorToInt(Mathf.Sqrt(N_UNITS));

    private static readonly Vector3 SPACING = new Vector3(2.12f, 2.86f, 0);
    private static readonly Vector3 OFFSET = (- UNITS_PER_ROW / 2) * SPACING;

    private static readonly Quaternion DEFAULT_ROTATION = new(0, 0, 0, 0);

    void Start()
    {
        for(int j = 0; j < UNITS_PER_ROW; j++)
        {
            for(int i = 0; i < UNITS_PER_ROW; i++)
            {
                Vector3 position = OFFSET + Vector3.Scale(new Vector3(i, j, 0), SPACING);
                Instantiate(unit, position, DEFAULT_ROTATION);
            }
        }
    }
}
