using UnityEngine;

public class SelectionController : MonoBehaviour
{
    [SerializeField]
    private GameObject objectSelected;

    [SerializeField]
    private float stepMod;

    private bool isArrowKeyDown = false;

    public enum TransformState
    {
        Rotation,
        Translation,
        Scale,
    }

    public TransformState state;

    void Start()
    {
        state = TransformState.Translation;
    }

    public void SetSelectedObject(GameObject obj) => objectSelected = obj;
    public GameObject GetSelectedObject => objectSelected;

    void Update()
    {
        //State Change input keys
        if (Input.GetKeyDown(KeyCode.R)) { state = TransformState.Rotation; }
        if (Input.GetKeyDown(KeyCode.T)) { state = TransformState.Translation; }
        if (Input.GetKeyDown(KeyCode.Y)) { state = TransformState.Scale; }

        if (objectSelected != null) //Check Whether an object is currently selected
        {
            Vector2 arrowInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //Arrow Keys Vector
            if(arrowInput != Vector2.zero) //If a button is currently pressed, vector won't equal 0
            {
                if(isArrowKeyDown == false) //Bool to only get input on key down
                {
                    objectSelected.GetComponent<TranslateObject>().StepInput(arrowInput * stepMod); //Call objects translation function, passing in input vector and step modifier
                    isArrowKeyDown = true; //Set key down to true
                }
            }     
            else { isArrowKeyDown = false; } //If Vector is zero, set key down to false
        }
    }
}
