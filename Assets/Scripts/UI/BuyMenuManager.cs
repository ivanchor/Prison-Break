using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenuManager : MonoBehaviour
{
    public GameObject Player;
    public HudManager hud;

    //upgrades Katana
    public void UpgradeKatana()
    {
        GameManager.instance.BuyKatana(Player);
        hud.Refresh();
    }

    public void UpgradeKnife()
    {
        GameManager.instance.BuyKnife(Player);
        hud.Refresh();
    }

    public void UpgradeLaserGun()
    {
        GameManager.instance.BuyLaser(Player);
        hud.Refresh();
    }

    public void UpgradeTaser()
    {
        GameManager.instance.BuyTaser(Player);
        hud.Refresh();
    }

    public void UpgradePlayerDmg()
    {
        GameManager.instance.BuyDamage(Player);
        hud.Refresh();
    }

    public void UpgradePlayerDuration()
    {
        GameManager.instance.BuyDuration(Player);
        hud.Refresh();
    }

    public void UpgradeProjectileSpd()
    {
        GameManager.instance.BuyProjSpeed(Player);
        hud.Refresh();
    }

    public void UpgradePlayerSpeed()
    {
        GameManager.instance.BuySpeed(Player);
        hud.Refresh();
    }
}
