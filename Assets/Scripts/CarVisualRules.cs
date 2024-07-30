using UnityEngine;

public class CarVisualRules : MonoBehaviour
{
    [SerializeField]
    private Car car;
    [SerializeField]
    private VisualRule visualRulePrefab;

    void Start()
    {
        CreateRuleSprites();
    }

    private void CreateRuleSprites()
    {
        Sprite[] sprites = car.GetRuleSprites();
        float spriteOffsetY = -1f;

        for(int i = 0; i< sprites.Length; i++)
        {
            VisualRule newVisualRule = Instantiate(visualRulePrefab, transform);
            SpriteRenderer spriteRenderer = newVisualRule.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites[i];


            newVisualRule.transform.localPosition = new Vector3(0, i * spriteOffsetY, 0);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
