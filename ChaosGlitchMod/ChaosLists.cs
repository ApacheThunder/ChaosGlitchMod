using System.Collections.Generic;
using UnityEngine;


namespace ChaosGlitchMod {

    // Selects Random strings
    public static class ArrayExtensions {
        // This is an extension method. RandomString() will now exist on all arrays.
        public static STRINGRANDOMIZER RandomString<STRINGRANDOMIZER>(this STRINGRANDOMIZER[] array) { return array[Random.Range(0, array.Length)]; }
    }

    class ChaosLists : MonoBehaviour {

        public static List<int> RatChestItems = new List<int>() {
            626, // elimentaler
            662, // partially_eaten_cheese
            663, // resourceful_sack
            667 // rat_boots
        };

        public static string[] ThoughtBubbleList = {
            "Oh no!",
            "Eat my shorts!",
            "Die in a fire!",
            "Have some bees!",
            "Apache Thunder was here...",
            "Those blue dogs suck...",
            "Welcome to hell!",
            "That Wall Mimic gives you my regards.",
            "( ͡° ͜ʖ ͡°)",
            "I'm just here to cover up space and make things hard for you. :D",
            "Watch out! That Bullet Kin has a gun!",
        };

        public static string[] blobsAndCritters = {
            "0239c0680f9f467dbe5c4aab7dd1eca6", // blobulon
            "042edb1dfb614dc385d5ad1b010f2ee3", // blobuloid
            "42be66373a3d4d89b91a35c9ff8adfec", // blobulin
            "e61cab252cfb435db9172adc96ded75f", // poisbulon
            "fe3fe59d867347839824d5d9ae87f244", // poisbuloid
            "b8103805af174924b578c98e95313074", // poisbulin
            "1a4872dafdb34fd29fe8ac90bd2cea67", // king_bullat
            "6ad1cafc268f4214a101dca7af61bc91", // rat
            "14ea47ff46b54bb4a98f91ffcffb656d", // rat_candle
            "76bc43539fc24648bff4568c75c686d1", // chicken
            "1386da0f42fb4bcabc5be8feb16a7c38", // snake
            "95ea1a31fc9e4415a5f271b9aedf9b15", // robots_past_critter_1
            "42432592685e47c9941e339879379d3a", // robots_past_critter_2
            "4254a93fc3c84c0dbe0a8f0dddf48a5a", // robots_past_critter_3
            "8b43a5c59b854eb780f9ab669ec26b7a", // dragun_egg_slimeguy
            "d1c9781fdac54d9e8498ed89210a0238" // tiny_blobulord
        };

        public static string[] ValidSourceEnemyGUIDList = {
            "01972dee89fc4404a5c408d50007dad5",	// BulletMan
            "57255ed50ee24794b7aac1ac3cfb8a95",	// Cultist
	        "4db03291a12144d69fe940d5a01de376",	// Ghost
	        "05891b158cd542b1a5f3df30fb67a7ff",	// ArrowheadMan
	        "31a3ea0c54a745e182e22ea54844a82d",	// BulletRifleMan
	        "c5b11bfc065d417b9c4d03a5e385fe2c",	// BulletRifleProfessional
	        "1a78cfb776f54641b832e92c44021cf2",	// AshBulletMan
	        "1bd8e49f93614e76b140077ff2e33f2b",	// AshBulletShotgunMan
	        "8bb5578fba374e8aae8e10b754e61d62",	// BulletCardinal
	        "db35531e66ce41cbb81d507a34366dfe",	// BulletMachineGunMan
        	"5f3abc2d561b4b9c9e72b879c6f10c7e",	// BulletManDevil
	        "e5cffcfabfae489da61062ea20539887",	// BulletManShroomed
	        "95ec774b5a75467a9ab05fa230c0c143",	// BulletSkeletonHelmet
	        "2752019b770f473193b08b4005dc781f",	// BulletShotgunMan_SawedOff <-- Veteran Shotgun Kin
	        "7f665bd7151347e298e4d366f8818284",	// BulletShotgunMan_Mutant
	        "d4a9836f8ab14f3fadd0f597438b1f1f",	// BulletMan_Mutant
	        "044a9f39712f456597b9762893fbc19c"	// BulletShotgrubMan
        };


        public static string SafeEnemyGUIDList = "eeb33c3a5a8e4eaaaaf39a743e8767bc";  // candle_guy
        // {
        // "4538456236f64ea79f483784370bc62f", // fusebot
        // "c2f902b7cbe745efb3db4399927eab34" // skusket_head
        // };

