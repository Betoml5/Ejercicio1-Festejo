using Ejercicio1_Festejo.CRUD;
using Ejercicio1_Festejo.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ejercicio1_Festejo.ViewModels
{
    public class MenoresViewModel : INotifyPropertyChanged
    {
        MenoresCRUD crud = new();
        public ObservableCollection<Menor> Menores { get; set; } = new();
        public List<Vwcumplenhoy> CumplenHoyLista { get; set; } = new();
        public List<Vwcumplenmes> CumplenMesLista { get; set; } = new();
        public List<Vwmenoresdoce> MenoresDoceLista { get; set; } = new();
        public List<DatosMenoresPorAño> MenoresPorAñoLista { get; set; } = new();

        public List<DatosMenoresDiciembre> MenoresCumplenDiciembreLista { get; set; } = new();

        public string Vista { get; set; } = "verMenores";

        public ICommand ObtenerCumplenHoyCommand { get; set; }
        public ICommand ObtenerCumplenMesCommand { get; set; }

        public ICommand ObtenerMenoresDoceCommand { get; set; }
        public ICommand ObtenerMenoresPorAñoCommand{ get; set; }

        public ICommand ObtenerMenoresDiciembreCommand { get; set; }

        public ICommand CambiarVistaCommand { get; set; }

        
        public MenoresViewModel()
        {
            ObtenerCumplenHoyCommand = new RelayCommand(ObtenerCumpleañosHoy);
            ObtenerCumplenMesCommand = new RelayCommand(ObtenerCumpleañosMes);
            CambiarVistaCommand = new RelayCommand<string>(CambiarVista);
            ObtenerMenoresDoceCommand = new RelayCommand(ObtenerMenoresDoce);
            ObtenerMenoresPorAñoCommand = new RelayCommand(ObtenerMenoresPorAño);
            ObtenerMenoresDiciembreCommand = new RelayCommand(ObtenerMenoresCumplenDiciembre);



            var menores = crud.ObtenerMenores();
            foreach (var menor in menores)
            {
                Menores.Add(menor);
            }


        }



        public void ObtenerCumpleañosHoy()
        {
            CumplenHoyLista.Clear();

            Vista = "verCumpleañosHoy";
            var cumplenHoyMenores = crud.CumplenHoy();
            foreach (var menor in cumplenHoyMenores)
            {
                CumplenHoyLista.Add(menor);
            }

            PropertyChange();

        }

        public void ObtenerCumpleañosMes()
        {
            CumplenMesLista.Clear();

            Vista = "verCumpleañosMes";
            var cumplenMesMenores = crud.CumplenMes();
            foreach (var menor in cumplenMesMenores)
            {
                CumplenMesLista.Add(menor);
            }

            PropertyChange();
        }

        public void ObtenerMenoresDoce()
        {
            MenoresDoceLista.Clear();

            Vista = "verMenoresDoce";
            var menoresDoce = crud.MenoresDoce();
            foreach (var menor in menoresDoce)
            {
                MenoresDoceLista.Add(menor);
            }

            PropertyChange();
        }

        public void ObtenerMenoresCumplenDiciembre()
        {
            MenoresCumplenDiciembreLista.Clear();

            Vista = "verMenoresDiciembre";
            var menoresDiciembre = crud.ObtenerMenoresDiciembre();
            foreach (var menor in menoresDiciembre)
            {
                MenoresCumplenDiciembreLista.Add(menor);
            }

            PropertyChange();
        }

        public void ObtenerMenoresPorAño()
        {
            MenoresPorAñoLista.Clear();

            Vista = "verMenoresPorAño";
            var menores = crud.ObtenerMenoresPorAño();
            foreach (var menor in menores)
            {
                MenoresPorAñoLista.Add(menor);
            }

            PropertyChange();
        }





        void CambiarVista(string vista)
        {
            this.Vista = vista;
            PropertyChange();
        }
        void PropertyChange(string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
