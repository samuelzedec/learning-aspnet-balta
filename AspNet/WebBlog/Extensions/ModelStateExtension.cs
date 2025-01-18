using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebBlog.Extensions;

public static class ModelStateExtension
{
    public static List<string> GetErrors(this ModelStateDictionary modelState)
    {
        var result = new List<string>();
        foreach (var model in modelState.Values) 
            result.AddRange(model.Errors.Select(e => e.ErrorMessage));
        
        /* ======================================================
         * .Values(): Guarda as propriedades de erros
         * .Errors(): Guardar as mensagens de error
         * .ErrorMessage: são cada uma das mensagens de error
         * ====================================================== */
        return result;
    }
}