        // These enemies have or may have collision issues if resized
        // Many bosses will softlock or have collision issues too.
        public static string[] BannedEnemyGUIDList = {
            // Bosses and MiniBosses
            /*
            "ea40fcc863d34b0088f490f4e57f8913", // smiley
            "c00390483f394a849c36143eb878998f", // shades
            "bb73eeeb9e584fbeaf35877ec176de28", // blockner
            "edc61b105ddd4ce18302b82efdc47178", // blockner_rematch
            "0d3f7c641557426fbac8596b61c9fb45", // lord_of_the_jammed
            "880bbe4ce1014740ba6b4e2ea521e49d", // last_human
            "fc809bd43a4d41738a62d7565456622c", // ser_manuel
            "da797878d215453abba824ff902e21b4", // ammoconda
            "c367f00240a64d5d9f3c26484dc35833", // gorgun
            "9189f46c47564ed588b9108965f975c9", // door_lord
            */
            "3f11bbbc439c4086a180eb0fb9990cb4", // kill_pillars
            "6c43fddfd401456c916089fdd1c99b1c", // high_priest
            "1b5810fafbec445d89921a4efb4e42b7", // blobulord
            "4b992de5b4274168a8878ef9bf7ea36b", // beholster
            "ec6b674e0acd4553b47ee94493d66422", // gatling_gull
            "fa76c8cfdf1c4a88b55173666b4bc7fb", // treadnaught
            "df7fb62405dc4697b7721862c7b6b3cd", // treadnaughts_bullet_kin
            "f3b04a067a65492f8b279130323b41f0", // wallmonger
            "ffca09398635467da3b1f4a54bcfda80", // bullet_king
            "5729c8b5ffa7415bb3d01205663a33ef", // old_king
            "465da2bb086a4a88a803f79fe3a27677", // dragun
            "5e0af7f7d9de4755a68d2fd3bbc15df4", // cannonbalrog
            "6868795625bd46f3ae3e4377adce288b", // resourceful_rat
            "4d164ba3f62648809a4a82c90fc22cae", // resourceful_rat_mech
            "05b8afe0b6cc4fffa9dc6036fa24c8ec", // dragun_advanced
            "2e6223e42e574775b56c6349921f42cb", // dragun_knife_advanced
            "39de9bd6a863451a97906d949c103538", // tsar_bomba
            "8d441ad4e9924d91b6070d5b3438d066", // dr_wolfs_monster
            "ce2d2a0dced0444fb751b262ec6af08a", // dr_wolf
            "cd88c3ce60c442e9aa5b3904d31652bc", // lich
            "68a238ed6a82467ea85474c595c49c6e", // megalich
            "7c5d5f09911e49b78ae644d2b50ff3bf", // infinilich
            "dc3cd41623d447aeba77c77c99598426", // interdimensional_horror
            "8b913eea3d174184be1af362d441910d", // black_stache
            "b98b10fca77d469e80fb45f3c5badec5", // hm_absolution
            "78eca975263d4482a4bfa4c07b32e252", // draguns_knife
            "8b0dd96e2fe74ec7bebc1bc689c0008a", // mine_flayer
            "2ccaa1b7ae10457396a1796decda9cf6", // agunim
            "39dca963ae2b4688b016089d926308ab", // cannon
            "db97e486ef02425280129e1e27c33118", // shadow_agunim
            // Normal Enemies
            // "eed5addcc15148179f300cc0d9ee7f94", // spogre
            // "062b9b64371e46e195de17b6f10e47c8", // bloodbulon
            // "249db525a9464e5282d02162c88e0357", // spent
            // "9d50684ce2c044e880878e86dbada919", // coaler
            // "76bc43539fc24648bff4568c75c686d1", // chicken
            // "48d74b9c65f44b888a94f9e093554977", // x_det
            // "c5a0fd2774b64287bf11127ca59dd8b4", // diagonal_x_det
            // "b67ffe82c66742d1985e5888fd8e6a03", // vertical_det
            // "d9632631a18849539333a92332895ebd", // diagonal_det
            // "1898f6fe1ee0408e886aaf05c23cc216", // horizontal_det
            // "abd816b0bcbf4035b95837ca931169df", // vertical_x_det
            // "07d06d2b23cc48fe9f95454c839cb361", // horizontal_x_det
            // "0239c0680f9f467dbe5c4aab7dd1eca6", // blobulon
            // "e61cab252cfb435db9172adc96ded75f", // poisbulon
            // "042edb1dfb614dc385d5ad1b010f2ee3", // blobuloid
            // "fe3fe59d867347839824d5d9ae87f244", // poisbuloid
            "3cadf10c489b461f9fb8814abc1a09c1", // minelet
            "21dd14e5ca2a4a388adab5b11b69a1e1", // shelleton
            "1bc2a07ef87741be90c37096910843ab", // chancebulon
            "57255ed50ee24794b7aac1ac3cfb8a95", // gun_cultist
            "4db03291a12144d69fe940d5a01de376", // hollowpoint
            "206405acad4d4c33aac6717d184dc8d4", // apprentice_gunjurer
            "c4fba8def15e47b297865b18e36cbef8", // gunjurer
            "56fb939a434140308b8f257f0f447829", // lore_gunjurer
            "9b2cf2949a894599917d4d391a0b7394", // high_gunjurer
            "43426a2e39584871b287ac31df04b544", // wizbang
            "699cd24270af4cd183d671090d8323a1", // key_bullet_kin // Flee behaviour generates an exception in the logs.
            "a446c626b56d4166915a4e29869737fd", // chance_bullet_kin // His drops sometimes don't appear correctly when resized.
            "22fc2c2c45fb47cf9fb5f7b043a70122", // grip_master // Being tossed from a room from tiny Grip Master can soft lock the game.
            "42be66373a3d4d89b91a35c9ff8adfec", // blobulin
            "b8103805af174924b578c98e95313074", // poisbulin
            "3e98ccecf7334ff2800188c417e67c15", // killithid
            "ffdc8680bdaa487f8f31995539f74265", // muzzle_wisp
            "d8a445ea4d944cc1b55a40f22821ae69", // muzzle_flare
            "c2f902b7cbe745efb3db4399927eab34", // skusket_head
            "98ca70157c364750a60f5e0084f9d3e2", // phaser_spider
            "14ea47ff46b54bb4a98f91ffcffb656d", // rat_candle
            "6ad1cafc268f4214a101dca7af61bc91", // rat
            "479556d05c7c44f3b6abb3b2067fc778", // wall_mimic
            "796a7ed4ad804984859088fc91672c7f", // pedestal_mimic
            "475c20c1fd474dfbad54954e7cba29c1", // tarnisher
            "45192ff6d6cb43ed8f1a874ab6bef316", // misfire_beast
            "eeb33c3a5a8e4eaaaaf39a743e8767bc", // candle_guy
            "56f5a0f2c1fc4bc78875aea617ee31ac", // spectre
            "2feb50a6a40f4f50982e89fd276f6f15", // bullat
            "2d4f8b5404614e7d8b235006acde427a", // shotgat
            "b4666cb6ef4f4b038ba8924fd8adf38f", // grenat
            "7ec3e8146f634c559a7d58b19191cd43", // spirat
            "af84951206324e349e1f13f9b7b60c1a", // skusket
            "e667fdd01f1e43349c03a18e5b79e579", // tutorial_turret
            "41ba74c517534f02a62f2e2028395c58", // faster_tutorial_turret
            "ac986dabc5a24adab11d48a4bccf4cb1", // det
            "3f6d6b0c4a7c4690807435c7b37c35a5", // agonizer
            "cd4a4b7f612a4ba9a720b9f97c52f38c", // lead_maiden
            "98ea2fe181ab4323ab6e9981955a9bca", // shambling_round
            "d5a7b95774cd41f080e517bea07bf495", // revolvenant
            "88f037c3f93b4362a040a87b30770407", // gunreaper
            "1386da0f42fb4bcabc5be8feb16a7c38", // snake
            "566ecca5f3b04945ac6ce1f26dedbf4f", // mine_flayers_claymore
            // Thwomp type enemies
            "f155fd2759764f4a9217db29dd21b7eb", // mountain_cube
            "33b212b856b74ff09252bf4f2e8b8c57", // lead_cube
            "3f2026dc3712490289c4658a2ba4a24b", // flesh_cube
            // Chest Mimics
            "2ebf8ef6728648089babb507dec4edb7", // brown_chest_mimic
            "d8d651e3484f471ba8a2daa4bf535ce6", // blue_chest_mimic
            "abfb454340294a0992f4173d6e5898a8", // green_chest_mimic
            "d8fd592b184b4ac9a3be217bc70912a2", // red_chest_mimic
            "6450d20137994881aff0ddd13e3d40c8", // black_chest_mimic
            "ac9d345575444c9a8d11b799e8719be0", // rat_chest_mimic
            /*
            // Companions
            "c07ef60ae32b404f99e294a6f9acba75", // dog
            "7bd9c670f35b4b8d84280f52a5cc47f6", // cucco
            "998807b57e454f00a63d67883fcf90d6", // portable_turret
            "11a14dbd807e432985a89f69b5f9b31e", // phoenix
            "6f9c28403d3248c188c391f5e40774c5", // turkey
            */
            "705e9081261446039e1ed9ff16905d04", // cop
            "640238ba85dd4e94b3d6f68888e6ecb8", // cop_android
            "3a077fa5872d462196bb9a3cb1af02a3", // super_space_turtle
            "1ccdace06ebd42dc984d46cb1f0db6cf", // r2g2
            "fe51c83b41ce4a46b42f54ab5f31e6d0", // pig
            "ededff1deaf3430eaf8321d0c6b2bd80", // hunters_past_dog
            "d375913a61d1465f8e4ffcf4894e4427", // caterpillar
            "5695e8ffa77c4d099b4d9bd9536ff35e", // blank_companion
            "c6c8e59d0f5d41969c74e802c9d67d07", // ser_junkan
            "86237c6482754cd29819c239403a2de7", // pig_synergy
            "ad35abc5a3bf451581c3530417d89f2c", // blank_companion_synergy
            "e9fa6544000942a79ad05b6e4afb62db", // raccoon
            "ebf2314289ff4a4ead7ea7ef363a0a2e", // dog_synergy_1
            "ab4a779d6e8f429baafa4bf9e5dca3a9", // dog_synergy_2
            "9216803e9c894002a4b931d7ea9c6bdf", // super_space_turtle_synergy
            "cc9c41aa8c194e17b44ac45f993dd212", // super_space_turtle_dummy
            "45f5291a60724067bd3ccde50f65ac22", // payday_shooter_01
            "41ab10778daf4d3692e2bc4b370ab037", // payday_shooter_02
            "2976522ec560460c889d11bb54fbe758", // payday_shooter_03
            "e456b66ed3664a4cb590eab3a8ff3814" // baby_mimic
        };

