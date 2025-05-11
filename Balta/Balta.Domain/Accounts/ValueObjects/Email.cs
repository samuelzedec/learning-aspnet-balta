using System.Text.RegularExpressions;
using Balta.Domain.Accounts.Exceptions;
using Balta.Domain.Shared.ValueObjects;

namespace Balta.Domain.Accounts.ValueObjects;

/* -----------------------------------------------------------------------------------------------------
 * A classe é marcada como partial para permitir que o compilador crie outra parte desta mesma classe.
 * Com o atributo [GeneratedRegex] e o método parcial, o compilador irá automaticamente:
 * 1. Gerar uma implementação otimizada do método EmailRegex()
 * 2. Esta implementação usa o padrão de regex definido na constante Pattern
 * 3. A regex é compilada em tempo de compilação (não em tempo de execução), tornando-a mais eficiente
 * 4. Tudo isso resulta numa validação de email mais performática
 * ----------------------------------------------------------------------------------------------------- */
public sealed partial record Email : ValueObject
{
    #region Constants

    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
    public const int MinLength = 3;
    public const int MaxLength = 160;
    
    #endregion

    #region Constructors

    private Email(string address)
    {
        Address = address;
    }

    #endregion

    #region Factories

    public static Email Create(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new InvalidEmailLengthException("Email address cannot be empty");

        // Remove os espaços do começo e do fim.
        address = address.Trim(); 
        address = address.ToLower();
    
        if (!EmailRegex().IsMatch(address))
            throw new InvalidEmailException("Invalid email format");
    
        return new Email(address);
    }

    #endregion

    #region Properties

    public string Address { get; }

    #endregion

    #region Source Generators

    /* --------------------------------------------------------------------------- 
    * Este método parcial não tem implementação aqui.
    * O compilador gerará automaticamente a implementação otimizada do método
    * em outra parte da classe, durante o processo de compilação.
    * O método gerado usará o padrão de regex definido na constante Pattern.
    * --------------------------------------------------------------------------- */
    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();

    #endregion
}