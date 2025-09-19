using UnityEngine;
using UnityEngine.AI;

public static class NavMeshUtil
{
    // Trả về 1 điểm ngẫu nhiên trên NavMesh trong bán kính "range" quanh "center"
    public static bool RandomPoint(Vector3 center, float range, out Vector3 result, int areaMask = NavMesh.AllAreas, int maxTries = 30)
    {
        for (int i = 0; i < maxTries; i++)
        {
            var random = Random.insideUnitSphere * range;
            var samplePos = center + random;
            if (NavMesh.SamplePosition(samplePos, out var hit, 2.0f, areaMask))
            {
                result = hit.position;
                return true;
            }
        }
        result = center;
        return false;
    }
}
