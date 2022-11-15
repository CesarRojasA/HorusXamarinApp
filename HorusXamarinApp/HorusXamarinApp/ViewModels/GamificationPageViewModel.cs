using HorusXamarinApp.Interfaces;
using HorusXamarinApp.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HorusXamarinApp.ViewModels
{
    public class GamificationPageViewModel : ViewModelBase
    {
        #region [Private attributes]
        private readonly IRetoService _retoService;
        private RetoModel retoModel;
        private int contadorRetos;
        private int contadorRetosIncompletos;
        #endregion
        #region [Public attributes]
        public ObservableCollection<RetoModel> AllRetos { get; set; }

        public RetoModel RetoModel
        {
            set { SetProperty(ref retoModel, value); }
            get { return retoModel; }
        }
        public int ContadorRetos
        {
            set { SetProperty(ref contadorRetos, value); }
            get { return contadorRetos; }
        }
        public int ContadorRetosIncompletos
        {
            set { SetProperty(ref contadorRetosIncompletos, value); }
            get { return contadorRetosIncompletos; }
        }
        public string PorcentajeDeAvance { get; set; }
        #endregion

        #region [Constructor]
        public GamificationPageViewModel(INavigationService navigationService, IRetoService retoService) :
            base(navigationService)
        {
            _retoService = retoService;
            AllRetos = new ObservableCollection<RetoModel>();
        }
        #endregion
        #region [Methods]
        public override void Initialize(INavigationParameters parameters)
        {
            try
            {
                _ = GetRetos();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task GetRetos()
        {
            try
            {
                List<RetoModel> retos = await _retoService.getAllRetos();

                if (retos != null)
                {
                    RetoModel = retos.First();
                    foreach (RetoModel item in retos)
                    {
                        AllRetos.Add(item);
                        if (item.PorcentajeDeAvance == "100%")
                            ContadorRetosIncompletos++;
                    }
                    ContadorRetos = AllRetos.Count;
                    _ = AllRetos.Remove(RetoModel);
                    

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);   
            }

        }
        #endregion
    }
}