        public static string[] PotEnemyGUIDList = {
            "c182a5cb704d460d9d099a47af49c913", // pot_fairy
            "6ad1cafc268f4214a101dca7af61bc91", // rat
            "14ea47ff46b54bb4a98f91ffcffb656d", // rat_candle
            "76bc43539fc24648bff4568c75c686d1", // chicken
            "1386da0f42fb4bcabc5be8feb16a7c38", // snake
            "2feb50a6a40f4f50982e89fd276f6f15", // bullat
            "b4666cb6ef4f4b038ba8924fd8adf38f", // grenat
            "2d4f8b5404614e7d8b235006acde427a", // shotgat
            "7ec3e8146f634c559a7d58b19191cd43", // spirat
            "d4dd2b2bbda64cc9bcec534b4e920518", // bullet_kings_toadie_revenge
            "4d37ce3d666b4ddda8039929225b7ede", // grenade_kin
            "0ff278534abb4fbaaa65d3f638003648", // poopulons_corn
            "95ea1a31fc9e4415a5f271b9aedf9b15", // robots_past_critter_1
            "42432592685e47c9941e339879379d3a", // robots_past_critter_2
            "4254a93fc3c84c0dbe0a8f0dddf48a5a", // robots_past_critter_3
            "b5e699a0abb94666bda567ab23bd91c4", // bullet_kings_toadie
            "02a14dec58ab45fb8aacde7aacd25b01", // old_kings_toadie
            "566ecca5f3b04945ac6ce1f26dedbf4f", // mine_flayers_claymore
            "78a8ee40dff2477e9c2134f6990ef297", // mine_flayers_bell
            "8b43a5c59b854eb780f9ab669ec26b7a", // dragun_egg_slimeguy
            "d1c9781fdac54d9e8498ed89210a0238", // tiny_blobulord
            "4538456236f64ea79f483784370bc62f", // fusebot
            "b8103805af174924b578c98e95313074", // poisbulin
            "be0683affb0e41bbb699cb7125fdded6", // mouser
            "42be66373a3d4d89b91a35c9ff8adfec", // blobulin
            "6b7ef9e5d05b4f96b04f05ef4a0d1b18", // rubber_kin
            "98fdf153a4dd4d51bf0bafe43f3c77ff", // tazie
            "c2f902b7cbe745efb3db4399927eab34" // skusket_head
        };

