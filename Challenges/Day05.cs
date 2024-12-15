using System.Collections;

namespace Challenges
{
	//    Start:  9:07pm
	// A Solved: 10:15pm
	// B solved: 11:00pm

	public class Day05 : Shared
	{
		private const string ExampleRules = "47|53\r\n97|13\r\n97|61\r\n97|47\r\n75|29\r\n61|13\r\n75|53\r\n29|13\r\n97|29\r\n53|29\r\n61|53\r\n97|53\r\n61|29\r\n47|13\r\n75|47\r\n97|75\r\n47|61\r\n75|61\r\n47|29\r\n75|13\r\n53|13";
		private const string ExampleUpdates = "75,47,61,53,29\r\n97,61,53,29,13\r\n75,29,13\r\n75,97,47,61,53\r\n61,13,29\r\n97,13,75,29,47";
		private const string Rules = "53|62\r\n43|48\r\n43|99\r\n62|76\r\n62|19\r\n62|85\r\n58|55\r\n58|84\r\n58|43\r\n58|64\r\n98|82\r\n98|47\r\n98|73\r\n98|49\r\n98|66\r\n99|97\r\n99|14\r\n99|58\r\n99|57\r\n99|92\r\n99|49\r\n73|84\r\n73|49\r\n73|57\r\n73|87\r\n73|39\r\n73|59\r\n73|35\r\n92|82\r\n92|39\r\n92|83\r\n92|93\r\n92|84\r\n92|31\r\n92|53\r\n92|46\r\n87|36\r\n87|35\r\n87|38\r\n87|82\r\n87|58\r\n87|83\r\n87|11\r\n87|57\r\n87|53\r\n86|91\r\n86|23\r\n86|19\r\n86|16\r\n86|71\r\n86|62\r\n86|47\r\n86|31\r\n86|76\r\n86|97\r\n83|89\r\n83|86\r\n83|93\r\n83|84\r\n83|77\r\n83|64\r\n83|43\r\n83|36\r\n83|98\r\n83|48\r\n83|45\r\n91|76\r\n91|71\r\n91|69\r\n91|49\r\n91|38\r\n91|16\r\n91|14\r\n91|31\r\n91|35\r\n91|47\r\n91|73\r\n91|59\r\n84|61\r\n84|93\r\n84|99\r\n84|23\r\n84|98\r\n84|62\r\n84|66\r\n84|19\r\n84|11\r\n84|86\r\n84|32\r\n84|48\r\n84|43\r\n47|46\r\n47|31\r\n47|27\r\n47|92\r\n47|59\r\n47|39\r\n47|57\r\n47|36\r\n47|35\r\n47|82\r\n47|64\r\n47|84\r\n47|87\r\n47|71\r\n34|53\r\n34|69\r\n34|36\r\n34|92\r\n34|43\r\n34|58\r\n34|49\r\n34|87\r\n34|31\r\n34|39\r\n34|83\r\n34|84\r\n34|82\r\n34|27\r\n34|47\r\n89|23\r\n89|48\r\n89|77\r\n89|91\r\n89|76\r\n89|98\r\n89|51\r\n89|86\r\n89|97\r\n89|61\r\n89|69\r\n89|73\r\n89|16\r\n89|99\r\n89|32\r\n89|47\r\n71|31\r\n71|32\r\n71|45\r\n71|93\r\n71|53\r\n71|57\r\n71|36\r\n71|48\r\n71|27\r\n71|59\r\n71|17\r\n71|35\r\n71|67\r\n71|89\r\n71|11\r\n71|46\r\n71|39\r\n23|39\r\n23|16\r\n23|91\r\n23|87\r\n23|31\r\n23|35\r\n23|47\r\n23|99\r\n23|71\r\n23|59\r\n23|14\r\n23|66\r\n23|92\r\n23|97\r\n23|38\r\n23|76\r\n23|73\r\n23|34\r\n45|16\r\n45|62\r\n45|66\r\n45|97\r\n45|61\r\n45|77\r\n45|34\r\n45|14\r\n45|91\r\n45|51\r\n45|48\r\n45|99\r\n45|86\r\n45|76\r\n45|93\r\n45|47\r\n45|69\r\n45|23\r\n45|85\r\n51|47\r\n51|99\r\n51|49\r\n51|77\r\n51|92\r\n51|39\r\n51|82\r\n51|76\r\n51|87\r\n51|69\r\n51|34\r\n51|62\r\n51|14\r\n51|97\r\n51|71\r\n51|73\r\n51|19\r\n51|85\r\n51|86\r\n51|91\r\n59|51\r\n59|45\r\n59|48\r\n59|36\r\n59|17\r\n59|32\r\n59|58\r\n59|67\r\n59|89\r\n59|55\r\n59|83\r\n59|43\r\n59|64\r\n59|38\r\n59|57\r\n59|27\r\n59|53\r\n59|11\r\n59|93\r\n59|98\r\n59|84\r\n66|47\r\n66|46\r\n66|58\r\n66|59\r\n66|35\r\n66|38\r\n66|57\r\n66|83\r\n66|76\r\n66|36\r\n66|53\r\n66|39\r\n66|71\r\n66|82\r\n66|55\r\n66|31\r\n66|92\r\n66|16\r\n66|49\r\n66|17\r\n66|34\r\n66|73\r\n14|87\r\n14|57\r\n14|83\r\n14|59\r\n14|71\r\n14|31\r\n14|76\r\n14|16\r\n14|82\r\n14|92\r\n14|49\r\n14|35\r\n14|69\r\n14|47\r\n14|39\r\n14|17\r\n14|34\r\n14|66\r\n14|53\r\n14|55\r\n14|97\r\n14|38\r\n14|73\r\n69|53\r\n69|67\r\n69|16\r\n69|39\r\n69|43\r\n69|71\r\n69|31\r\n69|57\r\n69|36\r\n69|38\r\n69|17\r\n69|27\r\n69|83\r\n69|47\r\n69|87\r\n69|92\r\n69|55\r\n69|58\r\n69|82\r\n69|46\r\n69|59\r\n69|49\r\n69|84\r\n69|35\r\n76|83\r\n76|71\r\n76|34\r\n76|55\r\n76|59\r\n76|16\r\n76|92\r\n76|57\r\n76|35\r\n76|87\r\n76|36\r\n76|53\r\n76|47\r\n76|46\r\n76|17\r\n76|82\r\n76|69\r\n76|58\r\n76|31\r\n76|73\r\n76|39\r\n76|38\r\n76|27\r\n76|49\r\n46|45\r\n46|91\r\n46|98\r\n46|62\r\n46|27\r\n46|93\r\n46|23\r\n46|85\r\n46|32\r\n46|77\r\n46|64\r\n46|43\r\n46|86\r\n46|48\r\n46|51\r\n46|99\r\n46|84\r\n46|89\r\n46|14\r\n46|11\r\n46|67\r\n46|61\r\n46|97\r\n46|19\r\n31|84\r\n31|93\r\n31|27\r\n31|98\r\n31|59\r\n31|45\r\n31|67\r\n31|35\r\n31|55\r\n31|11\r\n31|89\r\n31|17\r\n31|36\r\n31|51\r\n31|46\r\n31|32\r\n31|64\r\n31|83\r\n31|53\r\n31|48\r\n31|57\r\n31|43\r\n31|58\r\n31|38\r\n48|87\r\n48|61\r\n48|82\r\n48|92\r\n48|47\r\n48|98\r\n48|34\r\n48|77\r\n48|14\r\n48|69\r\n48|19\r\n48|49\r\n48|99\r\n48|85\r\n48|76\r\n48|73\r\n48|66\r\n48|23\r\n48|91\r\n48|51\r\n48|16\r\n48|62\r\n48|97\r\n48|86\r\n77|73\r\n77|66\r\n77|69\r\n77|91\r\n77|19\r\n77|49\r\n77|76\r\n77|82\r\n77|34\r\n77|14\r\n77|16\r\n77|71\r\n77|92\r\n77|35\r\n77|99\r\n77|85\r\n77|87\r\n77|39\r\n77|31\r\n77|47\r\n77|23\r\n77|61\r\n77|59\r\n77|97\r\n61|19\r\n61|39\r\n61|91\r\n61|31\r\n61|49\r\n61|99\r\n61|71\r\n61|14\r\n61|16\r\n61|35\r\n61|34\r\n61|38\r\n61|87\r\n61|73\r\n61|58\r\n61|47\r\n61|97\r\n61|17\r\n61|69\r\n61|59\r\n61|82\r\n61|76\r\n61|92\r\n61|66\r\n32|51\r\n32|85\r\n32|69\r\n32|97\r\n32|61\r\n32|19\r\n32|23\r\n32|34\r\n32|49\r\n32|62\r\n32|48\r\n32|16\r\n32|98\r\n32|73\r\n32|14\r\n32|66\r\n32|91\r\n32|76\r\n32|77\r\n32|87\r\n32|92\r\n32|99\r\n32|47\r\n32|86\r\n82|57\r\n82|11\r\n82|43\r\n82|39\r\n82|59\r\n82|58\r\n82|35\r\n82|27\r\n82|64\r\n82|36\r\n82|45\r\n82|46\r\n82|38\r\n82|32\r\n82|31\r\n82|17\r\n82|71\r\n82|67\r\n82|93\r\n82|53\r\n82|83\r\n82|55\r\n82|89\r\n82|84\r\n16|67\r\n16|38\r\n16|84\r\n16|83\r\n16|39\r\n16|55\r\n16|53\r\n16|43\r\n16|92\r\n16|64\r\n16|59\r\n16|49\r\n16|58\r\n16|82\r\n16|35\r\n16|46\r\n16|57\r\n16|36\r\n16|27\r\n16|87\r\n16|11\r\n16|71\r\n16|17\r\n16|31\r\n19|97\r\n19|58\r\n19|39\r\n19|49\r\n19|17\r\n19|38\r\n19|31\r\n19|57\r\n19|35\r\n19|47\r\n19|59\r\n19|69\r\n19|66\r\n19|53\r\n19|73\r\n19|76\r\n19|14\r\n19|99\r\n19|82\r\n19|92\r\n19|87\r\n19|71\r\n19|16\r\n19|34\r\n49|64\r\n49|84\r\n49|55\r\n49|83\r\n49|58\r\n49|11\r\n49|38\r\n49|82\r\n49|27\r\n49|57\r\n49|46\r\n49|36\r\n49|67\r\n49|71\r\n49|59\r\n49|35\r\n49|31\r\n49|43\r\n49|17\r\n49|87\r\n49|89\r\n49|92\r\n49|53\r\n49|39\r\n11|51\r\n11|45\r\n11|32\r\n11|89\r\n11|93\r\n11|99\r\n11|62\r\n11|97\r\n11|19\r\n11|86\r\n11|69\r\n11|91\r\n11|48\r\n11|14\r\n11|61\r\n11|77\r\n11|85\r\n11|98\r\n11|76\r\n11|66\r\n11|34\r\n11|73\r\n11|23\r\n11|47\r\n97|71\r\n97|38\r\n97|49\r\n97|66\r\n97|47\r\n97|17\r\n97|92\r\n97|16\r\n97|58\r\n97|87\r\n97|35\r\n97|57\r\n97|34\r\n97|53\r\n97|36\r\n97|83\r\n97|39\r\n97|59\r\n97|31\r\n97|55\r\n97|73\r\n97|69\r\n97|76\r\n97|82\r\n36|77\r\n36|64\r\n36|43\r\n36|91\r\n36|67\r\n36|46\r\n36|62\r\n36|45\r\n36|93\r\n36|11\r\n36|48\r\n36|98\r\n36|19\r\n36|85\r\n36|89\r\n36|51\r\n36|27\r\n36|99\r\n36|86\r\n36|61\r\n36|84\r\n36|23\r\n36|14\r\n36|32\r\n64|19\r\n64|45\r\n64|69\r\n64|66\r\n64|32\r\n64|76\r\n64|51\r\n64|97\r\n64|86\r\n64|14\r\n64|85\r\n64|91\r\n64|73\r\n64|77\r\n64|93\r\n64|99\r\n64|61\r\n64|48\r\n64|89\r\n64|98\r\n64|23\r\n64|34\r\n64|11\r\n64|62\r\n67|48\r\n67|85\r\n67|32\r\n67|62\r\n67|23\r\n67|76\r\n67|99\r\n67|98\r\n67|86\r\n67|45\r\n67|91\r\n67|64\r\n67|11\r\n67|89\r\n67|14\r\n67|51\r\n67|93\r\n67|66\r\n67|73\r\n67|77\r\n67|34\r\n67|19\r\n67|61\r\n67|97\r\n27|91\r\n27|43\r\n27|11\r\n27|45\r\n27|77\r\n27|86\r\n27|97\r\n27|89\r\n27|51\r\n27|19\r\n27|66\r\n27|85\r\n27|62\r\n27|93\r\n27|98\r\n27|99\r\n27|64\r\n27|23\r\n27|32\r\n27|84\r\n27|67\r\n27|61\r\n27|14\r\n27|48\r\n17|48\r\n17|83\r\n17|55\r\n17|84\r\n17|64\r\n17|46\r\n17|51\r\n17|58\r\n17|27\r\n17|57\r\n17|93\r\n17|86\r\n17|62\r\n17|89\r\n17|67\r\n17|11\r\n17|32\r\n17|45\r\n17|77\r\n17|53\r\n17|38\r\n17|36\r\n17|98\r\n17|43\r\n35|51\r\n35|53\r\n35|89\r\n35|86\r\n35|57\r\n35|67\r\n35|98\r\n35|45\r\n35|46\r\n35|32\r\n35|27\r\n35|55\r\n35|11\r\n35|84\r\n35|83\r\n35|59\r\n35|36\r\n35|48\r\n35|38\r\n35|64\r\n35|43\r\n35|17\r\n35|58\r\n35|93\r\n57|61\r\n57|46\r\n57|89\r\n57|36\r\n57|64\r\n57|85\r\n57|11\r\n57|23\r\n57|55\r\n57|93\r\n57|67\r\n57|84\r\n57|48\r\n57|98\r\n57|27\r\n57|83\r\n57|77\r\n57|32\r\n57|62\r\n57|43\r\n57|86\r\n57|91\r\n57|45\r\n57|51\r\n93|51\r\n93|77\r\n93|73\r\n93|69\r\n93|62\r\n93|97\r\n93|61\r\n93|98\r\n93|19\r\n93|99\r\n93|86\r\n93|32\r\n93|23\r\n93|16\r\n93|85\r\n93|49\r\n93|14\r\n93|66\r\n93|47\r\n93|87\r\n93|91\r\n93|34\r\n93|76\r\n93|48\r\n85|91\r\n85|14\r\n85|49\r\n85|34\r\n85|59\r\n85|23\r\n85|92\r\n85|73\r\n85|16\r\n85|71\r\n85|87\r\n85|97\r\n85|35\r\n85|19\r\n85|82\r\n85|69\r\n85|31\r\n85|17\r\n85|66\r\n85|39\r\n85|61\r\n85|99\r\n85|76\r\n85|47\r\n38|77\r\n38|46\r\n38|58\r\n38|67\r\n38|53\r\n38|32\r\n38|89\r\n38|36\r\n38|93\r\n38|11\r\n38|98\r\n38|48\r\n38|27\r\n38|86\r\n38|85\r\n38|57\r\n38|84\r\n38|45\r\n38|64\r\n38|55\r\n38|43\r\n38|83\r\n38|51\r\n38|62\r\n39|17\r\n39|98\r\n39|45\r\n39|48\r\n39|83\r\n39|67\r\n39|36\r\n39|58\r\n39|38\r\n39|43\r\n39|53\r\n39|59\r\n39|32\r\n39|57\r\n39|46\r\n39|55\r\n39|27\r\n39|64\r\n39|35\r\n39|93\r\n39|84\r\n39|31\r\n39|89\r\n39|11\r\n55|23\r\n55|43\r\n55|19\r\n55|27\r\n55|62\r\n55|61\r\n55|99\r\n55|89\r\n55|91\r\n55|77\r\n55|36\r\n55|84\r\n55|98\r\n55|86\r\n55|11\r\n55|48\r\n55|64\r\n55|85\r\n55|45\r\n55|93\r\n55|46\r\n55|67\r\n55|51\r\n55|32\r\n53|86\r\n53|61\r\n53|55\r\n53|11\r\n53|45\r\n53|85\r\n53|93\r\n53|64\r\n53|89\r\n53|67\r\n53|48\r\n53|57\r\n53|98\r\n53|27\r\n53|46\r\n53|77\r\n53|84\r\n53|23\r\n53|51\r\n53|43\r\n53|36\r\n53|32\r\n53|83\r\n43|73\r\n43|93\r\n43|45\r\n43|14\r\n43|64\r\n43|98\r\n43|89\r\n43|77\r\n43|85\r\n43|11\r\n43|32\r\n43|91\r\n43|62\r\n43|19\r\n43|61\r\n43|67\r\n43|97\r\n43|23\r\n43|51\r\n43|76\r\n43|66\r\n43|86\r\n62|92\r\n62|77\r\n62|87\r\n62|61\r\n62|16\r\n62|23\r\n62|49\r\n62|31\r\n62|35\r\n62|71\r\n62|99\r\n62|39\r\n62|34\r\n62|14\r\n62|82\r\n62|97\r\n62|91\r\n62|47\r\n62|73\r\n62|66\r\n62|69\r\n58|46\r\n58|57\r\n58|53\r\n58|23\r\n58|51\r\n58|45\r\n58|86\r\n58|77\r\n58|32\r\n58|62\r\n58|67\r\n58|89\r\n58|93\r\n58|85\r\n58|48\r\n58|11\r\n58|83\r\n58|36\r\n58|27\r\n58|98\r\n98|85\r\n98|19\r\n98|69\r\n98|76\r\n98|61\r\n98|86\r\n98|92\r\n98|97\r\n98|99\r\n98|71\r\n98|91\r\n98|14\r\n98|77\r\n98|34\r\n98|23\r\n98|16\r\n98|62\r\n98|51\r\n98|87\r\n99|83\r\n99|39\r\n99|34\r\n99|17\r\n99|66\r\n99|16\r\n99|31\r\n99|87\r\n99|69\r\n99|53\r\n99|82\r\n99|71\r\n99|35\r\n99|47\r\n99|59\r\n99|76\r\n99|73\r\n99|38\r\n73|53\r\n73|58\r\n73|46\r\n73|16\r\n73|55\r\n73|27\r\n73|82\r\n73|17\r\n73|47\r\n73|69\r\n73|92\r\n73|31\r\n73|83\r\n73|36\r\n73|34\r\n73|71\r\n73|38\r\n92|58\r\n92|57\r\n92|38\r\n92|67\r\n92|59\r\n92|43\r\n92|36\r\n92|45\r\n92|11\r\n92|35\r\n92|17\r\n92|27\r\n92|55\r\n92|64\r\n92|89\r\n92|71\r\n87|45\r\n87|43\r\n87|89\r\n87|59\r\n87|64\r\n87|39\r\n87|27\r\n87|67\r\n87|71\r\n87|46\r\n87|55\r\n87|84\r\n87|31\r\n87|17\r\n87|92\r\n86|39\r\n86|49\r\n86|92\r\n86|69\r\n86|77\r\n86|66\r\n86|82\r\n86|61\r\n86|34\r\n86|87\r\n86|73\r\n86|14\r\n86|85\r\n86|99\r\n83|27\r\n83|55\r\n83|61\r\n83|23\r\n83|62\r\n83|32\r\n83|51\r\n83|67\r\n83|46\r\n83|11\r\n83|91\r\n83|85\r\n83|19\r\n91|53\r\n91|87\r\n91|82\r\n91|19\r\n91|17\r\n91|66\r\n91|92\r\n91|39\r\n91|99\r\n91|34\r\n91|97\r\n91|58\r\n84|97\r\n84|76\r\n84|85\r\n84|89\r\n84|77\r\n84|91\r\n84|64\r\n84|14\r\n84|51\r\n84|45\r\n84|67\r\n47|83\r\n47|67\r\n47|43\r\n47|16\r\n47|53\r\n47|49\r\n47|38\r\n47|58\r\n47|55\r\n47|17\r\n34|16\r\n34|35\r\n34|57\r\n34|46\r\n34|55\r\n34|71\r\n34|17\r\n34|38\r\n34|59\r\n89|85\r\n89|19\r\n89|62\r\n89|14\r\n89|66\r\n89|45\r\n89|34\r\n89|93\r\n71|58\r\n71|38\r\n71|55\r\n71|84\r\n71|64\r\n71|43\r\n71|83\r\n23|19\r\n23|69\r\n23|17\r\n23|82\r\n23|49\r\n23|61\r\n45|98\r\n45|73\r\n45|19\r\n45|49\r\n45|32\r\n51|66\r\n51|23\r\n51|61\r\n51|16\r\n59|86\r\n59|62\r\n59|46\r\n66|69\r\n66|87\r\n14|58";
		private const string Updates = "71,31,35,38,58,83,43,67,11,45,32\r\n32,99,27,62,48,64,46,98,14\r\n53,55,27,11,45,93,32,48,98,51,86\r\n97,76,73,34,69,47,16,49,87,92,71,39,31,35,17,38,53,57,83\r\n59,17,58,55,46,27,84,43,67,64,45,93,32,48,98,51,86\r\n89,91,55,62,98,93,51,45,23,85,83,86,43,32,27,64,67,36,61,46,77\r\n46,67,93,48,51\r\n43,67,64,11,89,32,98,51,86,77,85,23,91,99,97,66,76\r\n83,82,27,59,57,17,92,43,35,71,39,67,31\r\n49,87,92,82,71,31,59,17,57,83,55,46,84,43,11\r\n59,17,58,53,57,83,55,36,84,43,67,11,89,45,93,32,48,51,86\r\n39,31,35,59,38,58,53,57,83,55,36,46,27,84,43,67,64,11,89,45,93,32,48\r\n38,57,83,55,67,32,48,62,77\r\n84,43,67,64,89,45,32,48,51,86,85,61,19,99,66\r\n55,19,98,61,23,32,91\r\n84,43,77,48,86,62,89,53,85,57,98,64,36,93,11,58,55,83,51,27,45,46,67\r\n97,76,73,34,16,49,87,92,71,38,58,83,55\r\n61,32,85,27,19,23,48\r\n19,14,97,76,73,34,69,87,82,71,39,59,38,58,53\r\n61,91,19,14,97,66,76,73,69,47,16,49,87,92,82,71,39,31,35,17,38\r\n69,47,92,82,71,39,31,35,59,17,38,58,53,83,36,46,84\r\n55,98,57,67,38,51,11\r\n31,35,59,17,58,53,83,55,36,46,27,43,67,11,89,45,93,48,98\r\n99,92,73,49,51,91,82,97,71,47,34,76,19,61,77,66,87,86,69\r\n14,97,66,34,16,49,92,82,39,31,35,59,17,38,58,57,83\r\n49,35,59,38,46\r\n59,17,38,93,43,83,89,58,86,11,64,84,32,45,57\r\n19,35,97,85,66,77,49,92,34,91,87\r\n48,47,19,62,97,69,91,85,66,89,76,73,45,61,23\r\n85,23,91,19,99,14,97,66,76,73,34,69,49,92,82,39,31,35,59\r\n73,47,49,87,92,35,17,38,53,83,27\r\n97,14,23,47,49\r\n86,62,85,23,91,76,47,87,71\r\n31,84,87,34,82,35,17,55,46,83,39,58,49,27,47,59,57,16,38,53,71\r\n14,97,73,47,39\r\n48,98,51,86,62,77,85,61,91,99,14,97,76,34,69,47,16,87,92\r\n83,17,16,34,53,82,92,38,76,36,73,58,57,47,71,39,87,59,49,31,55,46,69\r\n66,19,73,92,99,34,47,97,71,87,82,35,49,16,31,53,58,76,59,39,38,14,69\r\n61,91,99,14,76,49,87,92,31,59,38\r\n99,82,19,73,51,16,91,76,97,71,77,86,61,62,66,34,87,23,69\r\n76,69,16,35,17,55,46\r\n83,55,31,93,46,38,36,58,59,89,53,27,43,64,67,84,39,11,57,32,71\r\n34,69,47,92,71,36,46,27,84\r\n45,86,61,43,51,84,89,67,85,64,14,93,27,97,32\r\n38,82,31,58,59,83,14,87,39,35,57,71,16,66,17,47,73\r\n19,84,11,91,64,55,98,61,86\r\n45,93,32,98,51,86,77,23,61,91,99,14,76,73,69,47,16\r\n93,32,48,98,51,62,77,85,23,61,19,99,97,66,76,73,34,16,49\r\n46,43,89,93,32,98,86,85,23\r\n93,48,98,51,62,77,85,91,19,99,97,76,34,69,49\r\n17,38,53,39,59,83,71,34,84,92,35,58,87,36,31,27,47,16,46\r\n62,77,85,69,47\r\n83,86,77,93,67,11,32,64,27,84,36,98,62,23,46,55,45,43,91\r\n55,27,84,64,11,89,45,93,32,98,51,86,62,85,19\r\n84,48,27,64,23,45,51,89,85,86,32,43,98,11,93,67,19,62,99,91,36,77,61\r\n53,57,83,55,46,84,43,67,11,89,93,32,48,98,51,86,62,85,23\r\n47,84,59,82,39,46,16,43,27,69,17,71,38,57,92\r\n82,17,53,57,83,46,84,43,93\r\n47,16,49,87,92,82,39,35,17,38,53,83,55,36,27,43,67\r\n16,49,71,59,38,43,64\r\n55,53,71,38,59,66,83,57,34,16,87,76,82,49,97\r\n45,93,48,98,51,86,62,77,23,61,19,97,66,76,73,34,69,47,16\r\n39,31,35,17,38,58,53,57,55,36,46,43,67,11,93,32,48\r\n87,82,71,39,58,53,57,83,55,36,27,84,67,11,89\r\n38,58,83,36,27,84,43,67,48\r\n32,85,58,51,11,84,48,83,36,64,43,27,46,62,98\r\n16,49,87,92,82,39,35,17,38,58,53,57,83,55,36,46,27,43,64\r\n46,53,57,58,43,83,48,89,77,55,62,64,84\r\n83,58,17,35,36,55,69,71,84,38,43,82,16\r\n11,86,77,23,19\r\n67,64,11,45,93,32,48,51,86,62,77,85,23,61,99,14,66,76,73\r\n58,34,59,76,39,69,19,91,17\r\n39,19,61,47,92,87,76,82,59,23,97,69,35,71,17\r\n55,46,48,89,85,27,11,45,58,57,53\r\n38,58,53,57,83,55,36,46,84,43,67,64,11,89,45,32,48,51,86,62,77\r\n61,19,14,97,76,73,34,69,47,49,87,92,82,71,39,31,59,17,38\r\n97,23,51,99,64,93,76,85,66,77,86,98,45,91,73,48,32,19,67\r\n92,82,71,39,31,35,59,38,53,57,83,55,36,46,27,84,67,64,11,89,45\r\n36,46,27,84,43,67,64,11,89,45,93,32,48,98,51,86,77,85,23,61,91,19,99\r\n76,73,34,69,47,16,49,92,82,71,39,31,35,59,58,53,83,36,46\r\n39,66,53,92,76,82,87,59,38,69,47,31,16,71,19,17,14,49,35,73,99,97,58\r\n11,45,93,48,86,61,91,19,99,14,66,34,69\r\n36,46,84,67,64,11,89,45,32,48,98,51,86,62,85,19,99\r\n98,86,85,19,99,73,34,47,16,49,92\r\n93,32,98,85,19,14,73,47,16\r\n19,99,97,76,69,82,17\r\n17,38,59,92,27,71,36,46,82,84,87,31,39\r\n38,53,27,64,45,93,98\r\n87,84,16,46,35,36,67,57,17,38,71,49,92,31,59,82,55\r\n61,66,76,34,16,39,31,59,38\r\n77,61,91,76,73,34,47,92,82,71,39,31,35\r\n83,55,36,46,27,43,67,64,11,45,93,32,48,98,86,62,77,85,23,61,91\r\n62,23,61,91,19,14,66,16,82,71,31\r\n64,11,89,93,51,86,77,61,19,76,34\r\n32,99,86,62,14\r\n76,66,91,16,49,87,35,58,99,38,92\r\n53,32,27,86,57,45,55,93,11,77,51,48,85,43,36,84,98,64,83,46,67,23,89\r\n71,39,31,35,59,17,38,58,53,57,83,55,46,27,84,43,67,64,11,89,45,93,32\r\n57,55,27,84,64,23,61\r\n99,69,91,71,61,49,97,16,39,73,86,82,62\r\n32,64,43,89,38,58,93,71,11,67,36,27,31,17,39\r\n64,82,49,87,27,38,16\r\n16,49,82,39,59,58,83,55,46,27,84,67,64\r\n17,53,57,84,11,89,32,51,62\r\n39,34,99,87,85,69,61,31,16,49,62,92,71\r\n31,35,59,17,38,58,53,57,83,36,46,27,84,43,67,64,11,89,45,93,32,48,98\r\n16,49,87,92,82,71,39,31,35,59,17,38,58,53,57,83,36,46,27,84,43,67,64\r\n14,97,66,76,73,34,47,49,87,92,39,31,35,59,38,58,53,57,83\r\n89,93,98,86,77,61,91,19,14,97,66,76,34,69,47\r\n84,43,67,64,11,89,32,48,98,51,62,77,85,23,61,91,19,99,14,97,66\r\n85,23,19,97,73,34,69,49,87,92,31,35,59\r\n11,89,93,32,48,23,61,91,19,66,76,73,69\r\n55,27,43,64,11,89,93,32,48,98,62,23,61\r\n51,47,69,45,23,91,77,14,89,66,76,85,99\r\n11,89,93,32,86,23,61,91,19,99,14,97,66,34,69\r\n14,97,66,73,34,69,47,16,49,87,92,82,71,39,31,35,59,17,38,58,57\r\n17,38,58,53,83,55,46,27,84,43,11,93,48,86,62\r\n48,91,77,67,83,32,55,46,61,27,36,45,98,86,89,62,11,43,64\r\n84,43,67,93,48,99,14\r\n66,47,77,49,51,23,99,61,93,19,14,48,62\r\n19,14,97,66,34,69,16,49,87,92,82,71,39,31,35,59,17,58,53\r\n14,69,35,38,61,66,34,91,59,87,47,31,17,82,76,92,97\r\n49,48,62,73,92,69,34\r\n86,77,85,23,61,91,19,14,97,76,73,82,39\r\n91,99,14,66,76,73,34,69,47,16,49,87,92,82,39,31,35,59,17,38,58\r\n45,93,32,48,98,51,86,62,23,99,14,97,66,76,73,34,69,47,16\r\n57,55,87,34,46,39,47,49,69,83,16,31,38,35,92,58,36\r\n43,67,89,93,98,77,85,19,99\r\n32,98,86,23,99,97,66,73,69,49,87\r\n66,76,73,69,47,92,39,35,38,53,57,83,36\r\n46,85,77,64,61,48,98,32,43,45,55,67,51,36,86\r\n23,91,19,14,97,66,73,34,69,47,16,49,87,92,82,71,39,31,35,59,17\r\n58,53,36,46,86\r\n84,49,82,47,16,83,55,27,39,17,69,46,58,38,43,53,59\r\n62,85,61,91,19,99,14,76,34,47,16,92,71\r\n27,84,11,89,93,32,77,91,19\r\n11,82,57,87,64,35,27,92,55,53,89,17,43,71,58,38,83\r\n67,64,11,89,93,32,48,98,51,62,77,85,23,61,19,99,14,97,66,76,73\r\n67,64,11,89,45,93,48,98,51,62,77,85,23,61,91,19,99,14,97,66,76\r\n36,27,84,43,67,11,89,93,32,48,51,77,85,61,91,19,99\r\n39,17,58,53,57,83,55,36,67,93,48\r\n89,45,93,32,48,98,86,62,77,85,23,61,91,19,99,14,97,66,76,73,34,69,47\r\n98,73,91,77,93,32,49\r\n89,93,83,45,36,58,55,46,17\r\n17,38,58,53,57,83,55,36,46,27,84,43,67,11,89,45,93,32,48,98,51,86,62\r\n92,62,14,97,86,51,23,71,76,77,69\r\n89,14,91,86,98,99,93,67,97,43,19,61,76,51,23,32,66\r\n39,31,35,38,58,53,46,27,84,67,64,11,89,45,93,32,48\r\n77,69,97,23,61,51,49,34,91,62,92,16,19,14,98,87,99,76,47,66,86,82,73\r\n84,38,27,17,82,83,49,36,67,71,31,55,46,59,35,53,39\r\n35,59,83,46,84,67,64,11,89,45,32,48,51\r\n69,49,87,92,82,71,39,31,35,59,17,38,58,53,83,55,36,46,27,84,43\r\n17,38,57,87,46,83,67,31,36,53,84,11,27,92,35,59,43,89,55,39,58,82,71\r\n98,62,85,61,97,66,82\r\n17,38,58,46,27,84,64,45,98\r\n23,61,91,99,14,97,66,76,73,34,47,49,87,92,82,71,39,31,35,59,17\r\n64,46,43,53,11,35,98,67,84,32,48,17,27,38,83,59,51,45,57,36,55,58,89\r\n73,76,16,48,49,66,34,86,14,93,91,32,47\r\n58,59,55,82,46,35,93\r\n84,43,67,64,11,89,45,93,32,48,98,51,86,62,85,23,91,19,14\r\n45,93,98,51,86,62,23,61,91,19,99,66,73,34,69,47,16\r\n76,53,39,49,82,31,99,66,73,16,14,58,17,57,97,71,47\r\n89,32,86,77,23,91,19,97,66,76,34\r\n89,45,77,19,99,76,47\r\n76,73,34,47,16,49,87,92,82,71,39,35,17,38,58,53,57,83,55,36,46\r\n61,91,19,99,14,97,66,76,73,34,47,49,87,92,82,71,39,31,35,59,38\r\n36,84,38,67,17,46,11,45,32,93,98,27,59,31,48,89,58,43,83\r\n36,84,43,64,11,89,93,32,98,51,86,62,85,23,61,91,99\r\n89,47,51,86,93,99,48\r\n97,86,98,87,66,34,69,14,48,19,99,23,51,91,92\r\n16,49,87,92,82,71,39,31,35,17,38,58,53,57,83,55,36,46,27,84,43,67,64\r\n59,38,58,53,57,83,55,36,27,84,43,67,64,89,45,93,32,48,98,51,86\r\n53,45,58,36,46,11,59,83,32,43,57,64,38,84,93\r\n92,82,71,39,31,35,17,53,83,55,46,27,84,67,45\r\n85,23,61,91,19,14,97,66,76,73,34,69,16,49,87,82,31,35,59\r\n38,58,36,43,11,93,48\r\n47,49,34,66,14,31,97,62,99\r\n35,17,27,55,49,92,31,87,59,58,47,71,36,84,16,46,34,82,38\r\n11,66,85,14,45,64,98,99,62,91,67,86,48,89,76,97,73,32,77,93,51,61,19\r\n73,71,31,59,57\r\n67,64,11,89,45,32,48,62,91,19,14,97,73\r\n27,67,89,93,48,61,91,99,97\r\n61,97,91,92,35,69,16,47,87,19,66,14,77,71,23,31,34,49,73,99,76,85,82\r\n48,11,53,89,38,35,64,57,39,36,17,45,67\r\n92,87,69,39,99,16,35,58,38,14,71\r\n14,76,34,47,49,82,71,39,31,35,38,53,83\r\n46,49,64,39,38,11,53,55,17,31,59\r\n89,11,27,62,45,67,91,77,99,46,14,86,51\r\n51,87,62,23,49,76,66,77,19,98,14,16,73,61,85,34,91,99,32\r\n49,87,92,82,31,35,59,17,38,57,83,55,27,84,43,67,11\r\n99,91,89,86,76,97,32,19,73,85,64,11,23,98,66,34,77,14,61,51,48,45,62\r\n34,49,69,39,16,23,66,97,77,86,73,87,14,85,62,92,71,47,82\r\n66,76,73,69,47,59,36\r\n27,11,89,32,48,86,77,85,23,19,97\r\n45,93,48,98,51,86,62,77,85,23,61,91,19,99,14,97,66,76,73,34,69,47,16\r\n83,71,39,35,55,59,64,67,93,84,11,45,53,27,58,46,38,36,32,17,43\r\n55,36,27,84,67,64,11,45,93,48,98,51,86,77,23,61,91\r\n14,62,49,97,19\r\n82,83,27,64,84,11,67,93,17,43,31\r\n23,34,86,76,69,61,97\r\n31,17,83,55,36,46,27,67,64,93,32\r\n46,45,48,32,86,67,55,51,59";

