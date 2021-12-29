using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace KymaurisChaoticCards.Cards
{
    class ChaosKCC : CustomCard
    {
        String title = "Chaos";
        String description = "This will make you the king of C H A O S . HAHAHAHAHAHAHA";
        CardInfo.Rarity rarity = CardInfo.Rarity.Rare;
                CardThemeColor.CardThemeColorType theme = CardThemeColor.CardThemeColorType.DestructiveRed;


        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            UnityEngine.Debug.Log($"[{KymaurisChaoticCards.ModInitials}][Card] {GetTitle()} has been setup.");

            gun.damage += 999999;
            gun.ammo += 999999;
            gun.reloadTime -= 999999;
            gun.projectileSpeed += 999999;
            gun.attackSpeed -= 999999;
            gun.projectileSize += 10;
            gun.randomBounces += 999999;
            gun.bursts += 999999;
            gun.unblockable += true;
            gun.teleport += true;
            gun.ignoreWalls += true;


            statModifiers.health += 999999;
            statModifiers.lifeSteal += 999999;
            statModifiers.respawns += 999999;
            statModifiers.automaticReload += true;


            block.additionalBlocks += 999999;
            block.cooldown -= 999999;
            block.autoBlock -= true;

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            UnityEngine.Debug.Log($"[{KymaurisChaoticCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            UnityEngine.Debug.Log($"[{KymaurisChaoticCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return title;
        }
        protected override string GetDescription()
        {
            return description;
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return rarity;
        }
        protected override CardInfoStat[] GetStats()
        {
return new CardInfoStat[]
{

    new CardInfoStat()
    {
        positive = true,
        stat = "All Stats",
        amount = "y e s",
        simepleAmount = CardInfoStat.SimpleAmount.notAssigned
    }
};

        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return theme;
        }
        public override string GetModName()
        {
            return "KymaurisChaoticCards.ModInitials";
        }
    }
}
