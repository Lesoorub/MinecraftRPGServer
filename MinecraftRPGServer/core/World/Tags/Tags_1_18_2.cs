public static class Tags_1_18_2
{
    public enum TagType : byte
    {
        blocks,
        entity_types,
        fluids,
        game_events,
        items,
        worldgen
    }
    public static class blocks
    {
        public static readonly string[] acacia_logs_names = System.Enum.GetNames(typeof(acacia_logs));
        public enum acacia_logs : byte
        {
            acacia_log,
            acacia_wood,
            stripped_acacia_log,
            stripped_acacia_wood,
        }
        public static readonly string[] animals_spawnable_on_names = System.Enum.GetNames(typeof(animals_spawnable_on));
        public enum animals_spawnable_on : byte
        {
            grass_block,
        }
        public static readonly string[] anvil_names = System.Enum.GetNames(typeof(anvil));
        public enum anvil : byte
        {
            anvil,
            chipped_anvil,
            damaged_anvil,
        }
        public static readonly string[] axolotls_spawnable_on_names = System.Enum.GetNames(typeof(axolotls_spawnable_on));
        public enum axolotls_spawnable_on : byte
        {
            clay,
        }
        public static readonly string[] azalea_grows_on_names = System.Enum.GetNames(typeof(azalea_grows_on));
        public enum azalea_grows_on : byte
        {
            __dirt,
            __sand,
            __terracotta,
            snow_block,
            powder_snow,
        }
        public static readonly string[] azalea_root_replaceable_names = System.Enum.GetNames(typeof(azalea_root_replaceable));
        public enum azalea_root_replaceable : byte
        {
            __base_stone_overworld,
            __dirt,
            __terracotta,
            red_sand,
            clay,
            gravel,
            sand,
            snow_block,
            powder_snow,
        }
        public static readonly string[] bamboo_plantable_on_names = System.Enum.GetNames(typeof(bamboo_plantable_on));
        public enum bamboo_plantable_on : byte
        {
            __sand,
            __dirt,
            bamboo,
            bamboo_sapling,
            gravel,
        }
        public static readonly string[] banners_names = System.Enum.GetNames(typeof(banners));
        public enum banners : byte
        {
            white_banner,
            orange_banner,
            magenta_banner,
            light_blue_banner,
            yellow_banner,
            lime_banner,
            pink_banner,
            gray_banner,
            light_gray_banner,
            cyan_banner,
            purple_banner,
            blue_banner,
            brown_banner,
            green_banner,
            red_banner,
            black_banner,
            white_wall_banner,
            orange_wall_banner,
            magenta_wall_banner,
            light_blue_wall_banner,
            yellow_wall_banner,
            lime_wall_banner,
            pink_wall_banner,
            gray_wall_banner,
            light_gray_wall_banner,
            cyan_wall_banner,
            purple_wall_banner,
            blue_wall_banner,
            brown_wall_banner,
            green_wall_banner,
            red_wall_banner,
            black_wall_banner,
        }
        public static readonly string[] base_stone_nether_names = System.Enum.GetNames(typeof(base_stone_nether));
        public enum base_stone_nether : byte
        {
            netherrack,
            basalt,
            blackstone,
        }
        public static readonly string[] base_stone_overworld_names = System.Enum.GetNames(typeof(base_stone_overworld));
        public enum base_stone_overworld : byte
        {
            stone,
            granite,
            diorite,
            andesite,
            tuff,
            deepslate,
        }
        public static readonly string[] beacon_base_blocks_names = System.Enum.GetNames(typeof(beacon_base_blocks));
        public enum beacon_base_blocks : byte
        {
            netherite_block,
            emerald_block,
            diamond_block,
            gold_block,
            iron_block,
        }
        public static readonly string[] beds_names = System.Enum.GetNames(typeof(beds));
        public enum beds : byte
        {
            red_bed,
            black_bed,
            blue_bed,
            brown_bed,
            cyan_bed,
            gray_bed,
            green_bed,
            light_blue_bed,
            light_gray_bed,
            lime_bed,
            magenta_bed,
            orange_bed,
            pink_bed,
            purple_bed,
            white_bed,
            yellow_bed,
        }
        public static readonly string[] beehives_names = System.Enum.GetNames(typeof(beehives));
        public enum beehives : byte
        {
            bee_nest,
            beehive,
        }
        public static readonly string[] bee_growables_names = System.Enum.GetNames(typeof(bee_growables));
        public enum bee_growables : byte
        {
            __crops,
            sweet_berry_bush,
            cave_vines,
            cave_vines_plant,
        }
        public static readonly string[] big_dripleaf_placeable_names = System.Enum.GetNames(typeof(big_dripleaf_placeable));
        public enum big_dripleaf_placeable : byte
        {
            __small_dripleaf_placeable,
            __dirt,
            farmland,
        }
        public static readonly string[] birch_logs_names = System.Enum.GetNames(typeof(birch_logs));
        public enum birch_logs : byte
        {
            birch_log,
            birch_wood,
            stripped_birch_log,
            stripped_birch_wood,
        }
        public static readonly string[] buttons_names = System.Enum.GetNames(typeof(buttons));
        public enum buttons : byte
        {
            __wooden_buttons,
            stone_button,
            polished_blackstone_button,
        }
        public static readonly string[] campfires_names = System.Enum.GetNames(typeof(campfires));
        public enum campfires : byte
        {
            campfire,
            soul_campfire,
        }
        public static readonly string[] candles_names = System.Enum.GetNames(typeof(candles));
        public enum candles : byte
        {
            candle,
            white_candle,
            orange_candle,
            magenta_candle,
            light_blue_candle,
            yellow_candle,
            lime_candle,
            pink_candle,
            gray_candle,
            light_gray_candle,
            cyan_candle,
            purple_candle,
            blue_candle,
            brown_candle,
            green_candle,
            red_candle,
            black_candle,
        }
        public static readonly string[] candle_cakes_names = System.Enum.GetNames(typeof(candle_cakes));
        public enum candle_cakes : byte
        {
            candle_cake,
            white_candle_cake,
            orange_candle_cake,
            magenta_candle_cake,
            light_blue_candle_cake,
            yellow_candle_cake,
            lime_candle_cake,
            pink_candle_cake,
            gray_candle_cake,
            light_gray_candle_cake,
            cyan_candle_cake,
            purple_candle_cake,
            blue_candle_cake,
            brown_candle_cake,
            green_candle_cake,
            red_candle_cake,
            black_candle_cake,
        }
        public static readonly string[] carpets_names = System.Enum.GetNames(typeof(carpets));
        public enum carpets : byte
        {
            white_carpet,
            orange_carpet,
            magenta_carpet,
            light_blue_carpet,
            yellow_carpet,
            lime_carpet,
            pink_carpet,
            gray_carpet,
            light_gray_carpet,
            cyan_carpet,
            purple_carpet,
            blue_carpet,
            brown_carpet,
            green_carpet,
            red_carpet,
            black_carpet,
        }
        public static readonly string[] cauldrons_names = System.Enum.GetNames(typeof(cauldrons));
        public enum cauldrons : byte
        {
            cauldron,
            water_cauldron,
            lava_cauldron,
            powder_snow_cauldron,
        }
        public static readonly string[] cave_vines_names = System.Enum.GetNames(typeof(cave_vines));
        public enum cave_vines : byte
        {
            cave_vines_plant,
            cave_vines,
        }
        public static readonly string[] climbable_names = System.Enum.GetNames(typeof(climbable));
        public enum climbable : byte
        {
            ladder,
            vine,
            scaffolding,
            weeping_vines,
            weeping_vines_plant,
            twisting_vines,
            twisting_vines_plant,
            cave_vines,
            cave_vines_plant,
        }
        public static readonly string[] coal_ores_names = System.Enum.GetNames(typeof(coal_ores));
        public enum coal_ores : byte
        {
            coal_ore,
            deepslate_coal_ore,
        }
        public static readonly string[] copper_ores_names = System.Enum.GetNames(typeof(copper_ores));
        public enum copper_ores : byte
        {
            copper_ore,
            deepslate_copper_ore,
        }
        public static readonly string[] corals_names = System.Enum.GetNames(typeof(corals));
        public enum corals : byte
        {
            __coral_plants,
            tube_coral_fan,
            brain_coral_fan,
            bubble_coral_fan,
            fire_coral_fan,
            horn_coral_fan,
        }
        public static readonly string[] coral_blocks_names = System.Enum.GetNames(typeof(coral_blocks));
        public enum coral_blocks : byte
        {
            tube_coral_block,
            brain_coral_block,
            bubble_coral_block,
            fire_coral_block,
            horn_coral_block,
        }
        public static readonly string[] coral_plants_names = System.Enum.GetNames(typeof(coral_plants));
        public enum coral_plants : byte
        {
            tube_coral,
            brain_coral,
            bubble_coral,
            fire_coral,
            horn_coral,
        }
        public static readonly string[] crimson_stems_names = System.Enum.GetNames(typeof(crimson_stems));
        public enum crimson_stems : byte
        {
            crimson_stem,
            stripped_crimson_stem,
            crimson_hyphae,
            stripped_crimson_hyphae,
        }
        public static readonly string[] crops_names = System.Enum.GetNames(typeof(crops));
        public enum crops : byte
        {
            beetroots,
            carrots,
            potatoes,
            wheat,
            melon_stem,
            pumpkin_stem,
        }
        public static readonly string[] crystal_sound_blocks_names = System.Enum.GetNames(typeof(crystal_sound_blocks));
        public enum crystal_sound_blocks : byte
        {
            amethyst_block,
            budding_amethyst,
        }
        public static readonly string[] dark_oak_logs_names = System.Enum.GetNames(typeof(dark_oak_logs));
        public enum dark_oak_logs : byte
        {
            dark_oak_log,
            dark_oak_wood,
            stripped_dark_oak_log,
            stripped_dark_oak_wood,
        }
        public static readonly string[] deepslate_ore_replaceables_names = System.Enum.GetNames(typeof(deepslate_ore_replaceables));
        public enum deepslate_ore_replaceables : byte
        {
            deepslate,
            tuff,
        }
        public static readonly string[] diamond_ores_names = System.Enum.GetNames(typeof(diamond_ores));
        public enum diamond_ores : byte
        {
            diamond_ore,
            deepslate_diamond_ore,
        }
        public static readonly string[] dirt_names = System.Enum.GetNames(typeof(dirt));
        public enum dirt : byte
        {
            dirt,
            grass_block,
            podzol,
            coarse_dirt,
            mycelium,
            rooted_dirt,
            moss_block,
        }
        public static readonly string[] doors_names = System.Enum.GetNames(typeof(doors));
        public enum doors : byte
        {
            __wooden_doors,
            iron_door,
        }
        public static readonly string[] dragon_immune_names = System.Enum.GetNames(typeof(dragon_immune));
        public enum dragon_immune : byte
        {
            barrier,
            bedrock,
            end_portal,
            end_portal_frame,
            end_gateway,
            command_block,
            repeating_command_block,
            chain_command_block,
            structure_block,
            jigsaw,
            moving_piston,
            obsidian,
            crying_obsidian,
            end_stone,
            iron_bars,
            respawn_anchor,
        }
        public static readonly string[] dripstone_replaceable_blocks_names = System.Enum.GetNames(typeof(dripstone_replaceable_blocks));
        public enum dripstone_replaceable_blocks : byte
        {
            __base_stone_overworld,
        }
        public static readonly string[] emerald_ores_names = System.Enum.GetNames(typeof(emerald_ores));
        public enum emerald_ores : byte
        {
            emerald_ore,
            deepslate_emerald_ore,
        }
        public static readonly string[] enderman_holdable_names = System.Enum.GetNames(typeof(enderman_holdable));
        public enum enderman_holdable : byte
        {
            __small_flowers,
            __dirt,
            sand,
            red_sand,
            gravel,
            brown_mushroom,
            red_mushroom,
            tnt,
            cactus,
            clay,
            pumpkin,
            carved_pumpkin,
            melon,
            crimson_fungus,
            crimson_nylium,
            crimson_roots,
            warped_fungus,
            warped_nylium,
            warped_roots,
        }
        public static readonly string[] fall_damage_resetting_names = System.Enum.GetNames(typeof(fall_damage_resetting));
        public enum fall_damage_resetting : byte
        {
            __climbable,
            sweet_berry_bush,
            cobweb,
        }
        public static readonly string[] features_cannot_replace_names = System.Enum.GetNames(typeof(features_cannot_replace));
        public enum features_cannot_replace : byte
        {
            bedrock,
            spawner,
            chest,
            end_portal_frame,
        }
        public static readonly string[] fences_names = System.Enum.GetNames(typeof(fences));
        public enum fences : byte
        {
            __wooden_fences,
            nether_brick_fence,
        }
        public static readonly string[] fence_gates_names = System.Enum.GetNames(typeof(fence_gates));
        public enum fence_gates : byte
        {
            acacia_fence_gate,
            birch_fence_gate,
            dark_oak_fence_gate,
            jungle_fence_gate,
            oak_fence_gate,
            spruce_fence_gate,
            crimson_fence_gate,
            warped_fence_gate,
        }
        public static readonly string[] fire_names = System.Enum.GetNames(typeof(fire));
        public enum fire : byte
        {
            fire,
            soul_fire,
        }
        public static readonly string[] flowers_names = System.Enum.GetNames(typeof(flowers));
        public enum flowers : byte
        {
            __small_flowers,
            __tall_flowers,
            flowering_azalea_leaves,
            flowering_azalea,
        }
        public static readonly string[] flower_pots_names = System.Enum.GetNames(typeof(flower_pots));
        public enum flower_pots : byte
        {
            flower_pot,
            potted_poppy,
            potted_blue_orchid,
            potted_allium,
            potted_azure_bluet,
            potted_red_tulip,
            potted_orange_tulip,
            potted_white_tulip,
            potted_pink_tulip,
            potted_oxeye_daisy,
            potted_dandelion,
            potted_oak_sapling,
            potted_spruce_sapling,
            potted_birch_sapling,
            potted_jungle_sapling,
            potted_acacia_sapling,
            potted_dark_oak_sapling,
            potted_red_mushroom,
            potted_brown_mushroom,
            potted_dead_bush,
            potted_fern,
            potted_cactus,
            potted_cornflower,
            potted_lily_of_the_valley,
            potted_wither_rose,
            potted_bamboo,
            potted_crimson_fungus,
            potted_warped_fungus,
            potted_crimson_roots,
            potted_warped_roots,
            potted_azalea_bush,
            potted_flowering_azalea_bush,
        }
        public static readonly string[] foxes_spawnable_on_names = System.Enum.GetNames(typeof(foxes_spawnable_on));
        public enum foxes_spawnable_on : byte
        {
            grass_block,
            snow,
            snow_block,
            podzol,
            coarse_dirt,
        }
        public static readonly string[] geode_invalid_blocks_names = System.Enum.GetNames(typeof(geode_invalid_blocks));
        public enum geode_invalid_blocks : byte
        {
            bedrock,
            water,
            lava,
            ice,
            packed_ice,
            blue_ice,
        }
        public static readonly string[] goats_spawnable_on_names = System.Enum.GetNames(typeof(goats_spawnable_on));
        public enum goats_spawnable_on : byte
        {
            stone,
            snow,
            snow_block,
            packed_ice,
            gravel,
        }
        public static readonly string[] gold_ores_names = System.Enum.GetNames(typeof(gold_ores));
        public enum gold_ores : byte
        {
            gold_ore,
            nether_gold_ore,
            deepslate_gold_ore,
        }
        public static readonly string[] guarded_by_piglins_names = System.Enum.GetNames(typeof(guarded_by_piglins));
        public enum guarded_by_piglins : byte
        {
            gold_block,
            barrel,
            chest,
            ender_chest,
            gilded_blackstone,
            trapped_chest,
            raw_gold_block,
            __shulker_boxes,
            __gold_ores,
        }
        public static readonly string[] hoglin_repellents_names = System.Enum.GetNames(typeof(hoglin_repellents));
        public enum hoglin_repellents : byte
        {
            warped_fungus,
            potted_warped_fungus,
            nether_portal,
            respawn_anchor,
        }
        public static readonly string[] ice_names = System.Enum.GetNames(typeof(ice));
        public enum ice : byte
        {
            ice,
            packed_ice,
            blue_ice,
            frosted_ice,
        }
        public static readonly string[] impermeable_names = System.Enum.GetNames(typeof(impermeable));
        public enum impermeable : byte
        {
            glass,
            white_stained_glass,
            orange_stained_glass,
            magenta_stained_glass,
            light_blue_stained_glass,
            yellow_stained_glass,
            lime_stained_glass,
            pink_stained_glass,
            gray_stained_glass,
            light_gray_stained_glass,
            cyan_stained_glass,
            purple_stained_glass,
            blue_stained_glass,
            brown_stained_glass,
            green_stained_glass,
            red_stained_glass,
            black_stained_glass,
            tinted_glass,
        }
        public static readonly string[] infiniburn_end_names = System.Enum.GetNames(typeof(infiniburn_end));
        public enum infiniburn_end : byte
        {
            __infiniburn_overworld,
            bedrock,
        }
        public static readonly string[] infiniburn_nether_names = System.Enum.GetNames(typeof(infiniburn_nether));
        public enum infiniburn_nether : byte
        {
            __infiniburn_overworld,
        }
        public static readonly string[] infiniburn_overworld_names = System.Enum.GetNames(typeof(infiniburn_overworld));
        public enum infiniburn_overworld : byte
        {
            netherrack,
            magma_block,
        }
        public static readonly string[] inside_step_sound_blocks_names = System.Enum.GetNames(typeof(inside_step_sound_blocks));
        public enum inside_step_sound_blocks : byte
        {
            snow,
            powder_snow,
        }
        public static readonly string[] iron_ores_names = System.Enum.GetNames(typeof(iron_ores));
        public enum iron_ores : byte
        {
            iron_ore,
            deepslate_iron_ore,
        }
        public static readonly string[] jungle_logs_names = System.Enum.GetNames(typeof(jungle_logs));
        public enum jungle_logs : byte
        {
            jungle_log,
            jungle_wood,
            stripped_jungle_log,
            stripped_jungle_wood,
        }
        public static readonly string[] lapis_ores_names = System.Enum.GetNames(typeof(lapis_ores));
        public enum lapis_ores : byte
        {
            lapis_ore,
            deepslate_lapis_ore,
        }
        public static readonly string[] lava_pool_stone_cannot_replace_names = System.Enum.GetNames(typeof(lava_pool_stone_cannot_replace));
        public enum lava_pool_stone_cannot_replace : byte
        {
            __features_cannot_replace,
            __leaves,
            __logs,
        }
        public static readonly string[] leaves_names = System.Enum.GetNames(typeof(leaves));
        public enum leaves : byte
        {
            jungle_leaves,
            oak_leaves,
            spruce_leaves,
            dark_oak_leaves,
            acacia_leaves,
            birch_leaves,
            azalea_leaves,
            flowering_azalea_leaves,
        }
        public static readonly string[] logs_names = System.Enum.GetNames(typeof(logs));
        public enum logs : byte
        {
            __logs_that_burn,
            __crimson_stems,
            __warped_stems,
        }
        public static readonly string[] logs_that_burn_names = System.Enum.GetNames(typeof(logs_that_burn));
        public enum logs_that_burn : byte
        {
            __dark_oak_logs,
            __oak_logs,
            __acacia_logs,
            __birch_logs,
            __jungle_logs,
            __spruce_logs,
        }
        public static readonly string[] lush_ground_replaceable_names = System.Enum.GetNames(typeof(lush_ground_replaceable));
        public enum lush_ground_replaceable : byte
        {
            __moss_replaceable,
            clay,
            gravel,
            sand,
        }
        public static readonly string[] mooshrooms_spawnable_on_names = System.Enum.GetNames(typeof(mooshrooms_spawnable_on));
        public enum mooshrooms_spawnable_on : byte
        {
            mycelium,
        }
        public static readonly string[] moss_replaceable_names = System.Enum.GetNames(typeof(moss_replaceable));
        public enum moss_replaceable : byte
        {
            __base_stone_overworld,
            __cave_vines,
            __dirt,
        }
        public static readonly string[] mushroom_grow_block_names = System.Enum.GetNames(typeof(mushroom_grow_block));
        public enum mushroom_grow_block : byte
        {
            mycelium,
            podzol,
            crimson_nylium,
            warped_nylium,
        }
        public static readonly string[] needs_diamond_tool_names = System.Enum.GetNames(typeof(needs_diamond_tool));
        public enum needs_diamond_tool : byte
        {
            obsidian,
            crying_obsidian,
            netherite_block,
            respawn_anchor,
            ancient_debris,
        }
        public static readonly string[] needs_iron_tool_names = System.Enum.GetNames(typeof(needs_iron_tool));
        public enum needs_iron_tool : byte
        {
            diamond_block,
            diamond_ore,
            deepslate_diamond_ore,
            emerald_ore,
            deepslate_emerald_ore,
            emerald_block,
            gold_block,
            raw_gold_block,
            gold_ore,
            deepslate_gold_ore,
            redstone_ore,
            deepslate_redstone_ore,
        }
        public static readonly string[] needs_stone_tool_names = System.Enum.GetNames(typeof(needs_stone_tool));
        public enum needs_stone_tool : byte
        {
            iron_block,
            raw_iron_block,
            iron_ore,
            deepslate_iron_ore,
            lapis_block,
            lapis_ore,
            deepslate_lapis_ore,
            copper_block,
            raw_copper_block,
            copper_ore,
            deepslate_copper_ore,
            cut_copper_slab,
            cut_copper_stairs,
            cut_copper,
            weathered_copper,
            weathered_cut_copper_slab,
            weathered_cut_copper_stairs,
            weathered_cut_copper,
            oxidized_copper,
            oxidized_cut_copper_slab,
            oxidized_cut_copper_stairs,
            oxidized_cut_copper,
            exposed_copper,
            exposed_cut_copper_slab,
            exposed_cut_copper_stairs,
            exposed_cut_copper,
            waxed_copper_block,
            waxed_cut_copper_slab,
            waxed_cut_copper_stairs,
            waxed_cut_copper,
            waxed_weathered_copper,
            waxed_weathered_cut_copper_slab,
            waxed_weathered_cut_copper_stairs,
            waxed_weathered_cut_copper,
            waxed_exposed_copper,
            waxed_exposed_cut_copper_slab,
            waxed_exposed_cut_copper_stairs,
            waxed_exposed_cut_copper,
            waxed_oxidized_copper,
            waxed_oxidized_cut_copper_slab,
            waxed_oxidized_cut_copper_stairs,
            waxed_oxidized_cut_copper,
            lightning_rod,
        }
        public static readonly string[] non_flammable_wood_names = System.Enum.GetNames(typeof(non_flammable_wood));
        public enum non_flammable_wood : byte
        {
            warped_stem,
            stripped_warped_stem,
            warped_hyphae,
            stripped_warped_hyphae,
            crimson_stem,
            stripped_crimson_stem,
            crimson_hyphae,
            stripped_crimson_hyphae,
            crimson_planks,
            warped_planks,
            crimson_slab,
            warped_slab,
            crimson_pressure_plate,
            warped_pressure_plate,
            crimson_fence,
            warped_fence,
            crimson_trapdoor,
            warped_trapdoor,
            crimson_fence_gate,
            warped_fence_gate,
            crimson_stairs,
            warped_stairs,
            crimson_button,
            warped_button,
            crimson_door,
            warped_door,
            crimson_sign,
            warped_sign,
            crimson_wall_sign,
            warped_wall_sign,
        }
        public static readonly string[] nylium_names = System.Enum.GetNames(typeof(nylium));
        public enum nylium : byte
        {
            crimson_nylium,
            warped_nylium,
        }
        public static readonly string[] oak_logs_names = System.Enum.GetNames(typeof(oak_logs));
        public enum oak_logs : byte
        {
            oak_log,
            oak_wood,
            stripped_oak_log,
            stripped_oak_wood,
        }
        public static readonly string[] occludes_vibration_signals_names = System.Enum.GetNames(typeof(occludes_vibration_signals));
        public enum occludes_vibration_signals : byte
        {
            __wool,
        }
        public static readonly string[] parrots_spawnable_on_names = System.Enum.GetNames(typeof(parrots_spawnable_on));
        public enum parrots_spawnable_on : byte
        {
            grass_block,
            air,
            __leaves,
            __logs,
        }
        public static readonly string[] piglin_repellents_names = System.Enum.GetNames(typeof(piglin_repellents));
        public enum piglin_repellents : byte
        {
            soul_fire,
            soul_torch,
            soul_lantern,
            soul_wall_torch,
            soul_campfire,
        }
        public static readonly string[] planks_names = System.Enum.GetNames(typeof(planks));
        public enum planks : byte
        {
            oak_planks,
            spruce_planks,
            birch_planks,
            jungle_planks,
            acacia_planks,
            dark_oak_planks,
            crimson_planks,
            warped_planks,
        }
        public static readonly string[] polar_bears_spawnable_on_in_frozen_ocean_names = System.Enum.GetNames(typeof(polar_bears_spawnable_on_in_frozen_ocean));
        public enum polar_bears_spawnable_on_in_frozen_ocean : byte
        {
            ice,
        }
        public static readonly string[] portals_names = System.Enum.GetNames(typeof(portals));
        public enum portals : byte
        {
            nether_portal,
            end_portal,
            end_gateway,
        }
        public static readonly string[] pressure_plates_names = System.Enum.GetNames(typeof(pressure_plates));
        public enum pressure_plates : byte
        {
            light_weighted_pressure_plate,
            heavy_weighted_pressure_plate,
            __wooden_pressure_plates,
            __stone_pressure_plates,
        }
        public static readonly string[] prevent_mob_spawning_inside_names = System.Enum.GetNames(typeof(prevent_mob_spawning_inside));
        public enum prevent_mob_spawning_inside : byte
        {
            __rails,
        }
        public static readonly string[] rabbits_spawnable_on_names = System.Enum.GetNames(typeof(rabbits_spawnable_on));
        public enum rabbits_spawnable_on : byte
        {
            grass_block,
            snow,
            snow_block,
            sand,
        }
        public static readonly string[] rails_names = System.Enum.GetNames(typeof(rails));
        public enum rails : byte
        {
            rail,
            powered_rail,
            detector_rail,
            activator_rail,
        }
        public static readonly string[] redstone_ores_names = System.Enum.GetNames(typeof(redstone_ores));
        public enum redstone_ores : byte
        {
            redstone_ore,
            deepslate_redstone_ore,
        }
        public static readonly string[] replaceable_plants_names = System.Enum.GetNames(typeof(replaceable_plants));
        public enum replaceable_plants : byte
        {
            grass,
            fern,
            dead_bush,
            vine,
            glow_lichen,
            sunflower,
            lilac,
            rose_bush,
            peony,
            tall_grass,
            large_fern,
            hanging_roots,
        }
        public static readonly string[] sand_names = System.Enum.GetNames(typeof(sand));
        public enum sand : byte
        {
            sand,
            red_sand,
        }
        public static readonly string[] saplings_names = System.Enum.GetNames(typeof(saplings));
        public enum saplings : byte
        {
            oak_sapling,
            spruce_sapling,
            birch_sapling,
            jungle_sapling,
            acacia_sapling,
            dark_oak_sapling,
            azalea,
            flowering_azalea,
        }
        public static readonly string[] shulker_boxes_names = System.Enum.GetNames(typeof(shulker_boxes));
        public enum shulker_boxes : byte
        {
            shulker_box,
            black_shulker_box,
            blue_shulker_box,
            brown_shulker_box,
            cyan_shulker_box,
            gray_shulker_box,
            green_shulker_box,
            light_blue_shulker_box,
            light_gray_shulker_box,
            lime_shulker_box,
            magenta_shulker_box,
            orange_shulker_box,
            pink_shulker_box,
            purple_shulker_box,
            red_shulker_box,
            white_shulker_box,
            yellow_shulker_box,
        }
        public static readonly string[] signs_names = System.Enum.GetNames(typeof(signs));
        public enum signs : byte
        {
            __standing_signs,
            __wall_signs,
        }
        public static readonly string[] slabs_names = System.Enum.GetNames(typeof(slabs));
        public enum slabs : byte
        {
            __wooden_slabs,
            stone_slab,
            smooth_stone_slab,
            stone_brick_slab,
            sandstone_slab,
            purpur_slab,
            quartz_slab,
            red_sandstone_slab,
            brick_slab,
            cobblestone_slab,
            nether_brick_slab,
            petrified_oak_slab,
            prismarine_slab,
            prismarine_brick_slab,
            dark_prismarine_slab,
            polished_granite_slab,
            smooth_red_sandstone_slab,
            mossy_stone_brick_slab,
            polished_diorite_slab,
            mossy_cobblestone_slab,
            end_stone_brick_slab,
            smooth_sandstone_slab,
            smooth_quartz_slab,
            granite_slab,
            andesite_slab,
            red_nether_brick_slab,
            polished_andesite_slab,
            diorite_slab,
            cut_sandstone_slab,
            cut_red_sandstone_slab,
            blackstone_slab,
            polished_blackstone_brick_slab,
            polished_blackstone_slab,
            cobbled_deepslate_slab,
            polished_deepslate_slab,
            deepslate_tile_slab,
            deepslate_brick_slab,
            waxed_weathered_cut_copper_slab,
            waxed_exposed_cut_copper_slab,
            waxed_cut_copper_slab,
            oxidized_cut_copper_slab,
            weathered_cut_copper_slab,
            exposed_cut_copper_slab,
            cut_copper_slab,
            waxed_oxidized_cut_copper_slab,
        }
        public static readonly string[] small_dripleaf_placeable_names = System.Enum.GetNames(typeof(small_dripleaf_placeable));
        public enum small_dripleaf_placeable : byte
        {
            clay,
            moss_block,
        }
        public static readonly string[] small_flowers_names = System.Enum.GetNames(typeof(small_flowers));
        public enum small_flowers : byte
        {
            dandelion,
            poppy,
            blue_orchid,
            allium,
            azure_bluet,
            red_tulip,
            orange_tulip,
            white_tulip,
            pink_tulip,
            oxeye_daisy,
            cornflower,
            lily_of_the_valley,
            wither_rose,
        }
        public static readonly string[] snow_names = System.Enum.GetNames(typeof(snow));
        public enum snow : byte
        {
            snow,
            snow_block,
            powder_snow,
        }
        public static readonly string[] soul_fire_base_blocks_names = System.Enum.GetNames(typeof(soul_fire_base_blocks));
        public enum soul_fire_base_blocks : byte
        {
            soul_sand,
            soul_soil,
        }
        public static readonly string[] soul_speed_blocks_names = System.Enum.GetNames(typeof(soul_speed_blocks));
        public enum soul_speed_blocks : byte
        {
            soul_sand,
            soul_soil,
        }
        public static readonly string[] spruce_logs_names = System.Enum.GetNames(typeof(spruce_logs));
        public enum spruce_logs : byte
        {
            spruce_log,
            spruce_wood,
            stripped_spruce_log,
            stripped_spruce_wood,
        }
        public static readonly string[] stairs_names = System.Enum.GetNames(typeof(stairs));
        public enum stairs : byte
        {
            __wooden_stairs,
            cobblestone_stairs,
            sandstone_stairs,
            nether_brick_stairs,
            stone_brick_stairs,
            brick_stairs,
            purpur_stairs,
            quartz_stairs,
            red_sandstone_stairs,
            prismarine_brick_stairs,
            prismarine_stairs,
            dark_prismarine_stairs,
            polished_granite_stairs,
            smooth_red_sandstone_stairs,
            mossy_stone_brick_stairs,
            polished_diorite_stairs,
            mossy_cobblestone_stairs,
            end_stone_brick_stairs,
            stone_stairs,
            smooth_sandstone_stairs,
            smooth_quartz_stairs,
            granite_stairs,
            andesite_stairs,
            red_nether_brick_stairs,
            polished_andesite_stairs,
            diorite_stairs,
            blackstone_stairs,
            polished_blackstone_brick_stairs,
            polished_blackstone_stairs,
            cobbled_deepslate_stairs,
            polished_deepslate_stairs,
            deepslate_tile_stairs,
            deepslate_brick_stairs,
            oxidized_cut_copper_stairs,
            weathered_cut_copper_stairs,
            exposed_cut_copper_stairs,
            cut_copper_stairs,
            waxed_weathered_cut_copper_stairs,
            waxed_exposed_cut_copper_stairs,
            waxed_cut_copper_stairs,
            waxed_oxidized_cut_copper_stairs,
        }
        public static readonly string[] standing_signs_names = System.Enum.GetNames(typeof(standing_signs));
        public enum standing_signs : byte
        {
            oak_sign,
            spruce_sign,
            birch_sign,
            acacia_sign,
            jungle_sign,
            dark_oak_sign,
            crimson_sign,
            warped_sign,
        }
        public static readonly string[] stone_bricks_names = System.Enum.GetNames(typeof(stone_bricks));
        public enum stone_bricks : byte
        {
            stone_bricks,
            mossy_stone_bricks,
            cracked_stone_bricks,
            chiseled_stone_bricks,
        }
        public static readonly string[] stone_ore_replaceables_names = System.Enum.GetNames(typeof(stone_ore_replaceables));
        public enum stone_ore_replaceables : byte
        {
            stone,
            granite,
            diorite,
            andesite,
        }
        public static readonly string[] stone_pressure_plates_names = System.Enum.GetNames(typeof(stone_pressure_plates));
        public enum stone_pressure_plates : byte
        {
            stone_pressure_plate,
            polished_blackstone_pressure_plate,
        }
        public static readonly string[] strider_warm_blocks_names = System.Enum.GetNames(typeof(strider_warm_blocks));
        public enum strider_warm_blocks : byte
        {
            lava,
        }
        public static readonly string[] tall_flowers_names = System.Enum.GetNames(typeof(tall_flowers));
        public enum tall_flowers : byte
        {
            sunflower,
            lilac,
            peony,
            rose_bush,
        }
        public static readonly string[] terracotta_names = System.Enum.GetNames(typeof(terracotta));
        public enum terracotta : byte
        {
            terracotta,
            white_terracotta,
            orange_terracotta,
            magenta_terracotta,
            light_blue_terracotta,
            yellow_terracotta,
            lime_terracotta,
            pink_terracotta,
            gray_terracotta,
            light_gray_terracotta,
            cyan_terracotta,
            purple_terracotta,
            blue_terracotta,
            brown_terracotta,
            green_terracotta,
            red_terracotta,
            black_terracotta,
        }
        public static readonly string[] trapdoors_names = System.Enum.GetNames(typeof(trapdoors));
        public enum trapdoors : byte
        {
            __wooden_trapdoors,
            iron_trapdoor,
        }
        public static readonly string[] underwater_bonemeals_names = System.Enum.GetNames(typeof(underwater_bonemeals));
        public enum underwater_bonemeals : byte
        {
            seagrass,
            __corals,
            __wall_corals,
        }
        public static readonly string[] unstable_bottom_center_names = System.Enum.GetNames(typeof(unstable_bottom_center));
        public enum unstable_bottom_center : byte
        {
            __fence_gates,
        }
        public static readonly string[] valid_spawn_names = System.Enum.GetNames(typeof(valid_spawn));
        public enum valid_spawn : byte
        {
            grass_block,
            podzol,
        }
        public static readonly string[] walls_names = System.Enum.GetNames(typeof(walls));
        public enum walls : byte
        {
            cobblestone_wall,
            mossy_cobblestone_wall,
            brick_wall,
            prismarine_wall,
            red_sandstone_wall,
            mossy_stone_brick_wall,
            granite_wall,
            stone_brick_wall,
            nether_brick_wall,
            andesite_wall,
            red_nether_brick_wall,
            sandstone_wall,
            end_stone_brick_wall,
            diorite_wall,
            blackstone_wall,
            polished_blackstone_brick_wall,
            polished_blackstone_wall,
            cobbled_deepslate_wall,
            polished_deepslate_wall,
            deepslate_tile_wall,
            deepslate_brick_wall,
        }
        public static readonly string[] wall_corals_names = System.Enum.GetNames(typeof(wall_corals));
        public enum wall_corals : byte
        {
            tube_coral_wall_fan,
            brain_coral_wall_fan,
            bubble_coral_wall_fan,
            fire_coral_wall_fan,
            horn_coral_wall_fan,
        }
        public static readonly string[] wall_post_override_names = System.Enum.GetNames(typeof(wall_post_override));
        public enum wall_post_override : byte
        {
            torch,
            soul_torch,
            redstone_torch,
            tripwire,
            __signs,
            __banners,
            __pressure_plates,
        }
        public static readonly string[] wall_signs_names = System.Enum.GetNames(typeof(wall_signs));
        public enum wall_signs : byte
        {
            oak_wall_sign,
            spruce_wall_sign,
            birch_wall_sign,
            acacia_wall_sign,
            jungle_wall_sign,
            dark_oak_wall_sign,
            crimson_wall_sign,
            warped_wall_sign,
        }
        public static readonly string[] warped_stems_names = System.Enum.GetNames(typeof(warped_stems));
        public enum warped_stems : byte
        {
            warped_stem,
            stripped_warped_stem,
            warped_hyphae,
            stripped_warped_hyphae,
        }
        public static readonly string[] wart_blocks_names = System.Enum.GetNames(typeof(wart_blocks));
        public enum wart_blocks : byte
        {
            nether_wart_block,
            warped_wart_block,
        }
        public static readonly string[] wither_immune_names = System.Enum.GetNames(typeof(wither_immune));
        public enum wither_immune : byte
        {
            barrier,
            bedrock,
            end_portal,
            end_portal_frame,
            end_gateway,
            command_block,
            repeating_command_block,
            chain_command_block,
            structure_block,
            jigsaw,
            moving_piston,
        }
        public static readonly string[] wither_summon_base_blocks_names = System.Enum.GetNames(typeof(wither_summon_base_blocks));
        public enum wither_summon_base_blocks : byte
        {
            soul_sand,
            soul_soil,
        }
        public static readonly string[] wolves_spawnable_on_names = System.Enum.GetNames(typeof(wolves_spawnable_on));
        public enum wolves_spawnable_on : byte
        {
            grass_block,
            snow,
            snow_block,
        }
        public static readonly string[] wooden_buttons_names = System.Enum.GetNames(typeof(wooden_buttons));
        public enum wooden_buttons : byte
        {
            oak_button,
            spruce_button,
            birch_button,
            jungle_button,
            acacia_button,
            dark_oak_button,
            crimson_button,
            warped_button,
        }
        public static readonly string[] wooden_doors_names = System.Enum.GetNames(typeof(wooden_doors));
        public enum wooden_doors : byte
        {
            oak_door,
            spruce_door,
            birch_door,
            jungle_door,
            acacia_door,
            dark_oak_door,
            crimson_door,
            warped_door,
        }
        public static readonly string[] wooden_fences_names = System.Enum.GetNames(typeof(wooden_fences));
        public enum wooden_fences : byte
        {
            oak_fence,
            acacia_fence,
            dark_oak_fence,
            spruce_fence,
            birch_fence,
            jungle_fence,
            crimson_fence,
            warped_fence,
        }
        public static readonly string[] wooden_pressure_plates_names = System.Enum.GetNames(typeof(wooden_pressure_plates));
        public enum wooden_pressure_plates : byte
        {
            oak_pressure_plate,
            spruce_pressure_plate,
            birch_pressure_plate,
            jungle_pressure_plate,
            acacia_pressure_plate,
            dark_oak_pressure_plate,
            crimson_pressure_plate,
            warped_pressure_plate,
        }
        public static readonly string[] wooden_slabs_names = System.Enum.GetNames(typeof(wooden_slabs));
        public enum wooden_slabs : byte
        {
            oak_slab,
            spruce_slab,
            birch_slab,
            jungle_slab,
            acacia_slab,
            dark_oak_slab,
            crimson_slab,
            warped_slab,
        }
        public static readonly string[] wooden_stairs_names = System.Enum.GetNames(typeof(wooden_stairs));
        public enum wooden_stairs : byte
        {
            oak_stairs,
            spruce_stairs,
            birch_stairs,
            jungle_stairs,
            acacia_stairs,
            dark_oak_stairs,
            crimson_stairs,
            warped_stairs,
        }
        public static readonly string[] wooden_trapdoors_names = System.Enum.GetNames(typeof(wooden_trapdoors));
        public enum wooden_trapdoors : byte
        {
            acacia_trapdoor,
            birch_trapdoor,
            dark_oak_trapdoor,
            jungle_trapdoor,
            oak_trapdoor,
            spruce_trapdoor,
            crimson_trapdoor,
            warped_trapdoor,
        }
        public static readonly string[] wool_names = System.Enum.GetNames(typeof(wool));
        public enum wool : byte
        {
            white_wool,
            orange_wool,
            magenta_wool,
            light_blue_wool,
            yellow_wool,
            lime_wool,
            pink_wool,
            gray_wool,
            light_gray_wool,
            cyan_wool,
            purple_wool,
            blue_wool,
            brown_wool,
            green_wool,
            red_wool,
            black_wool,
        }
        public static class mineable
        {
            public static readonly string[] axe_names = System.Enum.GetNames(typeof(axe));
            public enum axe : byte
            {
                note_block,
                attached_melon_stem,
                attached_pumpkin_stem,
                azalea,
                bamboo,
                barrel,
                bee_nest,
                beehive,
                beetroots,
                big_dripleaf_stem,
                big_dripleaf,
                bookshelf,
                brown_mushroom_block,
                brown_mushroom,
                campfire,
                carrots,
                cartography_table,
                carved_pumpkin,
                cave_vines_plant,
                cave_vines,
                chest,
                chorus_flower,
                chorus_plant,
                cocoa,
                composter,
                crafting_table,
                crimson_fungus,
                daylight_detector,
                dead_bush,
                fern,
                fletching_table,
                glow_lichen,
                grass,
                hanging_roots,
                jack_o_lantern,
                jukebox,
                ladder,
                large_fern,
                lectern,
                lily_pad,
                loom,
                melon_stem,
                melon,
                mushroom_stem,
                nether_wart,
                potatoes,
                pumpkin_stem,
                pumpkin,
                red_mushroom_block,
                red_mushroom,
                scaffolding,
                small_dripleaf,
                smithing_table,
                soul_campfire,
                spore_blossom,
                sugar_cane,
                sweet_berry_bush,
                tall_grass,
                trapped_chest,
                twisting_vines_plant,
                twisting_vines,
                vine,
                warped_fungus,
                weeping_vines_plant,
                weeping_vines,
                wheat,
                __banners,
                __fence_gates,
                __logs,
                __planks,
                __saplings,
                __signs,
                __wooden_buttons,
                __wooden_doors,
                __wooden_fences,
                __wooden_pressure_plates,
                __wooden_slabs,
                __wooden_stairs,
                __wooden_trapdoors,
            }
            public static readonly string[] hoe_names = System.Enum.GetNames(typeof(hoe));
            public enum hoe : byte
            {
                nether_wart_block,
                warped_wart_block,
                hay_block,
                dried_kelp_block,
                target,
                shroomlight,
                sponge,
                wet_sponge,
                jungle_leaves,
                oak_leaves,
                spruce_leaves,
                dark_oak_leaves,
                acacia_leaves,
                birch_leaves,
                azalea_leaves,
                flowering_azalea_leaves,
                sculk_sensor,
                moss_block,
                moss_carpet,
            }
            public static readonly string[] pickaxe_names = System.Enum.GetNames(typeof(pickaxe));
            public enum pickaxe : short
            {
                stone,
                granite,
                polished_granite,
                diorite,
                polished_diorite,
                andesite,
                polished_andesite,
                cobblestone,
                gold_ore,
                deepslate_gold_ore,
                iron_ore,
                deepslate_iron_ore,
                coal_ore,
                deepslate_coal_ore,
                nether_gold_ore,
                lapis_ore,
                deepslate_lapis_ore,
                lapis_block,
                dispenser,
                sandstone,
                chiseled_sandstone,
                cut_sandstone,
                gold_block,
                iron_block,
                bricks,
                mossy_cobblestone,
                obsidian,
                spawner,
                diamond_ore,
                deepslate_diamond_ore,
                diamond_block,
                furnace,
                cobblestone_stairs,
                stone_pressure_plate,
                iron_door,
                redstone_ore,
                deepslate_redstone_ore,
                netherrack,
                basalt,
                polished_basalt,
                stone_bricks,
                mossy_stone_bricks,
                cracked_stone_bricks,
                chiseled_stone_bricks,
                iron_bars,
                chain,
                brick_stairs,
                stone_brick_stairs,
                nether_bricks,
                nether_brick_fence,
                nether_brick_stairs,
                enchanting_table,
                brewing_stand,
                end_stone,
                sandstone_stairs,
                emerald_ore,
                deepslate_emerald_ore,
                ender_chest,
                emerald_block,
                light_weighted_pressure_plate,
                heavy_weighted_pressure_plate,
                redstone_block,
                nether_quartz_ore,
                hopper,
                quartz_block,
                chiseled_quartz_block,
                quartz_pillar,
                quartz_stairs,
                dropper,
                white_terracotta,
                orange_terracotta,
                magenta_terracotta,
                light_blue_terracotta,
                yellow_terracotta,
                lime_terracotta,
                pink_terracotta,
                gray_terracotta,
                light_gray_terracotta,
                cyan_terracotta,
                purple_terracotta,
                blue_terracotta,
                brown_terracotta,
                green_terracotta,
                red_terracotta,
                black_terracotta,
                iron_trapdoor,
                prismarine,
                prismarine_bricks,
                dark_prismarine,
                prismarine_stairs,
                prismarine_brick_stairs,
                dark_prismarine_stairs,
                prismarine_slab,
                prismarine_brick_slab,
                dark_prismarine_slab,
                terracotta,
                coal_block,
                red_sandstone,
                chiseled_red_sandstone,
                cut_red_sandstone,
                red_sandstone_stairs,
                stone_slab,
                smooth_stone_slab,
                sandstone_slab,
                cut_sandstone_slab,
                petrified_oak_slab,
                cobblestone_slab,
                brick_slab,
                stone_brick_slab,
                nether_brick_slab,
                quartz_slab,
                red_sandstone_slab,
                cut_red_sandstone_slab,
                purpur_slab,
                smooth_stone,
                smooth_sandstone,
                smooth_quartz,
                smooth_red_sandstone,
                purpur_block,
                purpur_pillar,
                purpur_stairs,
                end_stone_bricks,
                magma_block,
                red_nether_bricks,
                bone_block,
                observer,
                white_glazed_terracotta,
                orange_glazed_terracotta,
                magenta_glazed_terracotta,
                light_blue_glazed_terracotta,
                yellow_glazed_terracotta,
                lime_glazed_terracotta,
                pink_glazed_terracotta,
                gray_glazed_terracotta,
                light_gray_glazed_terracotta,
                cyan_glazed_terracotta,
                purple_glazed_terracotta,
                blue_glazed_terracotta,
                brown_glazed_terracotta,
                green_glazed_terracotta,
                red_glazed_terracotta,
                black_glazed_terracotta,
                white_concrete,
                orange_concrete,
                magenta_concrete,
                light_blue_concrete,
                yellow_concrete,
                lime_concrete,
                pink_concrete,
                gray_concrete,
                light_gray_concrete,
                cyan_concrete,
                purple_concrete,
                blue_concrete,
                brown_concrete,
                green_concrete,
                red_concrete,
                black_concrete,
                dead_tube_coral_block,
                dead_brain_coral_block,
                dead_bubble_coral_block,
                dead_fire_coral_block,
                dead_horn_coral_block,
                tube_coral_block,
                brain_coral_block,
                bubble_coral_block,
                fire_coral_block,
                horn_coral_block,
                dead_tube_coral,
                dead_brain_coral,
                dead_bubble_coral,
                dead_fire_coral,
                dead_horn_coral,
                dead_tube_coral_fan,
                dead_brain_coral_fan,
                dead_bubble_coral_fan,
                dead_fire_coral_fan,
                dead_horn_coral_fan,
                dead_tube_coral_wall_fan,
                dead_brain_coral_wall_fan,
                dead_bubble_coral_wall_fan,
                dead_fire_coral_wall_fan,
                dead_horn_coral_wall_fan,
                polished_granite_stairs,
                smooth_red_sandstone_stairs,
                mossy_stone_brick_stairs,
                polished_diorite_stairs,
                mossy_cobblestone_stairs,
                end_stone_brick_stairs,
                stone_stairs,
                smooth_sandstone_stairs,
                smooth_quartz_stairs,
                granite_stairs,
                andesite_stairs,
                red_nether_brick_stairs,
                polished_andesite_stairs,
                diorite_stairs,
                polished_granite_slab,
                smooth_red_sandstone_slab,
                mossy_stone_brick_slab,
                polished_diorite_slab,
                mossy_cobblestone_slab,
                end_stone_brick_slab,
                smooth_sandstone_slab,
                smooth_quartz_slab,
                granite_slab,
                andesite_slab,
                red_nether_brick_slab,
                polished_andesite_slab,
                diorite_slab,
                smoker,
                blast_furnace,
                grindstone,
                stonecutter,
                bell,
                lantern,
                soul_lantern,
                warped_nylium,
                crimson_nylium,
                netherite_block,
                ancient_debris,
                crying_obsidian,
                respawn_anchor,
                lodestone,
                blackstone,
                blackstone_stairs,
                blackstone_slab,
                polished_blackstone,
                polished_blackstone_bricks,
                cracked_polished_blackstone_bricks,
                chiseled_polished_blackstone,
                polished_blackstone_brick_slab,
                polished_blackstone_brick_stairs,
                gilded_blackstone,
                polished_blackstone_stairs,
                polished_blackstone_slab,
                polished_blackstone_pressure_plate,
                chiseled_nether_bricks,
                cracked_nether_bricks,
                quartz_bricks,
                tuff,
                calcite,
                oxidized_copper,
                weathered_copper,
                exposed_copper,
                copper_block,
                copper_ore,
                deepslate_copper_ore,
                oxidized_cut_copper,
                weathered_cut_copper,
                exposed_cut_copper,
                cut_copper,
                oxidized_cut_copper_stairs,
                weathered_cut_copper_stairs,
                exposed_cut_copper_stairs,
                cut_copper_stairs,
                oxidized_cut_copper_slab,
                weathered_cut_copper_slab,
                exposed_cut_copper_slab,
                cut_copper_slab,
                waxed_copper_block,
                waxed_weathered_copper,
                waxed_exposed_copper,
                waxed_oxidized_copper,
                waxed_oxidized_cut_copper,
                waxed_weathered_cut_copper,
                waxed_exposed_cut_copper,
                waxed_cut_copper,
                waxed_oxidized_cut_copper_stairs,
                waxed_weathered_cut_copper_stairs,
                waxed_exposed_cut_copper_stairs,
                waxed_cut_copper_stairs,
                waxed_oxidized_cut_copper_slab,
                waxed_weathered_cut_copper_slab,
                waxed_exposed_cut_copper_slab,
                waxed_cut_copper_slab,
                lightning_rod,
                pointed_dripstone,
                dripstone_block,
                deepslate,
                cobbled_deepslate,
                cobbled_deepslate_stairs,
                cobbled_deepslate_slab,
                polished_deepslate,
                polished_deepslate_stairs,
                polished_deepslate_slab,
                deepslate_tiles,
                deepslate_tile_stairs,
                deepslate_tile_slab,
                deepslate_bricks,
                deepslate_brick_stairs,
                deepslate_brick_slab,
                chiseled_deepslate,
                cracked_deepslate_bricks,
                cracked_deepslate_tiles,
                smooth_basalt,
                raw_iron_block,
                raw_copper_block,
                raw_gold_block,
                ice,
                packed_ice,
                blue_ice,
                stone_button,
                piston,
                sticky_piston,
                piston_head,
                amethyst_cluster,
                small_amethyst_bud,
                medium_amethyst_bud,
                large_amethyst_bud,
                amethyst_block,
                budding_amethyst,
                infested_cobblestone,
                infested_chiseled_stone_bricks,
                infested_cracked_stone_bricks,
                infested_deepslate,
                infested_stone,
                infested_mossy_stone_bricks,
                infested_stone_bricks,
                __walls,
                __shulker_boxes,
                __anvil,
                __cauldrons,
                __rails,
                conduit,
            }
            public static readonly string[] shovel_names = System.Enum.GetNames(typeof(shovel));
            public enum shovel : byte
            {
                clay,
                dirt,
                coarse_dirt,
                podzol,
                farmland,
                grass_block,
                gravel,
                mycelium,
                sand,
                red_sand,
                snow_block,
                snow,
                soul_sand,
                dirt_path,
                white_concrete_powder,
                orange_concrete_powder,
                magenta_concrete_powder,
                light_blue_concrete_powder,
                yellow_concrete_powder,
                lime_concrete_powder,
                pink_concrete_powder,
                gray_concrete_powder,
                light_gray_concrete_powder,
                cyan_concrete_powder,
                purple_concrete_powder,
                blue_concrete_powder,
                brown_concrete_powder,
                green_concrete_powder,
                red_concrete_powder,
                black_concrete_powder,
                soul_soil,
                rooted_dirt,
            }
        }
    }
    public static class entity_types
    {
        public static readonly string[] arrows_names = System.Enum.GetNames(typeof(arrows));
        public enum arrows : byte
        {
            arrow,
            spectral_arrow,
        }
        public static readonly string[] axolotl_always_hostiles_names = System.Enum.GetNames(typeof(axolotl_always_hostiles));
        public enum axolotl_always_hostiles : byte
        {
            drowned,
            guardian,
            elder_guardian,
        }
        public static readonly string[] axolotl_hunt_targets_names = System.Enum.GetNames(typeof(axolotl_hunt_targets));
        public enum axolotl_hunt_targets : byte
        {
            tropical_fish,
            pufferfish,
            salmon,
            cod,
            squid,
            glow_squid,
        }
        public static readonly string[] beehive_inhabitors_names = System.Enum.GetNames(typeof(beehive_inhabitors));
        public enum beehive_inhabitors : byte
        {
            bee,
        }
        public static readonly string[] freeze_hurts_extra_types_names = System.Enum.GetNames(typeof(freeze_hurts_extra_types));
        public enum freeze_hurts_extra_types : byte
        {
            strider,
            blaze,
            magma_cube,
        }
        public static readonly string[] freeze_immune_entity_types_names = System.Enum.GetNames(typeof(freeze_immune_entity_types));
        public enum freeze_immune_entity_types : byte
        {
            stray,
            polar_bear,
            snow_golem,
            wither,
        }
        public static readonly string[] impact_projectiles_names = System.Enum.GetNames(typeof(impact_projectiles));
        public enum impact_projectiles : byte
        {
            __arrows,
            snowball,
            fireball,
            small_fireball,
            egg,
            trident,
            dragon_fireball,
            wither_skull,
        }
        public static readonly string[] powder_snow_walkable_mobs_names = System.Enum.GetNames(typeof(powder_snow_walkable_mobs));
        public enum powder_snow_walkable_mobs : byte
        {
            rabbit,
            endermite,
            silverfish,
            fox,
        }
        public static readonly string[] raiders_names = System.Enum.GetNames(typeof(raiders));
        public enum raiders : byte
        {
            evoker,
            pillager,
            ravager,
            vindicator,
            illusioner,
            witch,
        }
        public static readonly string[] skeletons_names = System.Enum.GetNames(typeof(skeletons));
        public enum skeletons : byte
        {
            skeleton,
            stray,
            wither_skeleton,
        }
    }
    public static class fluids
    {
        public static readonly string[] lava_names = System.Enum.GetNames(typeof(lava));
        public enum lava : byte
        {
            lava,
            flowing_lava,
        }
        public static readonly string[] water_names = System.Enum.GetNames(typeof(water));
        public enum water : byte
        {
            water,
            flowing_water,
        }
    }
    public static class game_events
    {
        public static readonly string[] ignore_vibrations_sneaking_names = System.Enum.GetNames(typeof(ignore_vibrations_sneaking));
        public enum ignore_vibrations_sneaking : byte
        {
            hit_ground,
            projectile_shoot,
            step,
            swim,
        }
        public static readonly string[] vibrations_names = System.Enum.GetNames(typeof(vibrations));
        public enum vibrations : byte
        {
            block_attach,
            block_change,
            block_close,
            block_destroy,
            block_detach,
            block_open,
            block_place,
            block_press,
            block_switch,
            block_unpress,
            block_unswitch,
            container_close,
            container_open,
            dispense_fail,
            drinking_finish,
            eat,
            elytra_free_fall,
            entity_damaged,
            entity_killed,
            entity_place,
            equip,
            explode,
            fishing_rod_cast,
            fishing_rod_reel_in,
            flap,
            fluid_pickup,
            fluid_place,
            hit_ground,
            mob_interact,
            lightning_strike,
            minecart_moving,
            piston_contract,
            piston_extend,
            prime_fuse,
            projectile_land,
            projectile_shoot,
            ravager_roar,
            ring_bell,
            shear,
            shulker_close,
            shulker_open,
            splash,
            step,
            swim,
            wolf_shaking,
        }
    }
    public static class items
    {
        public static readonly string[] acacia_logs_names = System.Enum.GetNames(typeof(acacia_logs));
        public enum acacia_logs : byte
        {
            acacia_log,
            acacia_wood,
            stripped_acacia_log,
            stripped_acacia_wood,
        }
        public static readonly string[] anvil_names = System.Enum.GetNames(typeof(anvil));
        public enum anvil : byte
        {
            anvil,
            chipped_anvil,
            damaged_anvil,
        }
        public static readonly string[] arrows_names = System.Enum.GetNames(typeof(arrows));
        public enum arrows : byte
        {
            arrow,
            tipped_arrow,
            spectral_arrow,
        }
        public static readonly string[] axolotl_tempt_items_names = System.Enum.GetNames(typeof(axolotl_tempt_items));
        public enum axolotl_tempt_items : byte
        {
            tropical_fish_bucket,
        }
        public static readonly string[] banners_names = System.Enum.GetNames(typeof(banners));
        public enum banners : byte
        {
            white_banner,
            orange_banner,
            magenta_banner,
            light_blue_banner,
            yellow_banner,
            lime_banner,
            pink_banner,
            gray_banner,
            light_gray_banner,
            cyan_banner,
            purple_banner,
            blue_banner,
            brown_banner,
            green_banner,
            red_banner,
            black_banner,
        }
        public static readonly string[] beacon_payment_items_names = System.Enum.GetNames(typeof(beacon_payment_items));
        public enum beacon_payment_items : byte
        {
            netherite_ingot,
            emerald,
            diamond,
            gold_ingot,
            iron_ingot,
        }
        public static readonly string[] beds_names = System.Enum.GetNames(typeof(beds));
        public enum beds : byte
        {
            red_bed,
            black_bed,
            blue_bed,
            brown_bed,
            cyan_bed,
            gray_bed,
            green_bed,
            light_blue_bed,
            light_gray_bed,
            lime_bed,
            magenta_bed,
            orange_bed,
            pink_bed,
            purple_bed,
            white_bed,
            yellow_bed,
        }
        public static readonly string[] birch_logs_names = System.Enum.GetNames(typeof(birch_logs));
        public enum birch_logs : byte
        {
            birch_log,
            birch_wood,
            stripped_birch_log,
            stripped_birch_wood,
        }
        public static readonly string[] boats_names = System.Enum.GetNames(typeof(boats));
        public enum boats : byte
        {
            oak_boat,
            spruce_boat,
            birch_boat,
            jungle_boat,
            acacia_boat,
            dark_oak_boat,
        }
        public static readonly string[] buttons_names = System.Enum.GetNames(typeof(buttons));
        public enum buttons : byte
        {
            __wooden_buttons,
            stone_button,
            polished_blackstone_button,
        }
        public static readonly string[] candles_names = System.Enum.GetNames(typeof(candles));
        public enum candles : byte
        {
            candle,
            white_candle,
            orange_candle,
            magenta_candle,
            light_blue_candle,
            yellow_candle,
            lime_candle,
            pink_candle,
            gray_candle,
            light_gray_candle,
            cyan_candle,
            purple_candle,
            blue_candle,
            brown_candle,
            green_candle,
            red_candle,
            black_candle,
        }
        public static readonly string[] carpets_names = System.Enum.GetNames(typeof(carpets));
        public enum carpets : byte
        {
            white_carpet,
            orange_carpet,
            magenta_carpet,
            light_blue_carpet,
            yellow_carpet,
            lime_carpet,
            pink_carpet,
            gray_carpet,
            light_gray_carpet,
            cyan_carpet,
            purple_carpet,
            blue_carpet,
            brown_carpet,
            green_carpet,
            red_carpet,
            black_carpet,
        }
        public static readonly string[] cluster_max_harvestables_names = System.Enum.GetNames(typeof(cluster_max_harvestables));
        public enum cluster_max_harvestables : byte
        {
            diamond_pickaxe,
            golden_pickaxe,
            iron_pickaxe,
            netherite_pickaxe,
            stone_pickaxe,
            wooden_pickaxe,
        }
        public static readonly string[] coals_names = System.Enum.GetNames(typeof(coals));
        public enum coals : byte
        {
            coal,
            charcoal,
        }
        public static readonly string[] coal_ores_names = System.Enum.GetNames(typeof(coal_ores));
        public enum coal_ores : byte
        {
            coal_ore,
            deepslate_coal_ore,
        }
        public static readonly string[] copper_ores_names = System.Enum.GetNames(typeof(copper_ores));
        public enum copper_ores : byte
        {
            copper_ore,
            deepslate_copper_ore,
        }
        public static readonly string[] creeper_drop_music_discs_names = System.Enum.GetNames(typeof(creeper_drop_music_discs));
        public enum creeper_drop_music_discs : byte
        {
            music_disc_13,
            music_disc_cat,
            music_disc_blocks,
            music_disc_chirp,
            music_disc_far,
            music_disc_mall,
            music_disc_mellohi,
            music_disc_stal,
            music_disc_strad,
            music_disc_ward,
            music_disc_11,
            music_disc_wait,
        }
        public static readonly string[] crimson_stems_names = System.Enum.GetNames(typeof(crimson_stems));
        public enum crimson_stems : byte
        {
            crimson_stem,
            stripped_crimson_stem,
            crimson_hyphae,
            stripped_crimson_hyphae,
        }
        public static readonly string[] dark_oak_logs_names = System.Enum.GetNames(typeof(dark_oak_logs));
        public enum dark_oak_logs : byte
        {
            dark_oak_log,
            dark_oak_wood,
            stripped_dark_oak_log,
            stripped_dark_oak_wood,
        }
        public static readonly string[] diamond_ores_names = System.Enum.GetNames(typeof(diamond_ores));
        public enum diamond_ores : byte
        {
            diamond_ore,
            deepslate_diamond_ore,
        }
        public static readonly string[] dirt_names = System.Enum.GetNames(typeof(dirt));
        public enum dirt : byte
        {
            dirt,
            grass_block,
            podzol,
            coarse_dirt,
            mycelium,
            rooted_dirt,
            moss_block,
        }
        public static readonly string[] doors_names = System.Enum.GetNames(typeof(doors));
        public enum doors : byte
        {
            __wooden_doors,
            iron_door,
        }
        public static readonly string[] emerald_ores_names = System.Enum.GetNames(typeof(emerald_ores));
        public enum emerald_ores : byte
        {
            emerald_ore,
            deepslate_emerald_ore,
        }
        public static readonly string[] fences_names = System.Enum.GetNames(typeof(fences));
        public enum fences : byte
        {
            __wooden_fences,
            nether_brick_fence,
        }
        public static readonly string[] fishes_names = System.Enum.GetNames(typeof(fishes));
        public enum fishes : byte
        {
            cod,
            cooked_cod,
            salmon,
            cooked_salmon,
            pufferfish,
            tropical_fish,
        }
        public static readonly string[] flowers_names = System.Enum.GetNames(typeof(flowers));
        public enum flowers : byte
        {
            __small_flowers,
            __tall_flowers,
            flowering_azalea_leaves,
            flowering_azalea,
        }
        public static readonly string[] fox_food_names = System.Enum.GetNames(typeof(fox_food));
        public enum fox_food : byte
        {
            sweet_berries,
            glow_berries,
        }
        public static readonly string[] freeze_immune_wearables_names = System.Enum.GetNames(typeof(freeze_immune_wearables));
        public enum freeze_immune_wearables : byte
        {
            leather_boots,
            leather_leggings,
            leather_chestplate,
            leather_helmet,
            leather_horse_armor,
        }
        public static readonly string[] gold_ores_names = System.Enum.GetNames(typeof(gold_ores));
        public enum gold_ores : byte
        {
            gold_ore,
            nether_gold_ore,
            deepslate_gold_ore,
        }
        public static readonly string[] ignored_by_piglin_babies_names = System.Enum.GetNames(typeof(ignored_by_piglin_babies));
        public enum ignored_by_piglin_babies : byte
        {
            leather,
        }
        public static readonly string[] iron_ores_names = System.Enum.GetNames(typeof(iron_ores));
        public enum iron_ores : byte
        {
            iron_ore,
            deepslate_iron_ore,
        }
        public static readonly string[] jungle_logs_names = System.Enum.GetNames(typeof(jungle_logs));
        public enum jungle_logs : byte
        {
            jungle_log,
            jungle_wood,
            stripped_jungle_log,
            stripped_jungle_wood,
        }
        public static readonly string[] lapis_ores_names = System.Enum.GetNames(typeof(lapis_ores));
        public enum lapis_ores : byte
        {
            lapis_ore,
            deepslate_lapis_ore,
        }
        public static readonly string[] leaves_names = System.Enum.GetNames(typeof(leaves));
        public enum leaves : byte
        {
            jungle_leaves,
            oak_leaves,
            spruce_leaves,
            dark_oak_leaves,
            acacia_leaves,
            birch_leaves,
            azalea_leaves,
            flowering_azalea_leaves,
        }
        public static readonly string[] lectern_books_names = System.Enum.GetNames(typeof(lectern_books));
        public enum lectern_books : byte
        {
            written_book,
            writable_book,
        }
        public static readonly string[] logs_names = System.Enum.GetNames(typeof(logs));
        public enum logs : byte
        {
            __logs_that_burn,
            __crimson_stems,
            __warped_stems,
        }
        public static readonly string[] logs_that_burn_names = System.Enum.GetNames(typeof(logs_that_burn));
        public enum logs_that_burn : byte
        {
            __dark_oak_logs,
            __oak_logs,
            __acacia_logs,
            __birch_logs,
            __jungle_logs,
            __spruce_logs,
        }
        public static readonly string[] music_discs_names = System.Enum.GetNames(typeof(music_discs));
        public enum music_discs : byte
        {
            __creeper_drop_music_discs,
            music_disc_pigstep,
            music_disc_otherside,
        }
        public static readonly string[] non_flammable_wood_names = System.Enum.GetNames(typeof(non_flammable_wood));
        public enum non_flammable_wood : byte
        {
            warped_stem,
            stripped_warped_stem,
            warped_hyphae,
            stripped_warped_hyphae,
            crimson_stem,
            stripped_crimson_stem,
            crimson_hyphae,
            stripped_crimson_hyphae,
            crimson_planks,
            warped_planks,
            crimson_slab,
            warped_slab,
            crimson_pressure_plate,
            warped_pressure_plate,
            crimson_fence,
            warped_fence,
            crimson_trapdoor,
            warped_trapdoor,
            crimson_fence_gate,
            warped_fence_gate,
            crimson_stairs,
            warped_stairs,
            crimson_button,
            warped_button,
            crimson_door,
            warped_door,
            crimson_sign,
            warped_sign,
        }
        public static readonly string[] oak_logs_names = System.Enum.GetNames(typeof(oak_logs));
        public enum oak_logs : byte
        {
            oak_log,
            oak_wood,
            stripped_oak_log,
            stripped_oak_wood,
        }
        public static readonly string[] occludes_vibration_signals_names = System.Enum.GetNames(typeof(occludes_vibration_signals));
        public enum occludes_vibration_signals : byte
        {
            __wool,
        }
        public static readonly string[] piglin_food_names = System.Enum.GetNames(typeof(piglin_food));
        public enum piglin_food : byte
        {
            porkchop,
            cooked_porkchop,
        }
        public static readonly string[] piglin_loved_names = System.Enum.GetNames(typeof(piglin_loved));
        public enum piglin_loved : byte
        {
            __gold_ores,
            gold_block,
            gilded_blackstone,
            light_weighted_pressure_plate,
            gold_ingot,
            bell,
            clock,
            golden_carrot,
            glistering_melon_slice,
            golden_apple,
            enchanted_golden_apple,
            golden_helmet,
            golden_chestplate,
            golden_leggings,
            golden_boots,
            golden_horse_armor,
            golden_sword,
            golden_pickaxe,
            golden_shovel,
            golden_axe,
            golden_hoe,
            raw_gold,
            raw_gold_block,
        }
        public static readonly string[] piglin_repellents_names = System.Enum.GetNames(typeof(piglin_repellents));
        public enum piglin_repellents : byte
        {
            soul_torch,
            soul_lantern,
            soul_campfire,
        }
        public static readonly string[] planks_names = System.Enum.GetNames(typeof(planks));
        public enum planks : byte
        {
            oak_planks,
            spruce_planks,
            birch_planks,
            jungle_planks,
            acacia_planks,
            dark_oak_planks,
            crimson_planks,
            warped_planks,
        }
        public static readonly string[] rails_names = System.Enum.GetNames(typeof(rails));
        public enum rails : byte
        {
            rail,
            powered_rail,
            detector_rail,
            activator_rail,
        }
        public static readonly string[] redstone_ores_names = System.Enum.GetNames(typeof(redstone_ores));
        public enum redstone_ores : byte
        {
            redstone_ore,
            deepslate_redstone_ore,
        }
        public static readonly string[] sand_names = System.Enum.GetNames(typeof(sand));
        public enum sand : byte
        {
            sand,
            red_sand,
        }
        public static readonly string[] saplings_names = System.Enum.GetNames(typeof(saplings));
        public enum saplings : byte
        {
            oak_sapling,
            spruce_sapling,
            birch_sapling,
            jungle_sapling,
            acacia_sapling,
            dark_oak_sapling,
            azalea,
            flowering_azalea,
        }
        public static readonly string[] signs_names = System.Enum.GetNames(typeof(signs));
        public enum signs : byte
        {
            oak_sign,
            spruce_sign,
            birch_sign,
            acacia_sign,
            jungle_sign,
            dark_oak_sign,
            crimson_sign,
            warped_sign,
        }
        public static readonly string[] slabs_names = System.Enum.GetNames(typeof(slabs));
        public enum slabs : byte
        {
            __wooden_slabs,
            stone_slab,
            smooth_stone_slab,
            stone_brick_slab,
            sandstone_slab,
            purpur_slab,
            quartz_slab,
            red_sandstone_slab,
            brick_slab,
            cobblestone_slab,
            nether_brick_slab,
            petrified_oak_slab,
            prismarine_slab,
            prismarine_brick_slab,
            dark_prismarine_slab,
            polished_granite_slab,
            smooth_red_sandstone_slab,
            mossy_stone_brick_slab,
            polished_diorite_slab,
            mossy_cobblestone_slab,
            end_stone_brick_slab,
            smooth_sandstone_slab,
            smooth_quartz_slab,
            granite_slab,
            andesite_slab,
            red_nether_brick_slab,
            polished_andesite_slab,
            diorite_slab,
            cut_sandstone_slab,
            cut_red_sandstone_slab,
            blackstone_slab,
            polished_blackstone_brick_slab,
            polished_blackstone_slab,
            cobbled_deepslate_slab,
            polished_deepslate_slab,
            deepslate_tile_slab,
            deepslate_brick_slab,
            waxed_weathered_cut_copper_slab,
            waxed_exposed_cut_copper_slab,
            waxed_cut_copper_slab,
            oxidized_cut_copper_slab,
            weathered_cut_copper_slab,
            exposed_cut_copper_slab,
            cut_copper_slab,
            waxed_oxidized_cut_copper_slab,
        }
        public static readonly string[] small_flowers_names = System.Enum.GetNames(typeof(small_flowers));
        public enum small_flowers : byte
        {
            dandelion,
            poppy,
            blue_orchid,
            allium,
            azure_bluet,
            red_tulip,
            orange_tulip,
            white_tulip,
            pink_tulip,
            oxeye_daisy,
            cornflower,
            lily_of_the_valley,
            wither_rose,
        }
        public static readonly string[] soul_fire_base_blocks_names = System.Enum.GetNames(typeof(soul_fire_base_blocks));
        public enum soul_fire_base_blocks : byte
        {
            soul_sand,
            soul_soil,
        }
        public static readonly string[] spruce_logs_names = System.Enum.GetNames(typeof(spruce_logs));
        public enum spruce_logs : byte
        {
            spruce_log,
            spruce_wood,
            stripped_spruce_log,
            stripped_spruce_wood,
        }
        public static readonly string[] stairs_names = System.Enum.GetNames(typeof(stairs));
        public enum stairs : byte
        {
            __wooden_stairs,
            cobblestone_stairs,
            sandstone_stairs,
            nether_brick_stairs,
            stone_brick_stairs,
            brick_stairs,
            purpur_stairs,
            quartz_stairs,
            red_sandstone_stairs,
            prismarine_brick_stairs,
            prismarine_stairs,
            dark_prismarine_stairs,
            polished_granite_stairs,
            smooth_red_sandstone_stairs,
            mossy_stone_brick_stairs,
            polished_diorite_stairs,
            mossy_cobblestone_stairs,
            end_stone_brick_stairs,
            stone_stairs,
            smooth_sandstone_stairs,
            smooth_quartz_stairs,
            granite_stairs,
            andesite_stairs,
            red_nether_brick_stairs,
            polished_andesite_stairs,
            diorite_stairs,
            blackstone_stairs,
            polished_blackstone_brick_stairs,
            polished_blackstone_stairs,
            cobbled_deepslate_stairs,
            polished_deepslate_stairs,
            deepslate_tile_stairs,
            deepslate_brick_stairs,
            oxidized_cut_copper_stairs,
            weathered_cut_copper_stairs,
            exposed_cut_copper_stairs,
            cut_copper_stairs,
            waxed_weathered_cut_copper_stairs,
            waxed_exposed_cut_copper_stairs,
            waxed_cut_copper_stairs,
            waxed_oxidized_cut_copper_stairs,
        }
        public static readonly string[] stone_bricks_names = System.Enum.GetNames(typeof(stone_bricks));
        public enum stone_bricks : byte
        {
            stone_bricks,
            mossy_stone_bricks,
            cracked_stone_bricks,
            chiseled_stone_bricks,
        }
        public static readonly string[] stone_crafting_materials_names = System.Enum.GetNames(typeof(stone_crafting_materials));
        public enum stone_crafting_materials : byte
        {
            cobblestone,
            blackstone,
            cobbled_deepslate,
        }
        public static readonly string[] stone_tool_materials_names = System.Enum.GetNames(typeof(stone_tool_materials));
        public enum stone_tool_materials : byte
        {
            cobblestone,
            blackstone,
            cobbled_deepslate,
        }
        public static readonly string[] tall_flowers_names = System.Enum.GetNames(typeof(tall_flowers));
        public enum tall_flowers : byte
        {
            sunflower,
            lilac,
            peony,
            rose_bush,
        }
        public static readonly string[] terracotta_names = System.Enum.GetNames(typeof(terracotta));
        public enum terracotta : byte
        {
            terracotta,
            white_terracotta,
            orange_terracotta,
            magenta_terracotta,
            light_blue_terracotta,
            yellow_terracotta,
            lime_terracotta,
            pink_terracotta,
            gray_terracotta,
            light_gray_terracotta,
            cyan_terracotta,
            purple_terracotta,
            blue_terracotta,
            brown_terracotta,
            green_terracotta,
            red_terracotta,
            black_terracotta,
        }
        public static readonly string[] trapdoors_names = System.Enum.GetNames(typeof(trapdoors));
        public enum trapdoors : byte
        {
            __wooden_trapdoors,
            iron_trapdoor,
        }
        public static readonly string[] walls_names = System.Enum.GetNames(typeof(walls));
        public enum walls : byte
        {
            cobblestone_wall,
            mossy_cobblestone_wall,
            brick_wall,
            prismarine_wall,
            red_sandstone_wall,
            mossy_stone_brick_wall,
            granite_wall,
            stone_brick_wall,
            nether_brick_wall,
            andesite_wall,
            red_nether_brick_wall,
            sandstone_wall,
            end_stone_brick_wall,
            diorite_wall,
            blackstone_wall,
            polished_blackstone_brick_wall,
            polished_blackstone_wall,
            cobbled_deepslate_wall,
            polished_deepslate_wall,
            deepslate_tile_wall,
            deepslate_brick_wall,
        }
        public static readonly string[] warped_stems_names = System.Enum.GetNames(typeof(warped_stems));
        public enum warped_stems : byte
        {
            warped_stem,
            stripped_warped_stem,
            warped_hyphae,
            stripped_warped_hyphae,
        }
        public static readonly string[] wooden_buttons_names = System.Enum.GetNames(typeof(wooden_buttons));
        public enum wooden_buttons : byte
        {
            oak_button,
            spruce_button,
            birch_button,
            jungle_button,
            acacia_button,
            dark_oak_button,
            crimson_button,
            warped_button,
        }
        public static readonly string[] wooden_doors_names = System.Enum.GetNames(typeof(wooden_doors));
        public enum wooden_doors : byte
        {
            oak_door,
            spruce_door,
            birch_door,
            jungle_door,
            acacia_door,
            dark_oak_door,
            crimson_door,
            warped_door,
        }
        public static readonly string[] wooden_fences_names = System.Enum.GetNames(typeof(wooden_fences));
        public enum wooden_fences : byte
        {
            oak_fence,
            acacia_fence,
            dark_oak_fence,
            spruce_fence,
            birch_fence,
            jungle_fence,
            crimson_fence,
            warped_fence,
        }
        public static readonly string[] wooden_pressure_plates_names = System.Enum.GetNames(typeof(wooden_pressure_plates));
        public enum wooden_pressure_plates : byte
        {
            oak_pressure_plate,
            spruce_pressure_plate,
            birch_pressure_plate,
            jungle_pressure_plate,
            acacia_pressure_plate,
            dark_oak_pressure_plate,
            crimson_pressure_plate,
            warped_pressure_plate,
        }
        public static readonly string[] wooden_slabs_names = System.Enum.GetNames(typeof(wooden_slabs));
        public enum wooden_slabs : byte
        {
            oak_slab,
            spruce_slab,
            birch_slab,
            jungle_slab,
            acacia_slab,
            dark_oak_slab,
            crimson_slab,
            warped_slab,
        }
        public static readonly string[] wooden_stairs_names = System.Enum.GetNames(typeof(wooden_stairs));
        public enum wooden_stairs : byte
        {
            oak_stairs,
            spruce_stairs,
            birch_stairs,
            jungle_stairs,
            acacia_stairs,
            dark_oak_stairs,
            crimson_stairs,
            warped_stairs,
        }
        public static readonly string[] wooden_trapdoors_names = System.Enum.GetNames(typeof(wooden_trapdoors));
        public enum wooden_trapdoors : byte
        {
            acacia_trapdoor,
            birch_trapdoor,
            dark_oak_trapdoor,
            jungle_trapdoor,
            oak_trapdoor,
            spruce_trapdoor,
            crimson_trapdoor,
            warped_trapdoor,
        }
        public static readonly string[] wool_names = System.Enum.GetNames(typeof(wool));
        public enum wool : byte
        {
            white_wool,
            orange_wool,
            magenta_wool,
            light_blue_wool,
            yellow_wool,
            lime_wool,
            pink_wool,
            gray_wool,
            light_gray_wool,
            cyan_wool,
            purple_wool,
            blue_wool,
            brown_wool,
            green_wool,
            red_wool,
            black_wool,
        }
    }
    public static class worldgen
    {
        public static class biome
        {
            public static readonly string[] is_badlands_names = System.Enum.GetNames(typeof(is_badlands));
            public enum is_badlands : byte
            {
                badlands,
                eroded_badlands,
                wooded_badlands,
            }
            public static readonly string[] is_beach_names = System.Enum.GetNames(typeof(is_beach));
            public enum is_beach : byte
            {
                beach,
                snowy_beach,
            }
            public static readonly string[] is_deep_ocean_names = System.Enum.GetNames(typeof(is_deep_ocean));
            public enum is_deep_ocean : byte
            {
                deep_frozen_ocean,
                deep_cold_ocean,
                deep_ocean,
                deep_lukewarm_ocean,
            }
            public static readonly string[] is_forest_names = System.Enum.GetNames(typeof(is_forest));
            public enum is_forest : byte
            {
                forest,
                flower_forest,
                birch_forest,
                old_growth_birch_forest,
                dark_forest,
                grove,
            }
            public static readonly string[] is_hill_names = System.Enum.GetNames(typeof(is_hill));
            public enum is_hill : byte
            {
                windswept_hills,
                windswept_forest,
                windswept_gravelly_hills,
            }
            public static readonly string[] is_jungle_names = System.Enum.GetNames(typeof(is_jungle));
            public enum is_jungle : byte
            {
                bamboo_jungle,
                jungle,
                sparse_jungle,
            }
            public static readonly string[] is_mountain_names = System.Enum.GetNames(typeof(is_mountain));
            public enum is_mountain : byte
            {
                meadow,
                frozen_peaks,
                jagged_peaks,
                stony_peaks,
                snowy_slopes,
            }
            public static readonly string[] is_nether_names = System.Enum.GetNames(typeof(is_nether));
            public enum is_nether : byte
            {
                nether_wastes,
                basalt_deltas,
                soul_sand_valley,
                crimson_forest,
                warped_forest,
            }
            public static readonly string[] is_ocean_names = System.Enum.GetNames(typeof(is_ocean));
            public enum is_ocean : byte
            {
                __is_deep_ocean,
                frozen_ocean,
                ocean,
                cold_ocean,
                lukewarm_ocean,
                warm_ocean,
            }
            public static readonly string[] is_river_names = System.Enum.GetNames(typeof(is_river));
            public enum is_river : byte
            {
                river,
                frozen_river,
            }
            public static readonly string[] is_taiga_names = System.Enum.GetNames(typeof(is_taiga));
            public enum is_taiga : byte
            {
                taiga,
                snowy_taiga,
                old_growth_pine_taiga,
                old_growth_spruce_taiga,
            }
            public static class has_structure
            {
                public static readonly string[] bastion_remnant_names = System.Enum.GetNames(typeof(bastion_remnant));
                public enum bastion_remnant : byte
                {
                    crimson_forest,
                    nether_wastes,
                    soul_sand_valley,
                    warped_forest,
                }
                public static readonly string[] buried_treasure_names = System.Enum.GetNames(typeof(buried_treasure));
                public enum buried_treasure : byte
                {
                    __is_beach,
                }
                public static readonly string[] desert_pyramid_names = System.Enum.GetNames(typeof(desert_pyramid));
                public enum desert_pyramid : byte
                {
                    desert,
                }
                public static readonly string[] end_city_names = System.Enum.GetNames(typeof(end_city));
                public enum end_city : byte
                {
                    end_highlands,
                    end_midlands,
                }
                public static readonly string[] igloo_names = System.Enum.GetNames(typeof(igloo));
                public enum igloo : byte
                {
                    snowy_taiga,
                    snowy_plains,
                    snowy_slopes,
                }
                public static readonly string[] jungle_temple_names = System.Enum.GetNames(typeof(jungle_temple));
                public enum jungle_temple : byte
                {
                    bamboo_jungle,
                    jungle,
                }
                public static readonly string[] mineshaft_names = System.Enum.GetNames(typeof(mineshaft));
                public enum mineshaft : byte
                {
                    __is_ocean,
                    __is_river,
                    __is_beach,
                    __is_mountain,
                    __is_hill,
                    __is_taiga,
                    __is_jungle,
                    __is_forest,
                    stony_shore,
                    mushroom_fields,
                    ice_spikes,
                    windswept_savanna,
                    desert,
                    savanna,
                    snowy_plains,
                    plains,
                    sunflower_plains,
                    swamp,
                    savanna_plateau,
                    dripstone_caves,
                    lush_caves,
                }
                public static readonly string[] mineshaft_mesa_names = System.Enum.GetNames(typeof(mineshaft_mesa));
                public enum mineshaft_mesa : byte
                {
                    __is_badlands,
                }
                public static readonly string[] nether_fortress_names = System.Enum.GetNames(typeof(nether_fortress));
                public enum nether_fortress : byte
                {
                    __is_nether,
                }
                public static readonly string[] nether_fossil_names = System.Enum.GetNames(typeof(nether_fossil));
                public enum nether_fossil : byte
                {
                    soul_sand_valley,
                }
                public static readonly string[] ocean_monument_names = System.Enum.GetNames(typeof(ocean_monument));
                public enum ocean_monument : byte
                {
                    __is_deep_ocean,
                }
                public static readonly string[] ocean_ruin_cold_names = System.Enum.GetNames(typeof(ocean_ruin_cold));
                public enum ocean_ruin_cold : byte
                {
                    frozen_ocean,
                    cold_ocean,
                    ocean,
                    deep_frozen_ocean,
                    deep_cold_ocean,
                    deep_ocean,
                }
                public static readonly string[] ocean_ruin_warm_names = System.Enum.GetNames(typeof(ocean_ruin_warm));
                public enum ocean_ruin_warm : byte
                {
                    lukewarm_ocean,
                    warm_ocean,
                    deep_lukewarm_ocean,
                }
                public static readonly string[] pillager_outpost_names = System.Enum.GetNames(typeof(pillager_outpost));
                public enum pillager_outpost : byte
                {
                    desert,
                    plains,
                    savanna,
                    snowy_plains,
                    taiga,
                    __is_mountain,
                    grove,
                }
                public static readonly string[] ruined_portal_desert_names = System.Enum.GetNames(typeof(ruined_portal_desert));
                public enum ruined_portal_desert : byte
                {
                    desert,
                }
                public static readonly string[] ruined_portal_jungle_names = System.Enum.GetNames(typeof(ruined_portal_jungle));
                public enum ruined_portal_jungle : byte
                {
                    __is_jungle,
                }
                public static readonly string[] ruined_portal_mountain_names = System.Enum.GetNames(typeof(ruined_portal_mountain));
                public enum ruined_portal_mountain : byte
                {
                    __is_badlands,
                    __is_hill,
                    savanna_plateau,
                    windswept_savanna,
                    stony_shore,
                    __is_mountain,
                }
                public static readonly string[] ruined_portal_nether_names = System.Enum.GetNames(typeof(ruined_portal_nether));
                public enum ruined_portal_nether : byte
                {
                    __is_nether,
                }
                public static readonly string[] ruined_portal_ocean_names = System.Enum.GetNames(typeof(ruined_portal_ocean));
                public enum ruined_portal_ocean : byte
                {
                    __is_ocean,
                }
                public static readonly string[] ruined_portal_standard_names = System.Enum.GetNames(typeof(ruined_portal_standard));
                public enum ruined_portal_standard : byte
                {
                    __is_beach,
                    __is_river,
                    __is_taiga,
                    __is_forest,
                    mushroom_fields,
                    ice_spikes,
                    dripstone_caves,
                    lush_caves,
                    savanna,
                    snowy_plains,
                    plains,
                    sunflower_plains,
                }
                public static readonly string[] ruined_portal_swamp_names = System.Enum.GetNames(typeof(ruined_portal_swamp));
                public enum ruined_portal_swamp : byte
                {
                    swamp,
                }
                public static readonly string[] shipwreck_names = System.Enum.GetNames(typeof(shipwreck));
                public enum shipwreck : byte
                {
                    __is_ocean,
                }
                public static readonly string[] shipwreck_beached_names = System.Enum.GetNames(typeof(shipwreck_beached));
                public enum shipwreck_beached : byte
                {
                    __is_beach,
                }
                public static readonly string[] stronghold_names = System.Enum.GetNames(typeof(stronghold));
                public enum stronghold : byte
                {
                    plains,
                    sunflower_plains,
                    snowy_plains,
                    ice_spikes,
                    desert,
                    forest,
                    flower_forest,
                    birch_forest,
                    dark_forest,
                    old_growth_birch_forest,
                    old_growth_pine_taiga,
                    old_growth_spruce_taiga,
                    taiga,
                    snowy_taiga,
                    savanna,
                    savanna_plateau,
                    windswept_hills,
                    windswept_gravelly_hills,
                    windswept_forest,
                    windswept_savanna,
                    jungle,
                    sparse_jungle,
                    bamboo_jungle,
                    badlands,
                    eroded_badlands,
                    wooded_badlands,
                    meadow,
                    grove,
                    snowy_slopes,
                    frozen_peaks,
                    jagged_peaks,
                    stony_peaks,
                    mushroom_fields,
                    dripstone_caves,
                    lush_caves,
                }
                public static readonly string[] swamp_hut_names = System.Enum.GetNames(typeof(swamp_hut));
                public enum swamp_hut : byte
                {
                    swamp,
                }
                public static readonly string[] village_desert_names = System.Enum.GetNames(typeof(village_desert));
                public enum village_desert : byte
                {
                    desert,
                }
                public static readonly string[] village_plains_names = System.Enum.GetNames(typeof(village_plains));
                public enum village_plains : byte
                {
                    plains,
                    meadow,
                }
                public static readonly string[] village_savanna_names = System.Enum.GetNames(typeof(village_savanna));
                public enum village_savanna : byte
                {
                    savanna,
                }
                public static readonly string[] village_snowy_names = System.Enum.GetNames(typeof(village_snowy));
                public enum village_snowy : byte
                {
                    snowy_plains,
                }
                public static readonly string[] village_taiga_names = System.Enum.GetNames(typeof(village_taiga));
                public enum village_taiga : byte
                {
                    taiga,
                }
                public static readonly string[] woodland_mansion_names = System.Enum.GetNames(typeof(woodland_mansion));
                public enum woodland_mansion : byte
                {
                    dark_forest,
                }
            }
        }
        public static class configured_structure_feature
        {
            public static readonly string[] dolphin_located_names = System.Enum.GetNames(typeof(dolphin_located));
            public enum dolphin_located : byte
            {
                __ocean_ruin,
                __shipwreck,
            }
            public static readonly string[] eye_of_ender_located_names = System.Enum.GetNames(typeof(eye_of_ender_located));
            public enum eye_of_ender_located : byte
            {
                stronghold,
            }
            public static readonly string[] mineshaft_names = System.Enum.GetNames(typeof(mineshaft));
            public enum mineshaft : byte
            {
                mineshaft,
                mineshaft_mesa,
            }
            public static readonly string[] ocean_ruin_names = System.Enum.GetNames(typeof(ocean_ruin));
            public enum ocean_ruin : byte
            {
                ocean_ruin_cold,
                ocean_ruin_warm,
            }
            public static readonly string[] on_ocean_explorer_maps_names = System.Enum.GetNames(typeof(on_ocean_explorer_maps));
            public enum on_ocean_explorer_maps : byte
            {
                monument,
            }
            public static readonly string[] on_treasure_maps_names = System.Enum.GetNames(typeof(on_treasure_maps));
            public enum on_treasure_maps : byte
            {
                buried_treasure,
            }
            public static readonly string[] on_woodland_explorer_maps_names = System.Enum.GetNames(typeof(on_woodland_explorer_maps));
            public enum on_woodland_explorer_maps : byte
            {
                mansion,
            }
            public static readonly string[] ruined_portal_names = System.Enum.GetNames(typeof(ruined_portal));
            public enum ruined_portal : byte
            {
                ruined_portal_desert,
                ruined_portal_jungle,
                ruined_portal_mountain,
                ruined_portal_nether,
                ruined_portal_ocean,
                ruined_portal,
                ruined_portal_swamp,
            }
            public static readonly string[] shipwreck_names = System.Enum.GetNames(typeof(shipwreck));
            public enum shipwreck : byte
            {
                shipwreck,
                shipwreck_beached,
            }
            public static readonly string[] village_names = System.Enum.GetNames(typeof(village));
            public enum village : byte
            {
                village_plains,
                village_desert,
                village_savanna,
                village_snowy,
                village_taiga,
            }
        }
    }
}