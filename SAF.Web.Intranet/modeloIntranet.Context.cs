﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAF.Web.Intranet
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SI_SOCAUDEntities : DbContext
    {
        public SI_SOCAUDEntities()
            : base("name=SI_SOCAUDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SAF_AUDITOR> SAF_AUDITOR { get; set; }
        public virtual DbSet<SAF_AUDITORIA> SAF_AUDITORIA { get; set; }
        public virtual DbSet<SAF_BASE> SAF_BASE { get; set; }
        public virtual DbSet<SAF_BASEENTREGABLE> SAF_BASEENTREGABLE { get; set; }
        public virtual DbSet<SAF_CARGO> SAF_CARGO { get; set; }
        public virtual DbSet<SAF_CARRERA> SAF_CARRERA { get; set; }
        public virtual DbSet<SAF_CONSULTA> SAF_CONSULTA { get; set; }
        public virtual DbSet<SAF_CORTE_AUDITOR> SAF_CORTE_AUDITOR { get; set; }
        public virtual DbSet<SAF_CORTE_AUDITOR_CARGO> SAF_CORTE_AUDITOR_CARGO { get; set; }
        public virtual DbSet<SAF_CRONOENTIDAD> SAF_CRONOENTIDAD { get; set; }
        public virtual DbSet<SAF_CRONOGRAMA> SAF_CRONOGRAMA { get; set; }
        public virtual DbSet<SAF_DIAOCUPADO> SAF_DIAOCUPADO { get; set; }
        public virtual DbSet<SAF_DOCUMENTO> SAF_DOCUMENTO { get; set; }
        public virtual DbSet<SAF_EMPRESA> SAF_EMPRESA { get; set; }
        public virtual DbSet<SAF_ENTIDADES> SAF_ENTIDADES { get; set; }
        public virtual DbSet<SAF_FLUJO_DOCUMENTO> SAF_FLUJO_DOCUMENTO { get; set; }
        public virtual DbSet<SAF_INVITACION> SAF_INVITACION { get; set; }
        public virtual DbSet<SAF_INVITACIONDETALLE> SAF_INVITACIONDETALLE { get; set; }
        public virtual DbSet<SAF_NOTIFICACION> SAF_NOTIFICACION { get; set; }
        public virtual DbSet<SAF_PARAMETRICA> SAF_PARAMETRICA { get; set; }
        public virtual DbSet<SAF_PROPUESTA> SAF_PROPUESTA { get; set; }
        public virtual DbSet<SAF_PUBLICACION> SAF_PUBLICACION { get; set; }
        public virtual DbSet<SAF_SERAUDCARCAP> SAF_SERAUDCARCAP { get; set; }
        public virtual DbSet<SAF_SERAUDCAREXP> SAF_SERAUDCAREXP { get; set; }
        public virtual DbSet<SAF_SERAUDCARGO> SAF_SERAUDCARGO { get; set; }
        public virtual DbSet<SAF_SERVICIOAUDITORIA> SAF_SERVICIOAUDITORIA { get; set; }
        public virtual DbSet<SAF_SOA> SAF_SOA { get; set; }
        public virtual DbSet<SAF_SOLICITUD> SAF_SOLICITUD { get; set; }
        public virtual DbSet<SAF_TIPOPARAMETRICA> SAF_TIPOPARAMETRICA { get; set; }
        public virtual DbSet<SAF_TIPOSOLICITUD> SAF_TIPOSOLICITUD { get; set; }
        public virtual DbSet<SAF_UNIVERSIDAD> SAF_UNIVERSIDAD { get; set; }
        public virtual DbSet<SAF_USUARIO> SAF_USUARIO { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<SAF_DIALABORABLE> SAF_DIALABORABLE { get; set; }
        public virtual DbSet<VW_SAF_INVITACION> VW_SAF_INVITACION { get; set; }
        public virtual DbSet<VW_SAF_PUBLICACION> VW_SAF_PUBLICACION { get; set; }
        public virtual DbSet<VW_SAF_SOLICITUD> VW_SAF_SOLICITUD { get; set; }
        public virtual DbSet<SAF_ARCHIVO> SAF_ARCHIVO { get; set; }
        public virtual DbSet<SAF_DEPARTAMENTO> SAF_DEPARTAMENTO { get; set; }
        public virtual DbSet<SAF_DISTRITO> SAF_DISTRITO { get; set; }
        public virtual DbSet<SAF_PROVINCIA> SAF_PROVINCIA { get; set; }
        public virtual DbSet<SAF_CAPACITACION> SAF_CAPACITACION { get; set; }
        public virtual DbSet<SAF_EXPERIENCIA> SAF_EXPERIENCIA { get; set; }
        public virtual DbSet<SAF_SOLCAPACITACION> SAF_SOLCAPACITACION { get; set; }
        public virtual DbSet<SAF_SOLEXPERIENCIA> SAF_SOLEXPERIENCIA { get; set; }
    }
}