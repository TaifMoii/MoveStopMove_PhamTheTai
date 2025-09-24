using UnityEngine;
using UnityEngine.AI;

public static class NavMeshUtils
{
    public static Vector3 GetRandomPointOnNavMesh()
    {
        NavMeshTriangulation triangulation = NavMesh.CalculateTriangulation();

        // chọn random 1 tam giác trong navmesh
        int triangleIndex = Random.Range(0, triangulation.indices.Length / 3) * 3;
        Vector3 a = triangulation.vertices[triangulation.indices[triangleIndex]];
        Vector3 b = triangulation.vertices[triangulation.indices[triangleIndex + 1]];
        Vector3 c = triangulation.vertices[triangulation.indices[triangleIndex + 2]];

        // barycentric coordinates để random đều trong tam giác
        float r1 = Mathf.Sqrt(Random.value);
        float r2 = Random.value;
        Vector3 randomPoint = (1 - r1) * a + (r1 * (1 - r2)) * b + (r1 * r2) * c;

        // đảm bảo điểm hợp lệ trên NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return randomPoint;
    }
}
