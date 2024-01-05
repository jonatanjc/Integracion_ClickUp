using ClickUp.Repositories;
using System.Collections.Generic;

namespace ClickUp.Services
{
    public class ListService
    {
        public readonly ListRepository _listRepository;

        public ListService(ListRepository listRepository)
        {
            _listRepository = listRepository;
        }


    }
}
