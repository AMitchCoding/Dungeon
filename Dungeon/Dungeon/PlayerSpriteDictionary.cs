﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    /// <summary>
    /// List of items, armors, races, weapons, and foci
    /// </summary>
    class PlayerSpriteDictionary
    {
        Dictionary<String, Vector4> _characters = new Dictionary<string, Vector4>();
        Dictionary<String, Item> _itemDictionary = new Dictionary<string, Item>();
        Dictionary<String, Armor> _armorDictionary = new Dictionary<string, Armor>();
        Dictionary<String, Weapon> _weaponDictionary = new Dictionary<string, Weapon>();
        Dictionary<String, Focus> _focusDictionary = new Dictionary<string, Focus>();

        Vector2 OFFSET_X_8 = new Vector2(8, 0);
        Vector2 OFFSET_X_16 = new Vector2(16, 0);
        Vector2 OFFSET_Y_8 = new Vector2(0, 8);
        Vector2 OFFSET_Y_16 = new Vector2(0,16);
        Vector2 OFFSET_0 = new Vector2(0, 0);

        public PlayerSpriteDictionary()
        {
            

            // (topleft x, topleft y, bottom right x, bottom right y)
            // Races
            _characters.Add("human_f", new Vector4(0, 0, 31, 31));
            _characters.Add("human_m", new Vector4(32, 0, 63, 31));
            _characters.Add("elf_f", new Vector4(64, 0, 95, 31));
            _characters.Add("elf_m", new Vector4(96, 0, 127, 31));
            _characters.Add("deep_elf_f", new Vector4(128, 0, 159, 31));
            _characters.Add("deep_elf_m", new Vector4(160, 0, 191, 31));
            _characters.Add("dwarf_f", new Vector4(192, 0, 223, 31));
            _characters.Add("dwarf_m", new Vector4(224, 0, 255, 31));
            _characters.Add("halfling_f", new Vector4(256, 0, 287, 31));
            _characters.Add("halfling_m", new Vector4(288, 0, 319, 31));
            _characters.Add("orc_f", new Vector4(320, 0, 351, 31));
            _characters.Add("orc_m", new Vector4(352, 0, 383, 31));
            _characters.Add("kobold_f", new Vector4(384, 0, 415, 31));
            _characters.Add("kobold_m", new Vector4(416, 0, 447, 31));
            _characters.Add("mummy_f", new Vector4(448, 0, 479, 31));
            _characters.Add("mummy_m", new Vector4(480, 0, 511, 31));
            _characters.Add("naga_f", new Vector4(512, 0, 543, 31));
            _characters.Add("naga_m", new Vector4(544, 0, 575, 31));
            _characters.Add("gnome_f", new Vector4(576, 0, 607, 31));
            _characters.Add("gnome_m", new Vector4(608, 0, 639, 31));
            _characters.Add("ogre_f", new Vector4(0, 32, 31, 63));
            _characters.Add("ogre_m", new Vector4(32, 32, 63, 63));
            _characters.Add("troll_f", new Vector4(64, 32, 95, 63));
            _characters.Add("troll_m", new Vector4(96, 32, 127, 63));
            _characters.Add("ogre_mage_f", new Vector4(128, 32, 159, 63));
            _characters.Add("ogre_mage_m", new Vector4(160, 32, 191, 63));
            _characters.Add("draconian_f", new Vector4(192, 32, 223, 63));
            _characters.Add("draconian_m", new Vector4(224, 32, 255, 63));
            _characters.Add("centaur_f", new Vector4(256, 32, 287, 63));
            _characters.Add("centaur_m", new Vector4(288, 32, 319, 63));
            _characters.Add("demigod_f", new Vector4(320, 32, 351, 63));
            _characters.Add("demigod_m", new Vector4(352, 32, 383, 63));
            _characters.Add("spriggan_f", new Vector4(384, 32, 415, 63));
            _characters.Add("spriggan_m", new Vector4(416, 32, 447, 63));
            _characters.Add("minotaur_f", new Vector4(448, 32, 479, 63));
            _characters.Add("minotaur_m", new Vector4(480, 32, 511, 63));
            _characters.Add("demonspawn_f", new Vector4(512, 32, 543, 63));
            _characters.Add("demonspawn_m", new Vector4(544, 32, 575, 63));
            _characters.Add("ghoul_f", new Vector4(576, 32, 607, 63));
            _characters.Add("ghoul_m", new Vector4(608, 32, 639, 63));
            _characters.Add("kenku_f", new Vector4(0, 64, 31, 95));
            _characters.Add("kenku_m", new Vector4(32, 64, 63, 95));
            _characters.Add("merfolk_f", new Vector4(64, 64, 95, 95));
            _characters.Add("merfolk_m", new Vector4(96, 64, 127, 95));

            _characters.Add("shadow", new Vector4(128, 64, 159, 95));

            //Back
            _armorDictionary.Add("red_cape", new Armor(new Vector4(160, 64, 191, 95), OFFSET_0, 10, 100));
            _armorDictionary.Add("blue_cape", new Armor(new Vector4(192, 64, 223, 95), OFFSET_0, 10, 100, "Cloak"));
            _armorDictionary.Add("magenta_cape", new Armor(new Vector4(224, 64, 255, 95), OFFSET_0, 10, 100));
            _armorDictionary.Add("yellow_cape", new Armor(new Vector4(256, 64, 287, 95), OFFSET_0, 10, 100));
            _armorDictionary.Add("black_cape", new Armor(new Vector4(288, 64, 319, 95), OFFSET_0, 10, 100));
            _armorDictionary.Add("gray_cape", new Armor(new Vector4(320, 64, 351, 95), OFFSET_0, 10, 100));
            _armorDictionary.Add("lbrown_cape", new Armor(new Vector4(352, 64, 383, 95), OFFSET_0, 10, 100));
            _armorDictionary.Add("green_cape", new Armor(new Vector4(384, 64, 415, 95), OFFSET_0, 10, 100));
            _armorDictionary.Add("cyan_cape", new Armor(new Vector4(416, 64, 447, 95), OFFSET_0, 10, 100));
            _armorDictionary.Add("white_cape", new Armor(new Vector4(448, 64, 479, 95), OFFSET_0, 10, 100));

            //Feet
            _armorDictionary.Add("short_red_shoes", new Armor(new Vector4(480, 64, 511, 79), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("short_purple_shoes", new Armor(new Vector4(480, 80, 511, 95), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("short_brown_shoes", new Armor(new Vector4(512, 64, 543, 79), OFFSET_Y_16, 10, 100, "Shoes"));
            _armorDictionary.Add("short_brown2_shoes", new Armor(new Vector4(512, 80, 543, 95), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("pj_shoes", new Armor(new Vector4(544, 64, 575, 79), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("middle_brown_shoes", new Armor(new Vector4(544, 80, 575, 95), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("middle_gray_shoes", new Armor(new Vector4(576, 64, 607, 79), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("middle_green_shoes", new Armor(new Vector4(576, 80, 607, 95), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("middle_ybrown_shoes", new Armor(new Vector4(608, 64, 639, 79), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("middle_purple_shoes", new Armor(new Vector4(608, 80, 639, 95), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("middle_brown2_shoes", new Armor(new Vector4(0, 96, 31, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("mesh_red_shoes", new Armor(new Vector4(0, 112, 31, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("mesh_black_shoes", new Armor(new Vector4(32, 96, 63, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("mesh_white_shoes", new Armor(new Vector4(32, 112, 63, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("mesh_blue_shoes", new Armor(new Vector4(64, 96, 95, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("middle_gold_shoes", new Armor(new Vector4(64, 112, 95, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("long_red_shoes", new Armor(new Vector4(96, 96, 127, 111), OFFSET_Y_16, 10, 100));

            //Pants
            _armorDictionary.Add("bikini_red_bottom", new Armor(new Vector4(128, 96, 159, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("loincloth_red", new Armor(new Vector4(128, 112, 159, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("belt_redbrown", new Armor(new Vector4(160, 96, 191, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("belt_gray", new Armor(new Vector4(160, 112, 191, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("pants_black", new Armor(new Vector4(192, 96, 223, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("pants_orange", new Armor(new Vector4(192, 112, 223, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("pants_blue", new Armor(new Vector4(224, 96, 255, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("pants_darkgreen", new Armor(new Vector4(224, 112, 255, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("pants_brown", new Armor(new Vector4(256, 96, 287, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("pants_short_darkbrown", new Armor(new Vector4(256, 112, 287, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("pants_short_brown", new Armor(new Vector4(288, 96, 319, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("pants_short_brown3", new Armor(new Vector4(288, 112, 319, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("pants_short_gray", new Armor(new Vector4(320, 96, 351, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("pants_pj", new Armor(new Vector4(320, 112, 351, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("skirt_ofs", new Armor(new Vector4(352, 96, 383, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("skirt_green", new Armor(new Vector4(352, 112, 383, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("skirt_white", new Armor(new Vector4(384, 96, 415, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("lowarm1", new Armor(new Vector4(384, 112, 415, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("lowarm2", new Armor(new Vector4(416, 96, 447, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("lowarm3", new Armor(new Vector4(416, 112, 447, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("leg_arm_ofs", new Armor(new Vector4(448, 96, 479, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("leg_arm_red", new Armor(new Vector4(448, 112, 479, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("leg_arm_iron", new Armor(new Vector4(480, 96, 511, 111), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("leg_arm_black", new Armor(new Vector4(480, 112, 511, 127), OFFSET_Y_16, 10, 100));
            _armorDictionary.Add("leg_arm_steel", new Armor(new Vector4(512, 96, 543, 111), OFFSET_Y_16, 10, 100, "Greaves"));
            _armorDictionary.Add("leg_arm_green", new Armor(new Vector4(512, 112, 543, 127), OFFSET_Y_16, 10, 100));

            //Chest
            _armorDictionary.Add("robe_blue", new Armor(new Vector4(544, 96, 559, 127), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_black", new Armor(new Vector4(560, 96, 575, 127), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_white", new Armor(new Vector4(576, 96, 591, 127), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_red", new Armor(new Vector4(592, 96, 607, 127), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_magenta", new Armor(new Vector4(608, 96, 623, 127), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_green", new Armor(new Vector4(624, 96, 639, 127), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_yellow", new Armor(new Vector4(0, 128, 15, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_brown", new Armor(new Vector4(16, 128, 31, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_cyan", new Armor(new Vector4(32, 128, 47, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_rainbow", new Armor(new Vector4(48, 128, 63, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("gandalf_g", new Armor(new Vector4(64, 128, 79, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("saruman_robe", new Armor(new Vector4(80, 128, 95, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_black_hood", new Armor(new Vector4(96, 128, 111, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("monk_blue", new Armor(new Vector4(112, 128, 127, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("monk_black", new Armor(new Vector4(128, 128, 143, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dress_green", new Armor(new Vector4(144, 128, 159, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_black_gold", new Armor(new Vector4(160, 128, 175, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_white2", new Armor(new Vector4(176, 128, 191, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_red2", new Armor(new Vector4(192, 128, 207, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_white_red", new Armor(new Vector4(208, 128, 223, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_white_green", new Armor(new Vector4(224, 128, 239, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_blue_white", new Armor(new Vector4(240, 128, 255, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_purple", new Armor(new Vector4(256, 128, 271, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_red_gold", new Armor(new Vector4(272, 128, 287, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_black_red", new Armor(new Vector4(288, 128, 303, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_blue_green", new Armor(new Vector4(304, 128, 319, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_red3", new Armor(new Vector4(320, 128, 335, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_brown2", new Armor(new Vector4(336, 128, 351, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_green_gold", new Armor(new Vector4(352, 128, 367, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_brown3", new Armor(new Vector4(368, 128, 383, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_gray2", new Armor(new Vector4(384, 128, 399, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dress_white", new Armor(new Vector4(400, 128, 415, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("arwen_dress", new Armor(new Vector4(416, 128, 431, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("skirt_onep_grey", new Armor(new Vector4(432, 128, 447, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("bloody", new Armor(new Vector4(448, 128, 463, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("leather_short", new Armor(new Vector4(464, 128, 479, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("china_red2", new Armor(new Vector4(480, 128, 495, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("animal_skin", new Armor(new Vector4(496, 128, 511, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("neck", new Armor(new Vector4(512, 128, 527, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("belt1", new Armor(new Vector4(528, 128, 543, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("belt2", new Armor(new Vector4(544, 128, 559, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("susp_black", new Armor(new Vector4(560, 128, 575, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("shoulder_pad", new Armor(new Vector4(576, 128, 591, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("mesh_black", new Armor(new Vector4(592, 128, 607, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("mesh_red", new Armor(new Vector4(608, 128, 623, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("leather_jacket", new Armor(new Vector4(624, 128, 639, 159), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("shirt_white1", new Armor(new Vector4(0, 160, 15, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("shirt_white2", new Armor(new Vector4(16, 160, 31, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("shirt_white3", new Armor(new Vector4(32, 160, 47, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("shirt_blue", new Armor(new Vector4(48, 160, 63, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("bikini_red", new Armor(new Vector4(64, 160, 79, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("shirt_hawaii", new Armor(new Vector4(80, 160, 95, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("china_red", new Armor(new Vector4(96, 160, 111, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("leather_red", new Armor(new Vector4(112, 160, 127, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("chunli", new Armor(new Vector4(128, 160, 143, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("shirt_white_yellow", new Armor(new Vector4(144, 160, 159, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("shirt_check", new Armor(new Vector4(160, 160, 175, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("slit_black", new Armor(new Vector4(176, 160, 191, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("leather_armour", new Armor(new Vector4(192, 160, 207, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("leather_green", new Armor(new Vector4(208, 160, 223, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("shirt_black", new Armor(new Vector4(224, 160, 239, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("shirt_black_and_cloth", new Armor(new Vector4(240, 160, 255, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("shirt_black3", new Armor(new Vector4(256, 160, 271, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("leather2", new Armor(new Vector4(272, 160, 287, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("chainmail3", new Armor(new Vector4(288, 160, 303, 191), OFFSET_X_8, 10, 100, "Chainmail"));
            _armorDictionary.Add("shirt_vest", new Armor(new Vector4(304, 160, 319, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("karate", new Armor(new Vector4(320, 160, 335, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("karate2", new Armor(new Vector4(336, 160, 351, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("leather_heavy", new Armor(new Vector4(352, 160, 367, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("troll_hide", new Armor(new Vector4(368, 160, 383, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("green_chain", new Armor(new Vector4(384, 160, 399, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("metal_blue", new Armor(new Vector4(400, 160, 415, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("green_susp", new Armor(new Vector4(416, 160, 431, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("jacket2", new Armor(new Vector4(432, 160, 447, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("jacket3", new Armor(new Vector4(448, 160, 463, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("leather_stud", new Armor(new Vector4(464, 160, 479, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("jacket_stud", new Armor(new Vector4(480, 160, 495, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("chainmail", new Armor(new Vector4(496, 160, 511, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("chainmail2", new Armor(new Vector4(512, 160, 527, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("half_plate", new Armor(new Vector4(528, 160, 543, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("half_plate2", new Armor(new Vector4(544, 160, 559, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("half_plate3", new Armor(new Vector4(560, 160, 575, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("breast_black", new Armor(new Vector4(576, 160, 591, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("vest_red", new Armor(new Vector4(592, 160, 607, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("bplate_green", new Armor(new Vector4(608, 160, 623, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("bplate_metal1", new Armor(new Vector4(624, 160, 639, 191), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("banded", new Armor(new Vector4(0, 192, 15, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("plate_and_cloth", new Armor(new Vector4(16, 192, 31, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("plate_and_cloth2", new Armor(new Vector4(32, 192, 47, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("scalemail", new Armor(new Vector4(48, 192, 63, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("leather_metal", new Armor(new Vector4(64, 192, 79, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("plate", new Armor(new Vector4(80, 192, 95, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("plate_black", new Armor(new Vector4(96, 192, 111, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("crystal_plate", new Armor(new Vector4(112, 192, 127, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("armor_mummy", new Armor(new Vector4(128, 192, 143, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonsc_green", new Armor(new Vector4(144, 192, 159, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonsc_white", new Armor(new Vector4(160, 192, 175, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonsc_magenta", new Armor(new Vector4(176, 192, 191, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonsc_cyan", new Armor(new Vector4(192, 192, 207, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonsc_brown", new Armor(new Vector4(208, 192, 223, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonsc_blue", new Armor(new Vector4(224, 192, 239, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonsc_gold", new Armor(new Vector4(240, 192, 255, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonarm_green", new Armor(new Vector4(256, 192, 271, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonarm_white", new Armor(new Vector4(272, 192, 287, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonarm_magenta", new Armor(new Vector4(288, 192, 303, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonarm_cyan", new Armor(new Vector4(304, 192, 319, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonarm_brown", new Armor(new Vector4(320, 192, 335, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonarm_blue", new Armor(new Vector4(336, 192, 351, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dragonarm_gold", new Armor(new Vector4(352, 192, 367, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("aragorn_robe", new Armor(new Vector4(368, 192, 383, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("boromir_robe", new Armor(new Vector4(384, 192, 399, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("frodo_jacket", new Armor(new Vector4(400, 192, 415, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("gimli_shirt", new Armor(new Vector4(416, 192, 431, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("legolas_shirt", new Armor(new Vector4(432, 192, 447, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("merry_shirt", new Armor(new Vector4(448, 192, 463, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("pipin", new Armor(new Vector4(464, 192, 479, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("pj_shirt", new Armor(new Vector4(480, 192, 495, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("sam_shirt", new Armor(new Vector4(496, 192, 511, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("edison_armor", new Armor(new Vector4(512, 192, 527, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("lears_chain_mail", new Armor(new Vector4(528, 192, 543, 223), OFFSET_X_8, 10, 100));
            _armorDictionary.Add("robe_of_night", new Armor(new Vector4(544, 192, 559, 223), OFFSET_X_8, 10, 100));

            //Hands
            _armorDictionary.Add("glove_red", new Armor(new Vector4(576, 192, 607, 207), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_gray", new Armor(new Vector4(576, 208, 607, 223), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_white", new Armor(new Vector4(608, 192, 639, 207), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_blue", new Armor(new Vector4(608, 208, 639, 223), OFFSET_Y_8, 10, 100, "Gloves"));
            _armorDictionary.Add("glove_black", new Armor(new Vector4(0, 224, 31, 239), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_orange", new Armor(new Vector4(0, 240, 31, 255), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_brown", new Armor(new Vector4(32, 224, 63, 239), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_black2", new Armor(new Vector4(32, 240, 63, 255), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_grayfist", new Armor(new Vector4(64, 224, 95, 239), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_purple", new Armor(new Vector4(64, 240, 95, 255), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_wrist_purple", new Armor(new Vector4(96, 224, 127, 239), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_chunli", new Armor(new Vector4(96, 240, 127, 255), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_gold", new Armor(new Vector4(128, 224, 159, 239), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_short_yellow", new Armor(new Vector4(128, 240, 159, 255), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_short_red", new Armor(new Vector4(160, 224, 191, 239), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_short_white", new Armor(new Vector4(160, 240, 191, 255), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_short_green", new Armor(new Vector4(192, 224, 223, 239), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_short_blue", new Armor(new Vector4(192, 240, 223, 255), OFFSET_Y_8, 10, 100));
            _armorDictionary.Add("glove_short_gray", new Armor(new Vector4(224, 224, 255, 239), OFFSET_Y_8, 10, 100));

            //Head
            _armorDictionary.Add("hat_ofs", new Armor(new Vector4(416, 416, 431, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("corn_red", new Armor(new Vector4(432, 416, 447, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("straw", new Armor(new Vector4(416, 432, 431, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("wizard_blue", new Armor(new Vector4(432, 432, 447, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("big_cap_blue", new Armor(new Vector4(448, 416, 463, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("bandana_ybrown", new Armor(new Vector4(464, 416, 479, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hat_black", new Armor(new Vector4(448, 432, 463, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("gandalf_hat", new Armor(new Vector4(464, 432, 479, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("crown", new Armor(new Vector4(480, 416, 495, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("cult_hood", new Armor(new Vector4(496, 416, 511, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hat_jest", new Armor(new Vector4(480, 432, 495, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hat_robin_green", new Armor(new Vector4(496, 432, 511, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hat_robin_red", new Armor(new Vector4(512, 416, 527, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hat_robin_blue", new Armor(new Vector4(528, 416, 543, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hat_robin_yellow", new Armor(new Vector4(512, 432, 527, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hat_robin_white", new Armor(new Vector4(528, 432, 543, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("headband_white", new Armor(new Vector4(544, 416, 559, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("headband_red", new Armor(new Vector4(560, 416, 575, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("headband_yellow", new Armor(new Vector4(544, 432, 559, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("headband_blue", new Armor(new Vector4(560, 432, 575, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("headband_pink", new Armor(new Vector4(576, 416, 591, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("cap_blue", new Armor(new Vector4(592, 416, 607, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("cap_pink", new Armor(new Vector4(576, 432, 591, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("cap_yellow", new Armor(new Vector4(592, 432, 607, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("cap_red", new Armor(new Vector4(608, 416, 623, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("cap_white", new Armor(new Vector4(624, 416, 639, 431),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("dyrovepreva", new Armor(new Vector4(608, 432, 623, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("wizard_purple", new Armor(new Vector4(624, 432, 639, 447),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("wizard_blue_green", new Armor(new Vector4(0, 448, 15, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("wizard_green", new Armor(new Vector4(16, 448, 31, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("wizard_brown", new Armor(new Vector4(0, 464, 15, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("wizard_black_yellow", new Armor(new Vector4(16, 464, 31, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("wizard_black_red", new Armor(new Vector4(32, 448, 47, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("wizard_red", new Armor(new Vector4(48, 448, 63, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("wizard_white", new Armor(new Vector4(32, 464, 47, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hat_chefs_white", new Armor(new Vector4(48, 464, 63, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hat_chefs_orange", new Armor(new Vector4(64, 448, 79, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("helm_ofs", new Armor(new Vector4(80, 448, 95, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("bear_hat", new Armor(new Vector4(64, 464, 79, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("orange_horn_gold", new Armor(new Vector4(80, 464, 95, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("helm_green", new Armor(new Vector4(96, 448, 111, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("juggernaut", new Armor(new Vector4(112, 448, 127, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("helm_red", new Armor(new Vector4(96, 464, 111, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("blue_horn_gold", new Armor(new Vector4(112, 464, 127, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("white", new Armor(new Vector4(128, 448, 143, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("gray_horn_gold", new Armor(new Vector4(144, 448, 159, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("ghoul_helm", new Armor(new Vector4(128, 464, 143, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("demon_helm", new Armor(new Vector4(144, 464, 159, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("skell_helm_gold", new Armor(new Vector4(160, 448, 175, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("skell_helm", new Armor(new Vector4(176, 448, 191, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("fhelm_ofs", new Armor(new Vector4(160, 464, 175, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("fhelm_black", new Armor(new Vector4(176, 464, 191, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("fhelm_horn_gray", new Armor(new Vector4(192, 448, 207, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("fhelm_gray", new Armor(new Vector4(208, 448, 223, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("fhelm_gray2", new Armor(new Vector4(192, 464, 207, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("fhelm_gray3", new Armor(new Vector4(208, 464, 223, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("fhelm_horn_yellow", new Armor(new Vector4(224, 448, 239, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("fhelm_horn2", new Armor(new Vector4(240, 448, 255, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("fhelm_evil", new Armor(new Vector4(224, 464, 239, 479),OFFSET_X_8, 10, 100, "Full Helm"));
            _armorDictionary.Add("fhelm_plume", new Armor(new Vector4(240, 464, 255, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("fhelm_mummy", new Armor(new Vector4(256, 448, 271, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("art_dragonhelm", new Armor(new Vector4(272, 448, 287, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("fhelm_healer", new Armor(new Vector4(256, 464, 271, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hood_gray", new Armor(new Vector4(272, 464, 287, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hood_red", new Armor(new Vector4(288, 448, 303, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hood_green2", new Armor(new Vector4(304, 448, 319, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hood_cyan", new Armor(new Vector4(288, 464, 303, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hood_orange", new Armor(new Vector4(304, 464, 319, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hood_red2", new Armor(new Vector4(320, 448, 335, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hood_black2", new Armor(new Vector4(336, 448, 351, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hood_white2", new Armor(new Vector4(320, 464, 335, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hood_ybrown", new Armor(new Vector4(336, 464, 351, 479),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("hood_green", new Armor(new Vector4(352, 448, 367, 463),OFFSET_X_8, 10, 100));
            _armorDictionary.Add("mask_ninja_black", new Armor(new Vector4(368, 448, 383, 463),OFFSET_X_8, 10, 100));

            //Main hand
            _weaponDictionary.Add("dagger", new Weapon(new Vector4(256, 224, 271, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("dagger_slant", new Weapon(new Vector4(272, 224, 287, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("short_sword", new Weapon(new Vector4(288, 224, 303, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("short_sword_slant", new Weapon(new Vector4(304, 224, 319, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("short_sword2", new Weapon(new Vector4(320, 224, 335, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("sword_thief", new Weapon(new Vector4(336, 224, 351, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("long_sword", new Weapon(new Vector4(352, 224, 367, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("long_sword_slant", new Weapon(new Vector4(368, 224, 383, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("great_sword", new Weapon(new Vector4(384, 224, 399, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("great_sword_slant", new Weapon(new Vector4(400, 224, 415, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("katana", new Weapon(new Vector4(416, 224, 431, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("katana_slant", new Weapon(new Vector4(432, 224, 447, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("scimitar", new Weapon(new Vector4(448, 224, 463, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("falchion", new Weapon(new Vector4(464, 224, 479, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("sword2", new Weapon(new Vector4(480, 224, 495, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("sword_tri", new Weapon(new Vector4(496, 224, 511, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("broadsword", new Weapon(new Vector4(512, 224, 527, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("black_sword", new Weapon(new Vector4(528, 224, 543, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("sword_black", new Weapon(new Vector4(544, 224, 559, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("sword_twist", new Weapon(new Vector4(560, 224, 575, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("knife", new Weapon(new Vector4(576, 224, 591, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("sword_seven", new Weapon(new Vector4(592, 224, 607, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("heavy_sword", new Weapon(new Vector4(608, 224, 623, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("sabre", new Weapon(new Vector4(624, 224, 639, 255),OFFSET_0, 10,100));
            _weaponDictionary.Add("sword3", new Weapon(new Vector4(0, 256, 15, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("sword_breaker", new Weapon(new Vector4(16, 256, 31, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("sword_jag", new Weapon(new Vector4(32, 256, 47, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("bloodbane", new Weapon(new Vector4(48, 256, 63, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("chilly_death", new Weapon(new Vector4(64, 256, 79, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("doom_knight", new Weapon(new Vector4(80, 256, 95, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("flaming_death", new Weapon(new Vector4(96, 256, 111, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("leech", new Weapon(new Vector4(112, 256, 127, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("morg", new Weapon(new Vector4(128, 256, 143, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("plutonium_sword", new Weapon(new Vector4(144, 256, 159, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("jihad", new Weapon(new Vector4(160, 256, 175, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("singing_sword", new Weapon(new Vector4(176, 256, 191, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("zonguldrok", new Weapon(new Vector4(192, 256, 207, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("club", new Weapon(new Vector4(208, 256, 223, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("club_slant", new Weapon(new Vector4(224, 256, 239, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("club2", new Weapon(new Vector4(240, 256, 255, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("club3", new Weapon(new Vector4(256, 256, 271, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("stick", new Weapon(new Vector4(272, 256, 287, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("giant_club", new Weapon(new Vector4(288, 256, 303, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("giant_club_slant", new Weapon(new Vector4(304, 256, 319, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("giant_club_spike", new Weapon(new Vector4(320, 256, 335, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("giant_club_spike_slant", new Weapon(new Vector4(336, 256, 351, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("whip", new Weapon(new Vector4(352, 256, 367, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("sceptre", new Weapon(new Vector4(368, 256, 383, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("mace2", new Weapon(new Vector4(384, 256, 399, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("mace", new Weapon(new Vector4(400, 256, 415, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("great_mace", new Weapon(new Vector4(416, 256, 431, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("mace_ruby", new Weapon(new Vector4(432, 256, 447, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("morningstar2", new Weapon(new Vector4(448, 256, 463, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("morningstar", new Weapon(new Vector4(464, 256, 479, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("eveningstar", new Weapon(new Vector4(480, 256, 495, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("large_mace", new Weapon(new Vector4(496, 256, 511, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("black_whip", new Weapon(new Vector4(512, 256, 527, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("hammer", new Weapon(new Vector4(528, 256, 543, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("hammer2", new Weapon(new Vector4(544, 256, 559, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("flail_stick", new Weapon(new Vector4(560, 256, 575, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("flail", new Weapon(new Vector4(576, 256, 591, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("spiked_flail", new Weapon(new Vector4(592, 256, 607, 287),OFFSET_0, 10,100, "Spiked Flail"));
            _weaponDictionary.Add("great_flail", new Weapon(new Vector4(608, 256, 623, 287),OFFSET_0, 10,100, "Great Flail"));
            _weaponDictionary.Add("flail_ball2", new Weapon(new Vector4(624, 256, 639, 287),OFFSET_0, 10,100));
            _weaponDictionary.Add("flail_balls", new Weapon(new Vector4(0, 288, 15, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("flail_ball3", new Weapon(new Vector4(16, 288, 31, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("flail_ball4", new Weapon(new Vector4(32, 288, 47, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("nunchaku", new Weapon(new Vector4(48, 288, 63, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("mace_of_variability", new Weapon(new Vector4(64, 288, 79, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("spear", new Weapon(new Vector4(80, 288, 95, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("spear2", new Weapon(new Vector4(96, 288, 111, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("spear3", new Weapon(new Vector4(112, 288, 127, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("spear4", new Weapon(new Vector4(128, 288, 143, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("spear5", new Weapon(new Vector4(144, 288, 159, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("hook", new Weapon(new Vector4(160, 288, 175, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("halberd", new Weapon(new Vector4(176, 288, 191, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("pick_axe", new Weapon(new Vector4(192, 288, 207, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("trident", new Weapon(new Vector4(208, 288, 223, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("demon_trident", new Weapon(new Vector4(224, 288, 239, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("trident_elec", new Weapon(new Vector4(240, 288, 255, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("trident2", new Weapon(new Vector4(256, 288, 271, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("trident3", new Weapon(new Vector4(272, 288, 287, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("lance", new Weapon(new Vector4(288, 288, 303, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("lance2", new Weapon(new Vector4(304, 288, 319, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("scythe", new Weapon(new Vector4(320, 288, 335, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("scythe_slant", new Weapon(new Vector4(336, 288, 351, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("pike", new Weapon(new Vector4(352, 288, 367, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("quarterstaff1", new Weapon(new Vector4(368, 288, 383, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("quarterstaff2", new Weapon(new Vector4(384, 288, 399, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("quarterstaff3", new Weapon(new Vector4(400, 288, 415, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("quarterstaff4", new Weapon(new Vector4(416, 288, 431, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("sickle", new Weapon(new Vector4(432, 288, 447, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("glaive", new Weapon(new Vector4(448, 288, 463, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("glaive2", new Weapon(new Vector4(464, 288, 479, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("glaive3", new Weapon(new Vector4(480, 288, 495, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("d_glaive", new Weapon(new Vector4(496, 288, 511, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("pole_forked", new Weapon(new Vector4(512, 288, 527, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("fork2", new Weapon(new Vector4(528, 288, 543, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("glaive_of_prune", new Weapon(new Vector4(544, 288, 559, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("voodoo", new Weapon(new Vector4(560, 288, 575, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("finisher", new Weapon(new Vector4(576, 288, 591, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("staff_skull", new Weapon(new Vector4(592, 288, 607, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("staff_mage", new Weapon(new Vector4(608, 288, 623, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("staff_mage2", new Weapon(new Vector4(624, 288, 639, 319),OFFSET_0, 10,100));
            _weaponDictionary.Add("great_staff", new Weapon(new Vector4(0, 320, 15, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("staff_evil", new Weapon(new Vector4(16, 320, 31, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("staff_ring_blue", new Weapon(new Vector4(32, 320, 47, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("staff_mummy", new Weapon(new Vector4(48, 320, 63, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("staff_fork", new Weapon(new Vector4(64, 320, 79, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("staff_ruby", new Weapon(new Vector4(80, 320, 95, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("staff_large", new Weapon(new Vector4(96, 320, 111, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("elemental_staff", new Weapon(new Vector4(112, 320, 127, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("asmodeus", new Weapon(new Vector4(128, 320, 143, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("dispater", new Weapon(new Vector4(144, 320, 159, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("olgreb", new Weapon(new Vector4(160, 320, 175, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("axe_small", new Weapon(new Vector4(176, 320, 191, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("hand_axe", new Weapon(new Vector4(192, 320, 207, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("war_axe", new Weapon(new Vector4(208, 320, 223, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("broad_axe", new Weapon(new Vector4(224, 320, 239, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("battleaxe", new Weapon(new Vector4(240, 320, 255, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("executioners_axe", new Weapon(new Vector4(256, 320, 271, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("axe_double", new Weapon(new Vector4(272, 320, 287, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("axe_blood", new Weapon(new Vector4(288, 320, 303, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("axe_short", new Weapon(new Vector4(304, 320, 319, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("axe_trog", new Weapon(new Vector4(320, 320, 335, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("arga", new Weapon(new Vector4(336, 320, 351, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("sling", new Weapon(new Vector4(352, 320, 367, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("bow", new Weapon(new Vector4(368, 320, 383, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("bow2", new Weapon(new Vector4(384, 320, 399, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("bow3", new Weapon(new Vector4(400, 320, 415, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("great_bow", new Weapon(new Vector4(416, 320, 431, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("bow_blue", new Weapon(new Vector4(432, 320, 447, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("crossbow", new Weapon(new Vector4(448, 320, 463, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("crossbow2", new Weapon(new Vector4(464, 320, 479, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("crossbow3", new Weapon(new Vector4(480, 320, 495, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("crossbow4", new Weapon(new Vector4(496, 320, 511, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("punk", new Weapon(new Vector4(512, 320, 527, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("sniper", new Weapon(new Vector4(528, 320, 543, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("krishna", new Weapon(new Vector4(544, 320, 559, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("dart", new Weapon(new Vector4(560, 320, 575, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("bone_lantern", new Weapon(new Vector4(576, 320, 591, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("fan", new Weapon(new Vector4(592, 320, 607, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("bottle", new Weapon(new Vector4(608, 320, 623, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("box", new Weapon(new Vector4(624, 320, 639, 351),OFFSET_0, 10,100));
            _weaponDictionary.Add("crystal", new Weapon(new Vector4(0, 352, 15, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("deck", new Weapon(new Vector4(16, 352, 31, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("disc", new Weapon(new Vector4(32, 352, 47, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("horn", new Weapon(new Vector4(48, 352, 63, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("lantern_gold", new Weapon(new Vector4(64, 352, 79, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("orb", new Weapon(new Vector4(80, 352, 95, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("stone", new Weapon(new Vector4(96, 352, 111, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("fire_red", new Weapon(new Vector4(112, 352, 127, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("fire_blue", new Weapon(new Vector4(128, 352, 143, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("skull", new Weapon(new Vector4(144, 352, 159, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("black_head", new Weapon(new Vector4(160, 352, 175, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("fire_green_1", new Weapon(new Vector4(176, 352, 191, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("fire_cyan_1", new Weapon(new Vector4(192, 352, 207, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("fire_white_1", new Weapon(new Vector4(208, 352, 223, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("light_blue_orb_1", new Weapon(new Vector4(224, 352, 239, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("light_red_orb_1", new Weapon(new Vector4(240, 352, 255, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("light_yellow_orb_1", new Weapon(new Vector4(256, 352, 271, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("spark_1", new Weapon(new Vector4(272, 352, 287, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("fire_dark_1", new Weapon(new Vector4(288, 352, 303, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("fire_white2_1", new Weapon(new Vector4(304, 352, 319, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("aragorn_sword", new Weapon(new Vector4(320, 352, 335, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("arwen_sword", new Weapon(new Vector4(336, 352, 351, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("boromir_sword", new Weapon(new Vector4(352, 352, 367, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("frodo_dagger", new Weapon(new Vector4(368, 352, 383, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("gandalf_staff", new Weapon(new Vector4(384, 352, 399, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("gimli_axe", new Weapon(new Vector4(400, 352, 415, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("legolas_bow", new Weapon(new Vector4(416, 352, 431, 383),OFFSET_0, 10,100));
            _weaponDictionary.Add("saruman_staff", new Weapon(new Vector4(432, 352, 447, 383),OFFSET_0, 10,100));

            //Shields
            _weaponDictionary.Add("shield_round_small", new Weapon(new Vector4(448, 352, 463, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_round_small2", new Weapon(new Vector4(464, 352, 479, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("bullseye", new Weapon(new Vector4(480, 352, 495, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_middle_round", new Weapon(new Vector4(496, 352, 511, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_skull", new Weapon(new Vector4(512, 352, 527, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_round_white", new Weapon(new Vector4(528, 352, 543, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("boromir_shield", new Weapon(new Vector4(544, 352, 559, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_round1", new Weapon(new Vector4(560, 352, 575, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_round2", new Weapon(new Vector4(576, 352, 591, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_round3", new Weapon(new Vector4(592, 352, 607, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_round4", new Weapon(new Vector4(608, 352, 623, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_round5", new Weapon(new Vector4(624, 352, 639, 383),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_round6", new Weapon(new Vector4(0, 384, 15, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_round7", new Weapon(new Vector4(16, 384, 31, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_knight_blue", new Weapon(new Vector4(32, 384, 47, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_knight_gray", new Weapon(new Vector4(48, 384, 63, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_knight_rw", new Weapon(new Vector4(64, 384, 79, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_middle_unicorn", new Weapon(new Vector4(80, 384, 95, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_kite1", new Weapon(new Vector4(96, 384, 111, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_kite2", new Weapon(new Vector4(112, 384, 127, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_kite3", new Weapon(new Vector4(128, 384, 143, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_kite4", new Weapon(new Vector4(144, 384, 159, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_long_red", new Weapon(new Vector4(160, 384, 175, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_middle_gray", new Weapon(new Vector4(176, 384, 191, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_diamond_yellow", new Weapon(new Vector4(192, 384, 207, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_middle_brown", new Weapon(new Vector4(208, 384, 223, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_middle_black", new Weapon(new Vector4(224, 384, 239, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_middle_cyan", new Weapon(new Vector4(240, 384, 255, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_middle_ethn", new Weapon(new Vector4(256, 384, 271, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_long_cross", new Weapon(new Vector4(272, 384, 287, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_shaman", new Weapon(new Vector4(288, 384, 303, 415),OFFSET_X_16, 10,100));
            _weaponDictionary.Add("shield_of_resistance", new Weapon(new Vector4(304, 384, 319, 415),OFFSET_X_16, 10,100));

            //Foci
            _focusDictionary.Add("book_black", new Focus(new Vector4(320, 384, 335, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_blue", new Focus(new Vector4(336, 384, 351, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_red", new Focus(new Vector4(352, 384, 367, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_magenta", new Focus(new Vector4(368, 384, 383, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_green", new Focus(new Vector4(384, 384, 399, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_cyan", new Focus(new Vector4(400, 384, 415, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_yellow", new Focus(new Vector4(416, 384, 431, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_white", new Focus(new Vector4(432, 384, 447, 415),OFFSET_X_16, 10, "Cotton Book"));
            _focusDictionary.Add("book_sky", new Focus(new Vector4(448, 384, 463, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_blue_dim", new Focus(new Vector4(464, 384, 479, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_cyan_dim", new Focus(new Vector4(480, 384, 495, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_green_dim", new Focus(new Vector4(496, 384, 511, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_magenta_dim", new Focus(new Vector4(512, 384, 527, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_red_dim", new Focus(new Vector4(528, 384, 543, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("book_yellow_dim", new Focus(new Vector4(544, 384, 559, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("fire_green_2", new Focus(new Vector4(560, 384, 575, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("fire_cyan_2", new Focus(new Vector4(576, 384, 591, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("fire_white_2", new Focus(new Vector4(592, 384, 607, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("light_blue_orb_2", new Focus(new Vector4(608, 384, 623, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("light_red_orb_2", new Focus(new Vector4(624, 384, 639, 415),OFFSET_X_16, 10));
            _focusDictionary.Add("light_yellow_orb_2", new Focus(new Vector4(0, 416, 15, 447),OFFSET_X_16, 10));
            _focusDictionary.Add("spark_2", new Focus(new Vector4(16, 416, 31, 447),OFFSET_X_16, 10));
            _focusDictionary.Add("fire_dark_2", new Focus(new Vector4(32, 416, 47, 447),OFFSET_X_16, 10));
            _focusDictionary.Add("fire_white2_2", new Focus(new Vector4(48, 416, 63, 447),OFFSET_X_16, 10));
            _focusDictionary.Add("lantern_gray", new Focus(new Vector4(64, 416, 79, 447),OFFSET_X_16, 10));
            _focusDictionary.Add("torch", new Focus(new Vector4(80, 416, 95, 447),OFFSET_X_16, 10));
            _focusDictionary.Add("pj_thing", new Focus(new Vector4(96, 416, 111, 447),OFFSET_X_16, 10));
            _focusDictionary.Add("blonde_head", new Focus(new Vector4(112, 416, 127, 447),OFFSET_X_16, 10));

            //Hair
            _itemDictionary.Add("short_black_hair", new Item(new Vector4(128, 416, 143, 431),OFFSET_X_8));
            _itemDictionary.Add("short_red_hair", new Item(new Vector4(144, 416, 159, 431),OFFSET_X_8));
            _itemDictionary.Add("short_yellow_hair", new Item(new Vector4(128, 432, 143, 447),OFFSET_X_8));
            _itemDictionary.Add("short_white_hair", new Item(new Vector4(144, 432, 159, 447),OFFSET_X_8));
            _itemDictionary.Add("long_black_hair", new Item(new Vector4(160, 416, 175, 431),OFFSET_X_8));
            _itemDictionary.Add("long_red_hair", new Item(new Vector4(176, 416, 191, 431),OFFSET_X_8));
            _itemDictionary.Add("long_yellow_hair", new Item(new Vector4(160, 432, 175, 447),OFFSET_X_8));
            _itemDictionary.Add("long_white_hair", new Item(new Vector4(176, 432, 191, 447),OFFSET_X_8));
            _itemDictionary.Add("fem_black", new Item(new Vector4(192, 416, 207, 431),OFFSET_X_8));
            _itemDictionary.Add("fem_red", new Item(new Vector4(208, 416, 223, 431),OFFSET_X_8));
            _itemDictionary.Add("fem_yellow", new Item(new Vector4(192, 432, 207, 447),OFFSET_X_8));
            _itemDictionary.Add("fem_white", new Item(new Vector4(208, 432, 223, 447),OFFSET_X_8));
            _itemDictionary.Add("elf_black", new Item(new Vector4(224, 416, 239, 431),OFFSET_X_8));
            _itemDictionary.Add("elf_red", new Item(new Vector4(240, 416, 255, 431),OFFSET_X_8));
            _itemDictionary.Add("elf_yellow", new Item(new Vector4(224, 432, 239, 447),OFFSET_X_8));
            _itemDictionary.Add("elf_white", new Item(new Vector4(240, 432, 255, 447),OFFSET_X_8));
            _itemDictionary.Add("aragorn_hair", new Item(new Vector4(256, 416, 271, 431),OFFSET_X_8));
            _itemDictionary.Add("arwen_hair", new Item(new Vector4(272, 416, 287, 431),OFFSET_X_8));
            _itemDictionary.Add("boromir_hair", new Item(new Vector4(256, 432, 271, 447),OFFSET_X_8));
            _itemDictionary.Add("frodo_hair", new Item(new Vector4(272, 432, 287, 447),OFFSET_X_8));
            _itemDictionary.Add("legolas_hair", new Item(new Vector4(288, 416, 303, 431),OFFSET_X_8));
            _itemDictionary.Add("merry_hair", new Item(new Vector4(304, 416, 319, 431),OFFSET_X_8));
            _itemDictionary.Add("pj_hair", new Item(new Vector4(288, 432, 303, 447),OFFSET_X_8));
            _itemDictionary.Add("sam_hair", new Item(new Vector4(304, 432, 319, 447),OFFSET_X_8));

            //Beards
            _itemDictionary.Add("short_black_beard", new Item(new Vector4(320, 416, 335, 431),OFFSET_X_8));
            _itemDictionary.Add("short_red_beard", new Item(new Vector4(336, 416, 351, 431),OFFSET_X_8));
            _itemDictionary.Add("short_yellow_beard", new Item(new Vector4(320, 432, 335, 447),OFFSET_X_8));
            _itemDictionary.Add("short_white_beard", new Item(new Vector4(336, 432, 351, 447),OFFSET_X_8));
            _itemDictionary.Add("long_black_beard", new Item(new Vector4(352, 416, 367, 431),OFFSET_X_8));
            _itemDictionary.Add("long_red_beard", new Item(new Vector4(368, 416, 383, 431),OFFSET_X_8));
            _itemDictionary.Add("long_yellow_beard", new Item(new Vector4(352, 432, 367, 447),OFFSET_X_8));
            _itemDictionary.Add("long_white_beard", new Item(new Vector4(368, 432, 383, 447),OFFSET_X_8));
            _itemDictionary.Add("pj_beard", new Item(new Vector4(384, 416, 399, 431),OFFSET_X_8));


        }

        /// <summary>
        /// Returns the rectangle of the chosen race sprite
        /// </summary>
        /// <param name="raceName">Name of race being used</param>
        /// <returns>Rectangle of race sprite from sprite sheet</returns>
        public Rectangle GetSprite(String raceName)
        {
            Rectangle sprite = new Rectangle((int)_characters[raceName].X, (int)_characters[raceName].Y, 
                (int)(_characters[raceName].Z + 1 - _characters[raceName].X), 
                ((int)(_characters[raceName].W + 1 - _characters[raceName].Y)));
            return sprite;
        }

        /// <summary>
        /// Returns the rectangle of the item sprite
        /// </summary>
        /// <param name="spriteLoc">Location of sprite on sprite sheet</param>
        /// <returns>Rectangle of item sprite from the sprite sheet</returns>
        public Rectangle GetSprite(Vector4 spriteLoc)
        {
            Rectangle sprite = new Rectangle((int)spriteLoc.X, (int)spriteLoc.Y,
                (int)(spriteLoc.Z + 1 - spriteLoc.X),
                ((int)(spriteLoc.W + 1 - spriteLoc.Y)));
            return sprite;
        }

        /// <summary>
        /// Gets an item from the list of items
        /// </summary>
        /// <param name="item">The item to get</param>
        /// <returns>An item to be used</returns>
        public Item GetItem(String item)
        {
            return this._itemDictionary[item];
        }

        /// <summary>
        /// Gets a weapon from the list of weapons
        /// </summary>
        /// <param name="item">The weapon to get</param>
        /// <returns>A weapon to be used</returns>
        public Weapon GetWeapon(String item)
        {
            return this._weaponDictionary[item];
        }

        /// <summary>
        /// Gets an armor from the list of armors
        /// </summary>
        /// <param name="item">The armor to get</param>
        /// <returns>An armor to be used</returns>
        public Armor GetArmor(String item)
        {
            return this._armorDictionary[item];
        }

        /// <summary>
        /// Gets a focus from the list of foci
        /// </summary>
        /// <param name="item">The focus to get</param>
        /// <returns>A focus to be used</returns>
        public Focus GetFocus(String item)
        {
            return this._focusDictionary[item];
        }
            
    }
}
