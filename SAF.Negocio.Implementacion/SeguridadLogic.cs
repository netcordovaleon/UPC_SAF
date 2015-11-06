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
using SAF.Configuracion.Enum;
using SAF.Configuracion.ExcepcionNegocio;

namespace SAF.Negocio.Implementacion
{
    public class SeguridadLogic : ISeguridadLogic
    {
        private readonly ISafAuditorLogic _safAuditorLogic;
        private readonly ISafSoaLogic _safSoaLogic;
        public SeguridadLogic()
        {
            this._safAuditorLogic = new SafAuditorLogic();
            this._safSoaLogic = new SafSoaLogic();
        }
        public bool AccederSistemaExtranet(string usuario, string password, int tipoUsuario)
        {
            var result = false;
            if (tipoUsuario == (int)Tipo.TipoUsuarioExtranet.Auditor)
                result = this._safAuditorLogic.AccederAuditor(usuario, password);
            else
                result = this._safSoaLogic.AccederSoa(usuario, password);
            return result;
        }
    }
}
