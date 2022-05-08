using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementGrid : MonoBehaviour
{
    [SerializeField]
    private Vector2Int dimensions;
    [SerializeField]
    private int gridSize;

    [SerializeField]
    private Node nodePrefab;
    private Node[,] nodes;

    private void Start()
    {
        GenerateNodes();
    }

    private void GenerateNodes()
    {
        if (nodePrefab == null)
            return;

        var tilesParent = new GameObject("Nodes");
        tilesParent.transform.parent = transform;
        tilesParent.transform.localPosition = Vector3.zero;
        tilesParent.transform.localRotation = Quaternion.identity;
        nodes = new Node[dimensions.x, dimensions.y];
        
        for (int y = 0; y < dimensions.y; y++)
        {
            for (int x = 0; x < dimensions.x; x++)
            {
                Vector3 localPos = new Vector3(x, 0, y) * gridSize;
                Vector3 targetPos = transform.TransformPoint(localPos);
                Node newTile = Instantiate(nodePrefab);
                newTile.transform.parent = tilesParent.transform;
                newTile.transform.position = targetPos;
                newTile.transform.localRotation = Quaternion.identity;

                nodes[x, y] = newTile;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Color prevCol = Gizmos.color;
        Gizmos.color = Color.gray;

        Matrix4x4 originalMatrix = Gizmos.matrix;
        Gizmos.matrix = transform.localToWorldMatrix;

        // Draw local space flattened cubes
        for (int y = 0; y < dimensions.y; y++)
        {
            for (int x = 0; x < dimensions.x; x++)
            {
                var position = new Vector3(x * gridSize, -0.5f, y * gridSize);
                Gizmos.DrawWireCube(position, new Vector3(gridSize, 0, gridSize));
            }
        }

        Gizmos.matrix = originalMatrix;
        Gizmos.color = prevCol;
    }
}
