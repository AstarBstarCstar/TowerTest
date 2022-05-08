using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private Color startColor;
    public Color focusColor;
    public Color errorColor;
    public Vector3 positionOffset;

    public Turret turret;

    private Renderer rend;

    private void Awake() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}

    private void OnMouseExit() {
        rend.material.color = startColor;
    }

    private void OnMouseUp() {
        if (null == turret)
            Build();
        else
            BuildManager.instance.turretBar.Show(this);
    }
    
    private void OnMouseOver() {
        if (EventSystem.current.IsPointerOverGameObject())
		 	return;

		if (!BuildManager.instance.CanBuild)
			return;

        if (turret != null)
        {
            rend.material.color = startColor;
        }
		else if (BuildManager.instance.HasMoney)
		{
			rend.material.color = focusColor;
		}
        else
		{
			rend.material.color = errorColor;
		}
    }

    private void Build()
    {
        if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!BuildManager.instance.CanBuild)
			return;

		if (turret != null)
			return;

		BuildManager.instance.BuildTurretOn(this);
    }
}
