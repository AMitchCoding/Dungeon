﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    class NPCDictionary
    {
        Dictionary<String, NPC> _NPCSprites = new Dictionary<String, NPC>();

        public NPCDictionary()
        {

            _NPCSprites.Add("mons_shadow", new NPC(new Vector2(24, 13), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_earth_elemental", new NPC(new Vector2(25, 13), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_fire_elemental", new NPC(new Vector2(26, 13), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_vapour", new NPC(new Vector2(27, 13), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_death_cob", new NPC(new Vector2(28, 13), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_asmodeus", new NPC(new Vector2(29, 13), 10, 1, 0, 0, "corpse_wizard"));
            _NPCSprites.Add("mons_cerebov", new NPC(new Vector2(0, 14), 10, 1, 0, 0, "corpse_hell_knight"));
            _NPCSprites.Add("mons_dispater", new NPC(new Vector2(1, 14), 10, 1, 0, 0, "corpse_wizard"));
            _NPCSprites.Add("mons_ereshkigal", new NPC(new Vector2(2, 14), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_geryon", new NPC(new Vector2(3, 14), 10, 1, 0, 0, "corpse_naga"));
            _NPCSprites.Add("mons_gloorx_vloq", new NPC(new Vector2(4, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_lom_lobon", new NPC(new Vector2(5, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_mnoleg", new NPC(new Vector2(6, 14), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_pandemonium_demon", new NPC(new Vector2(7, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_ball_lightning", new NPC(new Vector2(8, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_orb_of_fire", new NPC(new Vector2(9, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_balrug", new NPC(new Vector2(10, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_blue_death", new NPC(new Vector2(11, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_cacodemon", new NPC(new Vector2(12, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_executioner", new NPC(new Vector2(13, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_fiend", new NPC(new Vector2(14, 14), 10, 1, 0, 0, "corpse_firedrake"));
            _NPCSprites.Add("mons_green_death", new NPC(new Vector2(15, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_ice_fiend", new NPC(new Vector2(16, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_pit_fiend", new NPC(new Vector2(17, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_shadow_fiend", new NPC(new Vector2(18, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_ice_devil", new NPC(new Vector2(19, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_lorocyproca", new NPC(new Vector2(20, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_reaper", new NPC(new Vector2(21, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_soul_eater", new NPC(new Vector2(22, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_sun_demon", new NPC(new Vector2(23, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_blue_devil", new NPC(new Vector2(24, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_demonic_crawler", new NPC(new Vector2(25, 14), 10, 1, 0, 0, "corpse_grey_snake"));
            _NPCSprites.Add("mons_hellion", new NPC(new Vector2(26, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_hellwing", new NPC(new Vector2(27, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_iron_devil", new NPC(new Vector2(28, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_neqoxec", new NPC(new Vector2(29, 14), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_orange_demon", new NPC(new Vector2(0, 15), 10, 1, 0, 0, "corpse_griffon"));
            _NPCSprites.Add("mons_shadow_demon", new NPC(new Vector2(1, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_tormentor", new NPC(new Vector2(2, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_ynoxinul", new NPC(new Vector2(3, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_beast", new NPC(new Vector2(4, 15), 10, 1, 0, 0, "corpse_rock_troll"));
            _NPCSprites.Add("mons_hairy_devil", new NPC(new Vector2(5, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_red_devil", new NPC(new Vector2(6, 15), 10, 1, 0, 0, "corpse_firedrake"));
            _NPCSprites.Add("mons_rotting_devil", new NPC(new Vector2(7, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_smoke_demon", new NPC(new Vector2(8, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_imp", new NPC(new Vector2(9, 15), 10, 1, 0, 0, "corpse_firedrake"));
            _NPCSprites.Add("mons_lemure", new NPC(new Vector2(10, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_manes", new NPC(new Vector2(11, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_midge", new NPC(new Vector2(12, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_shadow_imp", new NPC(new Vector2(13, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_ufetubus", new NPC(new Vector2(14, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_white_imp", new NPC(new Vector2(15, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_clay_golem", new NPC(new Vector2(16, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_crystal_golem", new NPC(new Vector2(17, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_electric_golem", new NPC(new Vector2(18, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_iron_golem", new NPC(new Vector2(19, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_stone_golem", new NPC(new Vector2(20, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_toenail_golem", new NPC(new Vector2(21, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_wood_golem", new NPC(new Vector2(22, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_big_fish", new NPC(new Vector2(23, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_electrical_eel", new NPC(new Vector2(24, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_giant_goldfish", new NPC(new Vector2(25, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_lava_fish", new NPC(new Vector2(26, 15), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_adolf", new NPC(new Vector2(27, 15), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_agnes", new NPC(new Vector2(28, 15), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_donald", new NPC(new Vector2(29, 15), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_duane", new NPC(new Vector2(0, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_edmund", new NPC(new Vector2(1, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_erica", new NPC(new Vector2(2, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_frances", new NPC(new Vector2(3, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_francis", new NPC(new Vector2(4, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_glowing_shapeshifter", new NPC(new Vector2(5, 16), 10, 1, 0, 0, "corpse_glowing_shapeshifter"));
            _NPCSprites.Add("mons_harold", new NPC(new Vector2(6, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_hell_knight", new NPC(new Vector2(7, 16), 10, 1, 0, 0, "corpse_hell_knight"));
            _NPCSprites.Add("mons_human", new NPC(new Vector2(8, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_jessica", new NPC(new Vector2(9, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_joseph", new NPC(new Vector2(10, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_josephine", new NPC(new Vector2(11, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_jozef", new NPC(new Vector2(12, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_killer_klown", new NPC(new Vector2(13, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_louise", new NPC(new Vector2(14, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_margery", new NPC(new Vector2(15, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_maud", new NPC(new Vector2(16, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_michael", new NPC(new Vector2(17, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_necromancer", new NPC(new Vector2(18, 16), 10, 1, 0, 0, "corpse_necromancer"));
            _NPCSprites.Add("mons_norbert", new NPC(new Vector2(19, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_norris", new NPC(new Vector2(20, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_psyche", new NPC(new Vector2(21, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_rupert", new NPC(new Vector2(22, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_shapeshifter", new NPC(new Vector2(23, 16), 10, 1, 0, 0, "corpse_shapeshifter"));
            _NPCSprites.Add("mons_sigmund", new NPC(new Vector2(24, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_terence", new NPC(new Vector2(25, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_vault_guard", new NPC(new Vector2(26, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_wayne", new NPC(new Vector2(27, 16), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_wizard", new NPC(new Vector2(28, 16), 10, 1, 0, 0, "corpse_wizard"));
            _NPCSprites.Add("mons_angel", new NPC(new Vector2(29, 16), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_daeva", new NPC(new Vector2(0, 17), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_boring_beetle", new NPC(new Vector2(1, 17), 10, 1, 0, 0, "corpse_boring_beetle"));
            _NPCSprites.Add("mons_boulder_beetle", new NPC(new Vector2(2, 17), 10, 1, 0, 0, "corpse_boulder_beetle"));
            _NPCSprites.Add("mons_giant_beetle", new NPC(new Vector2(3, 17), 10, 1, 0, 0, "corpse_giant_beetle"));
            _NPCSprites.Add("mons_program_bug", new NPC(new Vector2(4, 17), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_antaeus", new NPC(new Vector2(5, 17), 10, 1, 0, 0, "corpse_titan"));
            _NPCSprites.Add("mons_cyclops", new NPC(new Vector2(6, 17), 10, 1, 0, 0, "corpse_cyclops"));
            _NPCSprites.Add("mons_ettin", new NPC(new Vector2(7, 17), 10, 1, 0, 0, "corpse_two_headed_ogre"));
            _NPCSprites.Add("mons_fire_giant", new NPC(new Vector2(8, 17), 10, 1, 0, 0, "corpse_fire_giant"));
            _NPCSprites.Add("mons_frost_giant", new NPC(new Vector2(9, 17), 10, 1, 0, 0, "corpse_frost_giant"));
            _NPCSprites.Add("mons_hill_giant", new NPC(new Vector2(10, 17), 10, 1, 0, 0, "corpse_hill_giant"));
            _NPCSprites.Add("mons_stone_giant", new NPC(new Vector2(11, 17), 10, 1, 0, 0, "corpse_stone_giant"));
            _NPCSprites.Add("mons_titan", new NPC(new Vector2(12, 17), 10, 1, 0, 0, "corpse_titan"));
            _NPCSprites.Add("mons_dragon", new NPC(new Vector2(13, 17), 10, 1, 0, 0, "corpse_dragon"));
            _NPCSprites.Add("mons_golden_dragon", new NPC(new Vector2(14, 17), 10, 1, 0, 0, "corpse_golden_dragon"));
            _NPCSprites.Add("mons_hydra", new NPC(new Vector2(15, 17), 10, 1, 0, 0, "corpse_hydra"));
            _NPCSprites.Add("mons_hydra2", new NPC(new Vector2(16, 17), 10, 1, 0, 0, "corpse_hydra"));
            _NPCSprites.Add("mons_hydra3", new NPC(new Vector2(17, 17), 10, 1, 0, 0, "corpse_hydra"));
            _NPCSprites.Add("mons_hydra4", new NPC(new Vector2(18, 17), 10, 1, 0, 0, "corpse_hydra"));
            _NPCSprites.Add("mons_hydra5", new NPC(new Vector2(19, 17), 10, 1, 0, 0, "corpse_hydra"));
            _NPCSprites.Add("mons_hydra6", new NPC(new Vector2(20, 17), 10, 1, 0, 0, "corpse_hydra"));
            _NPCSprites.Add("mons_hydra7", new NPC(new Vector2(21, 17), 10, 1, 0, 0, "corpse_hydra"));
            _NPCSprites.Add("mons_ice_dragon", new NPC(new Vector2(22, 17), 10, 1, 0, 0, "corpse_ice_dragon"));
            _NPCSprites.Add("mons_iron_dragon", new NPC(new Vector2(23, 17), 10, 1, 0, 0, "corpse_ice_dragon"));
            _NPCSprites.Add("mons_quicksilver_dragon", new NPC(new Vector2(24, 17), 10, 1, 0, 0, "corpse_ice_dragon"));
            _NPCSprites.Add("mons_serpent_of_hell", new NPC(new Vector2(25, 17), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_shadow_dragon", new NPC(new Vector2(26, 17), 10, 1, 0, 0, "corpse_shadow_dragon"));
            _NPCSprites.Add("mons_skeletal_dragon", new NPC(new Vector2(27, 17), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_storm_dragon", new NPC(new Vector2(28, 17), 10, 1, 0, 0, "corpse_storm_dragon"));
            _NPCSprites.Add("mons_swamp_dragon", new NPC(new Vector2(29, 17), 10, 1, 0, 0, "corpse_swamp_dragon"));
            _NPCSprites.Add("mons_wyvern", new NPC(new Vector2(0, 18), 10, 1, 0, 0, "corpse_wyvern"));
            _NPCSprites.Add("mons_xtahua", new NPC(new Vector2(1, 18), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_efreet", new NPC(new Vector2(2, 18), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_blink_frog", new NPC(new Vector2(3, 18), 10, 1, 0, 0, "corpse_blink_frog"));
            _NPCSprites.Add("mons_giant_brown_frog", new NPC(new Vector2(4, 18), 10, 1, 0, 0, "corpse_giant_brown_frog"));
            _NPCSprites.Add("mons_giant_frog", new NPC(new Vector2(5, 18), 10, 1, 0, 0, "corpse_giant_frog"));
            _NPCSprites.Add("mons_spiny_frog", new NPC(new Vector2(6, 18), 10, 1, 0, 0, "corpse_spiny_frog"));
            _NPCSprites.Add("mons_eye_of_devastation", new NPC(new Vector2(7, 18), 10, 1, 0, 0, "corpse_giant_eyeball"));
            _NPCSprites.Add("mons_eye_of_draining", new NPC(new Vector2(8, 18), 10, 1, 0, 0, "corpse_eye_of_draining"));
            _NPCSprites.Add("mons_giant_eyeball", new NPC(new Vector2(9, 18), 10, 1, 0, 0, "corpse_giant_eyeball"));
            _NPCSprites.Add("mons_giant_orange_brain", new NPC(new Vector2(10, 18), 10, 1, 0, 0, "corpse_giant_orange_brain"));
            _NPCSprites.Add("mons_giant_spore", new NPC(new Vector2(11, 18), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_great_orb_of_eyes", new NPC(new Vector2(12, 18), 10, 1, 0, 0, "corpse_great_orb_of_eyes"));
            _NPCSprites.Add("mons_shining_eye", new NPC(new Vector2(13, 18), 10, 1, 0, 0, "corpse_giant_eyeball"));
            _NPCSprites.Add("mons_griffon", new NPC(new Vector2(14, 18), 10, 1, 0, 0, "corpse_griffon"));
            _NPCSprites.Add("mons_hippogriff", new NPC(new Vector2(15, 18), 10, 1, 0, 0, "corpse_hippogriff"));
            _NPCSprites.Add("mons_sphinx", new NPC(new Vector2(16, 18), 10, 1, 0, 0, "corpse_hippogriff"));
            _NPCSprites.Add("mons_ice_beast", new NPC(new Vector2(17, 18), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_acid_blob", new NPC(new Vector2(18, 18), 10, 1, 0, 0, "corpse_giant_amoeba"));
            _NPCSprites.Add("mons_azure_jelly", new NPC(new Vector2(19, 18), 10, 1, 0, 0, "corpse_giant_amoeba"));
            _NPCSprites.Add("mons_brown_ooze", new NPC(new Vector2(20, 18), 10, 1, 0, 0, "corpse_giant_amoeba"));
            _NPCSprites.Add("mons_death_ooze", new NPC(new Vector2(21, 18), 10, 1, 0, 0, "corpse_giant_amoeba"));
            _NPCSprites.Add("mons_giant_amoeba", new NPC(new Vector2(22, 18), 10, 1, 0, 0, "corpse_giant_amoeba"));
            _NPCSprites.Add("mons_jelly", new NPC(new Vector2(23, 18), 10, 1, 0, 0, "corpse_giant_amoeba"));
            _NPCSprites.Add("mons_jellyfish", new NPC(new Vector2(24, 18), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_ooze", new NPC(new Vector2(25, 18), 10, 1, 0, 0, "corpse_giant_amoeba"));
            _NPCSprites.Add("mons_pulsating_lump", new NPC(new Vector2(26, 18), 10, 1, 0, 0, "corpse_giant_amoeba"));
            _NPCSprites.Add("mons_royal_jelly", new NPC(new Vector2(27, 18), 10, 1, 0, 0, "corpse_giant_amoeba"));
            _NPCSprites.Add("mons_slime_creature", new NPC(new Vector2(28, 18), 10, 1, 0, 0, "corpse_giant_amoeba"));
            _NPCSprites.Add("mons_big_kobold", new NPC(new Vector2(29, 18), 10, 1, 0, 0, "corpse_kobold"));
            _NPCSprites.Add("mons_kobold", new NPC(new Vector2(0, 19), 10, 1, 0, 0, "corpse_kobold"));
            _NPCSprites.Add("mons_kobold_demonologist", new NPC(new Vector2(1, 19), 10, 1, 0, 0, "corpse_kobold"));
            _NPCSprites.Add("mons_ancient_lich", new NPC(new Vector2(2, 19), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_boris", new NPC(new Vector2(3, 19), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_lich", new NPC(new Vector2(4, 19), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_greater_mummy", new NPC(new Vector2(5, 19), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_guardian_mummy", new NPC(new Vector2(6, 19), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_mummy", new NPC(new Vector2(7, 19), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_mummy_priest", new NPC(new Vector2(8, 19), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_naga", new NPC(new Vector2(9, 19), 10, 1, 0, 0, "corpse_naga"));
            _NPCSprites.Add("mons_greater_naga", new NPC(new Vector2(10, 19), 10, 1, 0, 0, "corpse_greater_naga"));
            _NPCSprites.Add("mons_naga_warrior", new NPC(new Vector2(11, 19), 10, 1, 0, 0, "corpse_guardian_naga"));
            _NPCSprites.Add("mons_guardian_naga", new NPC(new Vector2(12, 19), 10, 1, 0, 0, "corpse_guardian_naga"));
            _NPCSprites.Add("mons_naga_mage", new NPC(new Vector2(13, 19), 10, 1, 0, 0, "corpse_greater_naga"));
            _NPCSprites.Add("mons_erolcha", new NPC(new Vector2(14, 19), 10, 1, 0, 0, "corpse_ogre"));
            _NPCSprites.Add("mons_ogre", new NPC(new Vector2(15, 19), 10, 1, 0, 0, "corpse_ogre"));
            _NPCSprites.Add("mons_ogre_mage", new NPC(new Vector2(16, 19), 10, 1, 0, 0, "corpse_ogre"));
            _NPCSprites.Add("mons_two_headed_ogre", new NPC(new Vector2(17, 19), 10, 1, 0, 0, "corpse_two_headed_ogre"));
            _NPCSprites.Add("mons_oklob_plant", new NPC(new Vector2(18, 19), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_plant", new NPC(new Vector2(19, 19), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_queen_ant", new NPC(new Vector2(20, 19), 10, 1, 0, 0, "corpse_queen_ant"));
            _NPCSprites.Add("mons_queen_bee", new NPC(new Vector2(21, 19), 10, 1, 0, 0, "corpse_queen_bee"));
            _NPCSprites.Add("mons_rakshasa", new NPC(new Vector2(22, 19), 10, 1, 0, 0, "corpse_human"));
            _NPCSprites.Add("mons_rakshasa_fake", new NPC(new Vector2(23, 19), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_black_snake", new NPC(new Vector2(24, 19), 10, 1, 0, 0, "corpse_black_snake"));
            _NPCSprites.Add("mons_brown_snake", new NPC(new Vector2(25, 19), 10, 1, 0, 0, "corpse_brown_snake"));
            _NPCSprites.Add("mons_grey_snake", new NPC(new Vector2(26, 19), 10, 1, 0, 0, "corpse_grey_snake"));
            _NPCSprites.Add("mons_lava_snake", new NPC(new Vector2(27, 19), 10, 1, 0, 0, "corpse_firedrake"));
            _NPCSprites.Add("mons_salamander", new NPC(new Vector2(28, 19), 10, 1, 0, 0, "corpse_firedrake"));
            _NPCSprites.Add("mons_small_snake", new NPC(new Vector2(29, 19), 10, 1, 0, 0, "corpse_small_snake"));
            _NPCSprites.Add("mons_snake", new NPC(new Vector2(0, 20), 10, 1, 0, 0, "corpse_snake"));
            _NPCSprites.Add("mons_yellow_snake", new NPC(new Vector2(1, 20), 10, 1, 0, 0, "corpse_yellow_snake"));
            _NPCSprites.Add("mons_deep_troll", new NPC(new Vector2(2, 20), 10, 1, 0, 0, "corpse_deep_troll"));
            _NPCSprites.Add("mons_iron_troll", new NPC(new Vector2(3, 20), 10, 1, 0, 0, "corpse_deep_troll"));
            _NPCSprites.Add("mons_rock_troll", new NPC(new Vector2(4, 20), 10, 1, 0, 0, "corpse_rock_troll"));
            _NPCSprites.Add("mons_snorg", new NPC(new Vector2(5, 20), 10, 1, 0, 0, "corpse_troll"));
            _NPCSprites.Add("mons_troll", new NPC(new Vector2(6, 20), 10, 1, 0, 0, "corpse_troll"));
            _NPCSprites.Add("mons_bear", new NPC(new Vector2(7, 20), 10, 1, 0, 0, "corpse_bear"));
            _NPCSprites.Add("mons_black_bear", new NPC(new Vector2(8, 20), 10, 1, 0, 0, "corpse_black_bear"));
            _NPCSprites.Add("mons_grizzly_bear", new NPC(new Vector2(9, 20), 10, 1, 0, 0, "corpse_grizzly_bear"));
            _NPCSprites.Add("mons_polar_bear", new NPC(new Vector2(10, 20), 10, 1, 0, 0, "corpse_polar_bear"));
            _NPCSprites.Add("mons_vampire", new NPC(new Vector2(11, 20), 10, 1, 0, 0, "corpse_giant_bat"));
            _NPCSprites.Add("mons_vampire_knight", new NPC(new Vector2(12, 20), 10, 1, 0, 0, "corpse_giant_bat"));
            _NPCSprites.Add("mons_vampire_mage", new NPC(new Vector2(13, 20), 10, 1, 0, 0, "corpse_giant_bat"));
            _NPCSprites.Add("mons_freezing_wraith", new NPC(new Vector2(14, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_shadow_wraith", new NPC(new Vector2(15, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_spectral_thing", new NPC(new Vector2(16, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_spectral_warrior", new NPC(new Vector2(17, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_wight", new NPC(new Vector2(18, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_wraith", new NPC(new Vector2(19, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_abomination_1", new NPC(new Vector2(20, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_abomination_2", new NPC(new Vector2(21, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_abomination_3", new NPC(new Vector2(22, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_abomination_4", new NPC(new Vector2(23, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_abomination_5", new NPC(new Vector2(24, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_abomination_6", new NPC(new Vector2(25, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_abomination_7", new NPC(new Vector2(26, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_orb_guardian", new NPC(new Vector2(27, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_tentacled_monstrosity", new NPC(new Vector2(28, 20), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_death_yak", new NPC(new Vector2(29, 20), 10, 1, 0, 0, "corpse_death_yak"));
            _NPCSprites.Add("mons_sheep", new NPC(new Vector2(0, 21), 10, 1, 0, 0, "corpse_sheep"));
            _NPCSprites.Add("mons_yak", new NPC(new Vector2(1, 21), 10, 1, 0, 0, "corpse_yak"));
            _NPCSprites.Add("mons_simulacrum_large", new NPC(new Vector2(2, 21), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_skeleton_large", new NPC(new Vector2(3, 21), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_zombie_large", new NPC(new Vector2(4, 21), 10, 1, 0, 0, "corpse_hill_giant"));
            _NPCSprites.Add("mons_giant_ant", new NPC(new Vector2(5, 21), 10, 1, 0, 0, "corpse_giant_ant"));
            _NPCSprites.Add("mons_giant_cockroach", new NPC(new Vector2(6, 21), 10, 1, 0, 0, "corpse_giant_cockroach"));
            _NPCSprites.Add("mons_soldier_ant", new NPC(new Vector2(7, 21), 10, 1, 0, 0, "corpse_soldier_ant"));
            _NPCSprites.Add("mons_butterfly_teal", new NPC(new Vector2(8, 21), 10, 1, 0, 0, "corpse_butterfly"));
            _NPCSprites.Add("mons_butterfly_red", new NPC(new Vector2(9, 21), 10, 1, 0, 0, "corpse_butterfly"));
            _NPCSprites.Add("mons_butterfly_green", new NPC(new Vector2(10, 21), 10, 1, 0, 0, "corpse_butterfly"));
            _NPCSprites.Add("mons_butterfly_yellow", new NPC(new Vector2(11, 21), 10, 1, 0, 0, "corpse_butterfly"));
            _NPCSprites.Add("mons_butterfly_blue", new NPC(new Vector2(12, 21), 10, 1, 0, 0, "corpse_butterfly"));
            _NPCSprites.Add("mons_butterfly_pink", new NPC(new Vector2(13, 21), 10, 1, 0, 0, "corpse_butterfly"));
            _NPCSprites.Add("mons_butterfly_green_2", new NPC(new Vector2(14, 21), 10, 1, 0, 0, "corpse_butterfly"));
            _NPCSprites.Add("mons_giant_bat", new NPC(new Vector2(15, 21), 10, 1, 0, 0, "corpse_giant_bat"));
            _NPCSprites.Add("mons_centaur", new NPC(new Vector2(16, 21), 10, 1, 0, 0, "corpse_centaur"));
            _NPCSprites.Add("mons_centaur_warrior", new NPC(new Vector2(17, 21), 10, 1, 0, 0, "corpse_centaur"));
            _NPCSprites.Add("mons_yaktaur", new NPC(new Vector2(18, 21), 10, 1, 0, 0,"corpse_yaktaur"));
            _NPCSprites.Add("mons_yaktaur_captain", new NPC(new Vector2(19, 21), 10, 1, 0, 0, "corpse_yaktaur"));
            _NPCSprites.Add("mons_firedrake", new NPC(new Vector2(20, 21), 10, 1, 0, 0, "corpse_firedrake"));
            _NPCSprites.Add("mons_lindwurm", new NPC(new Vector2(21, 21), 10, 1, 0, 0, "corpse_lindwurm"));
            _NPCSprites.Add("mons_mottled_dragon", new NPC(new Vector2(22, 21), 10, 1, 0, 0, "corpse_mottled_dragon"));
            _NPCSprites.Add("mons_steam_dragon", new NPC(new Vector2(23, 21), 10, 1, 0, 0, "corpse_steam_dragon"));
            _NPCSprites.Add("mons_swamp_drake", new NPC(new Vector2(24, 21), 10, 1, 0, 0, "corpse_swamp_drake"));
            _NPCSprites.Add("mons_elf", new NPC(new Vector2(25, 21), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_fighter", new NPC(new Vector2(26, 21), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_soldier", new NPC(new Vector2(27, 21), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_knight", new NPC(new Vector2(28, 21), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_mage", new NPC(new Vector2(29, 21), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_sorcerer", new NPC(new Vector2(0, 22), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_conjurer", new NPC(new Vector2(1, 22), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_death_mage", new NPC(new Vector2(2, 22), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_demonologist", new NPC(new Vector2(3, 22), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_summoner", new NPC(new Vector2(4, 22), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_annihilator", new NPC(new Vector2(5, 22), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_priest", new NPC(new Vector2(6, 22), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_deep_elf_high_priest", new NPC(new Vector2(7, 22), 10, 1, 0, 0, "corpse_elf"));
            _NPCSprites.Add("mons_fungus", new NPC(new Vector2(8, 22), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_wandering_mushroom", new NPC(new Vector2(9, 22), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_goblin", new NPC(new Vector2(10, 22), 10, 1, 0, 0, "corpse_goblin"));
            _NPCSprites.Add("mons_hobgoblin", new NPC(new Vector2(11, 22), 10, 1, 0, 0, "corpse_hobgoblin"));
            _NPCSprites.Add("mons_gnoll", new NPC(new Vector2(12, 22), 10, 1, 0, 0, "corpse_gnoll"));
            _NPCSprites.Add("mons_ijyb", new NPC(new Vector2(13, 22), 10, 1, 0, 0, "corpse_goblin"));
            _NPCSprites.Add("mons_boggart", new NPC(new Vector2(14, 22), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_gargoyle", new NPC(new Vector2(15, 22), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_metal_gargoyle", new NPC(new Vector2(16, 22), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_molten_gargoyle", new NPC(new Vector2(17, 22), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_hell_hog", new NPC(new Vector2(18, 22), 10, 1, 0, 0, "corpse_hog"));
            _NPCSprites.Add("mons_hell_hound", new NPC(new Vector2(19, 22), 10, 1, 0, 0, "corpse_hound"));
            _NPCSprites.Add("mons_hog", new NPC(new Vector2(20, 22), 10, 1, 0, 0, "corpse_hog"));
            _NPCSprites.Add("mons_hound", new NPC(new Vector2(21, 22), 10, 1, 0, 0, "corpse_hound"));
            _NPCSprites.Add("mons_warg", new NPC(new Vector2(22, 22), 10, 1, 0, 0, "corpse_warg"));
            _NPCSprites.Add("mons_war_dog", new NPC(new Vector2(23, 22), 10, 1, 0, 0, "corpse_war_dog"));
            _NPCSprites.Add("mons_wolf", new NPC(new Vector2(24, 22), 10, 1, 0, 0, "corpse_wolf"));
            _NPCSprites.Add("mons_jackal", new NPC(new Vector2(25, 22), 10, 1, 0, 0, "corpse_jackal"));
            _NPCSprites.Add("mons_bumblebee", new NPC(new Vector2(26, 22), 10, 1, 0, 0, "corpse_bumblebee"));
            _NPCSprites.Add("mons_killer_bee", new NPC(new Vector2(27, 22), 10, 1, 0, 0, "corpse_killer_bee"));
            _NPCSprites.Add("mons_giant_gecko", new NPC(new Vector2(28, 22), 10, 1, 0, 0, "corpse_giant_gecko"));
            _NPCSprites.Add("mons_giant_iguana", new NPC(new Vector2(29, 22), 10, 1, 0, 0, "corpse_giant_iguana"));
            _NPCSprites.Add("mons_giant_lizard", new NPC(new Vector2(0, 23), 10, 1, 0, 0, "corpse_giant_lizard"));
            _NPCSprites.Add("mons_giant_newt", new NPC(new Vector2(1, 23), 10, 1, 0, 0, "corpse_giant_newt"));
            _NPCSprites.Add("mons_gila_monster", new NPC(new Vector2(2, 23), 10, 1, 0, 0, "corpse_gila_monster"));
            _NPCSprites.Add("mons_komodo_dragon", new NPC(new Vector2(3, 23), 10, 1, 0, 0, "corpse_komodo_dragon"));
            _NPCSprites.Add("mons_elephant_slug", new NPC(new Vector2(4, 23), 10, 1, 0, 0, "corpse_elephant_slug"));
            _NPCSprites.Add("mons_giant_slug", new NPC(new Vector2(5, 23), 10, 1, 0, 0, "corpse_giant_slug"));
            _NPCSprites.Add("mons_giant_snail", new NPC(new Vector2(6, 23), 10, 1, 0, 0, "corpse_giant_snail"));
            _NPCSprites.Add("mons_manticore", new NPC(new Vector2(7, 23), 10, 1, 0, 0, "corpse_manticore"));
            _NPCSprites.Add("mons_minotaur", new NPC(new Vector2(8, 23), 10, 1, 0, 0, "corpse_minotaur"));
            _NPCSprites.Add("mons_ghoul", new NPC(new Vector2(9, 23), 10, 1, 0, 0, "corpse_ghoul"));
            _NPCSprites.Add("mons_necrophage", new NPC(new Vector2(10, 23), 10, 1, 0, 0, "corpse_necrophage"));
            _NPCSprites.Add("mons_rotting_hulk", new NPC(new Vector2(11, 23), 10, 1, 0, 0, "corpse_gila_monster"));
            _NPCSprites.Add("mons_orc", new NPC(new Vector2(12, 23), 10, 1, 0, 0, "corpse_orc"));
            _NPCSprites.Add("mons_orc_warrior", new NPC(new Vector2(13, 23), 10, 1, 0, 0, "corpse_orc"));
            _NPCSprites.Add("mons_orc_knight", new NPC(new Vector2(14, 23), 10, 1, 0, 0, "corpse_orc"));
            _NPCSprites.Add("mons_orc_warlord", new NPC(new Vector2(15, 23), 10, 1, 0, 0, "corpse_orc"));
            _NPCSprites.Add("mons_blork_the_orc", new NPC(new Vector2(16, 23), 10, 1, 0, 0, "corpse_orc"));
            _NPCSprites.Add("mons_urug", new NPC(new Vector2(17, 23), 10, 1, 0, 0, "corpse_orc"));
            _NPCSprites.Add("mons_orc_priest", new NPC(new Vector2(18, 23), 10, 1, 0, 0, "corpse_orc"));
            _NPCSprites.Add("mons_orc_high_priest", new NPC(new Vector2(19, 23), 10, 1, 0, 0, "corpse_orc"));
            _NPCSprites.Add("mons_orc_sorcerer", new NPC(new Vector2(20, 23), 10, 1, 0, 0, "corpse_orc"));
            _NPCSprites.Add("mons_orc_wizard", new NPC(new Vector2(21, 23), 10, 1, 0, 0, "corpse_orc"));
            _NPCSprites.Add("mons_flayed_ghost", new NPC(new Vector2(22, 23), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_hungry_ghost", new NPC(new Vector2(23, 23), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_insubstantial_wisp", new NPC(new Vector2(24, 23), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_phantom", new NPC(new Vector2(25, 23), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_player_ghost", new NPC(new Vector2(26, 23), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_quasit", new NPC(new Vector2(27, 23), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_green_rat", new NPC(new Vector2(28, 23), 10, 1, 0, 0, "corpse_green_rat"));
            _NPCSprites.Add("mons_grey_rat", new NPC(new Vector2(29, 23), 10, 1, 0, 0, "corpse_grey_rat"));
            _NPCSprites.Add("mons_orange_rat", new NPC(new Vector2(0, 24), 10, 1, 0, 0, "corpse_orange_rat"));
            _NPCSprites.Add("mons_quokka", new NPC(new Vector2(1, 24), 10, 1, 0, 0, "corpse_quokka"));
            _NPCSprites.Add("mons_rat", new NPC(new Vector2(2, 24), 10, 1, 0, 0, "corpse_rat"));
            _NPCSprites.Add("mons_giant_centipede", new NPC(new Vector2(3, 24), 10, 1, 0, 0, "corpse_giant_centipede"));
            _NPCSprites.Add("mons_giant_mite", new NPC(new Vector2(4, 24), 10, 1, 0, 0, "corpse_giant_mite"));
            _NPCSprites.Add("mons_redback", new NPC(new Vector2(5, 24), 10, 1, 0, 0, "corpse_redback"));
            _NPCSprites.Add("mons_scorpion", new NPC(new Vector2(6, 24), 10, 1, 0, 0, "corpse_scorpion"));
            _NPCSprites.Add("mons_wolf_spider", new NPC(new Vector2(7, 24), 10, 1, 0, 0, "corpse_wolf_spider"));
            _NPCSprites.Add("mons_ugly_thing", new NPC(new Vector2(8, 24), 10, 1, 0, 0, "corpse_ugly_thing"));
            _NPCSprites.Add("mons_very_ugly_thing", new NPC(new Vector2(9, 24), 10, 1, 0, 0, "corpse_very_ugly_thing"));
            _NPCSprites.Add("mons_air_elemental", new NPC(new Vector2(10, 24), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_fire_vortex", new NPC(new Vector2(11, 24), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_spatial_vortex", new NPC(new Vector2(12, 24), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_ant_larva", new NPC(new Vector2(13, 24), 10, 1, 0, 0, "corpse_ant_larva"));
            _NPCSprites.Add("mons_brain_worm", new NPC(new Vector2(14, 24), 10, 1, 0, 0, "corpse_brain_worm"));
            _NPCSprites.Add("mons_killer_bee_larva", new NPC(new Vector2(15, 24), 10, 1, 0, 0, "corpse_killer_bee_larva"));
            _NPCSprites.Add("mons_lava_worm", new NPC(new Vector2(16, 24), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_spiny_worm", new NPC(new Vector2(17, 24), 10, 1, 0, 0, "corpse_spiny_worm"));
            _NPCSprites.Add("mons_swamp_worm", new NPC(new Vector2(18, 24), 10, 1, 0, 0, "corpse_worm"));
            _NPCSprites.Add("mons_worm", new NPC(new Vector2(19, 24), 10, 1, 0, 0, "corpse_worm"));
            _NPCSprites.Add("mons_abomination_small", new NPC(new Vector2(20, 24), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_unseen_horror", new NPC(new Vector2(21, 24), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_giant_blowfly", new NPC(new Vector2(22, 24), 10, 1, 0, 0, "corpse_giant_blowfly"));
            _NPCSprites.Add("mons_giant_mosquito", new NPC(new Vector2(23, 24), 10, 1, 0, 0, "corpse_giant_mosquito"));
            _NPCSprites.Add("mons_moth_of_wrath", new NPC(new Vector2(24, 24), 10, 1, 0, 0, "corpse_giant_centipede"));
            _NPCSprites.Add("mons_red_wasp", new NPC(new Vector2(25, 24), 10, 1, 0, 0, "corpse_red_wasp"));
            _NPCSprites.Add("mons_yellow_wasp", new NPC(new Vector2(26, 24), 10, 1, 0, 0, "corpse_yellow_wasp"));
            _NPCSprites.Add("mons_curse_skull", new NPC(new Vector2(27, 24), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_curse_toe", new NPC(new Vector2(28, 24), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_flying_skull", new NPC(new Vector2(29, 24), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_simulacrum_small", new NPC(new Vector2(0, 25), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_skeletal_warrior", new NPC(new Vector2(1, 25), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_skeleton_small", new NPC(new Vector2(2, 25), 10, 1, 0, 0, "empty"));
            _NPCSprites.Add("mons_zombie_small", new NPC(new Vector2(3, 25), 10, 1, 0, 0, "corpse_orc"));
            _NPCSprites.Add("mons_water_elemental", new NPC(new Vector2(4, 25), 10, 1, 0, 0, "empty"));
        }

        public NPC GetNPC(String monsterName)
        {
            return this._NPCSprites[monsterName];
        }
    }
}