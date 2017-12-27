﻿using System.Collections.Generic;
using System.Text;
using System;



namespace SampleDemoWebApi.CustomerApi.Global
{
	public static class Globals
	{

		public static Dictionary<string, string> MaritalStatus = new Dictionary<string, string>();
		public static Dictionary<string, string> Gender = new Dictionary<string, string>();

		public static byte[] FemaleImage = Encoding.UTF8.GetBytes("0xFFD8FFE000104A46494600010100000100010000FFDB0084000906070D0E0D0D0D0D0D0D0D0D0D0D0D0D0D0D0F0D0F0E0D0E0D1611161715161513181D2820181A261C15172231212529372E2E2E17203F38332C37282D2E2B010A0A0A0D0D0E0F0F0D0E371915193737372D2B2B372B2B2B2B2B2B2B372B2D2B2D2B2B2D2B2B2B2B2B2B2D2B2B2B2B2B2B2B2B2B2B2B2B2B2B2B2B2B2B2B2B2BFFC000110800E100E103012200021101031101FFC4001C0001010002030101000000000000000000000106070405080302FFC400441000020201020207040509060603000000010200030405111221060713314151611422718108328291A115234252627292A2B13343B2C2D1F053748393B3D2242563FFC400160101010100000000000000000000000000000102FFC400161101010100000000000000000000000000000111FFDA000C03010002110311003F00DE311101111011130A0F902D26A3A81C8F6DD43B656F6A389EC40DDC1F5FDC1FDD70F67EF13B787140CD6260B9DACE72A59501776C71B24578FECB78E20B826C465B87367366C360DBF3DB6DC127F7AA6AF9F8F4E48A7DA2DC85C9CE6AC3E2D8F5AA2977A6BDD2B6670CA576DBC88E25819B4B31DB1B2FD8B51358BC5C6DBCD3B026D09C2BFD906E44EDC5C3E1BCE23EA498C9C589EDF6D4CB707ED69D4729C5E29E2AC28B016E641DC0E5BEC3913032D926139FA9EA2CD626F7D615B0ADED28C6722AA45F8DDA87E24DF88ABDA765E20555BBB620F20EADA817B1503F1715CA51B0DCAD2832ABAE9B03F20FC7533395DFF878488197C93A0D22FCFF00690990DC7491A82EFECC6A20D57D6B4B716FB6EC8CE4F81D81006C77E973ADC94BF37B3F6BCA764D40A10DA853D86D4B9AD4D3CAB75E20155908624A91BFBCD03399661C5B3D2DB6DACDDB56735856D53D8B68F6C1C2A37EE1C1BEDB73DB6DB90E7F4FCB79AACE592C645B47B428C3B47B32FB6A5615481BD80D2CEC586FB7071720C040CB2261E9ACEA4F7D2A2B155563A70B598F9086CACE65A8E0A8ADB859695AD87115E6DB9E5BEDC4C2D4351AF1EB736655F78D328FCDDB8B66C72D4B0BF8B64DF8D410761CDB6E5BC0CF2263375F996E9579DCBE412CB51A8DF4BB2F6800F7B81581DB91655F5138D5DDA8E35894316605F1DEA40B7662BAD992CB6D6721806FCDD603066DBEB7881B40CBA598565E6EA758AAF365AD63E97A85C94261B763ED8A2A6AAB751B9E2FADDE413B36DB774FDEA3A9EA35E48C750F72F05AB6BFB35A8A77C4B6D57ACA290071AA26E6CDF7DC6DBEC606632CE8BA3975C6CCC4B9EE256DA4A259532AA56D8F51F71C8F7871710EF3CC1DF9EF3BD81259220258881222205888808888088881C74C2A16D6BD69A85EEA15EE15A8B5979722FB6E4721F709C8888088880888808888089F9B2C551BB3051E64802702DD77010ECF9B8887C9B26A53F8981D8C4EBE9D6F06C3B579988E7C9722A63F819CF56046E0820F88E620588880888808888088880888808888088880888808888088880889D76A9AEE0E1945CBCCC5C56B3728B7DF5D4587980C79881D8CE2EA5A8E3E2D4D7E4DD5D14A7D6B2C60AA3C873EF3E931AE90F591A461D0D6265D1996EDF9BC7C6B92E776F0DCA92107A9FC7BA680E94749B3354BCDF9766E013D950BB8A285F245F3F363CCFE10368F48FAEBA949AF4CC5376DCBDA3237AEAF8AD63DE6F9959AFF0055EB135BCA278F3ECA94FF00778C171D47C197DFFBDA62D10AFDE55D65C78AFB2CB9BF5AD76B5BEF6267C8281DC00F94FD442BF2501EF00FC409CCD3B52C9C520E2E4DF8C473FCCDAF58F980763F39C5881B13A3FD706A98C5572C57A8543604B05A7200F4741C27E6BF39B77A25D38D3B551B635A52F0377C5B804BD4789037D987AA922797A7EA9B5D1D6CAD9ABB118323A3157461DC5587306131EC489AC7AACEB1CE715D3F506033429EC2FE4AB94A07304770B00DCEC3910091DC44D9D0844440444404444092C4404444044440444C7BA7DAF9D334CC9CB400DAAAB5D008DD7B77215091E2013B91E4207CFA5BD38D3B4A1B64DA5EF2BC498B500F7B0F0247728F56204D4FADF5CBA9DCC461D546157CF6257DA2FDBF79BDD1F0E1F9CD75937D96D8F75CED6DB6B17B2C73BBBB9EF24CF9C2E3267EB075D63B9D5323E4B4A8FB824E9756D572736DEDF2EE7C8BB816BED1C286E05DF61C801E27EF9C388088885222202222022220222207EE9B9EB74B2B76AECAD95EB753B323A9DD587A8227A8FA09D221AA69B8F97C85A41AB214772E42727DBD0F261E8C279666D9FA3F6A857233B058FBB6D69975AFEDA1E0B3EF0D5FF0C256ED888842222022220224960222202222026AAFA40E670E0E0E383B1B731AD237EF4AEA61FD6C53F29B5668EFA41DA4E669C9E098D7BEDEAD628FF240D551110D3BEE87F45AFD5ADC8A31ECAD2DA719B21459BF0D8C1D5426E3EAEFC5DFE93AFD6345CCC1B3B2CCC6B71DCEE543AFBAE0779571BAB0F8199D750B66DABDCBFAFA7DDF85D4FF00ACECFE9079DBDFA7628DBDCAAFC87F3F799513FC0F08D491110A444404444044440444404CBBAA5CC34EBD81E571BE87FDD6A5C8FE655988CEFBA05BFE59D2F6EFF6EA3EEE2E7F86F08F53CB110844440444404444044440444404D15F4801FF00D860FF00C9BFFE5337ACD1DF4835FF00E669C7CF1B207DD62FFED046AA8888699A753B9829D7B101FEFD3231FEFACB8FC6B13B0EBE37FCB55EFDDF93B1F87FEF5FBCC2FA3B9C71B3F0B241DBB1CBC7B18FEC0B071FF2EE26D2FA40E924FB06A0A3751C78969037DB7F7EBDCF97F69F788469D88885222481622202222022220266DD4F613D9ACD16AD0D78C54B2D6D99516A2CA6B0EC58F30388F21CF7F84C26665D53F48174FD5AA36B70D196A716D63DC858835B1F83003E0C7CA11E948925842222022220488881624960222202694FA42AFE7F4B6FFF001CC1FCD54DD734B7D21BFB5D2BF7337FAD3046A28888690A16F746E49E436EF9EA1A70E9D6742C7AEFFA99D818EE586C5ABB4D6AC197F695B9FCA79EFA0B8C2ED5F4EA986EAF92A187A0049FE937FF005584FE42D394F335D4F57F05AE9FE584AF366A584F8D917E35BFDA63DD6D0FC8805918AEE0791DB71E8671E6D1EBB3A2575596DAAD15B3E35E8BED45149EC6E550BC4DB772950BCFB81077EF1356C0B1110A4444044440444404846FC8F7196763D1DD21F3F371B06B75ADF26C282C704AA008CC491E3C94F2F13B40DDFD4DF4B9F3F15F0F258B6560AA0161E66EC73B8463E6C36E13F64F899B16627D05E81E2E8C2D6AACB2FC8BC2AD9759C2BEE03B85441F546FCFC4FAF74CB6194962204896204888816249602222026BCEBC34D5B7477C8E006CC5BA8B15BC4233F037CB67DFE5361CE87A7B866FD1F53A80DD9B0B21907EDAA165FC5440F2BC482586993756842EB780EDF56A6C9B98F92A62DADBFE137D7569514D0F4DE2E46CC65BCFFD526CFF003CF3469F75C966D8EDC36DC9662A9DB73B5C86A207A90E46FEB3D6B818AB4D34D08365A6AAEA51E0155428FE9095F72011B11B83C88F02279E7AE1E89D7A7E6ADF8B514C4CB46B0A2A1ECB1EE565561B8E4AA789481E64EDE027A1E7E2DA51C10EAAC0A9521806054F7820F818478F2266BD6CF45AAD2F51518CBC18B9759BEAAFC2A70DB588BFB237523CB8B6EE130A8522221488880888809DEF4170F26FD5B01317716AE4D5717F0AEA460D631F4E1047AEE078CE8A6DDEA1B42CB5BAED49876787650D8F5EE0715EE2C07897C42AF091BF893E908DD12C4908B124B01124404444044B101111013E397507AAC43DCF5BA9F815227DA7C7332AAA2AB2EB9D6AAAA467B2C72022201B924C0F1E54085507BC000FC769FB9F6CE7ADAFBDA90452D7DCD482362292E4A03EBC3B4EC34CC6C5383A8E4DE78AFA862D1874F115DEDB9DB8AC3B77F0256DB0EEDCF3F0869CDEAE74D395AD69D56DBAA642E43F905A77B39FCD00F9CF51CD19D4168ECF99959E41ECF1E9F6643E06EB0AB36DEA1547F189BCA12AC92C908D31F4864FCE694DFB19ABF8D3350CDB7F48663DB6943C3B2CD3F3E2A66A4852222148899EF53DD15A752CEB6CCAAC598B855A3B54C374B6E72422B79A80AC48FDDF0846BFED17F597EF13F73D7874DC629D99C7A0D7B6DC1D92706DE5B6DB4E8F2BA01A1DA4B36998809E64D75F63B9FB1B41AF2F7C0127B8003724F8003C4CF58744B4F389A6606330E17A3131EBB079582B1C7FCDBCE2699D07D1F16C5BB1F4FC74B50EE9630363A379A972763EA264308B12440B12440B1244044440B111011110134CFD20755B83616082571DD1F26C0390B6C560AA0F985E676F3607C04DCD318EB03A2156B1866A24264D5C4F8977EA59B7D56F346D8023E07BC081ACF43E87E95A6E969ABEBBBDEF7D6AD8D861881BBAEE8A141F7EC20EE77E4BF2DE60BD13E8B666AB78A715392902FC8607B1A14F7963E27C94733E8398CDBA1FD1AC9D73211359B32128D2EAF62A695428B61A4F0589DA8EE6042F111CDB96C7972DDBA6E9F462D294635494528365AEB50AA3FD4FAC2B89D19D0A8D370E9C3C70782A1EF39DB8ECB0F3676F527FDF29DAC4421113F175AA8ACEEC15114B3313B055037249F281A57E90B68393A627E92D196E7D033D607F84FDD3534C8BA6FAFBEAFA8DF968AE6A0169C65E13BAE3A93C248F02C4B37DADBC2747EC96FF00C36FBA15F189F5F66B7FE1BF8FE89818B69FEEDFC7F44F877C2BE53797D1F69DB033ACF17CE09F6569AC8FC5CCD222873BEC8FCBBFDD3E5BCDF3D43D4C9A56471295273ED3B11B1DBB1AA12B644B24422C912C0492C4044440492C4092C9102C492C044440492C40F8E3632541856BC21ECB2D6F57762CC7EF33ED110124B10135CF5E1AF7B36983111B6B7507351DBBC632EC6D3F03BAAFDB9B1A79B7AE0D74666B1722B034E101875731B171CED23D78C95FB02061D55CE9BF09E1DF6DC8EFE5EB28C8B00D83B6DB6DB6FE13909A4E630E25C3CC65FD65C5BD97EF0B388EA558A302AE3BD181561F10798869F64CCB46DB3B72F9CFCB64D87605C9037D872D86FDFCA7CA207D8E559B93C677249DFD7FDFF41E533EEA87A65661E62E0DEC0E2675A002DDF4E5300A8C0F936CAA479F09E5CF7D771CFC0907C083B107CC1F0308F62C4C67ABBE91FE53D328C8620DE83B0CA1E22F4D813B7ED0D9BED4C9A1096248089648089620489620496496024896022220222202222022220274DA4745B4EC366B31B1294B5D99DEE2BDA5ECCC4924D8DBB7793CB79DCC404EB759D0B0B3AB35666355909E1C683897D55C7353EA0CECA20680EB07AAEB7003E5E017C8C25DDACA8FBD918C3CF7FD34F5EF1E3BF3235BCF634D35D67F563B769A8E95572E6F938283E66CA547DE507CBC8975A7E2496159FF00531D23F62D4862D8DB63EA1C349DCFBA992373537CF729F697CA7A1A78E812082A4AB020AB03B32B0EE20F8113D49D01E910D4F4DC7CA3B76DB1AB2547E8E42726E5E00F261E8C212B219622108888088880888812225808892058888088880888808888088881258880925881AABACBEAC0649B33F4C455CA3BBDF8A3654C83DE593C16CFC1BD0F33A42DAD91991D591D18ABA3A957461DE194F307D27B12623D36EAFF00075606C61ECF981764CBAD471103B858BDCEBF1E63C0885799E6C5EA4BA47EC9A8B6158DB51A800ABBF72E5A8F70FDA1BAFC78263DD2AE83EA5A59639149B31C1E5974EEF46DFB5E35FDA1F026639558CACAE8C55D195D1C77AB83BAB0F5040303D8B24E8FA13AFAEA7A763660D83BAF05E83B93217938F86FCC7A113BD84222202222022220224880962202222022220222202222022220222202224816222043CE623AE756BA2E6B177C4145A7726DC6634127CCAAFBAC7D489974B0316E83F4313461935D39575F4643A582BB9538ABB00E12432800EE028EEFD113298880888808888088881259220258881204B10244440B111011110244B10244440B2444044440B24440B24B101111024B110244B10244440FFFD9");

		static Globals()
		{
			MaritalStatus.Add("M", "Married");
			MaritalStatus.Add("S", "Single");
			MaritalStatus.Add("D", "Divorced");
			MaritalStatus.Add("W", "Widowed");

			Gender.Add("M", "Male");
			Gender.Add("F", "Female");
			Gender.Add("U", "Undisclosed");

		}

	}
}