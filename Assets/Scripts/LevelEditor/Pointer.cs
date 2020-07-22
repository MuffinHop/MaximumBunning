using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Pointer : MonoBehaviour
{
    [SerializeField]private Transform _planePointer;
    [SerializeField] private LevelEditorMode _levelEditorMode;
    private MeshCollider _meshCollider;
    private GameObject[,] map = new GameObject[32, 32];
    public UnityEvent EnviromentChanged;
    
    void Start()
    {
        _meshCollider = GetComponent<MeshCollider>();
    }
    public Fence GetEnvironment(int x, int y)
    {
        GameObject furni = map[x, y];
        if (furni == null)
        {
            return null;
        }
        return furni.GetComponent<Fence>();
    }
    public Fence GetEnvironment(Vector3 point)
    {
        Vector2Int gridPosition = new Vector2Int(Mathf.FloorToInt(16f + point.x), Mathf.FloorToInt(f: 16f + point.z));
        GameObject furni = map[gridPosition.x, gridPosition.y];
        if (furni == null)
        {
            return null;
        }
        return furni.GetComponent<Fence>();
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit getInfo;

        
        if (!EventSystem.current.IsPointerOverGameObject() && _meshCollider.Raycast(ray, out getInfo, 1000f))
        {
            var point = new Vector3(getInfo.point.x, getInfo.point.y, getInfo.point.z);
            var signPoint = new Vector3(Mathf.Sign(point.x), Mathf.Sign(point.y), Mathf.Sign(point.z));
            _planePointer.position = new Vector3(
                Mathf.Floor(Mathf.Abs(point.x)) * signPoint.x,
                Mathf.Floor(Mathf.Abs(point.y)) * signPoint.y, 
                Mathf.Floor(Mathf.Abs(point.z)) * signPoint.z);
            point = _planePointer.position;
            if (Input.GetMouseButtonDown(0))
            {
                Vector2Int gridPosition = new Vector2Int(Mathf.FloorToInt(16f + point.x), Mathf.FloorToInt(f: 16f + point.z));
                if (GetEnvironment(gridPosition.x, gridPosition.y) == null)
                {
                    var environmentGameObject = map[gridPosition.x, gridPosition.y] = Instantiate(_levelEditorMode.GetSelectedPiece().Prefab, _planePointer.position, Quaternion.identity);
                    var environmentControl = environmentGameObject.GetComponent<Environment>();
                    environmentGameObject.transform.SetParent(transform);
                    environmentControl.SetPointer(this);
                    environmentControl.SetGridPoint(gridPosition);
                    EnviromentChanged.Invoke();
                }
            }
        }
    }
}
