using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreMVC.Models.DBModels;

namespace WebCoreMVC.Models
{
    public class SortUsersModel
    {
        public SortState NameSort { get; set; } // значение для сортировки по имени
        public SortState AgeSort { get; set; }    // значение для сортировки по возрасту
        public SortState CompanySort { get; set; }   // значение для сортировки по компании
        public SortState Current { get; set; }     // значение свойства, выбранного для сортировки
        public bool Up { get; set; }  // Сортировка по возрастанию или убыванию

        public SortUsersModel(SortState sortOrder)
        {
            // значения по умолчанию
            NameSort = SortState.NameAsc;
            AgeSort = SortState.AgeAsc;
            CompanySort = SortState.CompanyAsc;
            Up = true;

            if (sortOrder == SortState.AgeDesc || sortOrder == SortState.NameDesc
                || sortOrder == SortState.CompanyDesc)
            {
                Up = false;
            }

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    Current = NameSort = SortState.NameAsc;
                    break;
                case SortState.AgeAsc:
                    Current = AgeSort = SortState.AgeDesc;
                    break;
                case SortState.AgeDesc:
                    Current = AgeSort = SortState.AgeAsc;
                    break;
                case SortState.CompanyAsc:
                    Current = CompanySort = SortState.CompanyDesc;
                    break;
                case SortState.CompanyDesc:
                    Current = CompanySort = SortState.CompanyAsc;
                    break;
                default:
                    Current = NameSort = SortState.NameDesc;
                    break;
            }
        }
    }

    public class SortViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public SortUsersModel SortUsersModel { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
