using UnityEngine;

public class TileStateHandler : MonoBehaviour
{
    public TileStateMachine TileStateMachine => tileStateMachine;
    private TileStateMachine tileStateMachine;
    private Renderer tileRenderer;
    [SerializeField] private Material hoverMaterial;
    private Material normalMaterial;
    private Vector3 posOffset = new Vector3(0, .475f, 0);
    private bool isBuilded = false;
    ITurretProduct turret;
    GameObject towerMenu;

    private void Awake()
    {
        tileStateMachine = new TileStateMachine(this);
    }

    private void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        normalMaterial = tileRenderer.materials[0];
        tileStateMachine.Initialize(tileStateMachine.normalState);
        tileStateMachine.stateChanged += OnStateChanged;
        towerMenu = GameObject.Find("TowerMenu");
    }

    void OnDestroy()
    {
        tileStateMachine.stateChanged -= OnStateChanged;
    }

    private void OnStateChanged(ITileState state)
    {
        Material[] matArray = tileRenderer.materials;
        matArray[0] = state.GetType().Name == "TileHoverState" ? hoverMaterial : normalMaterial;
        tileRenderer.materials = matArray;
    }

    private void OnMouseOver()
    {
        tileStateMachine.TransitionTo(tileStateMachine.hoverState);
        iTween.PunchScale(gameObject, new Vector3(60, 60, 60), .5f);
    }

    private void OnMouseExit()
    {
        tileStateMachine.TransitionTo(tileStateMachine.normalState);
    }

    private void OnMouseUp()
    {
        if (!towerMenu.activeInHierarchy)
        {
            if (transform.childCount == 0)
            {
                Vector3 pos = transform.position + posOffset;
                turret = TurretBuilder.Instance.CreateSelectedTowerAtPosition(pos);
                if (turret != null)
                {
                    CamShake.Instance.Shake(.1f, .4f, .8f);
                    isBuilded = true;
                    turret.gameObject.transform.parent = transform;
                }
                else
                {
                    isBuilded = false;
                }
            }
            else
            {
                print(turret.TurretLevel);
                towerMenu.GetComponent<TowerMenu>().turret = turret;
                towerMenu.SetActive(true);
            }
        }
    }
}
