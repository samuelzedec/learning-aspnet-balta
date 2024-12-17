namespace Balta.ContentContext;

public class Career : Content
{
    /**
     * -----------------------------------------------------------------------------------------------
     * O 'readonly' é usado para garantir que um campo seja imutável, ou seja,
     * ele só pode ser atribuído uma vez, seja durante a declaração ou no construtor,
     * e o seu valor não pode ser modificado após a inicialização, tanto dentro quanto fora da classe.
     *
     * Por outro lado, o 'required' é usado para garantir que uma propriedade seja
     * obrigatoriamente inicializada quando o objeto for criado, ou seja, o valor
     * precisa ser fornecido no momento da criação do objeto.
     *
     * Quando usamos 'required' com 'init', conseguimos um comportamento semelhante
     * ao do 'readonly' para propriedades. Isso porque o 'init' permite que a propriedade
     * seja inicializada apenas durante a criação do objeto, tornando-a imutável após esse ponto,
     * assim como o 'readonly' faz para campos. Ou seja, a combinação de 'required' com 'init'
     * garante que o valor seja fornecido e não alterado após a criação do objeto.
     * -----------------------------------------------------------------------------------------------
     */
    public Career(string title, string url) 
        : base(title, url)
    {
        Items = new List<CareerItem>();
    }
    public IList<CareerItem> Items { get; set; }

    public int TotalCourses => Items.Count; 
    /*
     * Nome dessa syntax: Expression Body
     * Podemos usar uma propriedade dessa forma quando so temos o get e só uma linha de código
     */

}