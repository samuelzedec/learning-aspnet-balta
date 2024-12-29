using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

public static class Program
{
	public static async Task Main(string[] args)
	{
		var context = new BlogDataContext();
		Console.WriteLine("Teste");
	}

}