        public static string[] PotEnemyGUIDListNoFairies = {
            "6ad1cafc268f4214a101dca7af61bc91", // rat
            "14ea47ff46b54bb4a98f91ffcffb656d", // rat_candle
            "76bc43539fc24648bff4568c75c686d1", // chicken
            "1386da0f42fb4bcabc5be8feb16a7c38", // snake
            "2feb50a6a40f4f50982e89fd276f6f15", // bullat
            "b4666cb6ef4f4b038ba8924fd8adf38f", // grenat
            "2d4f8b5404614e7d8b235006acde427a", // shotgat
            "7ec3e8146f634c559a7d58b19191cd43", // spirat
            "d4dd2b2bbda64cc9bcec534b4e920518", // bullet_kings_toadie_revenge
            "4d37ce3d666b4ddda8039929225b7ede", // grenade_kin
            "0ff278534abb4fbaaa65d3f638003648", // poopulons_corn
            "95ea1a31fc9e4415a5f271b9aedf9b15", // robots_past_critter_1
            "42432592685e47c9941e339879379d3a", // robots_past_critter_2
            "4254a93fc3c84c0dbe0a8f0dddf48a5a", // robots_past_critter_3
            "b5e699a0abb94666bda567ab23bd91c4", // bullet_kings_toadie
            "02a14dec58ab45fb8aacde7aacd25b01", // old_kings_toadie
            "566ecca5f3b04945ac6ce1f26dedbf4f", // mine_flayers_claymore
            "78a8ee40dff2477e9c2134f6990ef297", // mine_flayers_bell
            "8b43a5c59b854eb780f9ab669ec26b7a", // dragun_egg_slimeguy
            "d1c9781fdac54d9e8498ed89210a0238", // tiny_blobulord
            "4538456236f64ea79f483784370bc62f", // fusebot
            "b8103805af174924b578c98e95313074", // poisbulin
            "be0683affb0e41bbb699cb7125fdded6", // mouser
            "42be66373a3d4d89b91a35c9ff8adfec", // blobulin
            "6b7ef9e5d05b4f96b04f05ef4a0d1b18", // rubber_kin
            "98fdf153a4dd4d51bf0bafe43f3c77ff", // tazie
            "c2f902b7cbe745efb3db4399927eab34" // skusket_head
        };

        public static string[] ContactOverrideGUIDList = {
            "6ad1cafc268f4214a101dca7af61bc91", // rat
            "14ea47ff46b54bb4a98f91ffcffb656d", // rat_candle
            "1386da0f42fb4bcabc5be8feb16a7c38", // snake
            "95ea1a31fc9e4415a5f271b9aedf9b15", // robots_past_critter_1
            "42432592685e47c9941e339879379d3a", // robots_past_critter_2
            "4254a93fc3c84c0dbe0a8f0dddf48a5a" // robots_past_critter_3
        };


        public static string[] CritterGUIDList = {
            "6ad1cafc268f4214a101dca7af61bc91", // rat
            "14ea47ff46b54bb4a98f91ffcffb656d", // rat_candle
            "76bc43539fc24648bff4568c75c686d1", // chicken
            "1386da0f42fb4bcabc5be8feb16a7c38", // snake
            "95ea1a31fc9e4415a5f271b9aedf9b15", // robots_past_critter_1
            "42432592685e47c9941e339879379d3a", // robots_past_critter_2
            "4254a93fc3c84c0dbe0a8f0dddf48a5a" // robots_past_critter_3
        };

        public static string[] PestGUIDList = {
            "6ad1cafc268f4214a101dca7af61bc91", // rat
            "14ea47ff46b54bb4a98f91ffcffb656d", // rat_candle
            "1386da0f42fb4bcabc5be8feb16a7c38", // snake
            "8b43a5c59b854eb780f9ab669ec26b7a", // dragun_egg_slimeguy
            "d1c9781fdac54d9e8498ed89210a0238", // tiny_blobulord
        };

        public static string[] SpawnEnemyOnDeathGUIDList = {
            "6ad1cafc268f4214a101dca7af61bc91", // rat
            "14ea47ff46b54bb4a98f91ffcffb656d", // rat_candle
            "76bc43539fc24648bff4568c75c686d1", // chicken
            "1386da0f42fb4bcabc5be8feb16a7c38", // snake
            "8b43a5c59b854eb780f9ab669ec26b7a", // dragun_egg_slimeguy
            "d1c9781fdac54d9e8498ed89210a0238", // tiny_blobulord
            "95ea1a31fc9e4415a5f271b9aedf9b15", // robots_past_critter_1
            "42432592685e47c9941e339879379d3a", // robots_past_critter_2
            "4254a93fc3c84c0dbe0a8f0dddf48a5a", // robots_past_critter_3
            "042edb1dfb614dc385d5ad1b010f2ee3", // blobuloid
            "fe3fe59d867347839824d5d9ae87f244", // poisbuloid
            "01972dee89fc4404a5c408d50007dad5", // bullet_kin
            "70216cae6c1346309d86d4a0b4603045", // veteran_bullet_kin
            "d4a9836f8ab14f3fadd0f597438b1f1f", // mutant_bullet_kin
            "d4dd2b2bbda64cc9bcec534b4e920518", // bullet_kings_toadie_revenge
            "05891b158cd542b1a5f3df30fb67a7ff", // arrow_head
            "699cd24270af4cd183d671090d8323a1", // key_bullet_kin
            "022d7c822bc146b58fe3b0287568aaa2", // blizzbulon
            "7ec3e8146f634c559a7d58b19191cd43", // spirat
            "b4666cb6ef4f4b038ba8924fd8adf38f", // grenat
            "2feb50a6a40f4f50982e89fd276f6f15", // bullat
            "2d4f8b5404614e7d8b235006acde427a" // shotgat
        };

