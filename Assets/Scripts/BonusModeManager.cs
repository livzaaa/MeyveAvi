using UnityEngine;
using System.Collections;

public class BonusModeManager : MonoBehaviour
{
    public static BonusModeManager instance;

    public GameObject normalBackground;
    public GameObject bonusBackground;

    public bool isBonusMode = false;

    private bool bonusUsed = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (normalBackground != null)
        {
            normalBackground.SetActive(true);
        }

        if (bonusBackground != null)
        {
            bonusBackground.SetActive(false);
        }
    }

    public void TryActivateBonusMode()
    {
        if (!bonusUsed && !isBonusMode && ScoreManager.instance.score >= 100)
        {
            StartCoroutine(BonusModeRoutine());
        }
    }

    IEnumerator BonusModeRoutine()
    {
        bonusUsed = true;
        isBonusMode = true;

        if (normalBackground != null)
        {
            normalBackground.SetActive(false);
        }

        if (bonusBackground != null)
        {
            bonusBackground.SetActive(true);
        }

        yield return new WaitForSeconds(5f);

        if (bonusBackground != null)
        {
            bonusBackground.SetActive(false);
        }

        if (normalBackground != null)
        {
            normalBackground.SetActive(true);
        }

        isBonusMode = false;
    }

    public void ResetBonusMode()
    {
        StopAllCoroutines();

        isBonusMode = false;
        bonusUsed = false;

        if (bonusBackground != null)
        {
            bonusBackground.SetActive(false);
        }

        if (normalBackground != null)
        {
            normalBackground.SetActive(true);
        }
    }
}