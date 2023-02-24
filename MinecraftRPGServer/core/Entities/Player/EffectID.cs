public enum EffectID : int
{
    Dispenser_dispenses = 1000,
    Dispenser_fails_to_dispense = 1001,
    Dispenser_shoots = 1002,
    Ender_eye_launched = 1003,
    Firework_shot = 1004,
    Iron_door_opened = 1005,
    Wooden_door_opened = 1006,
    Wooden_trapdoor_opened = 1007,
    Fence_gate_opened = 1008,
    Fire_extinguished = 1009,
    /// <summary>
    /// Data: This is actually a special case within this packet. 
    /// You can start/stop a record at a specific location. 
    /// Use a valid Record ID to start a record 
    /// (or overwrite a currently playing one), any other value will stop the record. 
    /// See <see href="https://wiki.vg/Data_Generators">Data Generators</see> for information on item IDs.
    /// </summary>
    Play_record = 1010,
    Iron_door_closed = 1011,
    Wooden_door_closed = 1012,
    Wooden_trapdoor_closed = 1013,
    Fence_gate_closed = 1014,
    Ghast_warns = 1015,
    Ghast_shoots = 1016,
    Enderdragon_shoots = 1017,
    Blaze_shoots = 1018,
    Zombie_attacks_wood_door = 1019,
    Zombie_attacks_iron_door = 1020,
    Zombie_breaks_wood_door = 1021,
    Wither_breaks_block = 1022,
    Wither_spawned = 1023,
    Wither_shoots = 1024,
    Bat_takes_off = 1025,
    Zombie_infects = 1026,
    Zombie_villager_converted = 1027,
    Ender_dragon_death = 1028,
    Anvil_destroyed = 1029,
    Anvil_used = 1030,
    Anvil_landed = 1031,
    Portal_travel = 1032,
    Chorus_flower_grown = 1033,
    Chorus_flower_died = 1034,
    Brewing_stand_brewed = 1035,
    Iron_trapdoor_opened = 1036,
    Iron_trapdoor_closed = 1037,
    End_portal_created_in_overworld = 1038,
    Phantom_bites = 1039,
    Zombie_converts_to_drowned = 1040,
    Husk_converts_to_zombie_by_drowning = 1041,
    Grindstone_used = 1042,
    Book_page_turned = 1043,
    Composter_composts = 1500,
    Lava_converts_block = 1501,//either water to stone, or removes existing blocks such as torches
    Redstone_torch_burns_out = 1502,
    Ender_eye_placed = 1503,
    /// <summary>
    /// <para>Spawns 10 smoke particles, e.g. from a fire</para>
    /// <para>Data: Direction</para>
    /// </summary>
    Spawns_10_smoke_particles = 2000,
    /// <summary>
    /// <para>Block break + block break sound</para>
    /// <para>Data: Block state, as an index into the global palette.</para>
    /// </summary>
    Block_break = 2001,
    /// <summary>
    /// <para>Particle effect + glass break sound.</para>
    /// <para>Data: RGB color as an integer (e.g. 8364543 for #7FA1FF).</para>
    /// </summary>
    Splash_potion = 2002,
    /// <summary>
    /// Eye of Ender entity break animation — particles and sound
    /// </summary>
    Eye_of_Ender_entity_break_animation = 2003,
    /// <summary>
    /// Mob spawn particle effect: smoke + flames
    /// </summary>
    Mob_spawn_particle_effect = 2004,
    /// <summary>
    /// Data: How many particles to spawn (if set to 0, 15 are spawned).
    /// </summary>
    Bonemeal_particles = 2005,
    Dragon_breath = 2006,
    /// <summary>
    /// <para>Particle effect + glass break sound.</para>
    /// <para>Data: RGB color as an integer (e.g. 8364543 for #7FA1FF).</para>
    /// </summary>
    Instant_splash_potion = 2007,
    Ender_dragon_destroys_block = 2008,
    Wet_sponge_vaporizes_in_nether = 2009,
    End_gateway_spawn = 3000,
    Enderdragon_growl = 3001,
    Electric_spark = 3002,
    Copper_apply_wax = 3003,
    Copper_remove_wax = 3004,
    Copper_scrape_oxidation = 3005,
}