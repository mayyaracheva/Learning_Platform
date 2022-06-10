using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poodle.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRestricted = table.Column<bool>(type: "bit", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseUser",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUser", x => new { x.CoursesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CourseUser_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Public" },
                    { 2, "Private" },
                    { 3, "Restricted" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageUrl", "UserId" },
                values: new object[,]
                {
                    { 1, "/img/DefaultImage.jpg", 1 },
                    { 2, "/img/DefaultImage.jpg", 2 },
                    { 3, "/img/DefaultImage.jpg", 3 },
                    { 4, "/img/DefaultImage.jpg", 4 },
                    { 5, "/img/DefaultImage.jpg", 5 },
                    { 6, "/img/DefaultImage.jpg", 6 },
                    { 7, "/img/DefaultImage.jpg", 7 },
                    { 8, "/img/DefaultImage.jpg", 8 },
                    { 9, "/img/DefaultImage.jpg", 9 },
                    { 10, "/img/DefaultImage.jpg", 10 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Teacher" },
                    { 2, "Student" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "IsDeleted", "ModifiedOn", "PhotoURL", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2705), "The course gives you a broad range of fundamental knowledge for all IT careers. Through a combination of lecture, hands-on labs, and self-study, you will learn how to install, operate, configure, and verify basic IPv4 and IPv6 networks. The course covers configuring network components such as switches, routers, and wireless LAN controllers; managing network devices; and identifying basic security threats. The course also gives you a foundation in network programmability, automation, and software-defined networking.", false, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2729), "img/course-1.jpg", "Implementing and Administering Solutions(CCNA)" },
                    { 7, 2, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2860), "A Guided Study Group offers you a 180-day journey of certification preparation. This approach offers a best-of-all-worlds path toward certification, with the flexibility and convenience of e-learning plus the motivation and accountability of working with a live coach. A mix of participants from various backgrounds and skill levels encourages collaboration.", false, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2862), "img/course-7.jpg", "Guided Study Group - CyberOps (GSG-CBROPS) 1.0" },
                    { 6, 2, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2854), "The course, Mulitcloud Automation and Orchestration with  CloudCenter Suite (CLDAO) v1.0 teaches you how to configure simplified orchestration and workflow automation that provides seamless integration within the Cisco® CloudCenter suite. Through lessons and hands-on experiences, you will learn to use the tools of the CloudCenter Suite to streamline business processes, automate tasks, and increase efficiency in business processes.", false, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2856), "img/course-6.jpg", "Multicloud Automation and Orchestration with CloudCenter Suite (CLDAO) 1.0" },
                    { 5, 2, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2833), "The course shows you how to implement, manage, and troubleshoot  Nexus® 9000 Series Switches in Cisco® NX-OS mode. Through expert instruction and extensive hands-on learning, you will learn how to deploy capabilities including Virtual Extensible LAN (VXLAN), Multiprotocol Label Switching (MPLS), high availability features, Intelligent Traffic Director, troubleshooting tools and techniques, NX-OS programmability features, and open interface technologies.", false, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2836), "img/course-5.jpg", "Nexus 9000 Switches in NX-OS Mode" },
                    { 10, 1, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2884), "Create a basic GitHub Action and use that action in a workflow.", false, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2887), "img/course-10.jpg", "Automate development tasks by using GitHub Actions" },
                    { 8, 2, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2866), "Through a combination of lessons and hands-on learning, you will practice operating, managing, and integrating Cisco DNA Center, programmable network infrastructure, and Cisco SD-Access fundamentals. You will learn how Cisco delivers intent-based networking across the campus, branch, WAN, and extended enterprise and ensures that your network is operating as intended.", false, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2868), "img/course-8.jpg", "Transforming to a Intent Based Network (IBNTRN) 1.0" },
                    { 4, 1, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2827), "The course shows you how to deploy and manage the  Nexus® 9000 Series Switches in Cisco Application Centric Infrastructure (Cisco ACI®) mode. You will learn how to configure and manage Cisco Nexus 9000 Series Switches in ACI mode, how to connect the Cisco ACI fabric to external networks and services, and the fundamentals of Virtual Machine Manager (VMM) integration. You will gain hands-on practice implementing key capabilities such as fabric discovery, policies, connectivity, VMM integration, and more.", false, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2829), "img/course-4.jpg", "Implementing Application Centric Infrastructure (DCACI)" },
                    { 3, 1, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2820), "The course shows you how to deploy, secure, operate, and maintain Unified Computing System™ (Cisco UCS®) B-series blade servers, Cisco UCS C-Series, and S-Series rack servers for use in data centers. You will learn how to implement management and orchestration software for Cisco UCS. You will gain hands-on practice: configuring key features of Cisco UCS, Cisco UCS Director, and Cisco UCS Manager; implementing UCS management software including Cisco UCS Manager and Cisco Intersight™; and more.", false, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2822), "img/course-3.jpg", "Configuring Unified Computing System (DCCUCS)" },
                    { 2, 1, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2810), "The course helps you prepare for DevNet Professional certification and for professional-level network automation engineer roles. You will learn how to implement network applications using Cisco® platforms as a base, from initial software design to diverse system integration, as well as testing and deployment automation. The course gives you hands-on experience solving real world problems using Cisco Application Programming Interfaces (APIs) and modern development tools.", false, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2813), "img/course-2.jpg", "Developing Applications Using Core Platforms and APIs (DEVCOR)" },
                    { 9, 1, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2873), "In this module, you'll learn how to take advantage of several virtualization services in Azure compute, which can help your applications scale out quickly and efficiently to meet increasing demands.", false, new DateTime(2022, 6, 10, 7, 31, 32, 98, DateTimeKind.Utc).AddTicks(2876), "img/course-9.jpg", "Microsoft Azure Fundamentals: Describe core Azure services" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "FirstName", "ImageId", "IsDeleted", "LastName", "ModifiedOn", "Password", "RoleId" },
                values: new object[,]
                {
                    { 9, new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9836), "Harriet.Dark@gmail.com", "Harriet", 9, false, "Dark", new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9838), "hardiR789*", 2 },
                    { 1, new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(6125), "Ragnar.Lodbrock@abv.com", "Ragnar", 1, false, "Lodbrock", new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(7629), "adminADMIN123?", 1 },
                    { 2, new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9762), "Jack.Richmond@yahoo.com", "Jack", 2, false, "Richmond", new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9771), "johnJOHN123!", 1 },
                    { 3, new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9778), "Jonathan.Davis@gmail.com", "Jonathan", 3, false, "Davis", new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9780), "jondav123*", 2 },
                    { 4, new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9785), "Ignatio.Italiano@gmail.com", "Ignatio", 4, false, "Italiano", new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9787), "ignitalo123*", 2 },
                    { 5, new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9792), "Reginald.Hargreeves@gmail.com", "Reginald", 5, false, "Hargreeves", new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9794), "jamesonN123*", 2 },
                    { 6, new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9816), "John.Hanes@gmail.com", "John", 6, false, "Hanes", new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9818), "johnsonN123*", 2 },
                    { 7, new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9823), "Horatio.Spanish@gmail.com", "Horatio", 7, false, "Spanish", new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9825), "horspanP123*", 2 },
                    { 8, new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9830), "Herbert.Spencer@gmail.com", "Herbert", 8, false, "Spencer", new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9832), "hurspenM456!", 2 },
                    { 10, new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9847), "Mario.Caruso@gmail.com", "Mario", 10, false, "Caruso", new DateTime(2022, 6, 10, 7, 31, 32, 94, DateTimeKind.Utc).AddTicks(9850), "marrob123!", 2 }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Content", "CourseId", "CreatedOn", "IsDeleted", "IsRestricted", "ModifiedOn", "Rank", "Title" },
                values: new object[,]
                {
                    { 1, "testTest", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Exploring the Functions of Networking" },
                    { 22, "testTest", 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Introducing DNA Architecture" },
                    { 21, "testTest", 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "SOC Analyst tools" },
                    { 20, "testTest", 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Defining the Security Operations Center" },
                    { 19, "testTest", 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Identifying Security Concepts" },
                    { 18, "testTest", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Defining Action Orchestrator User Management and Security Considerations" },
                    { 17, "testTest", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "CloudCenter Suite Architecture" },
                    { 16, "testTest", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Introducing CloudCenter Suite Action Orchestrator" },
                    { 15, "testTest", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Nexus 9000 NX-OS Features" },
                    { 14, "testTest", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Describing Nexus 9000 Series Hardware" },
                    { 13, "testTest", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Data Center Trends" },
                    { 30, "testTest", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Identify the components of GitHub Actions" },
                    { 29, "testTest", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "How does GitHub Actions automate development tasks?" },
                    { 28, "testTest", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Introduction" },
                    { 27, "testTest", 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Decide when to use Azure Virtual Machines" },
                    { 26, "testTest", 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Overview of Azure compute services" },
                    { 25, "testTest", 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Introduction" },
                    { 12, "testTest", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Understanding of networking protocols, routing, and switching" },
                    { 11, "testTest", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Data center architecture" },
                    { 10, "testTest", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ethernet switching products" },
                    { 9, "testTest", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Describing Cisco UCS Policies for Service Profiles" },
                    { 8, "testTest", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Implementing External Authentication Providers" },
                    { 7, "testTest", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Implementing Cisco UCS Storage Area Network (SAN)" },
                    { 6, "testTest", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Describing Advanced REST API Integration" },
                    { 5, "testTest", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Designing for Serviceability" },
                    { 4, "testTest", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Designing for Maintainability" },
                    { 3, "testTest", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Operating Cisco IOS Software" },
                    { 2, "testTest", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Introducing the Host-to-Host Communications Model" },
                    { 23, "testTest", 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Deploy Wired Fabric Networks with DNA Center" },
                    { 24, "testTest", 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Deploy Brownfield and Fabric Wireless Network with DNA Center" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Title",
                table: "Courses",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_UsersId",
                table: "CourseUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ImageId",
                table: "Users",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseUser");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
