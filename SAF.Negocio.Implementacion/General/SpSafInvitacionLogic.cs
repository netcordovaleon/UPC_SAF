using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AccesoDatos;
using SAF.AccesoDatos.Repository;
using SAF.Entidad;
using SAF.DTO;
using SAF.Configuracion;

using SAF.Negocio.Contrato;

namespace SAF.Negocio.Implementacion.General
{
    public class SpSafInvitacionLogic : ISpSafInvitacionLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IDatabaseFactory _dataFactory;
        private readonly ISpSafInvitacionData _spSafInvitacionData;
        public SpSafInvitacionLogic()
        {
            this._uow = new UnitOfWork();
            this._dataFactory = new DatabaseFactory();
            this._spSafInvitacionData = new SpSafInvitacionData(_dataFactory, _uow);
        }

        public IEnumerable<SP_SAF_INVITACION_Result> VerResultadoCorte(int idPublicacion, int idServicioAud)
        {
            return this._spSafInvitacionData.VerInvitaciones(idPublicacion, idServicioAud);
        }
    }
}