        public static string[] RoomEnemyGUIDList = {
            "01972dee89fc4404a5c408d50007dad5", // bullet_kin
            "d4a9836f8ab14f3fadd0f597438b1f1f", // mutant_bullet_kin
            "05891b158cd542b1a5f3df30fb67a7ff", // arrow_head
            "f155fd2759764f4a9217db29dd21b7eb", // mountain_cube
            "9b2cf2949a894599917d4d391a0b7394", // high_gunjurer
            "a9cc6a4e9b3d46ea871e70a03c9f77d4", // marines_past_imp
            "1cec0cdf383e42b19920787798353e46", // black_skusket
            "95ec774b5a75467a9ab05fa230c0c143", // skullmet
            "5288e86d20184fa69c91ceb642d31474", // gummy
            "d8a445ea4d944cc1b55a40f22821ae69", // muzzle_flare
            "43426a2e39584871b287ac31df04b544", // wizbang
            "8b4a938cdbc64e64822e841e482ba3d2", // jammomancer
            "ba657723b2904aa79f9e51bce7d23872", // jamerlengo
            "2ebf8ef6728648089babb507dec4edb7", // brown_chest_mimic
            "8bb5578fba374e8aae8e10b754e61d62", // cardinal
            "37340393f97f41b2822bc02d14654172", // creech
            "062b9b64371e46e195de17b6f10e47c8", // bloodbulon
            "044a9f39712f456597b9762893fbc19c", // shotgrub
            "5f3abc2d561b4b9c9e72b879c6f10c7e", // fallen_bullet_kin
            "c4fba8def15e47b297865b18e36cbef8", // gunjurer
            "f38686671d524feda75261e469f30e0b", // ammoconda_ball
            "a446c626b56d4166915a4e29869737fd", // chance_bullet_kin
            "699cd24270af4cd183d671090d8323a1", // key_bullet_kin
            "57255ed50ee24794b7aac1ac3cfb8a95", // gun_cultist
            "022d7c822bc146b58fe3b0287568aaa2", // blizzbulon
            "56f5a0f2c1fc4bc78875aea617ee31ac", // spectre
            "56fb939a434140308b8f257f0f447829", // lore_gunjurer
            "1bd8e49f93614e76b140077ff2e33f2b", // ashen_shotgun_kin
            "1a78cfb776f54641b832e92c44021cf2", // ashen_bullet_kin
            "844657ad68894a4facb1b8e1aef1abf9", // hooded_bullet
            "3f6d6b0c4a7c4690807435c7b37c35a5", // agonizer
            "383175a55879441d90933b5c4e60cf6f", // spectre_gun_nut
            "b1770e0f1c744d9d887cc16122882b4f", // executioner
            "3e98ccecf7334ff2800188c417e67c15", // killithid
            "c5b11bfc065d417b9c4d03a5e385fe2c", // professional
            "2752019b770f473193b08b4005dc781f", // veteran_shotgun_kin
            "70216cae6c1346309d86d4a0b4603045", // veteran_bullet_kin
            "19b420dec96d4e9ea4aebc3398c0ba7a", // bombshee
            "98ca70157c364750a60f5e0084f9d3e2", // phaser_spider
            "1bc2a07ef87741be90c37096910843ab", // chancebulon
            "45192ff6d6cb43ed8f1a874ab6bef316", // misfire_beast
            "12a054b8a6e549dcac58a82b89e319e5", // robots_past_terminator
            "556e9f2a10f9411cb9dbfd61e0e0f1e1", // convicts_past_soldier
            "eeb33c3a5a8e4eaaaaf39a743e8767bc" // candle_guy
        };

        public static string[] ReplacementEnemyGUIDList = {
            "01972dee89fc4404a5c408d50007dad5", // bullet_kin
            "05891b158cd542b1a5f3df30fb67a7ff", // arrow_head
            "4d37ce3d666b4ddda8039929225b7ede", // grenade_kin
            "8bb5578fba374e8aae8e10b754e61d62", // cardinal
            "f905765488874846b7ff257ff81d6d0c", // fungun
            "37340393f97f41b2822bc02d14654172", // creech
            "5f3abc2d561b4b9c9e72b879c6f10c7e", // fallen_bullet_kin
            "f38686671d524feda75261e469f30e0b", // ammoconda_ball
            "1bd8e49f93614e76b140077ff2e33f2b", // ashen_shotgun_kin
            "1a78cfb776f54641b832e92c44021cf2", // ashen_bullet_kin
            "2752019b770f473193b08b4005dc781f", // veteran_shotgun_kin
            "70216cae6c1346309d86d4a0b4603045", // veteran_bullet_kin
            "d4dd2b2bbda64cc9bcec534b4e920518", // bullet_kings_toadie_revenge
            "a9cc6a4e9b3d46ea871e70a03c9f77d4", // marines_past_imp
            "6b7ef9e5d05b4f96b04f05ef4a0d1b18", // rubber_kin
            "98fdf153a4dd4d51bf0bafe43f3c77ff", // tazie
            "be0683affb0e41bbb699cb7125fdded6", // mouser
            "8b43a5c59b854eb780f9ab669ec26b7a", // dragun_egg_slimeguy
            "d1c9781fdac54d9e8498ed89210a0238", // tiny_blobulord
            "76bc43539fc24648bff4568c75c686d1", // chicken
            "eeb33c3a5a8e4eaaaaf39a743e8767bc" // candle_guy
        };

