using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;
namespace SAF.AccesoDatos.Repository
{
    public interface IDatabaseFactory : IDisposable
    {
        SI_SOCAUDEntities Get();
    }
}
