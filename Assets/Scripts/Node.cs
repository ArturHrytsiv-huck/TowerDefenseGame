using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    //public BuildManager manager;

    [SerializeField] private Vector3 positionOffset;
    private GameObject turret;
    private Renderer rend;
    private Color startColor;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can`t build there!");
            return;
        }
        //Build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
