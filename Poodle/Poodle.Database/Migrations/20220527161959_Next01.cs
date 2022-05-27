using Microsoft.EntityFrameworkCore.Migrations;

namespace Poodle.Data.Migrations
{
    public partial class Next01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Implementing and Administering Solutions(CCNA)");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The course helps you prepare for DevNet Professional certification and for professional-level network automation engineer roles. You will learn how to implement network applications using Cisco® platforms as a base, from initial software design to diverse system integration, as well as testing and deployment automation. The course gives you hands-on experience solving real world problems using Cisco Application Programming Interfaces (APIs) and modern development tools.", "Developing Applications Using Core Platforms and APIs (DEVCOR)" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The course shows you how to deploy, secure, operate, and maintain Unified Computing System™ (Cisco UCS®) B-series blade servers, Cisco UCS C-Series, and S-Series rack servers for use in data centers. You will learn how to implement management and orchestration software for Cisco UCS. You will gain hands-on practice: configuring key features of Cisco UCS, Cisco UCS Director, and Cisco UCS Manager; implementing UCS management software including Cisco UCS Manager and Cisco Intersight™; and more.", "Configuring Unified Computing System (DCCUCS)" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The course shows you how to deploy and manage the  Nexus® 9000 Series Switches in Cisco Application Centric Infrastructure (Cisco ACI®) mode. You will learn how to configure and manage Cisco Nexus 9000 Series Switches in ACI mode, how to connect the Cisco ACI fabric to external networks and services, and the fundamentals of Virtual Machine Manager (VMM) integration. You will gain hands-on practice implementing key capabilities such as fabric discovery, policies, connectivity, VMM integration, and more.", "Implementing Application Centric Infrastructure (DCACI)" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The course shows you how to implement, manage, and troubleshoot  Nexus® 9000 Series Switches in Cisco® NX-OS mode. Through expert instruction and extensive hands-on learning, you will learn how to deploy capabilities including Virtual Extensible LAN (VXLAN), Multiprotocol Label Switching (MPLS), high availability features, Intelligent Traffic Director, troubleshooting tools and techniques, NX-OS programmability features, and open interface technologies.", "Nexus 9000 Switches in NX-OS Mode" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Title" },
                values: new object[,]
                {
                    { 6, 2, "The course, Mulitcloud Automation and Orchestration with  CloudCenter Suite (CLDAO) v1.0 teaches you how to configure simplified orchestration and workflow automation that provides seamless integration within the Cisco® CloudCenter suite. Through lessons and hands-on experiences, you will learn to use the tools of the CloudCenter Suite to streamline business processes, automate tasks, and increase efficiency in business processes.", "Multicloud Automation and Orchestration with CloudCenter Suite (CLDAO) 1.0" },
                    { 7, 2, "A Guided Study Group offers you a 180-day journey of certification preparation. This approach offers a best-of-all-worlds path toward certification, with the flexibility and convenience of e-learning plus the motivation and accountability of working with a live coach. A mix of participants from various backgrounds and skill levels encourages collaboration.", "Guided Study Group - CyberOps (GSG-CBROPS) 1.0" },
                    { 8, 2, "Through a combination of lessons and hands-on learning, you will practice operating, managing, and integrating Cisco DNA Center, programmable network infrastructure, and Cisco SD-Access fundamentals. You will learn how Cisco delivers intent-based networking across the campus, branch, WAN, and extended enterprise and ensures that your network is operating as intended.", "Transforming to a Intent Based Network (IBNTRN) 1.0" },
                    { 9, 1, "In this module, you'll learn how to take advantage of several virtualization services in Azure compute, which can help your applications scale out quickly and efficiently to meet increasing demands.", "Microsoft Azure Fundamentals: Describe core Azure services" },
                    { 10, 1, "Create a basic GitHub Action and use that action in a workflow.", "Automate development tasks by using GitHub Actions" }
                });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 14,
                column: "Title",
                value: "Describing Nexus 9000 Series Hardware");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 15,
                column: "Title",
                value: "Nexus 9000 NX-OS Features");

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "Title" },
                values: new object[,]
                {
                    { 16, 6, "Introducing CloudCenter Suite Action Orchestrator" },
                    { 17, 6, "CloudCenter Suite Architecture" },
                    { 18, 6, "Defining Action Orchestrator User Management and Security Considerations" },
                    { 19, 7, "Identifying Security Concepts" },
                    { 20, 7, "Defining the Security Operations Center" },
                    { 21, 7, "SOC Analyst tools" },
                    { 22, 8, "Introducing DNA Architecture" },
                    { 23, 8, "Deploy Wired Fabric Networks with DNA Center" },
                    { 24, 8, "Deploy Brownfield and Fabric Wireless Network with DNA Center" },
                    { 25, 9, "Introduction" },
                    { 26, 9, "Overview of Azure compute services" },
                    { 27, 9, "Decide when to use Azure Virtual Machines" },
                    { 28, 10, "Introduction" },
                    { 29, 10, "How does GitHub Actions automate development tasks?" },
                    { 30, 10, "Identify the components of GitHub Actions" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Implementing and Administering Cisco Solutions(CCNA)");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The course helps you prepare for Cisco DevNet Professional certification and for professional-level network automation engineer roles. You will learn how to implement network applications using Cisco® platforms as a base, from initial software design to diverse system integration, as well as testing and deployment automation. The course gives you hands-on experience solving real world problems using Cisco Application Programming Interfaces (APIs) and modern development tools.", "Developing Applications Using Cisco Core Platforms and APIs (DEVCOR)" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The course shows you how to deploy, secure, operate, and maintain Cisco Unified Computing System™ (Cisco UCS®) B-series blade servers, Cisco UCS C-Series, and S-Series rack servers for use in data centers. You will learn how to implement management and orchestration software for Cisco UCS. You will gain hands-on practice: configuring key features of Cisco UCS, Cisco UCS Director, and Cisco UCS Manager; implementing UCS management software including Cisco UCS Manager and Cisco Intersight™; and more.", "Configuring Cisco Unified Computing System (DCCUCS)" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The course shows you how to deploy and manage the Cisco® Nexus® 9000 Series Switches in Cisco Application Centric Infrastructure (Cisco ACI®) mode. You will learn how to configure and manage Cisco Nexus 9000 Series Switches in ACI mode, how to connect the Cisco ACI fabric to external networks and services, and the fundamentals of Virtual Machine Manager (VMM) integration. You will gain hands-on practice implementing key capabilities such as fabric discovery, policies, connectivity, VMM integration, and more.", "Implementing Cisco Application Centric Infrastructure (DCACI)" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The course shows you how to implement, manage, and troubleshoot Cisco Nexus® 9000 Series Switches in Cisco® NX-OS mode. Through expert instruction and extensive hands-on learning, you will learn how to deploy capabilities including Virtual Extensible LAN (VXLAN), Multiprotocol Label Switching (MPLS), high availability features, Intelligent Traffic Director, troubleshooting tools and techniques, NX-OS programmability features, and open interface technologies.", "Cisco Nexus 9000 Switches in NX-OS Mode" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 14,
                column: "Title",
                value: "Describing Cisco Nexus 9000 Series Hardware");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 15,
                column: "Title",
                value: "Cisco Nexus 9000 NX-OS Features");
        }
    }
}
