using NUnit.Framework.Internal;

namespace Challenges
{
	public class Day1
	{
		private const string Example = "3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3";
		private const string Data = "87501   76559\r\n70867   16862\r\n12959   38527\r\n56898   81917\r\n80416   13287\r\n28886   54457\r\n79252   30354\r\n47576   88490\r\n43354   37397\r\n89248   74846\r\n39921   24805\r\n98636   51185\r\n33277   31605\r\n45307   13417\r\n33326   72874\r\n14449   42023\r\n64412   40326\r\n12630   40326\r\n35665   41197\r\n35932   59560\r\n22757   76636\r\n97387   91997\r\n83599   74846\r\n33718   54077\r\n20879   65995\r\n42419   35638\r\n50241   41197\r\n94123   27231\r\n82872   65149\r\n41378   85282\r\n81233   65415\r\n98875   21219\r\n21517   81917\r\n36314   65845\r\n64212   43331\r\n94404   34854\r\n42166   87444\r\n13351   12627\r\n53796   47507\r\n19837   28551\r\n59598   71749\r\n47765   93643\r\n11282   91997\r\n71285   69206\r\n27075   56104\r\n11470   50196\r\n75795   17345\r\n77811   85578\r\n56347   74690\r\n54911   35921\r\n26533   96584\r\n75314   58859\r\n49216   30077\r\n94855   14154\r\n10775   91997\r\n58190   81917\r\n38228   85154\r\n88321   21470\r\n99407   38527\r\n39166   13647\r\n22369   96563\r\n61678   29486\r\n94911   64616\r\n99565   66640\r\n64630   86818\r\n60973   22185\r\n83684   27341\r\n44345   22530\r\n43964   11793\r\n13207   62913\r\n20848   30354\r\n43944   38527\r\n48992   38527\r\n44659   10142\r\n93179   96119\r\n80123   86215\r\n46758   75732\r\n34750   18011\r\n38136   92652\r\n25072   58141\r\n99637   96563\r\n42591   32117\r\n48968   60830\r\n68846   15876\r\n63257   19695\r\n20217   69184\r\n50862   86772\r\n35900   31605\r\n61185   10607\r\n41487   98125\r\n29962   81917\r\n44777   73031\r\n40743   25415\r\n57518   13407\r\n89369   36534\r\n36269   31605\r\n59657   27902\r\n72361   51185\r\n71609   15589\r\n76578   19417\r\n35670   18977\r\n99141   95960\r\n30841   55313\r\n91034   30354\r\n70937   81509\r\n65910   12959\r\n62321   74690\r\n39367   79276\r\n39883   23467\r\n15590   54077\r\n70456   26094\r\n21706   97640\r\n91933   26097\r\n88390   65845\r\n24955   91997\r\n87059   71437\r\n33177   86262\r\n57578   84284\r\n24831   21219\r\n19693   74846\r\n87500   20041\r\n88393   50151\r\n18468   69184\r\n61548   69184\r\n75166   74739\r\n80975   52736\r\n54909   58854\r\n85260   61330\r\n86203   15355\r\n75868   81154\r\n57081   81917\r\n44633   41212\r\n53395   92203\r\n38922   84627\r\n45580   22005\r\n11492   12959\r\n13813   23052\r\n77790   31605\r\n97416   41197\r\n60784   40326\r\n91432   12377\r\n64293   74468\r\n53735   54077\r\n11377   23052\r\n35848   57154\r\n29067   57838\r\n14215   61664\r\n72068   30354\r\n23691   58540\r\n17111   28991\r\n66651   12959\r\n35155   25057\r\n76500   74690\r\n59018   78562\r\n51786   64460\r\n12770   80286\r\n41212   53868\r\n85299   46294\r\n58892   21646\r\n46842   31347\r\n80228   82547\r\n21816   41197\r\n63096   69071\r\n55837   74130\r\n13699   99276\r\n88678   23052\r\n17917   65679\r\n42692   28551\r\n42536   90759\r\n29227   74130\r\n44887   47070\r\n14869   96563\r\n62941   87555\r\n96430   52517\r\n92100   96563\r\n69859   65845\r\n78066   55780\r\n71937   80440\r\n79682   46524\r\n90428   37542\r\n17489   76606\r\n12443   48973\r\n92963   12959\r\n13845   39796\r\n27104   19295\r\n84047   92652\r\n17026   54077\r\n16587   14154\r\n38434   61664\r\n96992   78286\r\n60514   74130\r\n76740   31347\r\n77040   71639\r\n57707   69864\r\n18252   74823\r\n50362   92774\r\n87527   54077\r\n18024   62644\r\n16185   99146\r\n15836   31347\r\n71453   22056\r\n81519   20539\r\n92269   41197\r\n89510   98904\r\n64230   65845\r\n44965   69184\r\n97898   50122\r\n33394   71749\r\n51205   31347\r\n29970   91997\r\n18703   38527\r\n95881   85733\r\n78977   65679\r\n44185   42353\r\n59579   79102\r\n98081   88026\r\n75176   28551\r\n23052   25529\r\n23648   86507\r\n68646   65149\r\n81344   94453\r\n89002   23057\r\n91635   92652\r\n83079   54077\r\n19710   96563\r\n55515   31857\r\n94625   45828\r\n95178   40326\r\n43069   41940\r\n32573   48931\r\n28551   28551\r\n71918   31605\r\n64790   25534\r\n70603   80997\r\n98971   60973\r\n26316   45940\r\n56050   47638\r\n70043   86262\r\n89213   96563\r\n19535   86236\r\n75037   86262\r\n56394   30161\r\n10420   38501\r\n97325   34627\r\n79627   38019\r\n90943   64789\r\n89009   65149\r\n41714   74846\r\n56219   30354\r\n67414   33426\r\n70637   91997\r\n65116   68219\r\n65081   92652\r\n30062   28551\r\n53883   74846\r\n82201   35608\r\n30366   36832\r\n92536   34251\r\n41242   23208\r\n28183   95131\r\n95821   20974\r\n70104   53868\r\n92750   81866\r\n19452   31605\r\n63808   40326\r\n48841   74690\r\n78057   28551\r\n18349   23052\r\n49722   69184\r\n47153   92162\r\n87301   17834\r\n62420   60858\r\n77680   46524\r\n27690   17204\r\n59409   92652\r\n42268   28551\r\n63330   17663\r\n36144   77627\r\n31999   23179\r\n63097   44128\r\n32578   30185\r\n37261   39103\r\n75864   10428\r\n49682   64324\r\n19524   86615\r\n21013   57384\r\n28003   14804\r\n69912   23052\r\n56391   16437\r\n55578   63279\r\n66306   38527\r\n50485   97228\r\n17388   69184\r\n68640   51185\r\n34002   69184\r\n53182   74846\r\n26868   30764\r\n54480   21219\r\n78677   30346\r\n63487   49614\r\n96563   41212\r\n63947   86772\r\n95430   19044\r\n66914   70185\r\n17750   12959\r\n44339   31260\r\n91997   85956\r\n19858   81917\r\n39187   14154\r\n31250   11742\r\n81979   11075\r\n43865   93422\r\n41577   12959\r\n59486   26106\r\n84822   67408\r\n83663   28563\r\n53342   88705\r\n88483   31347\r\n26040   64385\r\n59222   22924\r\n28173   52034\r\n47265   12959\r\n98279   23813\r\n74690   53868\r\n50359   17936\r\n24495   97323\r\n67473   74690\r\n31605   86772\r\n47293   69495\r\n78146   54077\r\n62042   74130\r\n22969   81917\r\n86262   41212\r\n20100   14154\r\n31926   51869\r\n83586   20705\r\n78067   87533\r\n15120   80541\r\n60964   74514\r\n25983   86772\r\n22555   85287\r\n82691   41212\r\n33704   54077\r\n60332   65149\r\n88891   54077\r\n11798   54077\r\n33296   95893\r\n21560   71749\r\n72107   23992\r\n99423   16437\r\n74019   53868\r\n11793   31347\r\n24580   57047\r\n29058   41212\r\n13516   65325\r\n45127   65149\r\n78583   68013\r\n47357   26483\r\n74336   54077\r\n73563   89201\r\n48046   22056\r\n99277   40534\r\n51620   22865\r\n26126   50197\r\n39198   46524\r\n99101   38128\r\n53868   57894\r\n60036   79056\r\n98998   14506\r\n33596   49268\r\n96813   97654\r\n63461   51185\r\n44286   31605\r\n32282   65845\r\n40326   21219\r\n31739   99276\r\n86081   64405\r\n17565   11401\r\n98499   52794\r\n54371   51185\r\n64366   91997\r\n22558   44849\r\n80145   80748\r\n55344   30354\r\n82390   78198\r\n67477   52858\r\n41679   65845\r\n26759   61664\r\n25479   24285\r\n84759   94740\r\n23922   31734\r\n69409   32214\r\n16130   14154\r\n17075   41197\r\n26992   88528\r\n75638   14608\r\n40799   31367\r\n70389   65387\r\n48822   91997\r\n82741   65149\r\n53111   75593\r\n96714   91408\r\n61824   98553\r\n80721   68977\r\n14154   26094\r\n65521   21219\r\n62357   65149\r\n17248   33364\r\n62195   96563\r\n31347   69184\r\n21582   96563\r\n67200   15744\r\n32845   70938\r\n69303   16437\r\n43616   94424\r\n70647   32249\r\n37198   29513\r\n56883   86314\r\n55553   74130\r\n44144   29558\r\n93899   31605\r\n94230   96563\r\n92309   65679\r\n69517   91305\r\n30628   21219\r\n14181   15109\r\n86696   59832\r\n92793   79552\r\n26915   12959\r\n32013   99276\r\n81917   11773\r\n85533   91997\r\n10291   57895\r\n47306   86262\r\n40182   86772\r\n78380   96563\r\n14074   31347\r\n29716   51680\r\n34074   69184\r\n83682   79659\r\n32571   81917\r\n24215   65845\r\n14613   30354\r\n86190   46524\r\n22056   77073\r\n47602   77596\r\n40618   22388\r\n61777   69973\r\n83610   86262\r\n41123   74442\r\n14249   55123\r\n49493   94023\r\n42659   94250\r\n38055   92652\r\n49301   72817\r\n92652   96746\r\n96637   41212\r\n63286   53868\r\n64698   19412\r\n48939   65149\r\n77435   42058\r\n86082   97780\r\n56906   31605\r\n18370   69184\r\n55583   96944\r\n10163   99796\r\n57905   99276\r\n62348   28809\r\n84711   81543\r\n14792   31605\r\n27680   69184\r\n90559   55495\r\n56049   23052\r\n30776   23052\r\n25298   89829\r\n72656   86262\r\n74027   34083\r\n79517   31376\r\n70497   36800\r\n67662   65845\r\n71206   47116\r\n14457   17103\r\n79508   31347\r\n69184   24527\r\n18264   85310\r\n16462   81917\r\n48031   53868\r\n85157   82675\r\n12794   67521\r\n56636   69184\r\n63663   23052\r\n83754   12959\r\n90766   27743\r\n48559   15605\r\n95519   43790\r\n24578   14154\r\n13264   29964\r\n72984   53868\r\n23859   27144\r\n52266   14154\r\n74332   27923\r\n40908   37044\r\n45622   65679\r\n97941   41197\r\n29959   72533\r\n75077   76897\r\n43027   69795\r\n75223   54077\r\n46175   41212\r\n60194   78373\r\n63100   51133\r\n41845   19241\r\n33956   85483\r\n71994   81917\r\n32196   30354\r\n26319   55110\r\n52113   38527\r\n45378   17528\r\n29872   15275\r\n45386   92652\r\n50436   51185\r\n59375   77172\r\n29944   96563\r\n80342   40326\r\n10493   16437\r\n97587   64996\r\n59750   65664\r\n88477   53868\r\n95607   53868\r\n81650   60061\r\n89497   21219\r\n60828   69184\r\n18759   41212\r\n25409   86772\r\n42395   73365\r\n42537   71749\r\n23075   15595\r\n33176   92903\r\n61312   77585\r\n49549   16437\r\n13037   30354\r\n22694   27763\r\n55457   40372\r\n41517   74846\r\n62998   69981\r\n33002   81778\r\n19731   50866\r\n37666   72519\r\n44046   80344\r\n16308   34728\r\n39639   35278\r\n52166   58851\r\n18885   51185\r\n52717   16437\r\n54738   51185\r\n30354   23052\r\n71905   83743\r\n53902   53981\r\n49202   45117\r\n29053   53704\r\n73107   93596\r\n10814   81917\r\n47137   81917\r\n14681   46524\r\n23659   19157\r\n41523   19877\r\n37342   74712\r\n14677   35820\r\n80367   30354\r\n29514   68638\r\n92987   44546\r\n53999   13219\r\n53071   12959\r\n18116   30354\r\n41120   21219\r\n24265   13890\r\n74236   12238\r\n16153   40253\r\n29225   16518\r\n77153   69767\r\n11156   15109\r\n17676   72608\r\n97762   69184\r\n14294   74130\r\n20945   53868\r\n89054   69842\r\n50026   92308\r\n11773   35864\r\n43398   46524\r\n81325   76898\r\n72450   94665\r\n73264   14831\r\n11738   45600\r\n47816   33630\r\n96440   38527\r\n49621   26094\r\n99276   86262\r\n83302   66242\r\n44195   82631\r\n72375   19298\r\n62769   30354\r\n24836   41212\r\n54126   12959\r\n56172   53521\r\n40147   84315\r\n15109   48388\r\n36959   44227\r\n72676   50902\r\n29907   57407\r\n17101   59056\r\n27776   92652\r\n33908   38484\r\n31997   41212\r\n60558   60338\r\n76898   29376\r\n66530   12210\r\n55325   74690\r\n14813   81185\r\n65149   86262\r\n64181   42618\r\n13236   75101\r\n85280   25972\r\n23433   27380\r\n76693   28959\r\n27598   65845\r\n85215   16437\r\n69326   31605\r\n73527   54077\r\n83772   50003\r\n13383   90621\r\n74846   86772\r\n76968   51536\r\n67965   99132\r\n75669   71623\r\n11827   13380\r\n65958   99706\r\n27705   54077\r\n29880   83668\r\n64798   37851\r\n15552   20138\r\n81369   86262\r\n16035   13132\r\n19559   34135\r\n58504   41212\r\n53208   96563\r\n72798   44868\r\n63911   54077\r\n73341   86272\r\n57970   81361\r\n34600   40326\r\n32884   85531\r\n71749   49989\r\n16407   39922\r\n48023   47921\r\n55208   38527\r\n87016   88919\r\n61959   71284\r\n14403   20794\r\n61664   74846\r\n84201   12488\r\n73175   16437\r\n75814   65638\r\n91655   98512\r\n33948   23052\r\n80300   69184\r\n70886   76898\r\n41410   65149\r\n78044   16437\r\n32339   58862\r\n16859   18026\r\n10047   30354\r\n23013   31605\r\n37757   22056\r\n28383   39425\r\n88083   23844\r\n91191   21148\r\n21219   53868\r\n68359   54326\r\n36728   81111\r\n83279   55929\r\n30823   72588\r\n94846   60851\r\n45506   40326\r\n33240   21219\r\n65845   61445\r\n45314   95859\r\n94477   91997\r\n41623   91997\r\n18698   81917\r\n26025   96563\r\n67139   28719\r\n70864   20565\r\n63628   86772\r\n82479   12959\r\n56207   23052\r\n18780   68150\r\n61220   53868\r\n94501   47083\r\n58257   10169\r\n16437   38161\r\n89620   44175\r\n74771   46524\r\n99455   32934\r\n77273   91997\r\n20854   40324\r\n43825   74130\r\n89584   41212\r\n86772   87585\r\n16169   40326\r\n23079   91997\r\n20347   12771\r\n33162   53321\r\n77049   61664\r\n52391   11773\r\n98777   19105\r\n86182   77697\r\n84991   76064\r\n46587   14887\r\n13200   76667\r\n76967   65149\r\n56719   38542\r\n77987   41197\r\n74246   78717\r\n68857   23052\r\n92089   65845\r\n79803   44983\r\n16391   86083\r\n85511   82407\r\n14130   31605\r\n20211   65845\r\n51868   35534\r\n11881   17074\r\n43073   87808\r\n74013   95379\r\n63581   91997\r\n67718   75679\r\n95358   38527\r\n78186   12888\r\n35563   61664\r\n63140   92652\r\n11832   54077\r\n11698   58297\r\n22084   11865\r\n98044   64989\r\n26094   35964\r\n45393   92652\r\n38527   93080\r\n66819   46524\r\n31166   52386\r\n39568   79757\r\n94063   77614\r\n16452   83128\r\n24171   91977\r\n74980   12959\r\n47814   38527\r\n71716   45179\r\n34263   14154\r\n43631   53868\r\n47023   99276\r\n56699   27179\r\n13150   41212\r\n65739   46524\r\n87085   60735\r\n67283   21219\r\n23771   32301\r\n65647   55281\r\n50600   45366\r\n88186   54121\r\n48164   86262\r\n34469   21705\r\n76035   97022\r\n91266   69184\r\n55549   65149\r\n34832   38480\r\n72693   74690\r\n66050   65149\r\n50769   63440\r\n34690   91929\r\n58125   37769\r\n16861   65845\r\n26369   65845\r\n31834   74130\r\n24724   76898\r\n35677   46524\r\n79253   16437\r\n29593   31347\r\n29695   51028\r\n18196   96563\r\n33927   74846\r\n24378   16437\r\n37505   47616\r\n70048   31232\r\n27708   53750\r\n14952   92748\r\n37930   53868\r\n41197   28551\r\n77433   38527\r\n77320   54519\r\n37592   82995\r\n73963   65149\r\n67891   66894\r\n71199   71879\r\n13884   73982\r\n97681   33048\r\n44494   21083\r\n56856   62395\r\n56521   48031\r\n11077   40326\r\n98851   49244\r\n19484   46916\r\n51325   19011\r\n74821   65679\r\n90241   78808\r\n24897   60176\r\n40386   30354\r\n66435   10877\r\n17691   88972\r\n17430   96495\r\n76735   57514\r\n23936   46524\r\n86656   86003\r\n81533   46524\r\n23473   14374\r\n44831   17013\r\n73390   53868\r\n20456   38527\r\n47304   43209\r\n95484   26094\r\n40033   92652\r\n49629   65845\r\n11518   94552\r\n99642   28659\r\n46027   38527\r\n93133   99640\r\n88453   69184\r\n52465   87482\r\n65679   96563\r\n51133   86262\r\n82072   24993\r\n65019   81577\r\n73181   20846\r\n25682   74846\r\n89215   23052\r\n75313   28895\r\n59429   99506\r\n95353   98713\r\n14199   71449\r\n28894   21219\r\n34814   77228\r\n12462   81917\r\n77803   10891\r\n54077   25857\r\n56105   87001\r\n49225   91997\r\n33427   23052\r\n28144   53868\r\n44230   74256\r\n64121   38385\r\n44223   94238\r\n91417   28551\r\n27420   43632\r\n49221   41212\r\n37139   31605\r\n65039   36279\r\n40544   97794\r\n70621   62790\r\n89720   12494\r\n93652   70171\r\n99679   77510\r\n48132   65845\r\n27910   63372\r\n61906   54077\r\n79192   88515\r\n52071   15109\r\n68413   40326\r\n38094   65845\r\n85325   22914\r\n34519   60686\r\n18347   62726\r\n74130   86262\r\n22266   70119\r\n24902   79593\r\n58897   53868\r\n67166   94563\r\n86035   54859\r\n32151   51640\r\n19735   28551\r\n86835   65845\r\n48502   69184\r\n98335   65461\r\n85776   61664\r\n31060   41212\r\n51185   25984\r\n10538   61666\r\n89716   70800\r\n93969   46524\r\n87113   41212\r\n94835   43501\r\n31171   61231\r\n63678   83332\r\n27983   36115\r\n31882   66078\r\n69310   21182\r\n57748   69184\r\n34236   61664\r\n22019   53868\r\n40783   74204\r\n11443   65306\r\n61587   74130\r\n32107   20837\r\n42950   75914\r\n30318   28551\r\n71868   21219\r\n11717   29036\r\n15069   54142\r\n46368   23052\r\n19544   53868\r\n96045   10501\r\n70708   90926\r\n66286   14154\r\n93443   46524\r\n22988   52299\r\n59398   87705\r\n54189   79654\r\n44636   47669\r\n34569   12959\r\n75207   88665\r\n57213   81917\r\n17661   76365\r\n76744   41550\r\n18525   81729\r\n44095   89137\r\n47905   69184\r\n64998   70782\r\n94932   14154\r\n79764   85179\r\n94708   22056\r\n97002   11773\r\n65044   71749\r\n81636   90224\r\n67614   31605\r\n69858   12959\r\n37652   86650\r\n59098   35258\r\n26949   46653\r\n19239   21219\r\n46003   58379\r\n77640   55716\r\n92129   51133\r\n46524   60031\r\n11683   44416\r\n72664   86772\r\n80935   81071\r\n12683   86262\r\n47561   41319\r\n97326   32695\r\n91545   31605\r\n50527   99276\r\n78000   61404\r\n58880   14154\r\n47352   89525\r\n64943   54678\r\n34249   12959\r\n90703   52069\r\n42396   21732\r\n17077   72444\r\n40369   16956\r\n17581   39897\r\n18310   46524\r\n93377   20361\r\n21337   41798\r\n31532   65845\r\n63298   78248\r\n39119   46524\r\n53668   38527\r\n50927   96563\r\n57380   47367\r\n68451   16437\r\n96725   28551\r\n49778   86415\r\n46687   12305\r\n93651   84334\r\n17709   46524\r\n36657   38527\r\n67669   20743\r\n18254   55605\r\n99194   12959\r\n51889   29126\r\n11292   35259\r\n39589   74690\r\n14716   54077\r\n71832   67905\r\n54150   55806\r\n36451   46524\r\n14806   96563\r\n63718   74103\r\n58557   95632\r\n98671   95757\r\n48004   65149\r\n20103   21592";

