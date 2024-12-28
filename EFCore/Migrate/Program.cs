using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

public static class Program 
{
	public static async Task Main(string[] args) 
	{
		/* =============================================================================================
		* Lazy Loading: Quando você marca uma propriedade de navegação como `virtual`, 
		* o Entity Framework Core não carrega os dados relacionados imediatamente. 
		* Ao invés disso, ele **carrega** os dados **somente quando a propriedade for acessada** 
		* pela primeira vez, ou seja, ele executa um segundo SELECT para trazer os dados relacionados.
		* ============================================================================================= */
		
		/*
		 * Eager Loading: só irá trazer subconjuntos quando usarmos o .Include(x => u.Prop);
		 */
		var context = new BlogDataContext();
		
		
		Console.WriteLine("Teste");
	}
}
