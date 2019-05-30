-- projects
INSERT INTO [dbo].[Ziro_Project]           
			([Id]
           ,[Name]
           ,[ShortName]
           ,[Description])
VALUES('15A09976-6A3C-4AF8-A9CC-D0921741CE87',
           'Twitter','TWIT','���������� ���� ��� ���������� ������ ����������� ��� ������ ���-����������, SMS, ������� ����������� ������ ����������� ��� ��������� ��������-�������� ��� ������������� ��������� ������ ��������')

INSERT INTO [dbo].[Ziro_Project]
			([Id]
           ,[Name]
           ,[ShortName]
           ,[Description])
VALUES('15F09976-6A3C-4AF8-A9CC-D0921741CE87',
           'Facebook','FB','���������� ���������� ���� � �������� ����������� ������� ��� ����� ��������. Facebook ������������� ������������� ����������� ��������� ������, ��� ��� ���������� ����� �������������� ����������, ���������� ������ ��������� �������, ����� �� ����� ������ ������. Facebook ����� ��������� �� �������� �������� � Twitter, � ����� ���������� ����������� � ��������')

-- project documents
DECLARE @docData1 varchar(MAX) = '0xFFD8FFE000104A46494600010101004800480000FFE100224578696600004D4D002A00000008000101120003000000010001000000000000FFDB0043000201010201010202020202020202030503030303030604040305070607070706070708090B0908080A0807070A0D0A0A0B0C0C0C0C07090E0F0D0C0E0B0C0C0CFFDB004301020202030303060303060C0807080C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0CFFC00011080091009503012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00FDFCA28A2800A28A2800A423AD2D32E7FE3DE4E42FCA793DA800E9D29B232A119FBDF5AF87BF6C9FF82C6F877E03EB4DA1F8361B5F156BD1B34733CF23C76D6EC3A82CABF3E3F4AF88BE32FF00C172FE30F8DACE78B4D9AC7C3F6B0B12D25AC237A11E8CFD8572CB151475430736AE7EDB5E6A16F66CA249A38C9E70EC2A3B3D7ACAF64291DE5B4CEBD424A091F5AFE5BBE39FFC1467E2CF8D7C44B25D78A7C41A8471CACAB2DCDF49143106EAAA1BD7FD9E2B3FC3BFB61F8D2CE2895EFA4F3B1FBD5FED178D9F3D30475A5F5997F295F53FEF1FD5624AAFF74AB0F63530E95FCD8FC1EFF828DF8FBE195DC1FD93E2FF0015689712484A2BEA0D716E4F7C866240CEEEC7E86BEE6FD933FE0B8BE25B0D42C74FF1A3E9FE26D3AE2702E2E1C35BDFDBA70015DB9493D94804F4E2947151EA825839DAE8FD672B9A4DA715C7FC1FF8D3E1BF8E7E17875BF0CEAD6FAB594C065A17F9A227AABAF622BB2AEA8CAE726AB42361834A1F029E7A5475421C1F269D51D140125145140051451400504E0514D93946FA77A0086EA54B7B6924919638D54966278031C9AFC8AFF82A6FFC15BB56F136A575E12F01DE49A56811CD2DBC9796F29F3B54D8D8665DBFF2CC9F947BD7D77FF0574FDA1AE3E15FECF571E1ED1E70BAD78A219130ADFBC16C36A3B7D18BA2FE35F857F16BC4DF6DF164D0DAC8D24A91C50A2A9F9A30A3050A8EB82776075DD5E4E271179FB389EB6070B687B491977FE3D92C5AE2F6E26BDB8D46FB6C65B2FE7429824440F639E735CEF897C51A86B1711DACAD6F6D62B70624B5B7FB92951890F1CB2AA92B83D4AD6FF867E1BDE7C56F14C1A3E931BDD5F49869E68D030DEC7712A071C01CFF000A7DD1C9AF69B5FD84356D2B401AA5C59C8B1C23ECF68817E67C7393FF0001C570CB154A9FC47AD4F0B5267C81ADF8464F1A3B456A57ECEA4BAB31CACB22F2D81DB039FF0081567FFC23FA96837EDE66D96DE4014AB465D7F0C735F5BEB9FB27EA5E0AF0D5BCB1E9B32B5E4AFB9027DDC8FB9F875AE0F53F841ADDADB4CF716FE43479F9BCBF92623AE7DC0AA8E3A3226597C8F1AF0DF8E945F246D0ADDC2CC1CC178A329938CAB75007A371EB5ED5F0FBC4C62923F2ED5B508701930C44E17BF1D5980DB90DC95E95C85EE8535A2AAC31C3710CA089567888553DF6B0E57EA3A57A47C28F8797DAE3C2B1C335B4D1E1E19ADDDA4D84723047CDC1F5A2B6223CA1470B2E63E98FD963F6B1D7FF00659F1FAF883C37A94527DA021D4B4D964DB65A9405776F603A3B631E62FF007306BF633F64FF00DA7F43FDAAFE1B43E20D237C3346E2DEFAD1FEFDB4E065BE6EEA7B57E28784FE1A4CFE12BABCB5B1B77B50CEB71623B395DCFB14AE557700C1472ADCD5DFF826E7EDE927ECB9F1DDA292E1AD7C3A97262D4F4FB966DCD6A5B0EDF58DBE71FEF5181C77BDC873E6180F779D1FBF141E9591A2EA36FAB5A5ADE5A4D1DCDA5E469345347D2657C3295FAFDE3F5AD7AFA23E748E8CE2A43C8A684C1A004D9DFD68A7D140051451400532E39824F9B6FCA7E6F4A7D364FF0056DF4F4A1EC07E5EFF00C153EE2F756F8AFE3CBA312DC4DA5E8B1DB698ADF38B60E086623F87F784F3DB657E3EF88D19FC4BA80B28E4F385C1525DBFD611F2A463D8E4BFE15FB2DFF0548D35B4AF8ABA94CB0FDA2E3567B7B6651C062B14D240A47BE315F923F0274783C65F1C2D24991BC9D3AE56E26573B4CD78C4B3FF00C054915F332D2529C8FA6C3EB18A3F44BFE098BFB1D5AFC1DF85916B1AD42B75E20F10012CF2BAFDC8DBA28FC2BEC85F85FA4EA515AAB5BA3C36AB88976FAF5AF31F809E288352F0BC36F1B330806DCEEF954F1C0AF64F07DDE498646F9BA8F9BB578ABF7957DE3D692946362AEA5F01341F1140AD369F0B6D21932BF748AE57C4FF00B25E837B68CB1E9D66CCC7FBB5ED7A644AD07963A753505E816F27CAB5DD2C2C7A1C71C548F857E31FFC12E6C35CD76397446FB0CA9292C0AFC8C0FDE15EDDF047FE09E5E1BF087856DE0BB855AE19479BB7F88FAD7B75C4BBDBCC6EA2AEDA6ACD195C3718A50A51FB454EB55E5F74E22DFF0066BF0BF80D649AD6C6192498625120C83E9915F10FFC1507F622D2E4B9B6F8A5E17B5B7D26FA0FF44D6D604DA6753FEAEE3FDE43F2B7FB35FA1DE21D7167B7309F94E0FCD5E53F17745B4F16780B59D0D9D5BEDD65245F8853449C612F7498B94FE23A0FF822CFC77BAF8E5FB1168B06A5B7FB57C17792F87EE3FDB8E20AD11FFBF6F1FF00DF35F5E74AFCE7FF00837C359173E05F8AB631FCA2C75FB71222F48E431387FCCA0AFD180722BEA7092E6A5167CB62A3CB56510A28A2BA8C028A28A0028A28A0029B2FFAB6FA53A9B30DD0B0F97A1FBDD3F1A00F813FE0B3FE0FB86D33C297965753D89BEBC6496E9577AC252DE548D8FD1A406BF1CBC51610FC34F8A962BE1E924B53A9399E7B866CB967762580FE104347CFFB15FB67FF000560D5FC3BE25F04D9F866E1AEB52D6A1CDE1B3B3BE449E3808C6E788F255BEE8C73F2D7E28FC6A860D0FE29D935BA816B0882384C83388C246B83EE32B5E0E2395B9C627D1E1235214E12A91F74FD07FD8ABC75A86B768AAD692476F0A2A8909DDE71EE6BEBEF08CC64F2D8AED6E322BC07F65AD434FD47E0FE8B3D92C6B6F25BAC80A8DB918C7F3AF68D1FC496BE13D0E7D4B54BAB7D3F4DB24692E67B96DB1DBA019273D8601E6BE7E9C7DE3DBAD2F7743D4B4A9DEE22DAADBB68E9E94EBAB394FCC5BE51C9AF957C4DFF000589F83BE01964923D5A7D46DB2CC6E238F6290381B77FCC467B8E28D0BFE0B2DF077C66F1C4BAD49693CF8548668B6972781B597826BD6972F29E72854E6F84FA9AE2C37C39F9BE6E3EF536CED5946DFEED709E03FDA1B46F885A32EA1A46A09796A47556F957DBEB54BE287ED27A3FC2DF0ADEEABAA5D25BC36A37C9B9B938191FCAB9F9E2350A8DF29DE788EC83DB361F71DA703D2BC97C516CD63ADF9CCCC72718AF91FE277FC17A7C2DA1EA9358E83E1ED635A68F0AAF1A908DCF38C73F97350FC1AFF82B237C68F893A5E83AF781750D16DB58B95B68AF0865FB339202BB2B2F2189009ACAAD1E75CC7446328B68FAA3FE087DF0E5BC0DE36FDA52459375A4DE3E4B7813FBBB2D5646FF00D28C7FC06BF40A3AF06FF827FF00C1AFF8549F08758BA9195EEBC65E25D435F99B6F5F324D89FF0090E28EBDE63AFACC2C79694627C7E225CD56521D4514574988514514005145140053666DB0B13D003DF14EA6CE710B646460E4517B6A1BE87E787FC1417C3F6B0FED63AA6B9A8C02D6DB49F0A4663B929B44F2B4CC8067BFCA5C7FC06BF3DBF681F87BE1FF008E3A3C7E2AF0FC0DA7B6977A0DC87836FDA2257645908FEF03B496FEED7EB27FC158FE1F49E29FD9AEE6FADC2C7756F3C76F2CA0E02C6E71F37B6FC57C1BF0620B3D0F58B7F0EF8834BB3B5BA682DAD67B553BB16EC3E66FF8131AF87C553961F19CB1EBAFDE7E9981952C6654A5F6A1EEFF00E0276BFF0004D5826BCFD9934849BCB2D6F34F6E8E871B807CD7B1FC66D02CFC55F0FDF4DD5ECE5D534F67F364B28F72FDA597901B67DE1DB0DC1EF5DD689F057C3BF093C2F7963E1DB392CACD236B955FE146619E3EB51F856E8DD221D9B99720D695A3C92B1E4D29A71BB3F35FE3E6A9E32D5FC29A9EA1E15F85BE11F0BDAE8D33428B79A247797ECBB2465994320CC65C042DF2ED073F3572FE12F8037D61E1FF0003F883C45A7F85356D43C4AACDA868D368D6D14966E1BEF23C6BB9723D6BF59FC51E036D6F49912DE1B7996E065D658F7D79545FB16DAEBDE298EFAE63B3B1881C98EDE2DA5F9EE7B7D6B4A946538729B51AD1555CE72B2E912F7ECDBF06AC7C2DA65A69AB630E9B6F7016411C1F75723A57CB3FF058DBCF107C35F16786741B0B796E2D7C44A7F771A6FCBAEC43F2F7E0F4EF5F7B68DE1F4F095E42916ECDBB853CEEE9D2B07F6D6F81BA0FC79F08E8EDAB5AADC2E9B70CD04AA30F13633C1EC476ACFEAD1B72853C47EF94FB9F92B2FEC4BE34B6F8F905BD9F882F97C1F1DAB4CF736F726CBCC621994A8440C180C028C4B07C13915EC9FB11FC00F8C9A378DD4F8CA48F56D234CB80F6F797320F3D50723EF2E58EEC735F72FC39FD9736E956FF0067D46E9ADD502B007CB718E837575DAAFC2CB5F087879E38E6DA704E5BEF13EEDDEB5A91B24E2671AD18A946FCC7D57F0E2D23B1F03E8D0C3FEAD2D62C7D367F8D7415C7FC10BE3A87C29F0FCDBB76EB08573F4515D857D4D17CD08C8F8BAB1B546828A28AD8CC28A28A0028A28A00291C650FD29683D28039FF00197856C3C75E1CBAD3350B75BAB1BF8BCB96273F794F031EF935F983FB59FEC69F153C27F102EB54B5D3E4D4B47FB5A1B4BAD3658BCA98B3011C4EA7F78841C0F435FAB12B6D8D8FA026B9CF89BE1DFF00849FC09A958ADBF9F23C65A18FD5D1B72FEB8AE1C660615D7BDD0F472ECD6AE164F93667CEFAFE9F79A5FC3082DEF97C9BE9B4889E4192CA92AAFCCB95E3762B86F85FABAFD913CC664DAE413EB5E97F1FF5A6D0FC07A7C3343B666825847FB3BB951FF7CE6BE59B6F89ADA3BAA4796CCA50286E8D9E2BE6F32A91A7389F4796C7DBD394CFAE34DD62D7FB307CDDAB2AFF00C67696FA946BE61693236A0FE75E4761E39BC3E1F9195BCB664C92EDD38EB56FE1C6AF684C92CD74CD752360C921C363D14F61550C4734A3CA5CA8423F11DA1D7A4D5355F34C2C968ED8DC5B9CD749E2996D67F07CD6372BE4AAC66581CF56C0CF15F3F7C595F135A5C2C3A1EBEBA7D9E4BB2CB6BBE58C9F46DDC835E07F1F3F698F8977C9FF0008BE83E63DDB0092EA207EEAD97A16DBBB83DEAB9BD9F3391D30C2C66938C8FA43C3DFB57C1F0DFC730685AEAAC705D006CEFA2FBB2E41386F718AEBBE257C5DB6D434C568EE15ADE7C107FBD5F10FC5CD066F0FFC2BD3DAFB50177A859A2349717337DE7CE082DD8F3C0ACEF87DF18B55D7F5086C6699AEADE28D65739DCAB9700015E5CB195232507F09DDF51A3ACD1FB27F02205B6F84DE1D55FBBF6085C7E2A6BB61D2B94F855A5B691F0F341B665DAF6D616F1B7FBC23507F415D58E95F7543E089F9AD6FE2C828A28AE8330A28A2800A28A2800A28A28011CE14FD2B23C67E2DD37C09E16D4B5AD5AF20B1D2F49B792EAEAEA5395863452CEC7BE02827F0AD694ED898E377078F5AFCD3FF0082FCFF00C141AC7E0AFC1DB8F873A5DDC6FAA7882178EF3273B63EEA477E0D007A4FFC143BE2F4317C36D2BC49A1CC2E74DBDD9771CC0ED628E8AC9BB7738285715F147833C7F26BBE2072AC922AB89D7E6EA7392B5E41FB1AFED937FF00B50FECB1A97842EAF26D4BC5DF0FF4F549ACA4F9A5D77478C058EEA25FE29ED9488D87F122A1ED589F0B7E2C0F08789E355BC4910ED10CD9E244E791FDD2C7A8F6AF8DCF30B3752E7DC6475A2A8F21F785CF8A2E355F0906B6B88E39E35E07979590F6C8EE0578047E3BFDA1BF676D422D635A5F0AF8EBC1FA9DC3960F6AF6B7DA38DCFB106C6DB2A91B39FBC2BD17E1D78AA3F12694D1C244CAFB7CB01B92A7FF00AF5EE5A34F1EA9E1A5B7B8861B886480473447E78F3D307FBA7DEBCDC0CA5196A7673439BDF89E03A3FED9977E3C8EE2DF509BC19E1916F24B13BEAD0DD4324AAA30B200CC5983139D982DC64F15E5BF147F696F136956F347E0FB0D275DD4AE04AC24D33429A685581F9774F70C12352719254803920F4AF6AF8D1F0D2C35310C4F677EB0D99252146FF539F4F635C4C1F0B752D68ADBDB69B702D547CC256F95CF607E5E95EA4E513D4A31C1AF7B9A5FF80A3C57E1C7C08F88DFB4EE7C4BF16BC5D35C69BA7DE99F4BD134F8E2B7815D46D496531AE656C700FDD15F4D7ECF3F0B6C7E2C7ED05E1CF09E8F66B1D835DC335D347F32A410E5DF71F53973FF0003ACBF1CDB5DF817C0F1DB2AAADCDD300B08FBBB07403F1AFB6FFE0997FB294DF05FC1BFF0946BD0B47E22F1046AB1C32AFCF676F9CAFF00C0DFEF1F615CF86C3CEBE2637F851E4E6B9842952972EEF6F43EA9823540817EEA9DABF4E31FCAAD51457DC1F9E85145140051451400514543763223FF007C76FAD00899B95AF16FDB1FE34DEFC2FF000235BE8D3FD9756BE562B3FF0015B201C91EF5EC1A9DE43A6E9934D7127950C31B48EFFDC500927F015F077ED57E3A7F893ABEA13166586E58C70C5BF0AB1AF014FE3CD69463CD203E6DF8A3FF00055EF8D5E12D505B5978905CDBDAC9830269F1EFB800F2AD2188B73D3218119EA3AD7E5FFEDE7F14BC57F1B7E26DFF008975991EE9589C233315890FAFE35F7BFED17AAE97E0F8AE2CE24B692FF0380718CFFB3DFEB5F2078FF497F13BDC48B6EB9DC4BAFF00787A5744A8F6089F23FC27F8F3E20FD9C3E2E68FE32F0BDF1B7D63419D6682427E595470C8EBDE39132847704D7E8D6B3F0674BFDB53E11DBFC66F8431ADAC9AAEF9F5DF0E5BB1F334BBE5FF005FE501C95DC398CF2776F4F958D7C03F1D3E00CC12EB58D261559A33BA5B4032260392C9F4EF5D87FC12B7F6FF00BAFD8ABE3C42BA9DD31F01F89248EDF5B8CE40B37FBA97600E77467AE3FE59B3570D4C3C2A7BB50E9C3E325425CD13EACF81DFB45F893E105FA5BEAF6AD716B6F279723A0398883D195BA1AFB87E14FED47E1DF1C6836B716BA9C62491409A291D54A7AF14BF1E3F63EF0CFED3DA347E24F0EDC5AE93E26B983CE5BA888365AB0203289BB2B1181E62F1CF35F18EBFF05EFBC27E2ABAD3F54B2BCF0DEB960E5278D18C7201FC2F95E0AB7635F2F8CCBE5879F34FE13E9B09888E263784AF2FE53F48AE3E26787F48D223927BBB5F997799B72FCABD6B9DD57F68DF0BB68771750CD6AB6F08654937FDF38E6BF3F75FF04EB9AA681F639BC51ADBDBC7F757278CFF00B4393F857D6FFF00047EFD80FC37FB435DF88353F88B6B7DE24F0FE88638AC74EB9BC923B596627E66755D9BC28E0AB6E07CCC1047158D18FB697244DB152F611E691EF3FF0004F5F84A9FB4EFC5093E236A96AD3F84BC3F208F4D9278FE5D4EEC107781DD10E0E7FBE057E8444823DA385E838F95571D00159BE19F0AD8F83F47B1D374BB3B6D3F4FB14586DADAD6158618907408A3EEFBFAD6D6CC1AFA6C2E1634A1CA7C962B112AD3E763A8A28AEA39C28A28A0028A28A002A3B96C47D3773D3D6A4ACDF166BF6FE18D06E2FAE8B7936EA5885192C707000F7A2D7D1069D4F25FDA97E221B3D213C3D6926F9670B2DC90338507E446F673CFE15F937FF0529FF8296697F02B53B9F07784A4B7D57C65B717B386DE9A3B11823FDB9B1F90AF6CFF0082C17FC140E4FD98BE0FDEDE59DC2A78F3C64EF0E9815B3F648B0435C11FC3B47CA87FBD8AFC37D36FAEBC47E20B8BBD4266BABBBC90C92CAC7733B336E24D7443DD03D42F3E276BDF107547BCD6352BCBE9A67323176F9573DB6F6AD7D1BC4D3594D27DEDA07F7BA5729A3C71AC2A54EDDBC13E95BDA35DC2F70CBBB771FDDAE803B0B7D523D66D9D6E3E65501BEE7CDF857CD3FB57FECF43C2B24DE26D16359B4F94FF00A6C71B67CA27FE5A81D81E86BDD20244DF20C49B4F3ED5792EA1BEB792CAFBCB9EDE68CA491C8BF2C8A460A9F6238A99C39B52798F5CFF008213FF00C1471EEE08FE0BF8BEFF00FD26CD19FC33752B63CD8C72D69F54FBCBFECE47F0D7E907C61F843E1EFDA27C3EB67AAAFD9752B543F63D4E31FBDB738E0107EFAE7B77E95FCE4FC65F01EA9FB387C55B4BED1EFAE2CE3F3C5FE937B1FF00ACB692360467FE9A23607D2BF71FFE09C7FB60C3FB5FFC00D0FC40CCB1EB51A0B2D5618CE4C57318C3803FBADC32FF00BE6B9E515523ECA66D4AA3A72E7A678A7C4AF875E24F84BF104786F5A8FECC666DD6B7ABFEA2F22CFDE0C796C0EA3EF0EFC57DB9FB3C7ED1CBFB27FECA7AE78EB4FB65B8F0FF0083E6B6B8D5A08FFD64BA7FDA123BB913FDA4576907BC55DA7887E04691F1CFC153689AE45E75ADD21114B09FDF5AB9180F1376653CE3D457CFBE3FF83DE2EFD9E7FE09B5FB5069FE2C4867B5B5F0A6A7068F3DB1DD1EA16C2062B3ECED9EBB7B30CD791472F746B732F84F5B11982AD47967F11FADDE14F1059F8B744D3F54D36EA1BDD3754B68EEED2E21FF0057341200F1BAFF00B2CA548F626B62BF167FE0D87FF82C5D9FC48F867A6FC01F1FEA023D7B43F93C2D7F349B85D5B96FF8F166FEF464E23F552ABFC35FB46A41031F32B720D7A278A3E8A28A0028A28A0028A28A002B87FDA1FF00E49ACDFF005F10FF00E8628A29C7703F9E7FF8388FFE4E33C2DFF62EC7FF00A39EBE2BF057FC787E54515D313491D65B7FABB8FF0076A6F0C7FC7DAFFBC28A2BAA26323B28FA9FF70D589BFD7C7FEE8A28A19278DFEDE7FF00229E93FF006109BFF45D7D5FFF0006F0FF00C82BC7FF00F615B6FF00D132514572CBE33589FB4BF0F7FE3C22FA2D7957FC14A7FE4D5FE387FD925D67FF0041928A294F61F53F9F2FF8245FFC9E7780FF00EC216DFF00A18AFEC863FF008FD6FA0FFD09A8A2B9DEC8991668A28A4014514500145145007FFFD9'
INSERT INTO [dbo].[Ziro_ProjectDocument]
           ([Id],[FileName],[Description],[ContentType]
           ,[ContentData],[UploadDate],[ProjectId])
     VALUES
           ('1ADE419D-A6E4-4F3C-B2E1-73B7FA593FA1','Facebook - ���������.docx','����� ��������� ������� � �� ��������� �����������',
		   'application/vnd.openxmlformats-officedocument.wordprocessingml.document',CONVERT(VARBINARY(MAX), @docData1, 1),'2019-05-30 22:31:14.7386402', '15F09976-6A3C-4AF8-A9CC-D0921741CE87'
		   )

