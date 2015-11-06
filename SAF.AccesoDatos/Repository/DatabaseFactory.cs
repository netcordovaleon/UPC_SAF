using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;
namespace SAF.AccesoDatos.Repository
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private SI_SOCAUDEntities ctx;

        public SI_SOCAUDEntities Get()
        {
            return ctx ?? (ctx = new SI_SOCAUDEntities());
        }

        protected override void DisposeCore()
        {
            if (ctx != null)
                ctx.Dispose();
        }
    }
}
