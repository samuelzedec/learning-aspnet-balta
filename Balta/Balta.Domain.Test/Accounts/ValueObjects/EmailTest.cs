using Balta.Domain.Accounts.ValueObjects;

namespace Balta.Domain.Test.Accounts.ValueObjects;

public class EmailTest
{
    /*
     * [Theory]
     * Este atributo indica que o método de teste receberá diferentes conjuntos de dados.
     * Diferente do [Fact], que executa o teste uma única vez sem parâmetros externos,
     * o [Theory] permite executar o mesmo teste múltiplas vezes com dados diferentes.
     * Isso serve para verificar o comportamento do código com diversos valores de entrada,
     * reduzindo a duplicação de código de teste.
     */
    [Theory]
    
    /*
     * Estes atributos fornecem os dados que serão passados para o método de teste.
     * Cada [InlineData] representa uma execução separada do teste.
     *
     * Neste caso:
     * - A primeira execução usará "teste@gmail.com"
     * - A segunda execução usará "teste@hotmail.com"
     * - A terceira execução usará "teste@outlook.com"
     *
     * Os valores são passados na mesma ordem dos parâmetros do método.
     * Se o método tivesse mais parâmetros, cada [InlineData] precisaria
     * fornecer todos os valores correspondentes.
     */
    [InlineData("teste@gmail.com")]
    [InlineData("teste@hotmail.com")]
    [InlineData("teste@outlook.com")]
    public void ShouldCreateAnEmail(string address)
    {
        var email = Email.Create(address);
        Assert.Equal(email.Address, address);
    }
}