        /*
        public static string[] DieOnCollisionIfTinyGUIDList = {
            "c0ff3744760c4a2eb0bb52ac162056e6", // bookllet
            "6f22935656c54ccfb89fca30ad663a64", // blue_bookllet
            "a400523e535f41ac80a43ff6b06dc0bf", // green_bookllet
            "b5e699a0abb94666bda567ab23bd91c4", // bullet_kings_toadie
            "02a14dec58ab45fb8aacde7aacd25b01", // old_kings_toadie
            "d4dd2b2bbda64cc9bcec534b4e920518", // bullet_kings_toadie_revenge
            "be0683affb0e41bbb699cb7125fdded6", // mouser
            "6b7ef9e5d05b4f96b04f05ef4a0d1b18", // rubber_kin
            "98fdf153a4dd4d51bf0bafe43f3c77ff", // tazie
            "4538456236f64ea79f483784370bc62f", // fusebot
            "8b43a5c59b854eb780f9ab669ec26b7a", // dragun_egg_slimeguy
            "d1c9781fdac54d9e8498ed89210a0238", // tiny_blobulord
            "022d7c822bc146b58fe3b0287568aaa2", // blizzbulon
            "249db525a9464e5282d02162c88e0357", // spent
            "e21ac9492110493baef6df02a2682a0d", // gummy_spent
            "8b4a938cdbc64e64822e841e482ba3d2", // jammomancer
            "ba657723b2904aa79f9e51bce7d23872", // jamerlengo
            "c50a862d19fc4d30baeba54795e8cb93", // aged_gunsinger
            "56fb939a434140308b8f257f0f447829", // lore_gunjurer
            "b1540990a4f1480bbcb3bea70d67f60d", // ammomancer
            "cf2b7021eac44e3f95af07db9a7c442c", // LeadWizard
            "9b2cf2949a894599917d4d391a0b7394", // high_gunjurer
            "844657ad68894a4facb1b8e1aef1abf9", // hooded_bullet
            "fa6a7ac20a0e4083a4c2ee0d86f8bbf7", // red_caped_bullet_kin
            "57255ed50ee24794b7aac1ac3cfb8a95", // gun_cultist
            "206405acad4d4c33aac6717d184dc8d4", // apprentice_gunjurer
            "c4fba8def15e47b297865b18e36cbef8", // gunjurer
            "2ebf8ef6728648089babb507dec4edb7", // brown_chest_mimic
            "556e9f2a10f9411cb9dbfd61e0e0f1e1", // convicts_past_soldier
            "12a054b8a6e549dcac58a82b89e319e5", // robots_past_terminator
            "1398aaccb26d42f3b998c367b7800b85", // robots_past_human_1
            "9044d8e4431f490196ba697927a4e3d4", // robots_past_human_2
            "40bf8b0d97794a26b8c440425ec8cac1", // robots_past_human_3
            "3590db6c4eac474a93299a908cb77ab2", // robots_past_human_4
            "c182a5cb704d460d9d099a47af49c913", // pot_fairy
            "a9cc6a4e9b3d46ea871e70a03c9f77d4" // marines_past_imp
        };
        */

        public static string[] DontDieOnCollisionWhenTinyGUIDList = {
            "76bc43539fc24648bff4568c75c686d1", // chicken - This already dies on contact, plus I don't want to override it's death sound. :P
            // Companions
            "c07ef60ae32b404f99e294a6f9acba75", // dog
            "7bd9c670f35b4b8d84280f52a5cc47f6", // cucco
            "705e9081261446039e1ed9ff16905d04", // cop
            "998807b57e454f00a63d67883fcf90d6", // portable_turret
            "11a14dbd807e432985a89f69b5f9b31e", // phoenix
            "640238ba85dd4e94b3d6f68888e6ecb8", // cop_android
            "6f9c28403d3248c188c391f5e40774c5", // turkey
            "3a077fa5872d462196bb9a3cb1af02a3", // super_space_turtle
            "1ccdace06ebd42dc984d46cb1f0db6cf", // r2g2
            "fe51c83b41ce4a46b42f54ab5f31e6d0", // pig
            "ededff1deaf3430eaf8321d0c6b2bd80", // hunters_past_dog
            "d375913a61d1465f8e4ffcf4894e4427", // caterpillar
            "5695e8ffa77c4d099b4d9bd9536ff35e", // blank_companion
            "c6c8e59d0f5d41969c74e802c9d67d07", // ser_junkan
            "86237c6482754cd29819c239403a2de7", // pig_synergy
            "ad35abc5a3bf451581c3530417d89f2c", // blank_companion_synergy
            "e9fa6544000942a79ad05b6e4afb62db", // raccoon
            "ebf2314289ff4a4ead7ea7ef363a0a2e", // dog_synergy_1
            "ab4a779d6e8f429baafa4bf9e5dca3a9", // dog_synergy_2
            "9216803e9c894002a4b931d7ea9c6bdf", // super_space_turtle_synergy
            "cc9c41aa8c194e17b44ac45f993dd212", // super_space_turtle_dummy
            "45f5291a60724067bd3ccde50f65ac22", // payday_shooter_01
            "41ab10778daf4d3692e2bc4b370ab037", // payday_shooter_02
            "2976522ec560460c889d11bb54fbe758", // payday_shooter_03
            "e456b66ed3664a4cb590eab3a8ff3814" // baby_mimic
            // "4d37ce3d666b4ddda8039929225b7ede", // grenade_kin
            // "c0260c286c8d4538a697c5bf24976ccf" // dynamite_kin
            /*
            "f38686671d524feda75261e469f30e0b", // ammoconda_ball
            "21dd14e5ca2a4a388adab5b11b69a1e1", // shelleton"
            "ec8ea75b557d4e7b8ceeaacdf6f8238c", // gun_nut
            "383175a55879441d90933b5c4e60cf6f", // spectre_gun_nut
            "463d16121f884984abe759de38418e48", // chain_gunner
            "ac9d345575444c9a8d11b799e8719be0", // rat_chest_mimic
            "d8d651e3484f471ba8a2daa4bf535ce6", // blue_chest_mimic
            "abfb454340294a0992f4173d6e5898a8", // green_chest_mimic
            "6450d20137994881aff0ddd13e3d40c8", // black_chest_mimic
            "d8fd592b184b4ac9a3be217bc70912a2", // red_chest_mimic
            "b70cbd875fea498aa7fd14b970248920", // great_bullet_shark
            "78a8ee40dff2477e9c2134f6990ef297", // mine_flayers_bell
            "eed5addcc15148179f300cc0d9ee7f94", // spogre
            "0239c0680f9f467dbe5c4aab7dd1eca6", // blobulon
            "e61cab252cfb435db9172adc96ded75f", // poisbulon
            "c5b11bfc065d417b9c4d03a5e385fe2c" // professional
            */
        };

