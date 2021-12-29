﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace TemplateModID.Cards
{
    class TemplateCardID : CustomCard
    {
        String title = "TemplateCardName";
        String description = "TemplateDescription";
        CardInfo.Rarity rarity = CardInfo.Rarity.Common;
        CardThemeColor.CardThemeColorType theme = CardThemeColor.CardThemeColorType.ColdBlue;


        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            UnityEngine.Debug.Log($"[{TemplateModID.ModInitials}][Card] {GetTitle()} has been setup.");
            gun.stat = num;

            statModifiers.stat = num;

            block.stat = num;

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            UnityEngine.Debug.Log($"[{TemplateModID.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            UnityEngine.Debug.Log($"[{TemplateModID.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
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
            return new CardInfoStat[] { new CardInfoStat() { positive = true, stat = "Effect", amount = "No", simepleAmount = CardInfoStat.SimpleAmount.notAssigned } };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return theme;
        }
        public override string GetModName()
        {
            return "TemplateModID.ModInitials";
        }
    }
}