INSERT INTO [dbo].[Ziro_ProjectDocument]
           ([Id],[FileName],[Description],[ContentType]
           ,[ContentData],[UploadDate],[ProjectId])
     VALUES
           ('2ADE419D-A6E4-4F3C-B2E1-73B7FA593FA1','�������� ����������.docx','�������� ���������� �������, ������� ������ ������-������',
		   'application/vnd.openxmlformats-officedocument.wordprocessingml.document',CONVERT(VARBINARY(MAX), @docData1, 1),'2019-05-30 22:32:14.7386402', '15F09976-6A3C-4AF8-A9CC-D0921741CE87'
		   )
INSERT INTO [dbo].[Ziro_ProjectDocument]
           ([Id],[FileName],[Description],[ContentType]
           ,[ContentData],[UploadDate],[ProjectId])
     VALUES
           ('3ADE419D-A6E4-4F3C-B2E1-73B7FA593FA1','����������� ������� �������.docx','����������� �������� �������, ������������ ����������, ����������� � �������',
		   'application/vnd.openxmlformats-officedocument.wordprocessingml.document',CONVERT(VARBINARY(MAX), @docData1, 1),'2019-05-30 22:33:14.7386402', '15F09976-6A3C-4AF8-A9CC-D0921741CE87'
		   )