        public static string[] DontGlitchMeList = {
            "c0260c286c8d4538a697c5bf24976ccf", // dynamite_kin
            // "128db2f0781141bcb505d8f00f9e4d47", // red_shotgun_kin
            // "b54d89f9e802455cbb2b8a96a31e8259", // blue_shotgun_kin
            // "70216cae6c1346309d86d4a0b4603045", // veteran_bullet_kin
            // "2752019b770f473193b08b4005dc781f", // veteran_shotgun_kin
            "45192ff6d6cb43ed8f1a874ab6bef316" // misfire_beast
        };

        public static string[] OverrideFallIntoPitsList = {
            "ed37fa13e0fa4fcf8239643957c51293", // gigi
            "6b7ef9e5d05b4f96b04f05ef4a0d1b18", // rubber_kin
            "98fdf153a4dd4d51bf0bafe43f3c77ff", // tazie
            "2feb50a6a40f4f50982e89fd276f6f15", // bullat
            "2d4f8b5404614e7d8b235006acde427a", // shotgat
            "b4666cb6ef4f4b038ba8924fd8adf38f", // grenat
            "7ec3e8146f634c559a7d58b19191cd43", // spirat
            "4db03291a12144d69fe940d5a01de376", // hollowpoint
            "b70cbd875fea498aa7fd14b970248920", // great_bullet_shark
            "72d2f44431da43b8a3bae7d8a114a46d", // bullet_shark
            "c182a5cb704d460d9d099a47af49c913", // pot_fairy
            "9b4fb8a2a60a457f90dcf285d34143ac", // gat
            "48d74b9c65f44b888a94f9e093554977", // x_det
            "c5a0fd2774b64287bf11127ca59dd8b4", // diagonal_x_det
            "b67ffe82c66742d1985e5888fd8e6a03", // vertical_det
            "d9632631a18849539333a92332895ebd", // diagonal_det
            "1898f6fe1ee0408e886aaf05c23cc216", // horizontal_det
            "abd816b0bcbf4035b95837ca931169df", // vertical_x_det
            "07d06d2b23cc48fe9f95454c839cb361", // horizontal_x_det
            "ccf6d241dad64d989cbcaca2a8477f01", // t_bulon
            "864ea5a6a9324efc95a0dd2407f42810", // cubulon
            "1bc2a07ef87741be90c37096910843ab", // chancebulon
            "88f037c3f93b4362a040a87b30770407", // gunreaper
            "0d3f7c641557426fbac8596b61c9fb45", // lord_of_the_jammed
            // Companions
            "c07ef60ae32b404f99e294a6f9acba75", // dog
            "7bd9c670f35b4b8d84280f52a5cc47f6", // cucco
            "705e9081261446039e1ed9ff16905d04", // cop
            "998807b57e454f00a63d67883fcf90d6", // portable_turret
            "11a14dbd807e432985a89f69b5f9b31e", // phoenix
            "640238ba85dd4e94b3d6f68888e6ecb8", // cop_android
            "6f9c28403d3248c188c391f5e40774c5", // turkey
            "3a077fa5872d462196bb9a3cb1af02a3", // super_space_turtle
            "1ccdace06ebd42dc984d46cb1f0db6cf", // r2g2
            "fe51c83b41ce4a46b42f54ab5f31e6d0", // pig
            "ededff1deaf3430eaf8321d0c6b2bd80", // hunters_past_dog
            "d375913a61d1465f8e4ffcf4894e4427", // caterpillar
            "5695e8ffa77c4d099b4d9bd9536ff35e", // blank_companion
            "c6c8e59d0f5d41969c74e802c9d67d07", // ser_junkan
            "86237c6482754cd29819c239403a2de7", // pig_synergy
            "ad35abc5a3bf451581c3530417d89f2c", // blank_companion_synergy
            "e9fa6544000942a79ad05b6e4afb62db", // raccoon
            "ebf2314289ff4a4ead7ea7ef363a0a2e", // dog_synergy_1
            "ab4a779d6e8f429baafa4bf9e5dca3a9", // dog_synergy_2
            "9216803e9c894002a4b931d7ea9c6bdf", // super_space_turtle_synergy
            "cc9c41aa8c194e17b44ac45f993dd212", // super_space_turtle_dummy
            "45f5291a60724067bd3ccde50f65ac22", // payday_shooter_01
            "41ab10778daf4d3692e2bc4b370ab037", // payday_shooter_02
            "2976522ec560460c889d11bb54fbe758", // payday_shooter_03
            "e456b66ed3664a4cb590eab3a8ff3814" // baby_mimic
        };

        public static string[] DieOnContactOverrideList = {
            "2feb50a6a40f4f50982e89fd276f6f15", // bullat
            "2d4f8b5404614e7d8b235006acde427a", // shotgat
            "b4666cb6ef4f4b038ba8924fd8adf38f", // grenat
            "7ec3e8146f634c559a7d58b19191cd43" // spirat
        };

