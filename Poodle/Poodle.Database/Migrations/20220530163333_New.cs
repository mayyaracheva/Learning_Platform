using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poodle.Data.Migrations
{
    public partial class New : Migration
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    { 1, "/Images/DefaultImage.jpg", 1 },
                    { 2, "/Images/DefaultImage.jpg", 2 },
                    { 3, "/Images/DefaultImage.jpg", 3 },
                    { 4, "/Images/DefaultImage.jpg", 4 },
                    { 5, "/Images/DefaultImage.jpg", 5 },
                    { 6, "/Images/DefaultImage.jpg", 6 },
                    { 7, "/Images/DefaultImage.jpg", 7 },
                    { 8, "/Images/DefaultImage.jpg", 8 },
                    { 9, "/Images/DefaultImage.jpg", 9 },
                    { 10, "/Images/DefaultImage.jpg", 10 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Teacher" },
                    { 3, "Student" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "IsDeleted", "ModifiedOn", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The course gives you a broad range of fundamental knowledge for all IT careers. Through a combination of lecture, hands-on labs, and self-study, you will learn how to install, operate, configure, and verify basic IPv4 and IPv6 networks. The course covers configuring network components such as switches, routers, and wireless LAN controllers; managing network devices; and identifying basic security threats. The course also gives you a foundation in network programmability, automation, and software-defined networking.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Implementing and Administering Solutions(CCNA)" },
                    { 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Guided Study Group offers you a 180-day journey of certification preparation. This approach offers a best-of-all-worlds path toward certification, with the flexibility and convenience of e-learning plus the motivation and accountability of working with a live coach. A mix of participants from various backgrounds and skill levels encourages collaboration.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guided Study Group - CyberOps (GSG-CBROPS) 1.0" },
                    { 6, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The course, Mulitcloud Automation and Orchestration with  CloudCenter Suite (CLDAO) v1.0 teaches you how to configure simplified orchestration and workflow automation that provides seamless integration within the Cisco® CloudCenter suite. Through lessons and hands-on experiences, you will learn to use the tools of the CloudCenter Suite to streamline business processes, automate tasks, and increase efficiency in business processes.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Multicloud Automation and Orchestration with CloudCenter Suite (CLDAO) 1.0" },
                    { 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The course shows you how to implement, manage, and troubleshoot  Nexus® 9000 Series Switches in Cisco® NX-OS mode. Through expert instruction and extensive hands-on learning, you will learn how to deploy capabilities including Virtual Extensible LAN (VXLAN), Multiprotocol Label Switching (MPLS), high availability features, Intelligent Traffic Director, troubleshooting tools and techniques, NX-OS programmability features, and open interface technologies.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nexus 9000 Switches in NX-OS Mode" },
                    { 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The course shows you how to deploy and manage the  Nexus® 9000 Series Switches in Cisco Application Centric Infrastructure (Cisco ACI®) mode. You will learn how to configure and manage Cisco Nexus 9000 Series Switches in ACI mode, how to connect the Cisco ACI fabric to external networks and services, and the fundamentals of Virtual Machine Manager (VMM) integration. You will gain hands-on practice implementing key capabilities such as fabric discovery, policies, connectivity, VMM integration, and more.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Implementing Application Centric Infrastructure (DCACI)" },
                    { 8, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Through a combination of lessons and hands-on learning, you will practice operating, managing, and integrating Cisco DNA Center, programmable network infrastructure, and Cisco SD-Access fundamentals. You will learn how Cisco delivers intent-based networking across the campus, branch, WAN, and extended enterprise and ensures that your network is operating as intended.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transforming to a Intent Based Network (IBNTRN) 1.0" },
                    { 9, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In this module, you'll learn how to take advantage of several virtualization services in Azure compute, which can help your applications scale out quickly and efficiently to meet increasing demands.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Microsoft Azure Fundamentals: Describe core Azure services" },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The course shows you how to deploy, secure, operate, and maintain Unified Computing System™ (Cisco UCS®) B-series blade servers, Cisco UCS C-Series, and S-Series rack servers for use in data centers. You will learn how to implement management and orchestration software for Cisco UCS. You will gain hands-on practice: configuring key features of Cisco UCS, Cisco UCS Director, and Cisco UCS Manager; implementing UCS management software including Cisco UCS Manager and Cisco Intersight™; and more.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Configuring Unified Computing System (DCCUCS)" },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The course helps you prepare for DevNet Professional certification and for professional-level network automation engineer roles. You will learn how to implement network applications using Cisco® platforms as a base, from initial software design to diverse system integration, as well as testing and deployment automation. The course gives you hands-on experience solving real world problems using Cisco Application Programming Interfaces (APIs) and modern development tools.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developing Applications Using Core Platforms and APIs (DEVCOR)" },
                    { 10, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create a basic GitHub Action and use that action in a workflow.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Automate development tasks by using GitHub Actions" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "FirstName", "ImageId", "IsDeleted", "LastName", "ModifiedOn", "Password", "RoleId" },
                values: new object[,]
                {
                    { 9, new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7586), "Harriet.Dark@gmail.com", "Harriet", 9, false, "Dark", new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7588), "hardiR789*", 3 },
                    { 1, new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(6151), "Ragnar.Lodbrock@abv.com", "Ragnar", 1, false, "Lodbrock", new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(6665), "adminADMIN123?", 1 },
                    { 2, new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7542), "Jack.Richmond@yahoo.com", "Jack", 2, false, "Richmond", new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7546), "johnJOHN123!", 2 },
                    { 3, new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7550), "Jonathan.Davis@gmail.com", "Jonathan", 3, false, "Davis", new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7551), "jondav123*", 2 },
                    { 4, new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7555), "Ignatio.Italiano@gmail.com", "Ignatio", 4, false, "Italiano", new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7556), "ignitalo123*", 2 },
                    { 5, new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7559), "Reginald.Hargreeves@gmail.com", "Reginald", 5, false, "Hargreeves", new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7560), "jamesonN123*", 3 },
                    { 6, new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7575), "John.Hanes@gmail.com", "John", 6, false, "Hanes", new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7576), "johnsonN123*", 3 },
                    { 7, new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7578), "Horatio.Spanish@gmail.com", "Horatio", 7, false, "Spanish", new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7580), "horspanP123*", 3 },
                    { 8, new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7582), "Herbert.Spencer@gmail.com", "Herbert", 8, false, "Spencer", new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7583), "hurspenM456!", 3 },
                    { 10, new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7592), "Mario.Caruso@gmail.com", "Mario", 10, false, "Caruso", new DateTime(2022, 5, 30, 16, 33, 32, 856, DateTimeKind.Utc).AddTicks(7593), "marrob123!", 3 }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "CreatedOn", "IsDeleted", "ModifiedOn", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exploring the Functions of Networking" },
                    { 22, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introducing DNA Architecture" },
                    { 21, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOC Analyst tools" },
                    { 20, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Defining the Security Operations Center" },
                    { 19, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Identifying Security Concepts" },
                    { 18, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Defining Action Orchestrator User Management and Security Considerations" },
                    { 17, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CloudCenter Suite Architecture" },
                    { 16, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introducing CloudCenter Suite Action Orchestrator" },
                    { 15, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nexus 9000 NX-OS Features" },
                    { 14, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Describing Nexus 9000 Series Hardware" },
                    { 13, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data Center Trends" },
                    { 12, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Understanding of networking protocols, routing, and switching" },
                    { 11, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data center architecture" },
                    { 10, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethernet switching products" },
                    { 30, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Identify the components of GitHub Actions" },
                    { 29, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "How does GitHub Actions automate development tasks?" },
                    { 28, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction" },
                    { 27, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Decide when to use Azure Virtual Machines" },
                    { 26, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overview of Azure compute services" },
                    { 25, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction" },
                    { 9, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Describing Cisco UCS Policies for Service Profiles" },
                    { 8, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Implementing External Authentication Providers" },
                    { 7, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Implementing Cisco UCS Storage Area Network (SAN)" },
                    { 6, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Describing Advanced REST API Integration" },
                    { 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Designing for Serviceability" },
                    { 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Designing for Maintainability" },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operating Cisco IOS Software" },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introducing the Host-to-Host Communications Model" },
                    { 23, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deploy Wired Fabric Networks with DNA Center" },
                    { 24, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deploy Brownfield and Fabric Wireless Network with DNA Center" }
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
