using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Service.DTOs.Report;

namespace LunchMenu.Service.Interfaces
{
    public interface IReportService
    {
        Task<AllDishesStatsDto> GetMostOrderedDishesAsync();
        Task<AllDishesStatsDailyDto> GetDailyDishReportAsync(DateTime day);
    }
}