        public static string[] PreventBeingJammedOverrideList = {
            "2feb50a6a40f4f50982e89fd276f6f15", // bullat
            "2d4f8b5404614e7d8b235006acde427a", // shotgat
            "b4666cb6ef4f4b038ba8924fd8adf38f", // grenat
            "7ec3e8146f634c559a7d58b19191cd43", // spirat
            "6ad1cafc268f4214a101dca7af61bc91", // rat
            "14ea47ff46b54bb4a98f91ffcffb656d", // rat_candle
            "76bc43539fc24648bff4568c75c686d1", // chicken
            "0ff278534abb4fbaaa65d3f638003648", // poopulons_corn
            "8b43a5c59b854eb780f9ab669ec26b7a", // dragun_egg_slimeguy
            "d1c9781fdac54d9e8498ed89210a0238" // tiny_blobulord
        };

        public static string[] PreventDeathOnBossKillList = {
            "6ad1cafc268f4214a101dca7af61bc91", // rat
            "14ea47ff46b54bb4a98f91ffcffb656d", // rat_candle
            "76bc43539fc24648bff4568c75c686d1", // chicken
            "8b43a5c59b854eb780f9ab669ec26b7a", // dragun_egg_slimeguy
            "d1c9781fdac54d9e8498ed89210a0238" // tiny_blobulord
        };

        public static string[] KillOnRoomClearList = {
            "4538456236f64ea79f483784370bc62f", // fusebot
            "be0683affb0e41bbb699cb7125fdded6", // mouser
            "6b7ef9e5d05b4f96b04f05ef4a0d1b18", // rubber_kin
            "98fdf153a4dd4d51bf0bafe43f3c77ff", // tazie
            "d4dd2b2bbda64cc9bcec534b4e920518", // bullet_kings_toadie_revenge
            "42be66373a3d4d89b91a35c9ff8adfec", // blobulin
            "b8103805af174924b578c98e95313074", // poisbulin
            "c2f902b7cbe745efb3db4399927eab34", // skusket_head
            "4d37ce3d666b4ddda8039929225b7ede", // grenade_kin
            "2feb50a6a40f4f50982e89fd276f6f15", // bullat
            "2d4f8b5404614e7d8b235006acde427a", // shotgat
            "b4666cb6ef4f4b038ba8924fd8adf38f", // grenat
            "7ec3e8146f634c559a7d58b19191cd43", // spirat
            "566ecca5f3b04945ac6ce1f26dedbf4f" // mine_flayers_claymore
        };

        public static string[] AlreadyIgnoredForRoomClearList = {
            "6ad1cafc268f4214a101dca7af61bc91", // rat
            "14ea47ff46b54bb4a98f91ffcffb656d", // rat_candle
            "1386da0f42fb4bcabc5be8feb16a7c38", // snake
            "76bc43539fc24648bff4568c75c686d1", // chicken
            "c2f902b7cbe745efb3db4399927eab34", // skusket_head
            "8b43a5c59b854eb780f9ab669ec26b7a", // dragun_egg_slimeguy
            "d1c9781fdac54d9e8498ed89210a0238", // tiny_blobulord
            "95ea1a31fc9e4415a5f271b9aedf9b15", // robots_past_critter_1
            "42432592685e47c9941e339879379d3a", // robots_past_critter_2
            "4254a93fc3c84c0dbe0a8f0dddf48a5a", // robots_past_critter_3
            "b5e699a0abb94666bda567ab23bd91c4", // bullet_kings_toadie
            "02a14dec58ab45fb8aacde7aacd25b01", // old_kings_toadie
            "566ecca5f3b04945ac6ce1f26dedbf4f", // mine_flayers_claymore
            "78a8ee40dff2477e9c2134f6990ef297", // mine_flayers_bell
            "0ff278534abb4fbaaa65d3f638003648" // poopulons_corn
        };

        public static string[] TriggerTwinsGUIDList = {
            "ea40fcc863d34b0088f490f4e57f8913", // smiley
            "c00390483f394a849c36143eb878998f" // shades
        };

        public static string BulletKinEnemyGUID = "01972dee89fc4404a5c408d50007dad5";
        public static string LeadMaidenEnemyGUID = "cd4a4b7f612a4ba9a720b9f97c52f38c";
        public static string tombstonerEnemyGUID = "cf27dd464a504a428d87a8b2560ad40a";
        public static string poisbuloidEnemyGUID = "fe3fe59d867347839824d5d9ae87f244";
        public static string skusketHeadEnemyGUID = "c2f902b7cbe745efb3db4399927eab34";
        public static string fungunEnemyGUID = "f905765488874846b7ff257ff81d6d0c";
        // public static string chancekinEnemyGUID = "a446c626b56d4166915a4e29869737fd";
        public static string snakeGUID = "1386da0f42fb4bcabc5be8feb16a7c38";
        // public static string wallmongerGUID = "f3b04a067a65492f8b279130323b41f0";

        public static AIActor BulletKinGUID = EnemyDatabase.GetOrLoadByGuid(BulletKinEnemyGUID);
        public static AIActor TombstonerGUID = EnemyDatabase.GetOrLoadByGuid(tombstonerEnemyGUID);
        public static AIActor PoisbuloidGUID = EnemyDatabase.GetOrLoadByGuid(poisbuloidEnemyGUID);
        public static AIActor skusketHeadGUID = EnemyDatabase.GetOrLoadByGuid(skusketHeadEnemyGUID);
        public static AIActor fungunGUID = EnemyDatabase.GetOrLoadByGuid(fungunEnemyGUID);
        // public static AIActor chancekinGUID = EnemyDatabase.GetOrLoadByGuid(chancekinEnemyGUID);
    }
}

