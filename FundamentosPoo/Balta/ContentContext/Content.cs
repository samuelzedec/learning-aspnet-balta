using Balta.SharedContext;
namespace Balta.ContentContext;

public abstract class Content : Base
{
    /* -------------------------------------------------------------------------------------------------------
     * Ao usar o “abstract”, estamos a indicar que essa classe não pode ser instanciada diretamente.
     * Ela serve como base para outras classes e pode conter métodos abstratos que precisam ser implementados
     * nas classes derivadas.
     * -------------------------------------------------------------------------------------------------------
     */
    protected Content(string title, string url)
    {
        Title = title;
        Url = url;
    }
    public string Title { get; set; }
    public string Url { get; set; }
}
