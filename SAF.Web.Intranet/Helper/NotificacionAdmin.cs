using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Web.Intranet.Helper
{
    public class NotificacionAdmin
    {

        SI_SOCAUDEntities modelEntity = new SI_SOCAUDEntities();

        public void grabarNotificacion(int idAuditor, string asunto, string body) {
            var infoAuditor = this.modelEntity.SAF_AUDITOR.Where(c => c.CODAUD == idAuditor).FirstOrDefault();
            modelEntity.SAF_NOTIFICACION.Add(new SAF_NOTIFICACION(){
                DESNOT = body,       
                FECREG = DateTime.Now,
                INDLEIDO = "N",
                USUNOTREC = infoAuditor.NOMUSU
            });
            modelEntity.SaveChanges();
        }

        public void grabarNotificacionTodosUsuarios(string asunto, string body) {
            var auditoresInfo = this.modelEntity.SAF_AUDITOR.ToList();
            foreach (var item in auditoresInfo)
            {
                modelEntity.SAF_NOTIFICACION.Add(new SAF_NOTIFICACION()
                {
                    DESNOT = body,
                    FECREG = DateTime.Now,
                    INDLEIDO = "N",
                    USUNOTREC = item.NOMUSU
                });
                modelEntity.SaveChanges();                
            }   
        }
    }
}