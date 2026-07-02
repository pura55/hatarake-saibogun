using UnityEngine;
//’S“–@ç—tŒ‹‰Á

public class SkillMax : MonoBehaviour
{
    public StatusSkill status;
    public SkillTree skilltree;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (skilltree.skillmax == 10)
        {
            status.isSkillMax = true;
        }

    }
}