		[TestCase(Example, 11)]
		[TestCase(Data, 936063)]
		public void QuestionA(string data, int expected)
		{
			// split IDs into couplets based upon \r\n
			// foreach couplet, split based upon whitespace and add to list1 and list2
			// sort each list
			// for count of list 1, determine the difference with the item from list2 and add it to list3
			// sum list 3

			List<int> list1 = [];
			List<int> list2 = [];
			List<int> list3 = [];

			string[] couplets = data.Split("\r\n");
			foreach (string couplet in couplets)
			{
				string[] individualValues = couplet.Split(@"   ");
				list1.Add(Convert.ToInt32(individualValues[0]));
				list2.Add(Convert.ToInt32(individualValues[1]));
			}

			list1.Sort();
			list2.Sort();

			for (int i = 0; i < list1.Count; i++)
			{
				int difference = Math.Abs(list2[i] - list1[i]);
				list3.Add(difference);
			}

			var totalDifference = list3.Sum(x => x);

			Console.WriteLine(totalDifference);
			Assert.That(totalDifference, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(Example, 31)]
		[TestCase(Data, 23150395)]
		public void QuestionB(string data, int expected)
		{
			// split IDs into couplets based upon \r\n
			// foreach couplet, split based upon whitespace and add to list1 and list2
			// foreach item in list1, determine how many times it appears in list2
			//	then multiple the list1 value by how mnay times it appears in list2
			//  then add this product to list3
			// sum list 3

			List<int> list1 = [];
			List<int> list2 = [];
			List<int> list3 = [];

			string[] couplets = data.Split("\r\n");
			foreach (string couplet in couplets)
			{
				string[] individualValues = couplet.Split(@"   ");
				list1.Add(Convert.ToInt32(individualValues[0]));
				list2.Add(Convert.ToInt32(individualValues[1]));
			}

			for (int i = 0; i < list1.Count; i++)
			{
				var howMany = list2.Where(x => x == list1[i]);
				var product = list1[i] * howMany.Count();
				list3.Add(product);
			}

			var totalDifference = list3.Sum(x => x);

			Console.WriteLine(totalDifference);
			Assert.That(totalDifference, Is.EqualTo(expected));
		}
	}
}