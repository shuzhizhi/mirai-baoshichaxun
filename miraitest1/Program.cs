
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using System;
using System.Net;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Mirai.Net.Utils.Scaffolds;
using Mirai.Net.Data.Events.Concretes.Message;

class program
{
    static string[] a = new string[10];
    static int[] b = new int[10];
    static string juedou = "0";
    static int renshu = 0;
    static int huoshengzhe = 1;
    static string x = "0";
    static async Task Main(string[] args)
    {
        Random ran = new Random();
        // System.Threading.Thread.Sleep(180000);
        using var bot = new MiraiBot
        {
            Address = "localhost:8080",
            //   QQ = "2402989185",
            QQ = "815723827",
            VerifyKey = "123456798"
        };
        Console.WriteLine($"本程序已启动");
        Console.WriteLine($"正在尝试连接机器人。。。");
        try
        {
            await bot.LaunchAsync();
            Console.WriteLine($"机器人连接成功");
        }
        catch (Exception e)
        {
            Console.WriteLine($"连接失败，将在3分钟后再次尝试连接。");
            System.Threading.Thread.Sleep(180000);
            await bot.LaunchAsync();
        }



        bot.MessageReceived
    .OfType<GroupMessageReceiver>()
    .Subscribe(async receiver =>
    {

        var message = "0";
        if (receiver.MessageChain.OfType<PlainMessage>().Any())
        {
            message = receiver.MessageChain.OfType<PlainMessage>().First().Text;
        }
        else
        {
            message = "0";

        }

        Console.WriteLine("收到消息是" + message);
        var senderName = receiver.Sender.Name;
        var groupid = receiver.Id;
        var group = receiver.Name;
        var senderid = receiver.Sender.Id;
        try
        {

            if (message.Contains("复读") && senderid == "626942409")
            {

                message = message.Replace("复读", "");
                await MessageManager.SendGroupMessageAsync(receiver.Id, message);

            }
            // Console.WriteLine($"收到了来自{groupid}{group}群的{senderid}{senderName}这样的消息：{message}");
            if (message.Contains("查询宝石数据"))
            {
                string x = message;
                x = x.Replace(bot.QQ, "");
                string str = System.Text.RegularExpressions.Regex.Replace(x, @"[^0-9]+", "");
                if (System.Text.RegularExpressions.Regex.IsMatch(str, "^[0-9]+$"))
                {



                    //    await MessageManager.SendGroupMessageAsync(receiver.Id, str);

                    string str1 = "https://api.opendota.com/api/players/" + str;
                    string url = str1;
                    //    await MessageManager.SendGroupMessageAsync(receiver.Id, url);

                    WebResponse? response;



                    HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                    try
                    {
                        response = request.GetResponse();
                    }
                    catch (WebException ex)
                    {
                        response = ex.Response;

                    }
                    // WebResponse response = request.GetResponse();
                    string y;
                    if (response == null)
                    {
                        y = "0";
                    }
                    else
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        y = reader.ReadToEnd();//a为转换网页的整个文档  
                    }

                    string a = "0";
                    if (y.Contains("7656"))
                    {
                        a = y;
                    }
                    else
                    {

                        string str2 = "https://steamid.io/lookup/U:1:" + str;
                        string ur2 = str2;
                        //    await MessageManager.SendGroupMessageAsync(receiver.Id, url);

                        WebResponse response2;



                        HttpWebRequest request2 = (HttpWebRequest)WebRequest.CreateDefault(new Uri(ur2));
                        try
                        {
                            response2 = request2.GetResponse();
                        }
                        catch (WebException ex)
                        {
                            response2 = ex.Response;
                        }
                        // WebResponse response = request.GetResponse();
                        // StreamReader reader2 = new StreamReader(response2.GetResponseStream());
                        // string y2 = reader2.ReadToEnd();//a为转换网页的整个文档  
                        string y4;
                        if (response2 == null)
                        {
                            y4 = "0";
                        }
                        else
                        {
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            y4 = reader.ReadToEnd();//a为转换网页的整个文档  
                        }
                        a = y4;
                    }
                    string h = "7656";//h为64位id的头文档
                    int g = a.IndexOf(h);//g为64位id的位置数值
                    int changdu = a.Length;
                    string b = "0";
                    string o = "0";
                    if (changdu >= 17)
                    {
                        b = a.Substring(g, 17);
                        //   await MessageManager.SendGroupMessageAsync(receiver.Id, b);
                        string i = "personaname\":\"";//i位昵称的前置8位文档
                        int j = a.IndexOf(i);//j为昵称的前置8位数值
                        o = a.Substring(j + 14, 100);
                        int p = o.IndexOf('"');
                        o = o.Remove(p);
                    }
                    else
                    {
                        b = "123456789";
                        o = "查不到昵称的倒霉蛋";
                        //  Int64 b =  Convert.ToInt64("76561197960265728") + Convert.ToInt64(str);
                    }

                    // string c = "http://gemtd.ppbizon.com/gemtd/201901/heros/get/@" + Convert.ToString(b);
                    long id = 0;
                    string c = "0";
                    try
                    {
                        id = long.Parse(str);
                        id = id + 76561197960265728;
                        c = "http://gemtd.ppbizon.com/gemtd/202203/heros/get/@" + id;

                    }
                    catch
                    {
                        c = "http://gemtd.ppbizon.com/gemtd/202203/heros/get/@" + str;
                    }




                    WebResponse? responsea;



                    HttpWebRequest requesta = (HttpWebRequest)WebRequest.CreateDefault(new Uri(c));
                    try
                    {
                        responsea = requesta.GetResponse();
                    }
                    catch (WebException ex)
                    {
                        responsea = ex.Response;
                    }
                    string y3;
                    if (responsea == null)
                    {
                        y3 = "0";
                    }
                    else
                    {
                        StreamReader readera = new StreamReader(responsea.GetResponseStream());
                        y3 = readera.ReadToEnd();//a为转换网页的整个文档  
                    }
                    // WebResponse response = request.GetResponse();
                    // StreamReader reader = new StreamReader(responsea.GetResponseStream());
                    string d = y3;//d为转换网页的整个文档   
                    Encoding gb2312 = Encoding.GetEncoding(936);
                    d = gb2312.GetString(Encoding.Default.GetBytes(d));
                    // byte[] bytes = gb2312.GetBytes(d);
                    //    d = Encoding.UTF8.GetString(Encoding.Default.GetBytes(d));


                    //   await MessageManager.SendGroupMessageAsync(receiver.Id, d);
                    // string str = "1.234E0，2.05E1，-3.0E2，-1.1E-2";
                    //   string d1 = d.Replace("Hello", "Ni hao");//将子字符串Hello 替换为Ni Hao。
                    string l = "onduty_hero,当前英雄,hero_id,\r\n英雄,extend,特效款式,_expire,剩余时间（秒）,_finish_count,完成次数,shell,贝壳,ice,冰块,candy,糖果,pet,宠物,pass,通关任务剩余时间（秒）,season,赛季剩余时间（秒）,extend_tool,格子扩展包,a306,回到过去,hero_sea,英雄,common_hero,普通 英雄,rare_hero,稀有 英雄,mythical_hero,神话 英雄,legendary_hero,传说 英雄,common_ability,普通 英雄技能,rare_ability,稀有 英雄技能,mythical_ability,神话 英雄技能,legendary_ability,传说 英雄技能,common_effect,普通 英雄特效,rare_effect,稀有 英雄特效,mythical_effect,神话 英雄特效,legendary_effect,传说 英雄特效,luckybox,一箱好东西?,buy,购买!,b201607,卡尔幸运箱,a101,回春,a102,闪避,a103,守护,a104,石头,a201,蓝色祈祷,a202,蛋白祈祷,a203,白色祈祷,a204,红色祈祷,a205,绿色祈祷,a206,海浪祈祷,a207,黄色祈祷,a208,紫色祈祷,a209,精英祈祷,a301,快速射击,a302,暴击,a303,瞄准,a304,风暴之锤,a401,移形换位,a210,普通许愿,a305,无暇许愿,a402,完美许愿,b201608,卡尔幸运箱,a105,背水一战,a211,乾坤小挪移,a307,致命链接,q101,不合成白银完成全部关卡。,q102,不合成孔雀石完成全部关卡。,q103,不合成星彩红宝石完成全部关卡。,q104,击杀小飞象Zard-并完成全部关卡。,q105,60分钟内完成全部关卡。,q106,没有一回合合成任何塔完成全部关卡。,q107,宝石城堡满血完成全部关卡。,q108,合出任意隐藏塔并完成全部关卡。,q201,不合成玉完成全部关卡。,q202,不保留钻石完成全部关卡。,q203,不保留蓝宝石完成全部关卡。,q204,不保留红宝石完成全部关卡。,q205,不保留黄玉完成全部关卡。,q206,不保留紫晶完成全部关卡。,q207,不保留海晶石完成全部关卡。,q208,不保留翡翠完成全部关卡。,q209,50分钟内完成全部关卡。,q301,不合成深海珍珠完成全部关卡。,q302,40分钟内完成全部关卡。,q303,击杀黄金肉山宝宝并完成全部关卡。,e101,圣洁精华,e102,玛瑙光泽,e103,芳晓之庆,e104,水晶裂痕,e105,腐化触须,e106,毒虫肆虐,e107,夜魇暗潮腐化,e108,夜魇暗潮荒芜,e201,暗淡幻象,e202,冥魂大帝,e203,翡翠外质,e204,祸乱之源,e205,毒蕈之径,e206,2012冠军之辉,e207,2013冠军之辉,e208,2014冠军之辉,e301,骄阳之炎,e302,嬉戏蝴蝶,e303,冰女特效,e304,幸福之赐,e305,绽放莲花,e306,迎霜冰雪,e307,燃烧末日,e308,鱼泡泡,e401,燃焰之触,e402,霜寒之触,e403,迈达斯之触,e404,离子之汽,e109,大地灵气,e110,蓝色风暴,e309,紫色激情,e310,白雪飘零,e311,一股邪火,e209,霓虹蝴蝶,e210,旋转火花,e312,金币飞舞,e313,光辉岁月,e314,紫色星云,e315,噩梦缠绕,e111,一起哈啤,e112,宝石光泽,e211,雾气环绕,e212,迷幻缠绕,e405,光芒万丈,e316,星星,e113,污污污污,e499,金龙鱼,e114,雾里看花,e317,心心相印,e318,2017冠军之辉,e319,灿若繁星,e320,大漩涡,e407,飞沙走石,e406,星光蓝宝石,e409,血之环,e408,暗月来袭,a403,糖果道标,q109,任意关卡的敌人数量超过20并完成全部关卡。,q110,合成任意闪亮的石板并完成全部关卡。,q210,合成任意超级塔并完成全部关卡。,q211,不使用任何英雄技能完成全部关卡。,q304,升级五个MVP-MAX的塔并完成全部关卡。,e213,小家碧玉,e214,欲火焚身,e321,通灵术,e410,雪精灵,e450,虚无之焰,e451,虚无之焰|红色,e452,虚无之焰|橙色,e453,虚无之焰|黄色,e454,虚无之焰|绿色,e455,虚无之焰|青色,e456,虚无之焰|蓝色,e457,虚无之焰|紫色,e458,虚无之焰|白色,e459,虚无之焰|粉色,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1";
                    string[] n = l.Split(',');
                    //    d = "rarity_1,普通";
                    int m = 0;
                    for (m = 0; m < 307; m++)
                    {
                        if (d.Contains(n[m]))
                        {
                            d = d.Replace(n[m], n[m + 1]);
                            m++;
                        }
                    }
                    string l1 = "h101,npc_dota_hero_enchantress,h102,npc_dota_hero_puck,h103,npc_dota_hero_omniknight,h104,npc_dota_hero_wisp,h105,npc_dota_hero_ogre_magi,h106,npc_dota_hero_lion,h107,npc_dota_hero_keeper_of_the_light,h108,npc_dota_hero_rubick,h109,npc_dota_hero_jakiro,h110,npc_dota_hero_sand_king,h111,npc_dota_hero_ancient_apparition,h112,npc_dota_hero_earth_spirit,h201,npc_dota_hero_crystal_maiden,h203,npc_dota_hero_templar_assassin,h204,npc_dota_hero_lina,h205,npc_dota_hero_tidehunter,h206,npc_dota_hero_naga_siren,h207,npc_dota_hero_phoenix,h208,npc_dota_hero_dazzle,h209,npc_dota_hero_warlock,h210,npc_dota_hero_necrolyte,h211,npc_dota_hero_lich,h212,npc_dota_hero_furion,h213,npc_dota_hero_venomancer,h214,npc_dota_hero_kunkka,h215,npc_dota_hero_axe,h216,npc_dota_hero_slark,h217,npc_dota_hero_viper,h218,npc_dota_hero_tusk,h219,npc_dota_hero_abaddon,h220,npc_dota_hero_winter_wyvern,h221,npc_dota_hero_ember_spirit,h301,npc_dota_hero_windrunner,h302,npc_dota_hero_phantom_assassin,h303,npc_dota_hero_sniper,h304,npc_dota_hero_sven,h306,npc_dota_hero_mirana,h307,npc_dota_hero_nevermore,h308,npc_dota_hero_queenofpain,h309,npc_dota_hero_juggernaut,h310,npc_dota_hero_pudge,h311,npc_dota_hero_shredder,h312,npc_dota_hero_slardar,h313,npc_dota_hero_antimage,h314,npc_dota_hero_bristleback,h315,npc_dota_hero_lycan,h316,npc_dota_hero_lone_druid,h317,npc_dota_hero_storm_spirit,h318,npc_dota_hero_obsidian_destroyer,h319,npc_dota_hero_grimstroke,h401,npc_dota_hero_vengefulspirit,h402,npc_dota_hero_invoker,h403,npc_dota_hero_alchemist,h404,npc_dota_hero_spectre,h405,npc_dota_hero_morphling,h406,npc_dota_hero_techies,h407,npc_dota_hero_chaos_knight,h408,npc_dota_hero_faceless_void,h409,npc_dota_hero_legion_commander,h410,npc_dota_hero_monkey_king,h411,npc_dota_hero_razor,h412,npc_dota_hero_tinker,h413,npc_dota_hero_pangolier,h414,npc_dota_hero_dark_willow,h415,npc_dota_hero_terrorblade,h416,npc_dota_hero_enigma,t401,奶酪,t402,贪魔蛋,t403,值钱的贝壳,t301,南瓜,t302,雪球,t303,沙滩椅,t304,地渊孢林,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,";
                    string[] n1 = l1.Split(',');
                    //    d = "rarity_1,普通";
                    int m1 = 0;
                    for (m1 = 0; m1 < 151; m1++)
                    {
                        if (d.Contains(n1[m1]))
                        {
                            d = d.Replace(n1[m1], n1[m1 + 1]);
                            m1++;
                        }
                    }

                    string l2 = "common_toy,普通 玩具,rare_toy,稀有 玩具,mythical_toy,神话 玩具,legendary_toy,传说 玩具,npc_dota_hero_enchantress,魅惑魔女,npc_dota_hero_puck,精灵龙,npc_dota_hero_omniknignt,全能骑士,npc_dota_hero_crystal_maiden,水晶室女,npc_dota_hero_templar_assassin,圣堂刺客,npc_dota_hero_lina,秀逗魔导士,npc_dota_hero_windrunner,风行者,npc_dota_hero_phantom_assassin,幻影刺客,npc_dota_hero_sniper,狙击手,npc_dota_hero_vengefulspirit,复仇之魂,npc_dota_hero_sven,流浪剑客,npc_dota_hero_invoker,召唤师,npc_dota_hero_dazzle,暗影牧师,npc_dota_hero_riki,隐形刺客,npc_dota_hero_wisp,精灵守卫,npc_dota_hero_ogre_magi,食人魔法师,npc_dota_hero_lion,恶魔巫师,npc_dota_hero_phoenix,凤凰,npc_dota_hero_necrolyte,死灵法师,npc_dota_hero_lich,巫妖,npc_dota_hero_furion,先知,npc_dota_hero_mirana,月之女祭司,npc_dota_hero_nevermore,影魔,npc_dota_hero_queenofpain,痛苦女王,npc_dota_hero_alchemist,炼金,npc_dota_hero_spectre,幽鬼,npc_dota_hero_omniknight,全能骑士,npc_dota_hero_warlock,术士,npc_dota_hero_keeper_of_the_light,光之守卫,npc_dota_hero_rubick,大魔导师,npc_dota_hero_venomancer,剧毒,npc_dota_hero_kunkka,海军上将,npc_dota_hero_juggernaut,剑圣,npc_dota_hero_pudge,屠夫,npc_dota_hero_shredder,伐木机,npc_dota_hero_morphling,变体精灵,npc_dota_hero_techies,地精工程师,npc_dota_hero_tidehunter,潮汐猎人,npc_dota_hero_naga_siren,娜迦海妖,npc_dota_hero_chaos_knight,混沌骑士,npc_dota_hero_faceless_void,虚空假面,npc_dota_hero_slardar,鱼人守卫,npc_dota_hero_antimage,敌法师,npc_dota_hero_axe,斧王,npc_dota_hero_slark,鱼人夜行者,npc_dota_hero_legion_commander,军团指挥官,npc_dota_hero_jakiro,双头龙,npc_dota_hero_sand_king,沙王,npc_dota_hero_viper,冥界亚龙,npc_dota_hero_tusk,巨牙海民,npc_dota_hero_abaddon,死亡骑士,npc_dota_hero_bristleback,刚背兽,npc_dota_hero_lycan,狼人,npc_dota_hero_lone_druid,利爪德鲁伊,npc_dota_hero_monkey_king,齐天大圣,npc_dota_hero_razor,闪电幽魂,npc_dota_hero_tinker,地精修补匠,npc_dota_hero_dark_willow,邪影芳灵,npc_dota_hero_pangolier,石鳞剑士,npc_dota_hero_ancient_apparition,远古冰魄,npc_dota_hero_earth_spirit,大地之灵,npc_dota_hero_winter_wyvern,寒冬飞龙,npc_dota_hero_ember_spirit,灰烬之灵,npc_dota_hero_storm_spirit,风暴之灵,npc_dota_hero_obsidian_destroyer,殁境神噬者,npc_dota_hero_terrorblade,灵魂守卫,npc_dota_hero_enigma,谜团,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,";
                    string[] n2 = l2.Split(',');
                    //    d = "rarity_1,普通";
                    int m2 = 0;
                    for (m2 = 0; m2 < 160; m2++)
                    {
                        if (d.Contains(n2[m2]))
                        {
                            d = d.Replace(n2[m2], n2[m2 + 1]);
                            m2++;
                        }
                    }
                    d = d.Substring(d.IndexOf("英雄"));
                    // d = d.Substring(0, d.IndexOf("quest"));
                    d = d.Replace("{", "\r\n");
                    d = d.Replace("}", "\r\n");
                    d = d.Replace("\"", "");
                    d = d.Replace("q399", "丛林挑战");
                    d = d.Replace("q398", "暗月来袭");
                    d = d.Replace("a308", "乌索尔旋风");
                    d = d.Replace("ability:\r\n", "");
                    d = d.Replace("ability:", "");
                    d = d.Replace("effect:\r\n", "");
                    d = d.Replace("effect:", "");
                    //  d = d.Replace("pet", "任务完成次数");
                    d = d.Replace("h305", "月之骑土");
                    d = d.Replace("h202", "死亡仙知");
                    d = d.Replace("q111_", "队伍中带有");
                    //  d = d.Replace(":", "");
                    d = d.Replace("\r\n\r\n", "");
                    d = d.Replace(",", "");

                    //d = d.Replace("", "");
                    //  d = d.Replace("", "");
                    //  await MessageManager.SendGroupMessageAsync(receiver.Id, n[50]);
                    //  await MessageManager.SendGroupMessageAsync(receiver.Id, n[51]);
                    //  await MessageManager.SendGroupMessageAsync(receiver.Id, n[52]);
                    //   await MessageManager.SendGroupMessageAsync(receiver.Id, n[34]);

                    // d = Encoding.UTF8.GetString(Encoding.Default.GetBytes(d));

                    /*   string c1 = "http://gemtd.ppbizon.com/gemtd/201807/mmr/get/@" + id;

                       WebResponse? responsea1;



                       HttpWebRequest requesta1 = (HttpWebRequest)WebRequest.CreateDefault(new Uri(c1));
                       try
                       {
                           responsea1 = requesta1.GetResponse();
                       }
                       catch (WebException ex)
                       {
                           responsea1 = ex.Response;
                       }
                       string y2;
                       if (responsea1 == null)
                       {
                           y2 = "0";
                       }
                       else
                       {
                           StreamReader reader = new StreamReader(responsea1.GetResponseStream());
                           y2 = reader.ReadToEnd();//a为转换网页的整个文档  
                       }
                       // WebResponse response = request.GetResponse();
                      // StreamReader readera1 = new StreamReader(responsea1.GetResponseStream());
                       string d1 = y2;//d为转换网页的整个文档   

                       d1 = gb2312.GetString(Encoding.Default.GetBytes(d1));
                       d1 = d1.Substring(d1.IndexOf("match") + 8);
                       d1 = d1.Replace("mmr", "\r\n隐藏分");
                       d1 = d1.Replace("rankall", "总排位");
                       d1 = d1.Replace("rankcoop", "组队排位");
                       d1 = d1.Replace("rankrace", "比赛排位");
                       d1 = d1.Replace("all_level", "总体等级");
                       d1 = d1.Replace("coop_level", "coop等级");
                       d1 = d1.Replace("race_level", "race等级");
                       d1 = d1.Replace("score", "分数");
                           d1 = d1.Replace("best_kills", "最好成绩：");
                           d1 = d1.Replace("}]}", "");
                       d1 = d1.Replace("\"", "");
                           d1 = d1.Replace("{", "");
                           d1 = d1.Replace("}", "");



                           d = "查询的ID昵称为:" + o + "\r\n" + d + d1;*/
                    d = d.Replace("mmr", "\r\n隐藏分");
                    d = d.Replace("rankall", "总排位");
                    d = d.Replace("rankcoop", "组队排位");
                    d = d.Replace("rankrace", "比赛排位");
                    d = d.Replace("all_level", "总体等级");
                    d = d.Replace("coop_level", "coop等级");
                    d = d.Replace("race_level", "race等级");
                    d = d.Replace("score", "总排位");
                    d = d.Replace("best_kills", "最好成绩：");
                    d = d.Replace("}]}", "");
                    d = d.Replace("\"", "");
                    d = d.Replace("{", "");
                    d = d.Replace("}", "");
                    // d = d.Replace("quest:", "\r\n任务");
                    d = d.Replace("quest", "\r\n任务");
                    d = d.Replace("rank_info", "\r\n排位信息");
                    d = d.Replace("user", "\r\n用户id");
                    d = d.Replace("match", "\r\n比赛");
                    d = d.Replace("word_object", "\r\n赛季信息");
                    d = d.Replace("name", "\r\n当前主题");
                    d = d.Replace("word_next", "\r\n下季主题");
                    d = d.Replace("quest_expire", "\r\n任务剩余时间（秒）");
                    d = d.Replace("expire", "\r\n赛季剩余时间（秒）");
                    d = d.Replace("items", "\r\n石头饰品");
                    d = "查询的ID昵称为:" + o + "\r\n" + d;
                    try
                    {

                        await MessageManager.SendGroupMessageAsync(receiver.Id, d);

                    }

                    catch (Exception ex)
                    {
                        await MessageManager.SendGroupMessageAsync("145368121", "发送消息失败" + DateTime.Now);
                        Console.WriteLine("发送失败" + DateTime.Now);
                    };



                    d = "0";

                }
            }
            if (message.Contains("查询滑冰数据"))
            {
                string x = message;
                x = x.Replace(bot.QQ, "");

                string str = System.Text.RegularExpressions.Regex.Replace(x, @"[^0-9]+", "");
                if (System.Text.RegularExpressions.Regex.IsMatch(str, "^[0-9]+$"))
                {



                    //    await MessageManager.SendGroupMessageAsync(receiver.Id, str);

                    string str1 = "https://api.opendota.com/api/players/" + str;
                    string url = str1;
                    //    await MessageManager.SendGroupMessageAsync(receiver.Id, url);

                    WebResponse response;



                    HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                    try
                    {
                        response = request.GetResponse();
                    }
                    catch (WebException ex)
                    {
                        response = ex.Response;
                    }
                    string y2;
                    if (response == null)
                    {
                        y2 = "0";
                    }
                    else
                    {
                        StreamReader reader1 = new StreamReader(response.GetResponseStream());
                        y2 = reader1.ReadToEnd();//a为转换网页的整个文档  
                    }
                    // WebResponse response = request.GetResponse();
                    // StreamReader reader = new StreamReader(response.GetResponseStream());
                    string y = y2;//a为转换网页的整个文档  
                    string a = "0";
                    if (y.Contains("7656"))
                    {
                        a = y;
                    }
                    else
                    {

                        string str2 = "https://steamid.io/lookup/U:1:" + str;
                        string ur2 = str2;
                        //    await MessageManager.SendGroupMessageAsync(receiver.Id, url);

                        WebResponse response2;



                        HttpWebRequest request2 = (HttpWebRequest)WebRequest.CreateDefault(new Uri(ur2));
                        try
                        {
                            response2 = request2.GetResponse();
                        }
                        catch (WebException ex)
                        {
                            response2 = ex.Response;
                        }
                        string y3;
                        if (response2 == null)
                        {
                            y3 = "0";
                        }
                        else
                        {
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            y3 = reader.ReadToEnd();//a为转换网页的整个文档  
                        }
                        // WebResponse response = request.GetResponse();
                        // StreamReader reader2 = new StreamReader(response2.GetResponseStream());
                        //  string y2 = reader2.ReadToEnd();//a为转换网页的整个文档  
                        a = y3;
                    }
                    Console.WriteLine(a);

                    string h = "7656";//h为64位id的头文档
                    int g = a.IndexOf(h);//g为64位id的位置数值
                    int changdu = a.Length;
                    string b = "0";
                    string o = "0";
                    if (changdu >= 17)
                    {
                        b = a.Substring(g, 17);
                        //   await MessageManager.SendGroupMessageAsync(receiver.Id, b);
                        string i = "personaname\":\"";//i位昵称的前置8位文档
                        int j = a.IndexOf(i);//j为昵称的前置8位数值
                        o = a.Substring(j + 14, 100);
                        int p = o.IndexOf('"');
                        o = o.Remove(p);
                    }
                    else
                    {
                        b = "123456789";
                        o = "查不到昵称的倒霉蛋";
                        //  Int64 b =  Convert.ToInt64("76561197960265728") + Convert.ToInt64(str);
                    }
                    //  Int64 b =  Convert.ToInt64("76561197960265728") + Convert.ToInt64(str);


                    // string c = "http://gemtd.ppbizon.com/gemtd/201901/heros/get/@" + Convert.ToString(b);
                    long id = 0;
                    string c = "0";
                    try
                    {
                        id = long.Parse(str);
                        id = id + 76561197960265728;
                        c = "http://gemtd.ppbizon.com/sm/201901/heros/get/@" + id;

                    }
                    catch
                    {
                        c = "http://gemtd.ppbizon.com/sm/201901/heros/get/@" + str;
                    }


                    WebResponse responsea;



                    HttpWebRequest requesta = (HttpWebRequest)WebRequest.CreateDefault(new Uri(c));
                    try
                    {
                        responsea = requesta.GetResponse();
                    }
                    catch (WebException ex)
                    {
                        responsea = ex.Response;
                    }
                    // WebResponse response = request.GetResponse();
                    StreamReader readera = new StreamReader(responsea.GetResponseStream());
                    string d = readera.ReadToEnd();//d为转换网页的整个文档   
                    Encoding gb2312 = Encoding.GetEncoding(936);
                    d = gb2312.GetString(Encoding.Default.GetBytes(d));
                    // byte[] bytes = gb2312.GetBytes(d);
                    //    d = Encoding.UTF8.GetString(Encoding.Default.GetBytes(d));

                    Console.WriteLine(d);
                    //   await MessageManager.SendGroupMessageAsync(receiver.Id, d);
                    // string str = "1.234E0，2.05E1，-3.0E2，-1.1E-2";
                    //   string d1 = d.Replace("Hello", "Ni hao");//将子字符串Hello 替换为Ni Hao。
                    string l = "a407,技能窃取,a208,照明弹,a405,无敌,a406,海妖之歌,a101,冲刺,a101_help,3秒内提高移动速度200,a102,刹车,a101_help,瞬间停住,a103,加速光环,a101_help,1000范围内友军移动速度增加50,a104,减速光环,a101_help,1000范围内敌军移动速度降低100,a201,冰冻,a101_help,使500范围内敌人3秒无法移动,a202,击退,a101_help,击退自己附近的敌人,a203,时光倒流,a101_help,使自己回到四秒前位置,a204,信仰之跃,a101_help,向前跳跃,a205,折光,a206,链接,a207,粘滞,a101_help,10秒内抵挡一次伤害,a301,召唤,a101_help,立刻召唤任意一名队友到你身边,a302,传送,a101_help,立刻传送到一个队友身边,a303,投掷,a101_help,把一个队友扔到另一个队友身上,a305,标记,a304,消失,a401,沉默,a101_help,使2000范围内敌人沉默5秒,a402,复活,a101_help,随机复活一名死去的队友,a403,融化,a404,重生,beginner_hero,入门级 滑冰手,ameteur_hero,业余级 滑冰手,pro_hero,职业级 滑冰手,master_hero,大师级 滑冰手,beginner_ability,入门级 技能,ameteur_ability,业余级 技能,pro_ability,职业级 技能,master_ability,大师级 技能,beginner_effect,入门级 特效,ameteur_effect,业余级 特效,pro_effect,职业级 特效,master_effect,大师级 特效,OhIgota,噢耶，我获得了,h101,船长的鹦鹉,h102,宝石教父Zard-,h103,神兔,h104,粉嫩蝾螈,h105,酒桶浣熊,h106,毛毛鱼,h107,海盗船,h108,达士奇,h109,萌蛛,h110,翠花|红色,h111,白羽鸡,h112,绿毛龟,h113,空心恶魔人,h114,歪脖鸵鸟,h115,跳脚企鹅,h116,胡小桃,h117,小红毛,h118,极速蜗牛,h119,松鼠卫兵,h120,丹顶鹤,h401,NAVI黄鼬,h402,MVP滑板火烈鸟,h403,IG小火龙,h404,LGD的金萌萌,h405,VG飞狐侠|红色,h406,VP北极熊,h407,EG的麋鹿,h201,末日宝宝,h202,赏金宝宝,h203,屠夫宝宝,h204,血魔宝宝,h205,小白虎,h206,海民宝宝,h207,黑鸟宝宝,h208,虚空宝宝,h209,修补匠宝宝,h210,小星月,h301,魔典小龙,h302,斑竹队长,h303,滑板鲨鱼,h304,炸毛小鸡,h305,摇摆蘑菇,h306,坚果松鼠,h307,翠玉小龙,h308,巨鸟多多,h309,机械战驴,h310,基拉魔法师,h211,两栖鱼童,h408,石头人|天辉,h409,石头人|夜魇,h121,双头恶犬,h311,爆眼章鱼,h212,剧毒宝宝,h410,火星车|绿色,h411,火星车|红色,h122,飞僵小宝,h412,对映体|天使,h413,对映体|恶魔,h123,雷克,h312,金龟子,h124,快递青蛙跳跳,h213,不屈战犬,h313,毛茸茸的肥羊羊,h125,赤兔,h126,迅捷魔童,h314,魔暴龙,h127,狂暴野猪,h214,獭龙奥斯基,h215,死神,h315,基王海盗,h216,冰龙宝宝,h316,摇摆的驴革米,h217,忠诚高山牦牛,h317,伐士奇,h415,啾啾,h416,死亡仙知,h414,VG飞狐侠|青色,h318,肉山宝宝,h417,金银狐灵|黑色,h418,金银狐灵|白色,h319,小灰熊,h219,骏马,h320,白色龙蝶,h321,红色龙蝶,h419,风神飞镰,h420,抬轿兄弟,h220,忠诚之犬瓦尔迪,h221,八戒,h222,羊羊羊,h223,草泥马拉玛,h218,桃树精,h128,碧磷|入门,h224,碧磷|业余,h322,碧磷|职业,h421,碧磷|大师,h323,招财猫,h444,百变泽驴斯,h499,死亡仙知|纯金,h129,蠕行水母,h225,胆小南瓜人,h422,长耳兔妖,h226,蟹小蜗|海螺,h227,蟹小蜗|草鞋,h228,蟹小蜗|穷鬼盾,h324,蟹小蜗|死灵书,h325,蟹小蜗|飞鞋,h326,蟹小蜗|莲花球,h423,蟹小蜗|玲珑心,h424,蟹小蜗|冰眼,h425,蟹小蜗|冠军盾,h134,矿车鼠|矿车,h234,矿车鼠|蜡烛,h335,矿车鼠|挖掘机,h428,矿车鼠|纯金e101,圣洁精华,e102,玛瑙光泽,e103,芳晓之庆,e104,水晶裂痕,e105,腐化触须,e106,毒虫肆虐,e107,夜魇暗潮腐化,e108,夜魇暗潮荒芜,e201,暗淡幻象,e202,冥魂大帝,e203,翡翠外质,e204,祸乱之源,e205,毒蕈之径,e206,2012冠军之辉,e207,2013冠军之辉,e208,2014冠军之辉,e301,骄阳之炎,e302,嬉戏蝴蝶,e303,冰女特效,e304,幸福之赐,e305,绽放莲花,e306,迎霜冰雪,e307,燃烧末日,e308,鱼泡泡,e401,燃焰之触,e402,霜寒之触,e403,迈达斯之触,e404,离子之汽,e109,大地灵气,e110,蓝色风暴,e309,紫色激情,e310,白雪飘零,e311,一股邪火,e209,霓虹蝴蝶,e210,旋转火花,e312,金币飞舞,e313,光辉岁月,e314,紫色星云,e315,噩梦缠绕,e111,一起哈啤,e112,宝石光泽,e211,雾气环绕,e212,迷幻缠绕,e405,光芒万丈,e316,星星,e113,污污污污,e499,金龙鱼,e114,雾里看花,e317,心心相印,e318,2017冠军之辉,myskater,我的滑冰手车库,more_heros,通过老司机考试（铜牌、银牌、金牌、铂金）以获得更多车库位置,not_available_now,面板崩溃，暂不可用,h327,迅捷远足毛驴,h229,竭智法师,h130,驴法师,h328,天猫地狗,h230,蓝心白隼,h131,丰臀公主,h426,绽放树精,h329,万圣树群,h231,莲花人,h132,焚牙树精,h330,咬人箱|大嘴,h331,咬人箱|洛克,h232,咬人箱|甲虫,h133,咬人箱|机械,h427,小恶魔|飞毯,h333,小恶魔|海龟,h334,小恶魔|螃蟹,h233,小恶魔|鹦鹉,h332,布狗,e319,灿若繁星,e320,大漩涡,e407,飞沙走石,e406,星光蓝宝石,e409,血之环,e408,暗月来袭e213,小家碧玉,e214,欲火焚身,e321,通灵术,e410,雪精灵,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,";
                    string[] n = l.Split(',');
                    //    d = "rarity_1,普通";
                    int m = 0;
                    for (m = 0; m < 510; m++)
                    {
                        if (d.Contains(n[m]))
                        {
                            d = d.Replace(n[m], n[m + 1]);
                            m++;


                        }
                    }
                    /*string l1 = "h101,npc_dota_hero_enchantress,h102,npc_dota_hero_puck,h103,npc_dota_hero_omniknight,h104,npc_dota_hero_wisp,h105,npc_dota_hero_ogre_magi,h106,npc_dota_hero_lion,h107,npc_dota_hero_keeper_of_the_light,h108,npc_dota_hero_rubick,h109,npc_dota_hero_jakiro,h110,npc_dota_hero_sand_king,h111,npc_dota_hero_ancient_apparition,h112,npc_dota_hero_earth_spirit,h201,npc_dota_hero_crystal_maiden,h203,npc_dota_hero_templar_assassin,h204,npc_dota_hero_lina,h205,npc_dota_hero_tidehunter,h206,npc_dota_hero_naga_siren,h207,npc_dota_hero_phoenix,h208,npc_dota_hero_dazzle,h209,npc_dota_hero_warlock,h210,npc_dota_hero_necrolyte,h211,npc_dota_hero_lich,h212,npc_dota_hero_furion,h213,npc_dota_hero_venomancer,h214,npc_dota_hero_kunkka,h215,npc_dota_hero_axe,h216,npc_dota_hero_slark,h217,npc_dota_hero_viper,h218,npc_dota_hero_tusk,h219,npc_dota_hero_abaddon,h220,npc_dota_hero_winter_wyvern,h221,npc_dota_hero_ember_spirit,h301,npc_dota_hero_windrunner,h302,npc_dota_hero_phantom_assassin,h303,npc_dota_hero_sniper,h304,npc_dota_hero_sven,h306,npc_dota_hero_mirana,h307,npc_dota_hero_nevermore,h308,npc_dota_hero_queenofpain,h309,npc_dota_hero_juggernaut,h310,npc_dota_hero_pudge,h311,npc_dota_hero_shredder,h312,npc_dota_hero_slardar,h313,npc_dota_hero_antimage,h314,npc_dota_hero_bristleback,h315,npc_dota_hero_lycan,h316,npc_dota_hero_lone_druid,h317,npc_dota_hero_storm_spirit,h318,npc_dota_hero_obsidian_destroyer,h319,npc_dota_hero_grimstroke,h401,npc_dota_hero_vengefulspirit,h402,npc_dota_hero_invoker,h403,npc_dota_hero_alchemist,h404,npc_dota_hero_spectre,h405,npc_dota_hero_morphling,h406,npc_dota_hero_techies,h407,npc_dota_hero_chaos_knight,h408,npc_dota_hero_faceless_void,h409,npc_dota_hero_legion_commander,h410,npc_dota_hero_monkey_king,h411,npc_dota_hero_razor,h412,npc_dota_hero_tinker,h413,npc_dota_hero_pangolier,h414,npc_dota_hero_dark_willow,h415,npc_dota_hero_terrorblade,h416,npc_dota_hero_enigma,t401,奶酪,t402,贪魔蛋,t403,值钱的贝壳,t301,南瓜,t302,雪球,t303,沙滩椅,t304,地渊孢林,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,";
                    string[] n1 = l1.Split(',');
                    //    d = "rarity_1,普通";
                    int m1 = 0;
                    for (m1 = 0; m1 < 151; m1++)
                    {
                        if (d.Contains(n1[m1]))
                        {
                            d = d.Replace(n1[m1], n1[m1 + 1]);
                            m1++;
                        }
                    }

                    string l2 = "common_toy,普通 玩具,rare_toy,稀有 玩具,mythical_toy,神话 玩具,legendary_toy,传说 玩具,npc_dota_hero_enchantress,魅惑魔女,npc_dota_hero_puck,精灵龙,npc_dota_hero_omniknignt,全能骑士,npc_dota_hero_crystal_maiden,水晶室女,npc_dota_hero_templar_assassin,圣堂刺客,npc_dota_hero_lina,秀逗魔导士,npc_dota_hero_windrunner,风行者,npc_dota_hero_phantom_assassin,幻影刺客,npc_dota_hero_sniper,狙击手,npc_dota_hero_vengefulspirit,复仇之魂,npc_dota_hero_sven,流浪剑客,npc_dota_hero_invoker,召唤师,npc_dota_hero_dazzle,暗影牧师,npc_dota_hero_riki,隐形刺客,npc_dota_hero_wisp,精灵守卫,npc_dota_hero_ogre_magi,食人魔法师,npc_dota_hero_lion,恶魔巫师,npc_dota_hero_phoenix,凤凰,npc_dota_hero_necrolyte,死灵法师,npc_dota_hero_lich,巫妖,npc_dota_hero_furion,先知,npc_dota_hero_mirana,月之女祭司,npc_dota_hero_nevermore,影魔,npc_dota_hero_queenofpain,痛苦女王,npc_dota_hero_alchemist,炼金,npc_dota_hero_spectre,幽鬼,npc_dota_hero_omniknight,全能骑士,npc_dota_hero_warlock,术士,npc_dota_hero_keeper_of_the_light,光之守卫,npc_dota_hero_rubick,大魔导师,npc_dota_hero_venomancer,剧毒,npc_dota_hero_kunkka,海军上将,npc_dota_hero_juggernaut,剑圣,npc_dota_hero_pudge,屠夫,npc_dota_hero_shredder,伐木机,npc_dota_hero_morphling,变体精灵,npc_dota_hero_techies,地精工程师,npc_dota_hero_tidehunter,潮汐猎人,npc_dota_hero_naga_siren,娜迦海妖,npc_dota_hero_chaos_knight,混沌骑士,npc_dota_hero_faceless_void,虚空假面,npc_dota_hero_slardar,鱼人守卫,npc_dota_hero_antimage,敌法师,npc_dota_hero_axe,斧王,npc_dota_hero_slark,鱼人夜行者,npc_dota_hero_legion_commander,军团指挥官,npc_dota_hero_jakiro,双头龙,npc_dota_hero_sand_king,沙王,npc_dota_hero_viper,冥界亚龙,npc_dota_hero_tusk,巨牙海民,npc_dota_hero_abaddon,死亡骑士,npc_dota_hero_bristleback,刚背兽,npc_dota_hero_lycan,狼人,npc_dota_hero_lone_druid,利爪德鲁伊,npc_dota_hero_monkey_king,齐天大圣,npc_dota_hero_razor,闪电幽魂,npc_dota_hero_tinker,地精修补匠,npc_dota_hero_dark_willow,邪影芳灵,npc_dota_hero_pangolier,石鳞剑士,npc_dota_hero_ancient_apparition,远古冰魄,npc_dota_hero_earth_spirit,大地之灵,npc_dota_hero_winter_wyvern,寒冬飞龙,npc_dota_hero_ember_spirit,灰烬之灵,npc_dota_hero_storm_spirit,风暴之灵,npc_dota_hero_obsidian_destroyer,殁境神噬者,npc_dota_hero_terrorblade,灵魂守卫,npc_dota_hero_enigma,谜团,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,";
                    string[] n2 = l2.Split(',');
                    //    d = "rarity_1,普通";
                    int m2 = 0;
                    for (m2 = 0; m2 < 160; m2++)
                    {
                        if (d.Contains(n2[m2]))
                        {
                            d = d.Replace(n2[m2], n2[m2 + 1]);
                            m2++;
                        }
                    }*/
                    // d = d.Substring(d.IndexOf("skater_count"));
                    //  d = d.Substring(0, d.IndexOf("is_black"));
                    d = d.Replace("\\", "");
                    string l2 = "fansheng,繁盛,biaoche,飚车,wuyu,无语,zuie,罪恶,xuebeng,雪崩,fennu,愤怒,huohuan,火环,lengmo,冷漠,chongzhuang,冲撞,welcome_AA,第1季 冰蘑菇,welcome_LICH,第2季 椰子树,welcome_SOIL,第3季 狗尾草,welcome_PRAC,训练场╭(′▽`)╭(′▽`)╯,welcome_EDIT,地图工坊╭(′▽`)╭(′▽`)╯,welcome_TEST1,铜牌老司机考试╭(′▽`)╭(′▽`)╯,welcome_TEST2,银牌老司机考试╭(′▽`)╭(′▽`)╯,welcome_TEST3,金牌老司机考试╭(′▽`)╭(′▽`)╯,welcome_TEST4,铂金老司机考试╭(′▽`)╭(′▽`)╯,welcome_BEGINNER,新手村╭(′▽`)╭(′▽`)╯,welcome_CUSTOM,试玩工坊地图╭(′▽`)╭(′▽`)╯,welcome_RANDOM,随机闯关╭(′▽`)╭(′▽`)╯,welcome_NEXUS1F,第4季 地瓜叶,welcome_FROST,第5季 火山木,cm_1,冰蘑菇 1级,cm_2,冰蘑菇 2级,cm_3,冰蘑菇 3级,cm_4,冰蘑菇 4级,cm_5,冰蘑菇 5级,lina_1,椰子树 1级,lina_2,椰子树 2级,lina_3,椰子树 3级,lina_4,椰子树 4级,lina_5,椰子树 5级,tinker_1,火山木 1级,tinker_2,火山木 2级,tinker_3,火山木 3级,tinker_4,火山木 4级,tinker_5,火山木 5级,qop_1,狗尾草 1级,qop_2,狗尾草 2级,qop_3,狗尾草 3级,qop_4,狗尾草 4级,qop_5,狗尾草 5级,ns_1,地瓜叶 1级,ns_2,地瓜叶 2级,ns_3,地瓜叶 3级,ns_4,地瓜叶 4级,ns_5,地瓜叶 5级,BRD,黑石深渊,DOTA,刀塔堡垒,CSGO,污手街,C6,魔导师平台,QOP,黑翼血环,NEXUS1F,魔枢第1层,NEXUS2F,魔枢第2层,NEXUS3F,魔枢第3层,NEXUS4F,魔枢第4层,NEXUS5F,魔枢第5层,NEXUS6F,魔枢第6层,NEXUS7F,魔枢第7层,NEXUS8F,魔枢第8层,NEXUS9F,魔枢第9层,NEXUS10F,魔枢第10层,NEXUS11F,魔枢第11层,NEXUS12F,魔枢第12层,NEXUS13F,魔枢第13层,NS,魔枢顶层,STORMEYE,风暴之眼,FROST,霜火岭,DRAGON,龙眠神殿,SKYREACH,通天峰,FARM,半山农场,NEWZUG,新祖尔格拉布,MTH,蔑潮港,TINKER,诺莫瑞根,NASSAR,纳沙尔海湾,WINTER,洛丹伦的冬天,AUTUMN,洛丹伦的秋天,SUMMER,洛丹伦的夏天,SPRING,洛丹伦的春天,PANDA,潘达利亚,TLJD,提拉加德海峡,MUSIC,维克雷斯庄园,ELEPHANT,魔法动物店,CHICK,消逝冰川,UCURVE,阿坤达神殿,CATMIAO,喵人藏身处,MACDON,冥宫,TRAIL,蛇行峡谷,GO1234,日暮广场,MARIO,奇妙玩具店,CUBES,冬幕节小栈,BEGINNER,新手村,BEGINNER_TWO,新手村2,GO,选择线路,GOONE,滑冰手的家,RACE,对战模式,PRAC,练习,AA,艾尔文河,AA2,艾尔文河2,POM,白虎寺,TEST1,青铜试炼,TEST2,白银试炼,TEST3,黄金试炼,WIN1,冰蘑菇通关,WIN2,椰子树通关,WIN3,狗尾草通关,WIN4,地瓜叶通关,WIN5,火山木通关,WINRAN,随机闯关通关,ALLEY,逆风小径,KRZ,卡拉赞,AZARA,艾萨拉,FAIRE,暗月马戏团,DUST,尘泥沼泽,X!!,希利苏斯,CAVERN,时光之穴,BEACH,破碎海滩,STORM,大漩涡,TUNDRA,北风苔原,MOROGH,丹莫罗,NAXX,纳克萨玛斯,NEEDLE,千针石林,ULDUM,奥丹姆,VASJIR,瓦斯琪尔,TEMPLE,黑暗神殿,DARK,黑海岸,ZUG,祖尔格拉布,TUSK,雪流平原,TUSK2,雪流平原2,SS,祖达克,SSOLD,旧祖达克,LICH,冬拥湖,WR,紫罗兰哨站,PUCK,晶歌森林,PUCK2,晶歌森林2,BB,止水河,BB2,止水河2,MORPH,河流之心,MORPH2,河流之心2,FUR,扭木广场,FUR2,扭木广场2,LIGHT,达拉然,DS,风暴峭壁,WINGS,旋云之巅,CM,冰冠冰川,TECH,加基森,TECH2,加基森2,RAZOR,剃刀高地,ENIGMA,冬泉谷,VS,流沙岗哨,VS2,流沙岗哨2,SF,影月谷,SF2,影月谷2,SK,深沙平原,BS,塔纳利斯,BS2,塔纳利斯2,KUNKKA,热砂港,GYRO,科赞,MEEPO,安戈洛环形山,MEEPO2,安戈洛环形山2,PHX,海加尔山,PHX2,海加尔山2,LINA,火焰之地,TA,翡翠梦境,TA2,翡翠梦境2,GIANT,巨兽岛,SOIL,恐惧废土,DEEP,深岩之洲,ASHEN,灰谷,SEABED,烁光海床,ZANGAR,赞加沼泽,ZANGAR2,赞加沼泽2,RKLZ,重返卡拉赞,fansheng,繁盛,biaoche,飚车,wuyu,无语,zuie,罪恶,xuebeng,雪崩,fennu,愤怒,huohuan,火环,lengmo,冷漠,chongzhuang,冲撞,welcome,欢迎来到萌萌的滑冰场╭(′▽`)╯╭(′▽`)╯,welcome_AA,第1季 冰蘑菇,welcome_LICH,第2季 椰子树,welcome_SOIL,第3季 狗尾草,welcome_PRAC,训练场╭(′▽`)╭(′▽`)╯,welcome_EDIT,地图工坊╭(′▽`)╭(′▽`)╯,welcome_TEST1,铜牌老司机考试╭(′▽`)╭(′▽`)╯,welcome_TEST2,银牌老司机考试╭(′▽`)╭(′▽`)╯,welcome_TEST3,金牌老司机考试╭(′▽`)╭(′▽`)╯,welcome_TEST4,铂金老司机考试╭(′▽`)╭(′▽`)╯,welcome_BEGINNER,新手村╭(′▽`)╭(′▽`)╯,welcome_CUSTOM,试玩工坊地图╭(′▽`)╭(′▽`)╯,welcome_RANDOM,随机闯关╭(′▽`)╭(′▽`)╯,welcome_NEXUS1F,第4季 地瓜叶,welcome_FROST,第5季 火山木,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1";
                    string[] n2 = l2.Split(',');
                    //    d = "rarity_1,普通";
                    int ma = 0;
                    for (ma = 0; ma < 260; ma++)
                    {
                        if (d.Contains(n2[ma]))
                        {
                            d = d.Replace(n2[ma], n2[ma + 1]);
                            ma++;


                        }
                    }

                    d = d.Replace("{", "\r\n");

                    //  d = d.Replace("preice", "\r\n这项不知道");
                    //    d = d.Replace("compenice", "\r\n这项也不知道");
                    d = d.Replace("}", "\r\n");
                    d = d.Replace("hero_sea", "信使");
                    d = d.Substring(d.IndexOf("信使"));
                    d = d.Replace("ability", "");
                    d = d.Replace("shell", "\r\n贝壳：");
                    d = d.Replace("crab_season", "\r\n日常地图：");
                    d = d.Replace("effect", "");

                    d = d.Replace("skater_count", "\r\n信使数量");
                    d = d.Replace("onduty_hero", "\r\n当前信使");

                    d = d.Replace("task", "\r\n任务");
                    d = d.Replace("test", "\r\n驾照测试（秒）");
                    d = d.Replace("cm", "\r\n冰女通关任务（秒）");
                    d = d.Replace("lina", "\r\n火女通关任务（秒）");
                    d = d.Replace("qop", "\r\n女王通关任务（秒）");
                    d = d.Replace("tinker", "\r\n地精修补匠通关任务（秒）");
                    d = d.Replace("random", "\r\n随机关卡通关任务（秒）");
                    d = d.Replace("season", "\r\n赛季剩余时间（秒）");
                    d = d.Replace("daily", "\r\n日常剩余时间（秒）");
                    d = d.Replace("driver", "\r\n驾照等级");
                    //     d = d.Replace("rush", "\r\n这项还是不知道");
                    d = d.Replace("ns", "\r\n夜魔通关任务（秒）");

                    d = d.Replace("\"", "");
                    d = d.Replace(":", "");
                    d = d.Replace("]", "");
                    d = d.Replace("[", "");
                    d = d.Replace(",", "");
                    d = d.Replace("crab_level", "日常关卡：");
                    d = d.Replace("rank", "\r\n排名");
                    d = d.Replace("rush_content", "\r\n英雄难度主题：\r\n");
                    d = d.Replace("rush", "\r\n英雄难度主题刷新时间");
                    d = d.Replace("extend", "\r\n英雄挑战任务刷新时间");
                    d = d.Replace("badge", "\r\n英雄难度徽章");
                    d = d.Replace("ticket", "\r\n英雄难度门票");
                    d = d.Replace("camera", "\r\n视角状态");
                    d = d.Replace("distance", "\r\n视角高度");
                    d = d.Replace("go_teachfalse", "");
                    d = d.Replace("go_teachtrue", "");
                    d = d.Replace("preice0compenice0", "");
                    d = d.Replace("is_black0wed_icenullcount0", "");
                    d = d.Replace("beginnerfalsepre_cardnull", "");
                    d = d.Replace("ice", "\r\n冰块");
                    //  await MessageManager.SendGroupMessageAsync(receiver.Id, n[50]);
                    //  await MessageManager.SendGroupMessageAsync(receiver.Id, n[51]);
                    //  await MessageManager.SendGroupMessageAsync(receiver.Id, n[52]);
                    //   await MessageManager.SendGroupMessageAsync(receiver.Id, n[34]);

                    // d = Encoding.UTF8.GetString(Encoding.Default.GetBytes(d));

                    /*    string c1 = "http://gemtd.ppbizon.com/gemtd/201807/mmr/get/@" + b;

                        WebResponse responsea1;



                        HttpWebRequest requesta1 = (HttpWebRequest)WebRequest.CreateDefault(new Uri(c1));
                        try
                        {
                            responsea1 = requesta1.GetResponse();
                        }
                        catch (WebException ex)
                        {
                            responsea1 = ex.Response;
                        }
                        // WebResponse response = request.GetResponse();
                        StreamReader readera1 = new StreamReader(responsea1.GetResponseStream());
                        string d1 = readera1.ReadToEnd();//d为转换网页的整个文档   

                        d1 = gb2312.GetString(Encoding.Default.GetBytes(d1));
                        d1 = d1.Substring(d1.IndexOf("match") + 8);
                        d1 = d1.Replace("mmr", "\r\n隐藏分");
                        d1 = d1.Replace("rankall", "总排位");
                        d1 = d1.Replace("rankcoop", "组队排位");
                        d1 = d1.Replace("rankrace", "比赛排位");
                        d1 = d1.Replace("all_level", "总体等级");
                        d1 = d1.Replace("coop_level", "组队等级");
                        d1 = d1.Replace("race_level", "比赛等级");
                        d1 = d1.Replace("score", "分数");
                        d1 = d1.Replace("}]}", "");
                        d1 = d1.Replace("\"", "");*/
                    Console.WriteLine(d);
                    d = "查询的ID昵称为:" + o + "\r\n" + d;
                    try
                    {
                        await MessageManager.SendGroupMessageAsync(receiver.Id, d);


                    }
                    catch (Exception ex)
                    {
                        await MessageManager.SendGroupMessageAsync("145368121", "发送消息失败" + DateTime.Now);
                        Console.WriteLine("发送失败" + DateTime.Now);
                    };


                    d = "";


                }

            }
            if (message.Contains("宝石现在什么打折") || message.Contains("宝石打折") || message.Contains("你懂得") || message.Contains("你懂的"))
            {
                Console.WriteLine($"收到你懂得了");
                /*  string x = message;
                  string str = System.Text.RegularExpressions.Regex.Replace(x, @"[^0-9]+", "");
                  if (System.Text.RegularExpressions.Regex.IsMatch(str, "^[0-9]+$"))
                  {



                      //    await MessageManager.SendGroupMessageAsync(receiver.Id, str);

                      string str1 = "https://steamid.io/lookup/U:1:" + str;
                      string url = str1;
                      //    await MessageManager.SendGroupMessageAsync(receiver.Id, url);

                      WebResponse response;



                      HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                      try
                      {
                          response = request.GetResponse();
                      }
                      catch (WebException ex)
                      {
                          response = ex.Response;
                      }
                      // WebResponse response = request.GetResponse();
                      StreamReader reader = new StreamReader(response.GetResponseStream());
                      string a = reader.ReadToEnd();//a为转换网页的整个文档              
                      string h = "7656";//h为64位id的头文档
                      int g = a.IndexOf(h);//g为64位id的位置数值
                      string b = a.Substring(g, 17);
                      //   await MessageManager.SendGroupMessageAsync(receiver.Id, b);
                      string i = "name\": \"";//i位昵称的前置8位文档
                      int j = a.IndexOf(i);//j为昵称的前置8位数值
                      string o = a.Substring(j + 8, 100);
                      int p = o.IndexOf('"');
                      o = o.Remove(p);*/

                string c = "http://gemtd.ppbizon.com/gemtd/201803/goods/list/@76561198083388851";

                WebResponse responsea;



                HttpWebRequest requesta = (HttpWebRequest)WebRequest.CreateDefault(new Uri(c));
                try
                {
                    responsea = requesta.GetResponse();
                }
                catch (WebException ex)
                {
                    responsea = ex.Response;
                }
                // WebResponse response = request.GetResponse();
                StreamReader readera = new StreamReader(responsea.GetResponseStream());
                string d = readera.ReadToEnd();//d为转换网页的整个文档   
                if (d != "")
                {

                    //  Encoding gb2312 = Encoding.GetEncoding(936);
                    //  d = gb2312.GetString(Encoding.Default.GetBytes(d));
                    //  byte[] bytes = gb2312.GetBytes(d);
                    //  d = Encoding.UTF8.GetString(Encoding.Default.GetBytes(d));


                    //  await MessageManager.SendGroupMessageAsync(receiver.Id, d);
                    // string str = "1.234E0，2.05E1，-3.0E2，-1.1E-2";
                    //   string d1 = d.Replace("Hello", "Ni hao");//将子字符串Hello 替换为Ni Hao。
                    string l = "onduty_hero,当前英雄,hero_id,英雄ID,extend,特效款式,pet,任务完成次数,_expire,剩余时间（秒）,_finish_count,完成次数,shell,贝壳,candy,糖果,quest,任务,quest_finish_count,任务完成次数,pet,宠物1,pass,通关任务剩余时间（秒）,season,赛季剩余时间（秒）,extend_tool,格子扩展包,a306,回到过去,common_hero,普通英雄,rare_hero,稀有英雄,mythical_hero,神话英雄,legendary_hero,传说英雄,common_ability,普通英雄技能,rare_ability,稀有英雄技能,mythical_ability,神话英雄技能,legendary_ability,传说英雄技能,common_effect,普通 英雄特效,rare_effect,稀有 英雄特效,mythical_effect,神话 英雄特效,legendary_effect,传说 英雄特效,luckybox,一箱好东西?,buy,购买!,b201607,卡尔幸运箱,a101,回春,a102,闪避,a103,守护,a104,石头,a201,蓝色祈祷,a202,蛋白祈祷,a203,白色祈祷,a204,红色祈祷,a205,绿色祈祷,a206,海浪祈祷,a207,黄色祈祷,a208,紫色祈祷,a209,精英祈祷,a301,快速射击,a302,暴击,a303,瞄准,a304,风暴之锤,a401,移形换位,a210,普通许愿,a305,无暇许愿,a402,完美许愿,b201608,卡尔幸运箱,a105,背水一战,a211,乾坤小挪移,a307,致命链接,q101,不合成白银完成全部关卡。,q102,不合成孔雀石完成全部关卡。,q103,不合成星彩红宝石完成全部关卡。,q104,击杀小飞象Zard-并完成全部关卡。,q105,60分钟内完成全部关卡。,q106,没有一回合合成任何塔完成全部关卡。,q107,宝石城堡满血完成全部关卡。,q108,合出任意隐藏塔并完成全部关卡。,q201,不合成玉完成全部关卡。,q202,不保留钻石完成全部关卡。,q203,不保留蓝宝石完成全部关卡。,q204,不保留红宝石完成全部关卡。,q205,不保留黄玉完成全部关卡。,q206,不保留紫晶完成全部关卡。,q207,不保留海晶石完成全部关卡。,q208,不保留翡翠完成全部关卡。,q209,50分钟内完成全部关卡。,q301,不合成深海珍珠完成全部关卡。,q302,40分钟内完成全部关卡。,q303,击杀黄金肉山宝宝并完成全部关卡。,e101,圣洁精华,e102,玛瑙光泽,e103,芳晓之庆,e104,水晶裂痕,e105,腐化触须,e106,毒虫肆虐,e107,夜魇暗潮腐化,e108,夜魇暗潮荒芜,e201,暗淡幻象,e202,冥魂大帝,e203,翡翠外质,e204,祸乱之源,e205,毒蕈之径,e206,2012冠军之辉,e207,2013冠军之辉,e208,2014冠军之辉,e301,骄阳之炎,e302,嬉戏蝴蝶,e303,冰女特效,e304,幸福之赐,e305,绽放莲花,e306,迎霜冰雪,e307,燃烧末日,e308,鱼泡泡,e401,燃焰之触,e402,霜寒之触,e403,迈达斯之触,e404,离子之汽,e109,大地灵气,e110,蓝色风暴,e309,紫色激情,e310,白雪飘零,e311,一股邪火,e209,霓虹蝴蝶,e210,旋转火花,e312,金币飞舞,e313,光辉岁月,e314,紫色星云,e315,噩梦缠绕,e111,一起哈啤,e112,宝石光泽,e211,雾气环绕,e212,迷幻缠绕,e405,光芒万丈,e316,星星,e113,污污污污,e499,金龙鱼,e114,雾里看花,e317,心心相印,e318,2017冠军之辉,e319,灿若繁星,e320,大漩涡,e407,飞沙走石,e406,星光蓝宝石,e409,血之环,e408,暗月来袭,a403,糖果道标,q109,任意关卡的敌人数量超过20并完成全部关卡。,q110,合成任意闪亮的石板并完成全部关卡。,q210,合成任意超级塔并完成全部关卡。,q211,不使用任何英雄技能完成全部关卡。,q304,升级五个MVP-MAX的塔并完成全部关卡。,e213,小家碧玉,e214,欲火焚身,e321,通灵术,e410,雪精灵,e450,虚无之焰,e451,虚无之焰|红色,e452,虚无之焰|橙色,e453,虚无之焰|黄色,e454,虚无之焰|绿色,e455,虚无之焰|青色,e456,虚无之焰|蓝色,e457,虚无之焰|紫色,e458,虚无之焰|白色,e459,虚无之焰|粉色,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1";
                    string[] n = l.Split(',');
                    //    d = "rarity_1,普通";
                    int m = 0;
                    for (m = 0; m < 300; m++)
                    {
                        if (d.Contains(n[m]))
                        {
                            d = d.Replace(n[m], n[m + 1]);
                            m++;
                        }
                    }

                    string l1 = "h101,npc_dota_hero_enchantress,h102,npc_dota_hero_puck,h103,npc_dota_hero_omniknight,h104,npc_dota_hero_wisp,h105,npc_dota_hero_ogre_magi,h106,npc_dota_hero_lion,h107,npc_dota_hero_keeper_of_the_light,h108,npc_dota_hero_rubick,h109,npc_dota_hero_jakiro,h110,npc_dota_hero_sand_king,h111,npc_dota_hero_ancient_apparition,h112,npc_dota_hero_earth_spirit,h201,npc_dota_hero_crystal_maiden,h203,npc_dota_hero_templar_assassin,h204,npc_dota_hero_lina,h205,npc_dota_hero_tidehunter,h206,npc_dota_hero_naga_siren,h207,npc_dota_hero_phoenix,h208,npc_dota_hero_dazzle,h209,npc_dota_hero_warlock,h210,npc_dota_hero_necrolyte,h211,npc_dota_hero_lich,h212,npc_dota_hero_furion,h213,npc_dota_hero_venomancer,h214,npc_dota_hero_kunkka,h215,npc_dota_hero_axe,h216,npc_dota_hero_slark,h217,npc_dota_hero_viper,h218,npc_dota_hero_tusk,h219,npc_dota_hero_abaddon,h220,npc_dota_hero_winter_wyvern,h221,npc_dota_hero_ember_spirit,h301,npc_dota_hero_windrunner,h302,npc_dota_hero_phantom_assassin,h303,npc_dota_hero_sniper,h304,npc_dota_hero_sven,h306,npc_dota_hero_mirana,h307,npc_dota_hero_nevermore,h308,npc_dota_hero_queenofpain,h309,npc_dota_hero_juggernaut,h310,npc_dota_hero_pudge,h311,npc_dota_hero_shredder,h312,npc_dota_hero_slardar,h313,npc_dota_hero_antimage,h314,npc_dota_hero_bristleback,h315,npc_dota_hero_lycan,h316,npc_dota_hero_lone_druid,h317,npc_dota_hero_storm_spirit,h318,npc_dota_hero_obsidian_destroyer,h319,npc_dota_hero_grimstroke,h401,npc_dota_hero_vengefulspirit,h402,npc_dota_hero_invoker,h403,npc_dota_hero_alchemist,h404,npc_dota_hero_spectre,h405,npc_dota_hero_morphling,h406,npc_dota_hero_techies,h407,npc_dota_hero_chaos_knight,h408,npc_dota_hero_faceless_void,h409,npc_dota_hero_legion_commander,h410,npc_dota_hero_monkey_king,h411,npc_dota_hero_razor,h412,npc_dota_hero_tinker,h413,npc_dota_hero_pangolier,h414,npc_dota_hero_dark_willow,h415,npc_dota_hero_terrorblade,h416,npc_dota_hero_enigma,t401,奶酪,t402,贪魔蛋,t403,值钱的贝壳,t301,南瓜,t302,雪球,t303,沙滩椅,t304,地渊孢林,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,";
                    string[] n1 = l1.Split(',');
                    //    d = "rarity_1,普通";
                    int m1 = 0;
                    for (m1 = 0; m1 < 150; m1++)
                    {
                        if (d.Contains(n1[m1]))
                        {
                            d = d.Replace(n1[m1], n1[m1 + 1]);
                            m1++;
                        }
                    }
                    d = d.Replace("h305", "月之骑土");
                    d = d.Replace("h202", "死亡仙知");

                    string l2 = "common_toy,普通 玩具,rare_toy,稀有 玩具,mythical_toy,神话 玩具,legendary_toy,传说 玩具,a308,乌索尔旋风,a212,巨石阵,onsale,\r\n现在半价,expire,商店刷新时间,npc_dota_hero_enchantress,魅惑魔女,npc_dota_hero_puck,精灵龙,npc_dota_hero_omniknignt,全能骑士,npc_dota_hero_crystal_maiden,水晶室女,npc_dota_hero_templar_assassin,圣堂刺客,npc_dota_hero_lina,秀逗魔导士,npc_dota_hero_windrunner,风行者,npc_dota_hero_phantom_assassin,幻影刺客,npc_dota_hero_sniper,狙击手,npc_dota_hero_vengefulspirit,复仇之魂,npc_dota_hero_sven,流浪剑客,npc_dota_hero_invoker,召唤师,npc_dota_hero_dazzle,暗影牧师,npc_dota_hero_riki,隐形刺客,npc_dota_hero_wisp,精灵守卫,npc_dota_hero_ogre_magi,食人魔法师,npc_dota_hero_lion,恶魔巫师,npc_dota_hero_phoenix,凤凰,npc_dota_hero_necrolyte,死灵法师,npc_dota_hero_lich,巫妖,npc_dota_hero_furion,先知,npc_dota_hero_mirana,月之女祭司,npc_dota_hero_nevermore,影魔,npc_dota_hero_queenofpain,痛苦女王,npc_dota_hero_alchemist,炼金,npc_dota_hero_spectre,幽鬼,npc_dota_hero_omniknight,全能骑士,npc_dota_hero_warlock,术士,npc_dota_hero_keeper_of_the_light,光之守卫,npc_dota_hero_rubick,大魔导师,npc_dota_hero_venomancer,剧毒,npc_dota_hero_kunkka,海军上将,npc_dota_hero_juggernaut,剑圣,npc_dota_hero_pudge,屠夫,npc_dota_hero_shredder,伐木机,npc_dota_hero_morphling,变体精灵,npc_dota_hero_techies,地精工程师,npc_dota_hero_tidehunter,潮汐猎人,npc_dota_hero_naga_siren,娜迦海妖,npc_dota_hero_chaos_knight,混沌骑士,npc_dota_hero_faceless_void,虚空假面,npc_dota_hero_slardar,鱼人守卫,npc_dota_hero_antimage,敌法师,npc_dota_hero_axe,斧王,npc_dota_hero_slark,鱼人夜行者,npc_dota_hero_legion_commander,军团指挥官,npc_dota_hero_jakiro,双头龙,npc_dota_hero_sand_king,沙王,npc_dota_hero_viper,冥界亚龙,npc_dota_hero_tusk,巨牙海民,npc_dota_hero_abaddon,死亡骑士,npc_dota_hero_bristleback,刚背兽,npc_dota_hero_lycan,狼人,npc_dota_hero_lone_druid,利爪德鲁伊,npc_dota_hero_monkey_king,齐天大圣,npc_dota_hero_razor,闪电幽魂,npc_dota_hero_tinker,地精修补匠,npc_dota_hero_dark_willow,邪影芳灵,npc_dota_hero_pangolier,石鳞剑士,npc_dota_hero_ancient_apparition,远古冰魄,npc_dota_hero_earth_spirit,大地之灵,npc_dota_hero_winter_wyvern,寒冬飞龙,npc_dota_hero_ember_spirit,灰烬之灵,npc_dota_hero_storm_spirit,风暴之灵,npc_dota_hero_obsidian_destroyer,殁境神噬者,npc_dota_hero_terrorblade,灵魂守卫,npc_dota_hero_enigma,谜团,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,";
                    string[] n2 = l2.Split(',');
                    //    d = "rarity_1,普通";
                    int m2 = 0;
                    for (m2 = 0; m2 < 195; m2++)
                    {
                        if (d.Contains(n2[m2]))
                        {
                            d = d.Replace(n2[m2], n2[m2 + 1]);
                            m2++;
                        }
                    }


                    d = d.Substring(d.IndexOf("一箱好东西"));
                    // d = d.Substring(0, d.IndexOf("ti8"));
                    d = d.Replace("{", "");
                    d = d.Replace("}", "\r\n");
                    d = d.Replace("\"", "");
                    //  d = d.Replace("file://images/custom_game/lottery/", "");
                    d = d.Replace(".png", "");
                    d = d.Replace("taobao1111", "");
                    d = d.Replace("false", "");
                    d = d.Replace("ture", "");
                    d = d.Replace("gem_", "");
                    d = d.Replace("pic", "");
                    d = d.Replace("rarity", "");
                    d = d.Replace("file", "");
                    d = d.Replace("images", "");
                    d = d.Replace("custom_game", "");
                    d = d.Replace("lottery", "");
                    d = d.Replace("/", "");
                    d = d.Replace("id", "");
                    d = d.Replace(":", "");
                    d = d.Replace(",", "");
                    d = d.Replace("hero_avatar", "");
                    d = d.Replace("price", "价格");
                    //   d = d.Replace("toy", "玩具");
                    d = d.Replace("iceblocktrue", "（冰块购买）");
                    //一下程序为截取字符串内的数字时间
                    string shijianzhuanhuan = d;
                    shijianzhuanhuan = shijianzhuanhuan.Substring(shijianzhuanhuan.IndexOf("商店刷新时间") + 6);
                    shijianzhuanhuan = shijianzhuanhuan.Substring(0, shijianzhuanhuan.IndexOf("现在半价") - 1);
                    DateTime xianzaishijian = DateTime.Now;
                    double t = double.Parse(shijianzhuanhuan);
                    xianzaishijian = xianzaishijian.AddSeconds(t);
                    string xianzaishijian2 = xianzaishijian.ToString();
                    d = d.Replace(shijianzhuanhuan, xianzaishijian2);
                    //  await MessageManager.SendGroupMessageAsync(receiver.Id, n[50]);mythical_,神话,legendary_,传说,rare_,普通,common_,普通,price,价格,
                    //  await MessageManager.SendGroupMessageAsync(receiver.Id, n[51]);
                    //  await MessageManager.SendGroupMessageAsync(receiver.Id, n[52]);
                    //   await MessageManager.SendGroupMessageAsync(receiver.Id, n[34]);

                    // d = Encoding.UTF8.GetString(Encoding.Default.GetBytes(d));
                    //d = "查询的ID昵称为——" + o + "——" + d;
                    if (d == "")
                    {
                        try
                        {
                            await MessageManager.SendGroupMessageAsync(receiver.Id, "查询失败" + DateTime.Now);
                        }
                        catch (Exception ex)

                        {
                            await MessageManager.SendGroupMessageAsync("145368121", "发送消息失败" + DateTime.Now);
                            Console.WriteLine("发送失败" + DateTime.Now);
                        };

                    }
                    else
                    {
                        try
                        {
                            await MessageManager.SendGroupMessageAsync(receiver.Id, d);
                        }
                        catch (Exception ex)
                        {
                            await MessageManager.SendGroupMessageAsync("145368121", "发送消息失败" + DateTime.Now + receiver.Id);
                            Console.WriteLine("发送失败" + DateTime.Now);
                        };
                        // await MessageManager.SendGroupMessageAsync(receiver.Id, shijianzhuanhuan);
                        d = "";
                    }
                }
                else
                {
                    try
                    {


                        await MessageManager.SendGroupMessageAsync(receiver.Id, "查询失败" + DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        await MessageManager.SendGroupMessageAsync("145368121", "发送消息失败" + DateTime.Now);
                        Console.WriteLine("发送失败" + DateTime.Now);
                    };

                }
            }
            if (message.Contains("滑冰现在什么打折"))
            {
                /*  string x = e.Message.Text;
                  string str = System.Text.RegularExpressions.Regex.Replace(x, @"[^0-9]+", "");
                  if (System.Text.RegularExpressions.Regex.IsMatch(str, "^[0-9]+$"))
                  {



                      //    e.FromGroup.SendMessage(receiver.Id, str);

                      string str1 = "https://steamid.io/lookup/U:1:" + str;
                      string url = str1;
                      //    e.FromGroup.SendMessage(receiver.Id, url);

                      WebResponse response;



                      HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                      try
                      {
                          response = request.GetResponse();
                      }
                      catch (WebException ex)
                      {
                          response = ex.Response;
                      }
                      // WebResponse response = request.GetResponse();
                      StreamReader reader = new StreamReader(response.GetResponseStream());
                      string a = reader.ReadToEnd();//a为转换网页的整个文档              
                      string h = "7656";//h为64位id的头文档
                      int g = a.IndexOf(h);//g为64位id的位置数值
                      string b = a.Substring(g, 17);
                      //   e.FromGroup.SendMessage(receiver.Id, b);
                      string i = "name\": \"";//i位昵称的前置8位文档
                      int j = a.IndexOf(i);//j为昵称的前置8位数值
                      string o = a.Substring(j + 8, 100);
                      int p = o.IndexOf('"');
                      o = o.Remove(p);*/

                string c = "http://gemtd.ppbizon.com/sm/goods/list?hehe=";

                WebResponse responsea;



                HttpWebRequest requesta = (HttpWebRequest)WebRequest.CreateDefault(new Uri(c));
                try
                {
                    responsea = requesta.GetResponse();
                }
                catch (WebException ex)
                {
                    responsea = ex.Response;
                }
                // WebResponse response = request.GetResponse();
                StreamReader readera = new StreamReader(responsea.GetResponseStream());
                string d = readera.ReadToEnd();//d为转换网页的整个文档   
                Encoding gb2312 = Encoding.GetEncoding(936);
                d = gb2312.GetString(Encoding.Default.GetBytes(d));
                // byte[] bytes = gb2312.GetBytes(d);
                //    d = Encoding.UTF8.GetString(Encoding.Default.GetBytes(d));


                //   e.FromGroup.SendMessage(receiver.Id, d);
                // string str = "1.234E0，2.05E1，-3.0E2，-1.1E-2";
                //   string d1 = d.Replace("Hello", "Ni hao");//将子字符串Hello 替换为Ni Hao。
                string l = "a407,技能窃取,a208,照明弹,a405,无敌,a406,海妖之歌,a101,冲刺,a101_help,3秒内提高移动速度200,a102,刹车,a101_help,瞬间停住,a103,加速光环,a101_help,1000范围内友军移动速度增加50,a104,减速光环,a101_help,1000范围内敌军移动速度降低100,a201,冰冻,a101_help,使500范围内敌人3秒无法移动,a202,击退,a101_help,击退自己附近的敌人,a203,时光倒流,a101_help,使自己回到四秒前位置,a204,信仰之跃,a101_help,向前跳跃,a205,折光,a206,链接,a207,粘滞,a101_help,10秒内抵挡一次伤害,a301,召唤,a101_help,立刻召唤任意一名队友到你身边,a302,传送,a101_help,立刻传送到一个队友身边,a303,投掷,a101_help,把一个队友扔到另一个队友身上,a305,标记,a304,消失,a401,沉默,a101_help,使2000范围内敌人沉默5秒,a402,复活,a101_help,随机复活一名死去的队友,a403,融化,a404,重生,beginner_hero,入门级 滑冰手,ameteur_hero,业余级 滑冰手,pro_hero,职业级 滑冰手,master_hero,大师级 滑冰手,beginner_ability,入门级 技能,ameteur_ability,业余级 技能,pro_ability,职业级 技能,master_ability,大师级 技能,beginner_effect,入门级 特效,ameteur_effect,业余级 特效,pro_effect,职业级 特效,master_effect,大师级 特效,OhIgota,噢耶，我获得了,h101,船长的鹦鹉,h102,宝石教父Zard-,h103,神兔,h104,粉嫩蝾螈,h105,酒桶浣熊,h106,毛毛鱼,h107,海盗船,h108,达士奇,h109,萌蛛,h110,翠花|红色,h111,白羽鸡,h112,绿毛龟,h113,空心恶魔人,h114,歪脖鸵鸟,h115,跳脚企鹅,h116,胡小桃,h117,小红毛,h118,极速蜗牛,h119,松鼠卫兵,h120,丹顶鹤,h401,NAVI黄鼬,h402,MVP滑板火烈鸟,h403,IG小火龙,h404,LGD的金萌萌,h405,VG飞狐侠|红色,h406,VP北极熊,h407,EG的麋鹿,h201,末日宝宝,h202,赏金宝宝,h203,屠夫宝宝,h204,血魔宝宝,h205,小白虎,h206,海民宝宝,h207,黑鸟宝宝,h208,虚空宝宝,h209,修补匠宝宝,h210,小星月,h301,魔典小龙,h302,斑竹队长,h303,滑板鲨鱼,h304,炸毛小鸡,h305,摇摆蘑菇,h306,坚果松鼠,h307,翠玉小龙,h308,巨鸟多多,h309,机械战驴,h310,基拉魔法师,h211,两栖鱼童,h408,石头人|天辉,h409,石头人|夜魇,h121,双头恶犬,h311,爆眼章鱼,h212,剧毒宝宝,h410,火星车|绿色,h411,火星车|红色,h122,飞僵小宝,h412,对映体|天使,h413,对映体|恶魔,h123,雷克,h312,金龟子,h124,快递青蛙跳跳,h213,不屈战犬,h313,毛茸茸的肥羊羊,h125,赤兔,h126,迅捷魔童,h314,魔暴龙,h127,狂暴野猪,h214,獭龙奥斯基,h215,死神,h315,基王海盗,h216,冰龙宝宝,h316,摇摆的驴革米,h217,忠诚高山牦牛,h317,伐士奇,h415,啾啾,h416,死亡仙知,h414,VG飞狐侠|青色,h318,肉山宝宝,h417,金银狐灵|黑色,h418,金银狐灵|白色,h319,小灰熊,h219,骏马,h320,白色龙蝶,h321,红色龙蝶,h419,风神飞镰,h420,抬轿兄弟,h220,忠诚之犬瓦尔迪,h221,八戒,h222,羊羊羊,h223,草泥马拉玛,h218,桃树精,h128,碧磷|入门,h224,碧磷|业余,h322,碧磷|职业,h421,碧磷|大师,h323,招财猫,h444,百变泽驴斯,h499,死亡仙知|纯金,h129,蠕行水母,h225,胆小南瓜人,h422,长耳兔妖,h226,蟹小蜗|海螺,h227,蟹小蜗|草鞋,h228,蟹小蜗|穷鬼盾,h324,蟹小蜗|死灵书,h325,蟹小蜗|飞鞋,h326,蟹小蜗|莲花球,h423,蟹小蜗|玲珑心,h424,蟹小蜗|冰眼,h425,蟹小蜗|冠军盾,h134,矿车鼠|矿车,h234,矿车鼠|蜡烛,h335,矿车鼠|挖掘机,h428,矿车鼠|纯金e101,圣洁精华,e102,玛瑙光泽,e103,芳晓之庆,e104,水晶裂痕,e105,腐化触须,e106,毒虫肆虐,e107,夜魇暗潮腐化,e108,夜魇暗潮荒芜,e201,暗淡幻象,e202,冥魂大帝,e203,翡翠外质,e204,祸乱之源,e205,毒蕈之径,e206,2012冠军之辉,e207,2013冠军之辉,e208,2014冠军之辉,e301,骄阳之炎,e302,嬉戏蝴蝶,e303,冰女特效,e304,幸福之赐,e305,绽放莲花,e306,迎霜冰雪,e307,燃烧末日,e308,鱼泡泡,e401,燃焰之触,e402,霜寒之触,e403,迈达斯之触,e404,离子之汽,e109,大地灵气,e110,蓝色风暴,e309,紫色激情,e310,白雪飘零,e311,一股邪火,e209,霓虹蝴蝶,e210,旋转火花,e312,金币飞舞,e313,光辉岁月,e314,紫色星云,e315,噩梦缠绕,e111,一起哈啤,e112,宝石光泽,e211,雾气环绕,e212,迷幻缠绕,e405,光芒万丈,e316,星星,e113,污污污污,e499,金龙鱼,e114,雾里看花,e317,心心相印,e318,2017冠军之辉,myskater,我的滑冰手车库,more_heros,通过老司机考试（铜牌、银牌、金牌、铂金）以获得更多车库位置,not_available_now,面板崩溃，暂不可用,h327,迅捷远足毛驴,h229,竭智法师,h130,驴法师,h328,天猫地狗,h230,蓝心白隼,h131,丰臀公主,h426,绽放树精,h329,万圣树群,h231,莲花人,h132,焚牙树精,h330,咬人箱|大嘴,h331,咬人箱|洛克,h232,咬人箱|甲虫,h133,咬人箱|机械,h427,小恶魔|飞毯,h333,小恶魔|海龟,h334,小恶魔|螃蟹,h233,小恶魔|鹦鹉,h332,布狗,e319,灿若繁星,e320,大漩涡,e407,飞沙走石,e406,星光蓝宝石,e409,血之环,e408,暗月来袭e213,小家碧玉,e214,欲火焚身,e321,通灵术,e410,雪精灵,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,";
                string[] n = l.Split(',');
                //    d = "rarity_1,普通";
                int m = 0;
                for (m = 0; m < 450; m++)
                {
                    if (d.Contains(n[m]))
                    {
                        d = d.Replace(n[m], n[m + 1]);
                        m++;
                    }
                }

                d = d.Substring(d.IndexOf("list"));
                // d = d.Substring(0, d.IndexOf("ti8"));
                d = d.Replace("{", "");
                d = d.Replace("}", "\r\n");
                d = d.Replace("\"", "");
                d = d.Replace("file://images/custom_game/lottery/", "");
                d = d.Replace(".png", "");
                d = d.Replace("taobao1111", "");
                d = d.Replace("false", "");
                d = d.Replace("ture", "");
                d = d.Replace("gem_", "");
                d = d.Replace("pic", "");
                d = d.Replace("rarity", "");
                d = d.Replace("file", "");
                d = d.Replace("images", "");
                d = d.Replace("custom_game", "");
                d = d.Replace("lottery", "");
                d = d.Replace("/", "");
                d = d.Replace("id", "");
                d = d.Replace(":", "");
                d = d.Replace(",", "");
                d = d.Replace("price", "价格");
                d = d.Replace("rarity", "品质");
                d = d.Replace("onsale", "半价：");
                d = d.Replace("expire", "\r\n商店刷新剩余时间（秒）：");
                d = d.Replace("listh0h0", "倒霉盒子");
                d = d.Replace("luckybox", "");
                d = d.Replace("skaters", "");


                //  e.FromGroup.SendMessage(receiver.Id, n[50]);
                //  e.FromGroup.SendMessage(receiver.Id, n[51]);
                //  e.FromGroup.SendMessage(receiver.Id, n[52]);
                //   e.FromGroup.SendMessage(receiver.Id, n[34]);

                // d = Encoding.UTF8.GetString(Encoding.Default.GetBytes(d));
                //d = "查询的ID昵称为——" + o + "——" + d;
                try
                {

                    await MessageManager.SendGroupMessageAsync(receiver.Id, d);

                }
                catch (Exception ex)
                {
                    await MessageManager.SendGroupMessageAsync("145368121", "发送消息失败" + DateTime.Now);
                    Console.WriteLine("发送失败" + DateTime.Now);
                };


                d = "";
            }
            Random ran = new Random();
            if (3 > ran.Next(1, 100))
            {
                if (receiver.MessageChain.OfType<PlainMessage>().Any())
                {
                    string id = receiver.Sender.Id;
                    message = receiver.MessageChain.OfType<PlainMessage>().First().Text;
                    string str1 = "http://api.qingyunke.com/api.php?key=free&appid=0&msg=" + message;
                    string url = str1;
                    //    await MessageManager.SendGroupMessageAsync(receiver.Id, url);

                    WebResponse? response;



                    HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                    try
                    {
                        response = request.GetResponse();
                    }
                    catch (WebException ex)
                    {
                        response = ex.Response;

                    }
                    // WebResponse response = request.GetResponse();
                    string y;
                    if (response == null)
                    {
                        y = "0";
                    }
                    else
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        y = reader.ReadToEnd();//a为转换网页的整个文档
                        y = y.Replace("{\"result\":0,\"content\":\"", "");
                        y = y.Replace("\"}", "");
                        y = y.Replace("{br}", "\r\n");//
                    }
                    try
                    {
                        await receiver.SendMessageAsync("".Append(y));

                    }
                    catch (Exception ex)
                    {
                        await MessageManager.SendGroupMessageAsync("145368121", "发送消息失败" + DateTime.Now);
                        Console.WriteLine("发送失败" + DateTime.Now);
                    };



                }
            }
            if (message.Contains("创建决斗") && juedou == "0")
            {
                await MessageManager.SendGroupMessageAsync(receiver.Id, "创建决斗成功，请加入决斗。请输入 加入决斗。");
                juedou = "1";
                //  await MessageManager.SendGroupMessageAsync(receiver.Id, juedou);
            }
            else if (message.Contains("创建决斗") && juedou == "1")
            {
                await MessageManager.SendGroupMessageAsync(receiver.Id, "创建决斗失败，决斗已经开始，或者准备中。");
            }


            if (message.Contains("加入决斗") && juedou == "1" && renshu < 6)
            {
                int panduan1 = 0;

                for (int i = 0; i < 6; i++)
                {
                    if (a[i] == receiver.Sender.Name)
                    {
                        panduan1 = 1;
                    }
                }
                if (panduan1 == 0)
                {


                    string jiancheqq = receiver.Sender.Name;

                    //await MessageManager.SendGroupMessageAsync(receiver.Id, "1");
                    //   string x1 = e.FromQQ.GetFriendsRemark(e.Message.MsdId);
                    // await MessageManager.SendGroupMessageAsync(receiver.Id, x1);
                    x = receiver.Sender.Name;
                    //  x = e.Message.Text;

                    int RandKey = ran.Next(100, 999);
                    // await MessageManager.SendGroupMessageAsync(receiver.Id, "2");
                    renshu = renshu + 1;
                    a[renshu] = x;
                    b[renshu] = RandKey;
                    // await MessageManager.SendGroupMessageAsync(receiver.Id, "3");
                    string c = x + "加入成功，" + "你是" + renshu + "号选手，生命值为" + RandKey + "。";
                    await MessageManager.SendGroupMessageAsync(receiver.Id, c);
                }
                else
                {
                    await MessageManager.SendGroupMessageAsync(receiver.Id, "你已成功加入，不能重复加入决斗。");
                }


                //await MessageManager.SendGroupMessageAsync(receiver.Id,"4");
            }
            if (message.Contains("加入决斗") && juedou == "2" || message.Contains("加入决斗") && juedou == "0")
            {
                await MessageManager.SendGroupMessageAsync(receiver.Id, "加入失败,决斗未被创建，或者决斗已开始,或者已经加入决斗。");
                //await MessageManager.SendGroupMessageAsync(receiver.Id, "1");

            }
            if (message.Contains("开始决斗") && juedou == "0")
            {
                await MessageManager.SendGroupMessageAsync(receiver.Id, "开始失败，尚未创建游戏。");
            }

            if (renshu > 1 && message.Contains("开始决斗") && juedou == "1" || renshu == 5 && juedou == "1")
            {
                await MessageManager.SendGroupMessageAsync(receiver.Id, "决斗开始");
                juedou = "2";
                int r = 1;
                string x1 = "";
                while (renshu > 1)
                {


                    // int r = ran.Next(1, 3);
                    if (r == 1)
                    {
                        ran = new Random(GetRandomSeed());

                        Random ran2 = new Random(GetRandomSeed());
                        int RandKey = ran.Next(1, renshu + 1);
                        int RandKey2 = ran2.Next(1, renshu + 1);
                        int RandKey3 = ran.Next(1, 300);
                        int baoji = ran.Next(1, 11);
                        int biansheng = ran.Next(2, 5);
                        if (RandKey != RandKey2)
                        {
                            int RandKey4 = ran.Next(1, 100);
                            if (RandKey4 < 10)
                            {
                                x1 = a[RandKey] + "使用" + zhaoshi() + "打出了" + baoji + "倍恩赐解脱，对" + a[RandKey2] + "造成了" + RandKey3 * baoji + "点伤害。";
                                b[RandKey2] = b[RandKey2] - RandKey3 * baoji;
                                int randkey5 = ran.Next(1, 100);
                                int randkey6 = ran.Next(1, 100);
                                int randkey7 = ran.Next(1, 10);
                                if (randkey5 < 10)
                                {
                                    x1 = a[RandKey] + "使用了神之力量，获得了" + randkey7 + "倍攻击力。" + "并使用" + zhaoshi() + "打出了" + randkey6 + "倍超级恩赐解脱，对" + a[RandKey2] + "造成了" + RandKey3 * randkey6 * randkey7 + "点伤害。";
                                    b[RandKey2] = b[RandKey2] - RandKey3 * randkey6 * randkey7;
                                }
                            }


                            else if (RandKey4 > 95)
                            {
                                x1 = a[RandKey] + "使用了变身,血量翻了" + biansheng + "倍！";
                                b[RandKey] = b[RandKey] * biansheng;

                            }
                            else
                            {
                                x1 = a[RandKey] + "使用" + zhaoshi() + "对" + a[RandKey2] + "造成了" + RandKey3 + "点伤害。";
                                b[RandKey2] = b[RandKey2] - RandKey3;
                            }
                        }
                        else if (RandKey == RandKey2)
                        {
                            x1 = a[RandKey] + "使用了" + zhaoshi() + "，但招式并不熟练，对自己造成了" + RandKey3 + "点伤害。";
                            b[RandKey2] = b[RandKey2] - RandKey3;
                        }


                        if (b[RandKey2] < 1 && RandKey2 != renshu && RandKey == RandKey2)
                        {
                            x1 = x1 + a[RandKey] + "自杀了。";

                            for (int r2 = RandKey2; r2 < renshu; r2++)
                            {
                                a[r2] = a[r2 + 1];
                                b[r2] = b[r2 + 1];
                            }
                            renshu = renshu - 1;
                            huoshengzhe = RandKey;
                        }
                        else if (b[RandKey2] < 1 && RandKey2 == renshu && RandKey == RandKey2)
                        {
                            x1 = x1 + a[RandKey] + "自杀了。";


                            renshu = renshu - 1;
                            huoshengzhe = RandKey;
                        }
                        else if (b[RandKey2] < 1 && RandKey2 == renshu && RandKey != RandKey2)
                        {
                            x1 = x1 + a[RandKey] + "击败了" + a[RandKey2] + "。";



                            renshu = renshu - 1;
                            huoshengzhe = RandKey;
                        }
                        else if (b[RandKey2] < 1 && RandKey2 != renshu && RandKey != RandKey2)
                        {
                            x1 = x1 + a[RandKey] + "击败了" + a[RandKey2] + "。";

                            for (int r2 = RandKey2; r2 < renshu; r2++)
                            {
                                a[r2] = a[r2 + 1];
                                b[r2] = b[r2 + 1];
                            }
                            renshu = renshu - 1;
                            huoshengzhe = RandKey;
                        }
                        x1 = x1 + a[RandKey2] + "现在的血量为" + b[RandKey2] + "。";

                        await MessageManager.SendGroupMessageAsync(receiver.Id, x1);



                        Thread.Sleep(5000);
                    }

                }

                if (jianchesiwang() != 0)
                {
                    await MessageManager.SendGroupMessageAsync(receiver.Id, a[jianchesiwang()] + "获得了胜利！");

                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (b[i] > 0)
                        {
                            await MessageManager.SendGroupMessageAsync(receiver.Id, a[i] + "获得了胜利！");
                            juedou = "0";
                            break;
                        }
                    }
                    // await MessageManager.SendGroupMessageAsync(receiver.Id, a[jianchesiwang()] + "获得了胜利！");
                }


                juedou = "0";
                for (int i = 0; i < 10; i++)
                {
                    a[i] = "";
                    a[i] = "";
                }
                renshu = 0;
                huoshengzhe = 0;
                /*  for (int i=0;i<10;i++ ) 
                  {
                  int RandKey = ran.Next(1, renshu);
                  int RandKey2 = ran.Next(1, renshu);
                  int RandKey3= ran.Next(1, 100);
                  string x1 = a[RandKey] + "使用" + zhaoshi() + "对" + a[RandKey2] + "造成了" + RandKey3 + "点伤害。";
                 await MessageManager.SendGroupMessageAsync(receiver.Id,x1);
                  }*/
            }
        }
        catch (Exception)
        {

        }

    });
        //  await MessageManager.SendTempMessageAsync("目标id", "临时会话群id", "HelloWorld!");
        //await bot.MessageReceived MessageManager.SendGroupMessageAsync("目标群号", "Hello, World!");
        // await MessageManager.SendGroupMessageAsync("145368121", "Hello, World!");
        bot.EventReceived.OfType<AtEvent>()
            .Subscribe(async e =>
            {
                var message = "";
                if (e.Receiver.MessageChain.OfType<PlainMessage>().Any())
                {
                    string id = e.Receiver.Sender.Id;
                    message = e.Receiver.MessageChain.OfType<PlainMessage>().First().Text;
                    string str1 = "http://api.qingyunke.com/api.php?key=free&appid=0&msg=" + message;
                    string url = str1;
                    //    await MessageManager.SendGroupMessageAsync(receiver.Id, url);

                    WebResponse? response;



                    HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                    try
                    {
                        response = request.GetResponse();
                    }
                    catch (WebException ex)
                    {
                        response = ex.Response;

                    }
                    // WebResponse response = request.GetResponse();
                    string y;
                    if (response == null)
                    {
                        y = "0";
                    }
                    else
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        y = reader.ReadToEnd();//a为转换网页的整个文档
                        y = y.Replace("{\"result\":0,\"content\":\"", "");
                        y = y.Replace("\"}", "");
                        y = y.Replace("{br}", "\r\n");//
                    }
                    try
                    {
                        await e.Receiver.SendMessageAsync("".Append(new AtMessage(id)).Append(y));

                    }
                    catch (Exception)
                    {

                    };
                }

            });
        var signal = new ManualResetEvent(false);
        signal.WaitOne();


    }
    public static string zhaoshi()
    {
        string a = "严寒烧灼,绝冥再生,竭心光环,暗影之舞,幽冥守卫,智慧之刃,墓碑,折射,刀光谍影,回光返照,射手天赋,榴霰弹,复仇光环,海妖外壳,缩地,余震,复制之墙,风暴涌动,焦渴,剑刃风暴,连环霜冻,混乱之祭,烈焰焚身,衰退光环,阎刃,血肉傀儡,闪烁,骨影步,魔爪,火焰风暴,腐蚀皮肤,元素分离,太虚之径,狂战士之血,护身甲盾,自然之助,幽魂,魔法盾,毒性攻击,风行,群蛇守卫,掘地穿刺,化学狂暴,吸魂巫术,冰晶爆轰,崩裂禁锢,魔法箭,尖刺外壳,神行百变,倒影,魅影无形,沙尘暴,剧毒新星,风暴之锤,枷锁,追踪导弹,暗影之境,裂地尖刺,狂暴,月刃,陵卫斗篷,怒意狂击,鬼影重重,自然秩序,法术反制,冰霜漩涡,魔王降临,幻影之拥,荆棘迷宫,山崩,超新星,时间漫游,甲盾冲击,心炎,撕裂大地,腐烂,神龙摆尾,毒刺,野性之斧,幽鬼之刃,狂战士之吼,羁绊,毁灭,光击阵,麻痹药剂,冰封禁制,脉冲新星,镜像,死亡契约,灵能之刃,风雷之击,丝质重器,冰封路径,墨涌,马蹄践踏,治疗守卫,震荡光弹,午夜凋零,阴邪凝视,高射火炮,寒冬诅咒,自然之怒,疯狂生长,天国恩赐,跳跃,雪球,混沌一击,气运之末,深海重击,暗夜猎影,奔袭冲撞,混沌之军,作祟,支配死灵,冰霜新星,激怒,反击螺旋,吞噬,神力恩泽,怨念深渊,等离子场,全领域静默,震荡波,追踪术,极寒领域,过肩摔,折光,月神之箭,烟幕,咤,无光之盾,穿刺,授予力量,虫群,灵魂之矛,混乱之箭,鱼人冲刺,沟壑,憎恶,灵魂链接,急速冷却,弹幕冲击,闪烁,法力损毁,密林奔走,暗言术,战意,月之祝福,残阴,冥火爆击,天光现世,腐尸毒,暗影冲刺,棒击大地,上帝之手,古龙形态,霜冻之箭,爆栗出击,狂风,雷击,猴子猴孙,虚妄之诺,驱使恶灵,守护天使,缚魂,原始咆哮,月之暗面,真空,石化凝视,战神迅矛,反伤,时间膨胀,感应地雷,虚空,极度饥渴,电磁脉冲,旋风飞斧(近战),静态风暴,荒芜,幽冥剧毒,邪恶净化,自然卷握,长大,黑洞,幽灵船,地雷滚滚,盛宴,巨浪,死亡旋风,离子外壳,无影拳,吸血光环,波浪形态,相位转移,巫毒疗法,蜥蜴绝吻,热血竞技场,血祭,月光,妖术,钢毛后背,锯齿飞轮,侵蚀雾霭,熠熠生辉,蚀脑,妖术,遗言,推进,雷神之怒,龙族血统,焦土,极寒之触,时间结界,瞄准,新月之痕,球状闪电,强攻,粘稠鼻涕,电子涡流,不可侵犯,不稳定化合物,洪流,寒冰碎片,上古封印,暗影步,奥术诅咒,魔霭诅咒,压倒性优势,寒霜之足,并列,圣神一跳,感染,束缚击,野性驱使,战吼,黑暗契约,嗜血术,怒拳破,割裂,威吓,诱捕,奥术光环,震撼大地,瘴气,潮汐使者,剧毒之触,死亡脉冲,暗夜飞升,洗礼,石破天惊,死神镰刀,火箭弹幕,地震,野蛮咆哮,炽魂,织网,冰火交加,致命链接,激光,能量转移,变体打击(力量),鱼人碎击,发射钩爪,牺牲,爆破起飞,灵魂形态,炎阳锁,幽魂护罩,野性之心,野地奇袭,混沌陨石,幽冥漫步,隐匿,奥术天球,战斗专注,活性电击,奥术至尊,液态火,闪光幽魂,电光石火,灵动迅捷,共鸣脉冲,查克拉魔法,魂之挽歌,上界重锤,死亡守卫,月蚀,传送,活性护甲,风暴之眼,星体游魂,幻象法球,发芽,勇气之霎,惑幻,星体禁锢,真熊形态,醉酒云雾,龙炎饼干,群星风暴,双刃剑,捶,末日,尸鬼狂暴,两极反转,奔腾,秘术异蛇,踏,抓树,幻影突袭,变狼,赎罪,爆头,沸血之矛,异化,闪烁突袭,裂地沟壑,伤残恐惧,巨角冲撞,迷雾缠绕,残焰,神秘之耀,实相裂隙,巫蛊咒术,沉默魔法,极寒之拥,薄葬,阳炎冲击,隔空取物,无敌斩,召唤飞弹,寒霜爆发,时光倒流,灵魂超度,肢解,巨力挥舞,梦境缠绕,火焰爆轰,火焰飞行,动能力场,幸运一击,连击,炎阳之缚,旋风飞斧(远程),命运之笔,肉钩,腐肉堆积,灵魂猎手,分裂箭,健体术,一箭穿心,防御矩阵,磁场,诅咒王冠,瘟疫守卫,剧变,巨石冲击,引燃,精华变迁,粘性燃油,超负荷,霹雳铁手,本命一击,凤凰冲击,战斗饥渴,地穴虫群,神之力量,过载,强袭飓风,冰霜魔盾,奥法鹰隼,变体打击(敏捷),法力燃烧,突袭,暗影突袭,虚弱,暗杀,恐怖波动,海象神拳,腐朽,乱流,神之惩戒,魂断,痛苦尖叫,决斗,粘性炸弹,回音击,寒冰之墙,嗥叫,噬魂,雷霆一击,能量齿轮,数箭齐发,海妖之歌,法力虚空,烈火罩,窒碍短匕,忍术,酸性喷雾,激流,恶念瞥视,针刺扫射,突,超震声波,弱化能流,投掷,热血战魂,洗劫,淘汰之刃,命运敕令,剑舞,魅惑,时间锁定,巨力重击,黄泉颤抖,恶魔敕令,移形换位,生命汲取,虚张声势,影压(X),贪婪,冲击波,复仇,炽烈火雨,超声冲击波,锚击,回身踢,血怒,寄生种子,召唤佣兽,活体护甲,闪电风暴,燃烧枷锁,幻影冲锋,火焰气息,醉拳,蝮蛇突袭,照明火箭,龙破斩,绝杀秘技,强化图腾,灼热之箭,静止陷阱,烈日炙烤,忽悠,神智之蚀,残影,苍穹震击,超强力量,回音重踏,法力汲取,噩梦,强力击,魔化,X标记,熊灵伙伴,幽冥爆轰,衰老,伐木锯链,神灭斩,灵能陷阱,暗影波,野性召唤(豪猪),弧形闪电,孵化蜘蛛,摔跤行家,烈焰破击,如意棒法,磁化,巨石翻滚,恶魔之扉,投掷飞镖,恩赐解脱,烈火精灵,静电连接,纯洁之锤,降临,召狼,碎裂冲击,死亡之指,涤罪之焰,热导飞弹,丛林之舞,暗影剧毒,地之束缚,恶魔转化,集中火力,幽冥一击,邪能,神圣劝化,熔炉精灵,再装填,地磁之握,自然的呼唤,善咒,";
        string[] n = a.Split(',');
        Random ran = new Random();
        int RandKey = ran.Next(1, 100);
        return n[RandKey];
    }
    static int GetRandomSeed()
    {
        byte[] bytes = new byte[4];
        System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        rng.GetBytes(bytes);
        return BitConverter.ToInt32(bytes, 0);

    }
    static int jianchesiwang()
    {
        int c = 0;
        int d = 0;

        for (int i = 0; i < 8; i++)
        {
            if (b[i] > 0)
            {
                c++;
                d = i;
            }

        }
        if (c == 1)
        {
            return d;
        }
        else
        {
            return 0;
        }

    }


}