		[TestCase(ExampleRules, ExampleUpdates, 143)]
		[TestCase(Rules, Updates, 7307)]
		[Parallelizable]
		public void QuestionA(string qRules, string qUpdates, int expected)
		{
			// Parse the rules and put them into a hashtable
			// Parse the updates
			// Foreach update determine if it is correct
			//	If it is correct, find the middle number and add it to the sum of correct middle numbers

			int sumMiddleNumbers = 0;
			Hashtable rules = ParseRules(qRules);
			List<int[]> updates = ParseUpdates(qUpdates);
			foreach (var update in updates)
			{
				bool valid = IsValidUpdate(rules, update);
				if (valid)
				{
					sumMiddleNumbers += DetermineMiddleNumber(update);
				}
			}

			Console.WriteLine(sumMiddleNumbers);
			Assert.That(sumMiddleNumbers, Is.EqualTo(expected));
		}

		private static Hashtable ParseRules(string ruleSet)
		{
			Hashtable rules = [];

			string[] ruleStrings = ruleSet.Split("\r\n");
			foreach (var ruleString in ruleStrings)
			{
				string[] ruleElements = ruleString.Split("|");
				int element1 = Convert.ToInt32(ruleElements[0]);
				int element2 = Convert.ToInt32(ruleElements[1]);

				AddRule(rules, element1, Ordinality.Before, element2);
				AddRule(rules, element2, Ordinality.After, element1);
			}
			return rules;
		}

