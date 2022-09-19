using Microsoft.AspNetCore.Mvc;

namespace BattleRap.API.Utilities
{
    public static class Paging
    {
        public const int InitialPage = 1;
        public const int PageMinSize = 10;
        public const int PageMaxSize = 50;

        public static bool IsValid(int page, int pageSize, out ActionResult? actionResult)
        {
            actionResult = null;

            if (page < InitialPage)
                actionResult = new BadRequestObjectResult($"O índice da página não pode ser menor que {InitialPage}.");

            else if (pageSize < PageMinSize)
                actionResult = new BadRequestObjectResult($"O tamanho da página não pode ser menor que {PageMinSize}.");

            else if (pageSize > PageMaxSize)
                actionResult = new BadRequestObjectResult($"O tamanho da página não pode ser maior que {PageMaxSize}.");

            if (actionResult != null)
                return false;

            return true;
        }
    }
}
