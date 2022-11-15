using HorusXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HorusXamarinApp.Interfaces
{
    public interface IRetoService
    {
        Task<List<RetoModel>> getAllRetos();
    }
}