		private static void AddRule(Hashtable rules, int key, Ordinality ordinality, int page)
		{
			if (!rules.ContainsKey(key))
			{
				rules.Add(key, new Dictionary<int, Ordinality>());
			}

			Dictionary<int, Ordinality> pageRules = (Dictionary<int, Ordinality>)rules[key];
			if (!pageRules.ContainsKey(page))
			{
				pageRules.Add(page, ordinality);
			}
		}

		private List<int[]> ParseUpdates(string updatesSet)
		{
			List<int[]> updates = [];

			string[] updateStrings = updatesSet.Split("\r\n");
			foreach (var updateString in updateStrings)
			{
				string[] pages = updateString.Split(",");

				int[] pageNumbers = new int[pages.Length];
				for (int i = 0; i < pages.Length; i++)
				{
					int pageNumber = Convert.ToInt32(pages[i]);
					pageNumbers[i] = pageNumber;
				}
				updates.Add(pageNumbers);
			}

			return updates;
		}

		private bool IsValidUpdate(Hashtable rules, int[] update)
		{
			bool isValid = true;

			foreach (var page in update)
			{
				if (rules.ContainsKey(page))
				{
					var pageRules = (Dictionary<int, Ordinality>)rules[page];
					foreach (var key in pageRules.Keys)
					{
						if (update.Contains(key))
						{
							var oridinality = pageRules[key];
							switch (oridinality)
							{
								case Ordinality.Before:
									isValid = IsPageBeforePage(update, page, key);
									break;
								case Ordinality.After:
									isValid = IsPageAfterPage(update, page, key);
									break;
							}

							if (!isValid)
							{
								return false;
							}
						}
					}
				}
			}

			return isValid;
		}

