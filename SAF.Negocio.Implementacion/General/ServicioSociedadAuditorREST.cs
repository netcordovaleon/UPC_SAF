using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AccesoDatos;
using SAF.AccesoDatos.Repository;
using SAF.Negocio.Contrato;
using SAF.Configuracion;
using SAF.Configuracion.Mapeo;
using SAF.Entidad;
using SAF.DTO;
using System.Transactions;
using AutoMapper.Mappers;
using AutoMapper;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.ExcepcionNegocio;

namespace SAF.Negocio.Implementacion
{
    public class ServicioSociedadAuditorREST : IServicioSociedadAuditorREST
    {

        private readonly IUnitOfWork _uow;
        private readonly ISafPublicacionLogic _safPublicacionLogic;
        private readonly ISafConsultaLogic _safConsultaLogic;
        public ServicioSociedadAuditorREST()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safPublicacionLogic = new SafPublicacionLogic();
            this._safConsultaLogic = new SafConsultaLogic();
        }


        public IEnumerable<PublicacionDTO> ListarPublicacionJson()
        {
            return null;// return _safPublicacionLogic.ListarPublicacionJson();
        }


        public MensajeRespuesta RegistroConsultaJson(int idSoa, int idPub, string desCon)
        {
            return null;//return _safConsultaLogic.RegistroConsultaJson(idSoa, idPub, desCon);
            
        }

        public MensajeRespuesta EliminarConsultaJson(int idCon)
        {
            return null;//return _safConsultaLogic.EliminarConsultaJson(idCon);
        }

        public IEnumerable<ConsultaDTO> ListarConsultaJson(int idSoa, int idPub)
        {
            return null;//return _safConsultaLogic.ListarConsultaJson(idSoa, idPub);
        }
    }
}
