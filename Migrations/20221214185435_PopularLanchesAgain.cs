using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesJa.Migrations
{
    public partial class PopularLanchesAgain : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("INSERT INTO Lanches(Nome,DescricaoCurta, DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,CategoriaId) VALUES('X-Burguer', 'Delicioso pão de hambúrguer com ovo frito', 'Delicioso pão de hambúrguer com ovo frito, queijo e presunto de primeira qualidade acompanhados de uma ótima batata palha', 12.50, 'https://storage.googleapis.com/grandchef-apps/gc6632/images/products/616481f007bd6.png', 'https://w7.pngwing.com/pngs/378/296/png-transparent-cheeseburger-hamburger-fast-food-buffalo-burger-whopper-x-salada-food-recipe-cheeseburger-thumbnail.png', 0, 1, 1)");
			migrationBuilder.Sql("INSERT INTO Lanches(Nome,DescricaoCurta, DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,CategoriaId) VALUES('X-Salada', 'Delicioso pão de hambúrguer com tomate e salada', 'Delicioso pão de hambúrguer com ovo frito e salada, queijo e presunto de primeira qualidade acompanhados de uma ótima batata palha', 9.50, 'https://storage.googleapis.com/grandchef-apps/gc6632/images/products/616481f007bd6.png', 'https://w7.pngwing.com/pngs/378/296/png-transparent-cheeseburger-hamburger-fast-food-buffalo-burger-whopper-x-salada-food-recipe-cheeseburger-thumbnail.png', 0, 1, 1)");
			migrationBuilder.Sql("INSERT INTO Lanches(Nome,DescricaoCurta, DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,CategoriaId) VALUES('Sanduíche Natural', 'Delicioso sanduíche natural', 'Delicioso pão de primeira qualidade acompanhados de uma ótima salada', 10.00, 'https://storage.googleapis.com/grandchef-apps/gc6632/images/products/616481f007bd6.png', 'https://w7.pngwing.com/pngs/378/296/png-transparent-cheeseburger-hamburger-fast-food-buffalo-burger-whopper-x-salada-food-recipe-cheeseburger-thumbnail.png', 0, 1, 2)");
			migrationBuilder.Sql("INSERT INTO Lanches(Nome,DescricaoCurta, DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,CategoriaId) VALUES('X-Bacon', 'Delicioso pão de hambúrguer com ovo frito e bacon', 'Delicioso pão de hambúrguer com ovo frito, queijo e presunto de primeira qualidade acompanhados de uma ótima batata palha e muito bacon', 14.50, 'https://storage.googleapis.com/grandchef-apps/gc6632/images/products/616481f007bd6.png', 'https://w7.pngwing.com/pngs/378/296/png-transparent-cheeseburger-hamburger-fast-food-buffalo-burger-whopper-x-salada-food-recipe-cheeseburger-thumbnail.png', 0, 1, 1)");

		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DELETE FROM Lanches");
		}
	}
}