		private static bool IsPageBeforePage(int[] update, int page1, int page2)
		{
			int index1 = update.ToList().IndexOf(page1);
			int index2 = update.ToList().IndexOf(page2);

			return index1 < index2;
		}

		private static bool IsPageAfterPage(int[] update, int page1, int page2)
		{
			int index1 = update.ToList().IndexOf(page1);
			int index2 = update.ToList().IndexOf(page2);

			return index1 > index2;
		}

		private static int DetermineMiddleNumber(int[] update)
		{
			int middleNumber = update[(update.Length / 2) + 1 + ZERO_INDEX_OFFSET];
			return middleNumber;
		}

		[TestCase(ExampleRules, ExampleUpdates, 123)]
		[TestCase(Rules, Updates, 4713)]
		[Parallelizable]
		public void QuestionB(string qRules, string qUpdates, int expected)
		{
			// Parse the rules and put them into a hashtable
			// Parse the updates
			// Foreach update determine if it is correct
			//	If it is not correct, correct it then find the middle number and add it to the sum of corrected middle numbers

			int sumMiddleNumbers = 0;
			Hashtable rules = ParseRules(qRules);
			List<int[]> updates = ParseUpdates(qUpdates);
			foreach (var update in updates)
			{
				bool valid = IsValidUpdate(rules, update);
				if (!valid)
				{
					var correctedUpdate = CorrectUpdate(rules, update);
					sumMiddleNumbers += DetermineMiddleNumber(correctedUpdate);
				}
			}

			Console.WriteLine(sumMiddleNumbers);
			Assert.That(sumMiddleNumbers, Is.EqualTo(expected));
		}

