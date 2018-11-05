using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewsSite.Migrations
{
    public partial class EverythingShouldBeFineMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Descrip = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Primarch" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "God" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CategoryId", "Content", "Descrip", "Image", "Name" },
                values: new object[] { 1, 1, "Mortarion is a rather tragic character. He was tricked into service of The Ruinous Powers by his brother-primarch, Horus, into believing The Emperor of Mankind, their father, was using the same chaos powers the Primarchs were warned against. He was deceived so completely that Mortarion was convinced The Emperor of Mankind was a warp-tainted aberration. It's poetic that it is now Mortarion and his fellow traitor-primarch brothers who are the warp-tainted aberrations. Despite Mortarion being wholly evil now he is still my favorite character within the Warhammer 40,000 universe.", "Mortarion (also known as the Death Lord) was one of the original twenty Primarchs. He was given command of the Death Guard Legion on the arrival of the Emperor to his world of Barbarus but turned to the forces of Chaos during the Horus Heresy. Now he glides above countless battlefields on tainted wings, spreading plagues as gifts from his Chaos Lord, Nurgle", "/Images/Mortarion.png", "Mortarion" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CategoryId", "Content", "Descrip", "Image", "Name" },
                values: new object[] { 2, 1, "Roboute Guilliman is a great character if not a bit reliant on the trope of being without flaws. If not for Horus, I believe Roboute would be The Emperor's favored son given how natural he is at building, maintaining, and leading an empire. After the Horus heresy Roboute Guilliman assumed the role of leader for the Imperium of Mankind to maintain stability after the Emperor had fallen at the hands of Horus. Roboute, despite his flawless trope, is still a great character who espouses many great and noble virtues which contrast with the overall grimdark theme of Warhammer 40,000.", "Roboute Guilliman, known as The Avenging Son following the Battle of Calth, is the Primarch of the Ultramarines. An accomplished warlord and diplomat who ruled his own empire before rediscovery by the Emperor, Guilliman was unique among his brother Primarchs in that he saw himself as not only a warrior but also a builder of civilizations.", "/Images/Roboute.png", "Roboute" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CategoryId", "Content", "Descrip", "Image", "Name" },
                values: new object[] { 3, 2, "The Emperor of Mankind does not have a name, only a title. He is the perfect, omnipotent being who would have conquered the entire galaxy were it not for his favored son, Horus Lupercal, betraying humanity by siding with The Ruinous Powers, corrupting 8 of his primarch brothers, and invading Holy Terra(Earth) with hordes of demons. He was outrageously powerful and charismatic which takes the trope of flawlessness and turns it to 11....thousand. However, no king lasts forever, and it turns out the only one who can prove to be the undoing of the Emperor of Mankind is himself. His own creations turned against him and now he is nothing but a corpse interred on a golden throne who is kept alive by siphoning the power from hundreds of thousands of psychically powerful humans (psykers) every single day, these psykers do not survive this process.", "The Emperor of Mankind is the sovereign of the Imperium of Man, and Father, Guardian, and God of the human race. He has sat immobile within the Golden Throne of Terra for ten thousand years. Although once a living man, his shattered body can no longer support life, and remains intact only by a combination of ancient technology and the sheer force of his will, itself sustained by the soul-sacrifice of countless millions of psykers.", "/Images/EmperorOfMankind.png", "Emperor of Mankind" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CategoryId",
                table: "Reviews",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