-- tasks
INSERT INTO [dbo].[Ziro_Task]([Id]
           ,[Number]
           ,[Type]
           ,[Status]
           ,[Title]
           ,[Description]
           ,[Priority]
           ,[EstimatedTime]
           ,[SpentTime]
           ,[CreationDate]
           ,[LastUpdateDate]
           ,[ProjectId]
           ,[AssigneeId]
           ,[OwnerId])
VALUES('22F09976-6A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			1, --type
			0, --status
           '����������� ������� ���������� ������������',
		   '����������� ������ ���� ������������� �� ����������� � ������� ������������',
		   2, --priority
		   2, --estimated Time
		   1, --spentTime
		   '2019-05-05',
		   '2019-05-05',
		   '15A09976-6A3C-4AF8-A9CC-D0921741CE87', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   'A32F9976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   )

INSERT INTO [dbo].[Ziro_Task] ([Id]
           ,[Number]
           ,[Type]
           ,[Status]
           ,[Title]
           ,[Description]
           ,[Priority]
           ,[EstimatedTime]
           ,[SpentTime]
           ,[CreationDate]
           ,[LastUpdateDate]
           ,[ProjectId]
           ,[AssigneeId]
           ,[OwnerId])
VALUES('A5F39976-6A3C-4AF8-A9CC-D0921741CE87',
			2, --number
			0, --type
			1, --status
           '[�����������������] ��������� ������������������ �������� �������� � ��������������',
		   '- ����������� �������� � ����, 
		   - ����������� ��� �� ���-�������
		   ',
		   1, --priority
		   8, --estimated Time
		   0, --spentTime
		   '2019-05-04',
		   '2019-05-04',
		   '15A09976-6A3C-4AF8-A9CC-D0921741CE87', --project
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   '93A09976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   )

INSERT INTO [dbo].[Ziro_Task]([Id]
           ,[Number]
           ,[Type]
           ,[Status]
           ,[Title]
           ,[Description]
           ,[Priority]
           ,[EstimatedTime]
           ,[SpentTime]
           ,[CreationDate]
           ,[LastUpdateDate]
           ,[ProjectId]
           ,[AssigneeId]
           ,[OwnerId])
VALUES('F8839976-6A3C-4AF8-A9CC-D0921741CE87',
			1, --number
			2, --type
			0, --status
           '[������������] ����������� ��������� ��� ���������',
		   '- ������� ��������, 
		   - ������� �����������
		   - ������� ������������� ����������
		   - ����������� �����-�����������
		   ',
		   3, --priority
		   40, --estimated Time
		   65, --spentTime
		   '2019-05-01',
		   '2019-05-05',
		   '15F09976-6A3C-4AF8-A9CC-D0921741CE87', --project
		   'A32F9976-6A3C-4AF8-A9CC-D0921741CE87', --assignee
		   'A32F9976-6A3C-4AF8-A9CC-D0921741CE87' -- owner
		   )

-- project to users
INSERT INTO [dbo].[Ziro_Project_User]([ProjectId]
           ,[UserId])
VALUES('15A09976-6A3C-4AF8-A9CC-D0921741CE87',
           '93A09976-6A3C-4AF8-A9CC-D0921741CE87')
INSERT INTO [dbo].[Ziro_Project_User]([ProjectId]
           ,[UserId])
VALUES('15A09976-6A3C-4AF8-A9CC-D0921741CE87',
           'F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3')
INSERT INTO [dbo].[Ziro_Project_User]([ProjectId]
           ,[UserId])
VALUES('15A09976-6A3C-4AF8-A9CC-D0921741CE87',
           'A32F9976-6A3C-4AF8-A9CC-D0921741CE87')
INSERT INTO [dbo].[Ziro_Project_User]([ProjectId]
           ,[UserId])
VALUES('15F09976-6A3C-4AF8-A9CC-D0921741CE87',
           'A32F9976-6A3C-4AF8-A9CC-D0921741CE87')