		private static int[] CorrectUpdate(Hashtable rules, int[] update)
		{
			// find the first invalid page and make it valid
			// use recursion on the updated sequence until there are no more updates to make

			bool isValid = true;
			int[] fixedUpdate = [];

			foreach (var page in update)
			{
				if (!isValid)
				{
					break;
				}

				if (rules.ContainsKey(page))
				{
					var pageRules = (Dictionary<int, Ordinality>)rules[page];
					foreach (var key in pageRules.Keys)
					{
						if (update.Contains(key))
						{
							var oridinality = pageRules[key];
							switch (oridinality)
							{
								case Ordinality.Before:
									isValid = IsPageBeforePage(update, page, key);
									break;
								case Ordinality.After:
									isValid = IsPageAfterPage(update, page, key);
									break;
							}

							if (!isValid)
							{
								fixedUpdate = FixUpdatesPage(update, page, pageRules, key);
								break;
							}
						}
					}
				}
			}

			if (!isValid)
			{
				return CorrectUpdate(rules, fixedUpdate);
			}

			return update;
		}

		private static int[] FixUpdatesPage(int[] update, int targetPage, Dictionary<int, Ordinality> pageRules, int relatedPage)
		{
			List<int> fixedUpdate = [];

			bool waitForTargetPage = false;
			bool waitForRelatedPage = false;

			foreach (var page in update)
			{
				if ((page != targetPage) && (page != relatedPage))
				{
					fixedUpdate.Add(page);
				}
				else if (page == targetPage) // by inference, if we hit the target page first, then (A) it is supposed to be after the related page
				{
					if (!waitForRelatedPage && !waitForTargetPage)
					{
						waitForRelatedPage = true; // don't add anything; wait for the relatedPage to appear then enter the two pages in the correct order
					}
					else
					{
						// we first hit the relatedPage page, now we finally hit the target page; add the target page then the related page as per (B)
						fixedUpdate.Add(targetPage);
						fixedUpdate.Add(relatedPage);
					}
				}
				else if (page == relatedPage) // by inference, if we hit the related page first, then (B) it is supposed to be after the target page
				{
					if (!waitForTargetPage && !waitForRelatedPage)
					{
						waitForTargetPage = true; // don't add anything; wait for the target to appear then enter the two pages in the correct order
					}
					else
					{
						// we first hit the target page, now we finally hit the relatedPage page; add the related page then the target page as per (A)
						fixedUpdate.Add(relatedPage);
						fixedUpdate.Add(targetPage);
					}
				}
			}

			return [.. fixedUpdate];
		}
	}
}