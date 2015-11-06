using SAF.Configuracion.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.Configuracion.Constantes
{

    [DataContract]
    public class MensajeRespuesta
    {

        [DataMember]
        public string Mensaje { get; set; }
        [DataMember]
        public TipoMensaje TipoMensaje { get; set; }
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public object Data { get; set; }

        public MensajeRespuesta(string _mensaje)
        {
            this.Mensaje = _mensaje;
            this.Exito = false;
            this.TipoMensaje = TipoMensaje.advertencia;
        }

        public MensajeRespuesta(string _mensaje, bool _exito)
        {
            this.Mensaje = _mensaje;
            this.TipoMensaje = (_exito) ? TipoMensaje.satisfaccion : TipoMensaje.error;
            this.Exito = _exito;
        }

        public MensajeRespuesta(string _mensaje, bool _exito, object _data)
        {
            this.Mensaje = _mensaje;
            this.TipoMensaje = (_exito) ? TipoMensaje.satisfaccion : TipoMensaje.error;
            this.Exito = _exito;
            this.Data = _data;
        }

        public MensajeRespuesta(string _mensaje, TipoMensaje _tipoMensaje)
        {
            this.Mensaje = _mensaje;
            this.TipoMensaje = _tipoMensaje;
            this.Exito = _tipoMensaje.Equals(TipoMensaje.satisfaccion) ? true : false;
        }
    }
}
