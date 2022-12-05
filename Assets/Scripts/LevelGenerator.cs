using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformsPrefabs;
    public GameObject FirstPlatformPrefab;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float DistanceBetweenPlatforms;
    public Transform FinishPlatfoems;
    public Transform CylinderRoot;
    public float ExtraCylinderScale = 1f;
    public Game Game;

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        Random random = new Random(levelIndex);
        int platformsCount = RandomRange(random, MinPlatforms, MaxPlatforms + 1);

        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, PlatformsPrefabs.Length);
            GameObject platfoemPrefab = i == 0 ? FirstPlatformPrefab : PlatformsPrefabs[prefabIndex];
            GameObject platform = Instantiate(platfoemPrefab, transform);
            platform.transform.localPosition = CalculatePlatformsPosition(i);
            if (i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);
        }
        FinishPlatfoems.localPosition = CalculatePlatformsPosition(platformsCount);

        CylinderRoot.localScale = new Vector3(1, platformsCount * DistanceBetweenPlatforms + ExtraCylinderScale, 1);
    }

    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }

    private float RandomRange(Random random, float min, float max)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }

    private Vector3 CalculatePlatformsPosition(int platformIdex)
    {
        return new Vector3(0, -DistanceBetweenPlatforms * platformIdex, 0);
    }
}
