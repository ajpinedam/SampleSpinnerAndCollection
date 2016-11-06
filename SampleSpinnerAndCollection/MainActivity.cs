using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;

namespace SampleSpinnerAndCollection
{
    [Activity (Label = "SampleSpinnerAndCollection", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Que en tu caso esto seria la llamada al endpoint de tu WebService
            //List<Estado> estados = service.GetEstado();
            List<Estado> estados = GetFakeDataEstado ();

            //Aqui con Linq estas cambiando de List<Estado> a List<string> donde el string es el nombre del estado.
            List<string> estadosNombre = estados.Select (p => p.NombreEstado).ToList();

            var cmbEstado = FindViewById<Spinner> (Resource.Id.cmbEstado);

            //3 parametros: El Context, El Resource.Layout a usar, la lista de lo que se va a mostrar en el Spinner.
            var estadosAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleSpinnerItem, estadosNombre);

            cmbEstado.Adapter = estadosAdapter;
        }


        //Esta informacion es la que vendria de tu WebService.
        private List<Estado> GetFakeDataEstado ()
        {
            return new List<Estado>
            {
                new Estado{ IdEstado=1, NombreEstado="California" },
                new Estado{ IdEstado=2, NombreEstado="Texas" },
                new Estado{ IdEstado=3, NombreEstado="New York" },
                new Estado{ IdEstado=4, NombreEstado="Florida" },
                new Estado{ IdEstado=5, NombreEstado="Oregon" },
                new Estado{ IdEstado=6, NombreEstado="Ohio" }
            };
        }

    }
}

